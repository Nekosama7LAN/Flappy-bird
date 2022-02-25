using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Gamemanager : MonoBehaviour
{
    [SerializeField] Birds player = null;
    [SerializeField] Generator generator = null;
    [SerializeField] GameObject canvasLose;
    [SerializeField] GameObject canvasInitial;
    [SerializeField] GameObject loseFilter;
    private bool gameStarted = false;

    private bool needRestart = false;
    private void Awake()
    {
        canvasInitial.SetActive(true);
        canvasLose.SetActive(false);
    }
    private void Start()
    {
        SetUpGameplay();
    }
    void SetUpGameplay()
    {

        gameStarted = false;
        canvasLose.SetActive(false);

    }
    void StartGameplay()
    {

        player.ActiveBird();
        generator.StarGenerator();
        canvasInitial.SetActive(false);
        player.OnDeath += GameOver;
    }
    void GameOver()
    {
        loseFilter.SetActive(true);
        player.OnDeath -= GameOver;
        needRestart = true;
        generator.StopGenerator();
        canvasLose.SetActive(true);

    }
    public void Retry()
    {

        if (needRestart == false)
        {
            return;
        }
        
        SceneManager.LoadScene(0);
    }
    void ScoreCounter()
    {
        //player.
    }
    private void Update()
    {
        if (gameStarted)
        {
            return;
        }
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            StartGameplay();
            gameStarted = true;
        }
    }

}
