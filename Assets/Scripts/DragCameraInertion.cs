using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragCameraInertion : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private float _speed = 1.5f;
    
    private Vector3 direction;

    private void Start()
    {
        direction = _player.position - transform.position;
    }
    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _player.position, Time.deltaTime * _speed);
    }
}
