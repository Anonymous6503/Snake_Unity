using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public GameObject _pauseUI;
    public GameObject _deadUI;
    public Movement _movement;
        
    // Start is called before the first frame update

    private void Awake()
    {
        _pauseUI.GetComponent<GameObject>();
        _pauseUI.SetActive(false);
        _deadUI.GetComponent<GameObject>();
        _deadUI.SetActive(false);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_movement.isDead)
        {
            DeadUI();
        }
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        _pauseUI.SetActive(true);
        
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        _pauseUI.SetActive(false);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void DeadUI()
    {
        _deadUI.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
    }
}
