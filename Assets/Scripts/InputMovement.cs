using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputMovement : MonoBehaviour
{
    public static bool _isFire;
    public static bool _isPaused;
    [SerializeField] private GameObject _ballPrefab; 
    [SerializeField] private float _time; 
    [SerializeField] private float _speedMove = 5; 
    [SerializeField] private InputAction _movement;
    [SerializeField] private PlayerInput _playerInput;
    
    private PlayersControls _newPlayersControls;
    
    private void Awake() {
        _newPlayersControls = new PlayersControls();
        _playerInput = GetComponent<PlayerInput>();
        _isPaused = false;
        _isFire = false;
    }

    private void OnEnable()
    {
        _newPlayersControls.Enable();
        _playerInput.actions["Movement"].performed += Movement;
        _playerInput.actions["FireBall"].performed += FireBall;
        _playerInput.actions["Pause"].performed += Pause;

        _playerInput.actions["Movement"].Enable();
        _playerInput.actions["FireBall"].Enable();
        _playerInput.actions["Pause"].Enable();
    }

    public void Movement(InputAction.CallbackContext context)
    {
        var moving = context.ReadValue<Vector2>();  
    }  

    public void FireBall(InputAction.CallbackContext context)
    {
        _isFire = true;
        Invoke("DelayAfterShooting", 2.0f);
    } 

    public void DelayAfterShooting()
    {
        _isFire = false;
    }

    public void Pause(InputAction.CallbackContext context)
    {
        _isPaused = true;
        Debug.Log("Pause");
    } 

    private void FixedUpdate()
    {
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