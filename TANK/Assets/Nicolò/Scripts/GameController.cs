using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public string linkPortfolio;
    

    public bool isGame;

    public GameObject blackPanel;
    public float timer;
    public float time;
    


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (blackPanel.activeInHierarchy && isGame)
        {
            if(Time.time >= timer)
            {
                blackPanel.SetActive(false);
            }
        }


        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }


    public void StartGame()
    {
        isGame = true;
        blackPanel.SetActive(true);
        timer = Time.time + time;
    }

    public void OpenLink()
    {
        Application.OpenURL(@linkPortfolio);
    }
}
