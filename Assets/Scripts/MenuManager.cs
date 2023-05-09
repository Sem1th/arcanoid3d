using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private string _scene_name;
    [SerializeField] private GameObject _panel;
    [SerializeField] private Animator _anim;
    private InputMovement _isPaused;

    public void LoadGameScene()
    {
        SceneManager.LoadScene(_scene_name);
    }

    public void ExitGame()
    {
        UnityEditor.EditorApplication.isPaused = true;
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GamePaused()
    {
        _panel.SetActive(true);  
        Time.timeScale = 0;   
    }

    public void GameResumed()
    { 
        _anim.SetTrigger("Exit");
        InputMovement._isPaused = false;
        Time.timeScale = 1;  
        Invoke("DeactivatePanel", 1.0f);
    }

    public void GameStarted()
    {
       Time.timeScale = 1; 
    }

    public void DeactivatePanel()
    {
        _panel.SetActive(false);  
    }

    void Update()
    {
        _isPaused = FindObjectOfType<InputMovement>();

       if(InputMovement._isPaused)
        GamePaused();
    }
}
