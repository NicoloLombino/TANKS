using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PigBoss : MonoBehaviour
{



    [SerializeField] GameObject flames;
    [SerializeField] float attackTimer;
    [SerializeField] float timeToNextAttack;
    [SerializeField] bool isAttacking;
    Vector3 startPos;

    public GameObject[] weapons;
    public GameObject bombPrefab;
    public GameObject missilePrefab;

    public GameObject player1;
    public GameObject player2;
    public GameObject missile1Hole;
    public GameObject missile2Hole;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        BombAttack();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = startPos;
        if (Time.time >= timeToNextAttack && !isAttacking)
        {
            RandomAttack();
            //timeToNextAttack = Time.time + attackTimer;
        }

        if (gameObject.GetComponent<Player>().health <= 1000 && gameObject.GetComponent<Player>().health >= 600)
        {
            attackTimer = 4;
        }

        else if (gameObject.GetComponent<Player>().health <= 600 && gameObject.GetComponent<Player>().health >= 300)
        {
            attackTimer = 3;
        }

        else if (gameObject.GetComponent<Player>().health <= 300 && gameObject.GetComponent<Player>().health > 0)
        {
            attackTimer = 2;
        }

        else if (gameObject.GetComponent<Player>().health <= 0)
        {
            flames.SetActive(true);
            foreach(GameObject weapon in weapons)
            {
                Destroy(weapon);
            }
            gameObject.GetComponent<PigBoss>().enabled = false;
            gameObject.GetComponent<Player>().enabled = false;
        }
    }

    public void RandomAttack()
    {
        int rndAttack = Random.Range(0, weapons.Length + 1);
        switch(rndAttack)
        {
            case 0: BombAttack();
                break;
            case 1: TurretAttack();
                break;
            case 2:
                FlameAttack();
                break;
            case 3:
                MissileAttack();
                break;
        }
        Debug.Log("ATTACCO PIG" + rndAttack);
        

    }

    // weapon 0
    public void BombAttack()
    {
        //GameObject bombGroup = Instantiate(weapons[0]);
        //bombGroup.SetActive(true);
        StartCoroutine(Attack(weapons[0], 7));
        foreach (Transform child in weapons[0].transform)
        {
            float rndPos = Random.Range(0, -37);
            child.transform.localPosition = new Vector3(child.transform.localPosition.x, rndPos, child.transform.localPosition.z);
            //StartCoroutine(SpawnAttack(weapons[0]));
            GameObject bomb = Instantiate(bombPrefab, child.transform.position, Quaternion.identity);
            bomb.transform.localScale = bomb.transform.localScale * 5;
            bomb.transform.eulerAngles = new Vector3(90, 0, 0);
            bomb.transform.position += new Vector3(0, 30, 0);

            timeToNextAttack = Time.time + attackTimer;
        }
        
    }

    public void TurretAttack()
    {
        StartCoroutine(Attack(weapons[1], 11));
        //GameObject turretGroup = Instantiate(weapons[1]);
        //turretGroup.SetActive(true);
        float rndRot = Random.Range(-70, +71);
        weapons[1].transform.localEulerAngles = new Vector3(weapons[1].transform.eulerAngles.x, rndRot, weapons[1].transform.eulerAngles.z);
        //StartCoroutine(SpawnAttack(turretGroup));

        timeToNextAttack = Time.time + attackTimer + 2;
    }

    public void FlameAttack()
    {
        StartCoroutine(Attack(weapons[2], 12));
        //GameObject flameGroup = Instantiate(weapons[2]);
        //flameGroup.SetActive(true);
        //float rndRot = Random.Range(0, +71);
        //flameGroup.transform.eulerAngles = new Vector3(flameGroup.transform.eulerAngles.x, rndRot, flameGroup.transform.eulerAngles.z);
        //StartCoroutine(SpawnAttack(weapons[2]));

        timeToNextAttack = Time.time + attackTimer + 1;
    }

    public void MissileAttack()
    {
        StartCoroutine(Attack(null, 7));

        GameObject PigMissile1 = Instantiate(missilePrefab, missile1Hole.transform.position, missile1Hole.transform.rotation);
        PigMissile1.GetComponent<Missile>().target = player1;

        GameObject PigMissile2 = Instantiate(missilePrefab, missile2Hole.transform.position, missile2Hole.transform.rotation);
        PigMissile2.GetComponent<Missile>().target = player2;
        Debug.Log("COROUTINE MISSILE");

        timeToNextAttack = Time.time + attackTimer;
    }

    public IEnumerator SpawnAttack(GameObject weapon, bool active)
    {
        Debug.Log("COROUTINE" + weapon);
        yield return new WaitForSeconds(2);
        foreach (Transform child in weapon.transform)
        {
            foreach (Transform children in child.transform)
            {
                children.gameObject.SetActive(active);
            }
        }

    }
    public IEnumerator Attack(GameObject weapon, float timer)
    {
        //isAttacking = true;
        weapon.SetActive(true);
        StartCoroutine(SpawnAttack(weapon, true));
        yield return new WaitForSeconds(timer);
        //isAttacking = false;
        weapon.SetActive(false);
        StartCoroutine(SpawnAttack(weapon, false));
        
        
    }

    public void Death()
    {
        flames.SetActive(true);
        foreach (GameObject weapon in weapons)
        {
            Destroy(gameObject);
        }
        gameObject.GetComponent<PigBoss>().enabled = false;
        gameObject.GetComponent<Player>().enabled = false;
    }
}
