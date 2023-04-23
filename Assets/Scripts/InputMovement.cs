using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputMovement : MonoBehaviour
{
    [SerializeField] private GameObject _ballPrefab; 
    [SerializeField] private float _time; 
    [SerializeField] private float _speedMove = 5; 
    [SerializeField] private InputAction _movement;
    [SerializeField] private PlayerInput _playerInput;

    private BallMovement _speed;
    private PlayersControls _newPlayersControls;

    private void Awake() {
        _newPlayersControls = new PlayersControls();
        _playerInput = GetComponent<PlayerInput>();
    }

    private void OnEnable()
    {
        _newPlayersControls.Enable();
        _playerInput.actions["Movement"].performed += Movement;
        _playerInput.actions["FireBall"].performed += FireBall;

        _playerInput.actions["Movement"].Enable();
        _playerInput.actions["FireBall"].Enable();
    }

    public void Movement(InputAction.CallbackContext context)
    {
        var moving = context.ReadValue<Vector2>();  
    }  

    public void FireBall(InputAction.CallbackContext context)
    {
        BallMovement._speed = 4.0f;
    } 

    private void FixedUpdate()
    {
        _speed = FindObjectOfType<BallMovement>();

        _time -= Time.deltaTime;
        Vector2 inputVector = _playerInput.actions["Movement"].ReadValue<Vector2>();
        Vector3 movementDirection = new Vector3(inputVector.x, inputVector.y, 0);
        movementDirection.Normalize();
        transform.Translate(movementDirection * _speedMove * Time.deltaTime);
    }

    private void OnDisable()
    {
        _newPlayersControls.Disable();
        _playerInput.actions["Movement"].Disable();
        _playerInput.actions["FireBall"].Disable();
    }
}
