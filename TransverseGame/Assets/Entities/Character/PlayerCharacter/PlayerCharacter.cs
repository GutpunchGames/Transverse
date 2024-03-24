using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCharacter : MonoBehaviour
{
    private PlayerInputActions inputActions;

    // private field to store move action
    private InputAction moveAction;

    [HideInInspector]
    public CharacterController characterController;

    [SerializeField]
    public float moveSpeed = 5;

    [SerializeField]
    public float jumpImpulse = 20;

    [SerializeField]
    public float gravity = -2;

    [SerializeField]
    public Vector3 velocity;

    [SerializeField]
    private PlayerStateMachine stateMachine;

    void Awake()
    {
        inputActions = new PlayerInputActions();
    }

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        stateMachine = new PlayerStateMachine(this);
        stateMachine.Start();
    }

    // Update is called once per frame
    void Update()
    {
        stateMachine.Update();
    }

    void OnEnable()
    {
        inputActions.gameplay.Enable();
    }

    void OnDisable()
    {
        inputActions.gameplay.Disable();
    }

    public PlayerInputActions GetInputActions() {
        return inputActions;
    }
}
