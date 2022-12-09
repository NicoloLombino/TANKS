using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShoot : MonoBehaviour
{
    public GameObject hole;

    [Header("all for normal shot")]
    public float shootEnergy;
    public Image shootEnergyUI;
    public GameObject bullet;
    public float shotTimer;
    public float shootDelay;
    public GameObject particleShot;

    [Tooltip("the key for normal shoot")]
    public KeyCode shootKey;

    [Header("all for super shot")]
    public KeyCode superShootKey;
    public int superShotAmmo;
    public GameObject superBullet;
    public Text superAmmoText;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        shootEnergyUI.fillAmount = shootEnergy / 100;
        superAmmoText.text = superShotAmmo.ToString();

        if(shootEnergy >= 100)
        {
            shootEnergy = 100;
        }

        if (Input.GetKey(shootKey))
        {
            NormalShot();

        }

        else if(Input.GetKeyDown(superShootKey))
        {
            SuperShot();
        }

        else { shootEnergy += 1; }
    }

    void NormalShot()
    {
        if (shootEnergy >= 0)
        {
            shootEnergy -= 0.05f;

            if (Time.time >= shotTimer)
            {
                GameObject NormalBullet = Instantiate(bullet, hole.transform.position, hole.transform.rotation);
                shotTimer = Time.time + shootDelay;
                GameObject ShotFlash = Instantiate(particleShot, hole.transform.position, hole.transform.rotation);
                Destroy(ShotFlash, 0.5f);
                // add sound
            }
        }
    }

    void SuperShot()
    {
        if (superShotAmmo >= 1)
        {
            GameObject NormalBullet = Instantiate(superBullet, hole.transform.position, hole.transform.rotation);
            superShotAmmo--;
            GameObject ShotFlash = Instantiate(particleShot, hole.transform.position, hole.transform.rotation);
            ShotFlash.transform.localScale += new Vector3(2, 2, 2);
            Destroy(ShotFlash, 0.5f);
            // add sound
        }
    }

}
