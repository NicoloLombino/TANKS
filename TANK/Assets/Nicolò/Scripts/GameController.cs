using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    
    public GameObject allInGame;

    public float timer;
    public bool isGame;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        allInGame.SetActive(true);

        timer = Time.time + 2;
        isGame = true;
    }
}
