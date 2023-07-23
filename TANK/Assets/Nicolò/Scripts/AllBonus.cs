using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllBonus : MonoBehaviour
{
    public bool isCoin;
    public bool isShield;
    public bool isSword;

    public bool used;
    public GameObject particles;
    public AudioSource audio;

    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "tank")
        {

            if (isShield && used == false)
            {
                other.gameObject.GetComponent<Player>().UpdateHealth(-20);
                used = true;
                GameObject BonusSparks = Instantiate(particles, transform.position, Quaternion.Euler(-90, 0, 0));
                Destroy(BonusSparks, 1);
                audio.PlayOneShot(audio.clip);
                Destroy(gameObject);

            }

            if (isCoin && used == false)
            {
                other.gameObject.GetComponent<PlayerShoot>().personalDamage += 5;
                used = true;
                GameObject BonusSparks = Instantiate(particles, transform.position, Quaternion.Euler(-90, 0, 0));
                Destroy(BonusSparks, 1);
                audio.PlayOneShot(audio.clip);
                Destroy(gameObject);
            }

            if (isSword && used == false)
            {
                other.gameObject.GetComponent<PlayerShoot>().superShotAmmo += 1;
                other.gameObject.GetComponent<PlayerShoot>().flamethrowerEnergy += 50;
                used = true;
                GameObject BonusSparks = Instantiate(particles, transform.position, Quaternion.Euler(-90, 0, 0));
                Destroy(BonusSparks, 1);
                audio.PlayOneShot(audio.clip);
                Destroy(gameObject);
            }
        }
    }

}
