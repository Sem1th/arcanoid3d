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
    [SerializeField] private GameObject _panelGameOver;
    [SerializeField] private GameObject _panelMenu;

    public void MissBall()
    {
        _lives -= 1;
        if(_lives <= 0)
        {
            _panelGameOver.SetActive(true);
            Time.timeScale = 0; 
            Destroy(_panelMenu);
        }
    }

    public void SpawnBall()
    {
        Instantiate(_ballPrefab, _spawnPosition);
    }

    private void Start ()
    {
        SpawnBall();
        Time.timeScale = 1;  
    }

    private void Update()
    {
        _player1Text.text = "" + _lives;
        _player2Text.text = "" + _lives;
    }
}
