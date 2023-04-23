using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int _lives = 3;
    [SerializeField] private TMP_Text _player1Text, _player2Text;
    [SerializeField] private GameObject _ballPrefab;
    [SerializeField] private Transform _spawnPosition;

    public void MissBall()
    {
        _lives -= 1;
        if(_lives <= 0)
        {
            Debug.Log("Вы проиграли!");
            Debug.Break();
        }
    }

    public void SpawnBall()
    {
        Instantiate(_ballPrefab, _spawnPosition);
    }

    private void Start ()
    {
        SpawnBall();
    }

    private void Update()
    {
        _player1Text.text = "Жизни: " + _lives;
        _player2Text.text = "Жизни: " + _lives;
    }
}
