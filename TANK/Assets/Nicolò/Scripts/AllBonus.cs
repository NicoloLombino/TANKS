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

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
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

    public void GiveBonus(GameObject player)
    {
        if (isShield && used == false)
        {
            player.GetComponent<Player>().UpdateHealth(-20);
            used = true;
            GameObject BonusSparks = Instantiate(particles, transform.position, Quaternion.Euler(-90, 0, 0));
            Destroy(BonusSparks, 1);
            audio.PlayOneShot(audio.clip);
            Destroy(gameObject);

        }

        if (isCoin && used == false)
        {
            player.GetComponent<PlayerShoot>().personalDamage += 5;
            used = true;
            GameObject BonusSparks = Instantiate(particles, transform.position, Quaternion.Euler(-90, 0, 0));
            Destroy(BonusSparks, 1);
            audio.PlayOneShot(audio.clip);
            Destroy(gameObject);
        }

        if (isSword && used == false)
        {
            player.GetComponent<PlayerShoot>().superShotAmmo += 1;
            player.GetComponent<PlayerShoot>().flamethrowerEnergy += 50;
            used = true;
            GameObject BonusSparks = Instantiate(particles, transform.position, Quaternion.Euler(-90, 0, 0));
            Destroy(BonusSparks, 1);
            audio.PlayOneShot(audio.clip);
            Destroy(gameObject);
        }
    }
}
