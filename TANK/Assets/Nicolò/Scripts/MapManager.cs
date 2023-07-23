using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public GameObject[] bonus;
    public GameObject[] spawnPositions;

    public float spawnTimer;
    public float spawnRate;

    void Start()
    {
        spawnTimer += Time.time;
    }

    void Update()
    {
        if (Time.time > spawnTimer)
        {
            Debug.Log("timer");

            spawnTimer = Time.time + (spawnRate / 2);
            int randomNuM = (int)Random.Range(0, 100);
            Debug.Log(randomNuM);
            if (randomNuM >= 40)
            {
                int obj = (int)Random.Range(0, bonus.Length);
                int pos = (int)Random.Range(0, spawnPositions.Length);

                GameObject BONUS = Instantiate(bonus[obj], spawnPositions[pos].transform.position, spawnPositions[pos].transform.rotation);
                spawnTimer = Time.time + spawnRate;
            }
        }
    }
}



