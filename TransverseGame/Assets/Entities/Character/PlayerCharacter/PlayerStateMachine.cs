using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState_Grounded : State {

    private PlayerStateMachine stateMachine;

    public PlayerState_Grounded(PlayerStateMachine stateMachine) {
        this.stateMachine = stateMachine;
    }

    public override string GetName()
    {
        return "Grounded";
    }

    public override void Update() {
        PlayerCharacter player = stateMachine.player;
        PlayerInputActions inputActions = player.GetInputActions();
        float horizInput = player.GetInputActions().gameplay.move.ReadValue<Vector2>().x;
        player.velocity.x = horizInput * player.moveSpeed;

        if (player.characterController.isGrounded) {
            bool didJump = inputActions.gameplay.jump.ReadValue<float>() != 0;
            if (didJump) {
                player.velocity.y = player.jumpImpulse;
            } else {
                player.velocity.y = 0;
            }
        } else {
            player.velocity.y += player.gravity;
        }

        player.characterController.Move(player.velocity * Time.deltaTime);
    }
}

public class PlayerStateMachine : StateMachine
{
    public PlayerState_Grounded groundedState;

    [HideInInspector]
    public PlayerCharacter player;

    public PlayerStateMachine(PlayerCharacter player)
    {
        this.player = player;
        groundedState = new PlayerState_Grounded(this);
    }

    protected override State GetInitialState()
    {
        Debug.Log("check 2");
        return groundedState;
    }

    protected override void OnStateChanged(State oldState, State newState)
    {
        if (oldState != null)
        {
            Debug.Log("State change: " + oldState.GetName() + " to " + newState.GetName());
        }
    }
}