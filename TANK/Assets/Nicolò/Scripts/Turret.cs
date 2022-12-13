using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public float timeToDestroy;
    public GameObject turretBullet;
    public GameObject hole;
    public int turretDamage;

    public float shotTimer;
    public float shotDelay;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, timeToDestroy);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= shotTimer)
        {
            GameObject BulletTurret = Instantiate(turretBullet, hole.transform.position, hole.transform.rotation);
            BulletTurret.transform.localScale -= new Vector3(0.2f, 0.2f, 0f);
            BulletTurret.GetComponent<Bullet>().damage = turretDamage;
            shotTimer = Time.time + shotDelay;
        }
    }
}
