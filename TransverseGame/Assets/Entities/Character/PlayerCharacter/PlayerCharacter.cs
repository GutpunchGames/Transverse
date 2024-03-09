using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCharacter : MonoBehaviour
{
    private PlayerInputActions inputActions;

    // private field to store move action
    private InputAction moveAction;

    private CharacterController characterController;

    [SerializeField]
    private float moveSpeed = 5;

    [SerializeField]
    private float jumpImpulse = 20;

    [SerializeField]
    private float gravity = -2;

    [SerializeField]
    private Vector3 velocity;

    void Awake()
    {
        inputActions = new PlayerInputActions();
    }

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizInput = inputActions.gameplay.move.ReadValue<Vector2>().x;
        velocity.x = horizInput * moveSpeed;

        if (characterController.isGrounded) {
            bool didJump = inputActions.gameplay.jump.ReadValue<float>() != 0;
            if (didJump) {
                velocity.y = jumpImpulse;
            } else {
                velocity.y = 0;
            }
        } else {
            velocity.y += gravity;
        }

        characterController.Move(velocity * Time.deltaTime);
    }

    void OnEnable()
    {
        inputActions.gameplay.Enable();
    }

    void OnDisable()
    {
        inputActions.gameplay.Disable();
    }
}
