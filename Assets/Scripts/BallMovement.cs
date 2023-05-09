using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public static float _speed;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private GameManager _gamemanager;
    private InputMovement _isFire;

    private void Start()
    {
        _speed = 0.0f;
        _gamemanager = FindObjectOfType<GameManager>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate ()
    {
        _isFire = FindObjectOfType<InputMovement>();

        _rigidbody.velocity = transform.forward * _speed;

        if (_speed != 0)
        transform.SetParent(null);

        if(InputMovement._isFire)
        {
            _speed = 4.0f;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Box")
        {
            //new direction
            Vector3 newDirection = Vector3.Reflect(transform.forward, collision.contacts[0].normal);
            transform.rotation = Quaternion.LookRotation(newDirection);
            _rigidbody.velocity = transform.forward * _speed;
        } 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "TriggerZone")
         {
            _gamemanager.MissBall();
            Destroy(gameObject);
            _gamemanager.SpawnBall();
         }
    }
}
