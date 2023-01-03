using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShoot : MonoBehaviour
{
    [Tooltip("mi serve per il missile telecomandato (missile) per dare il target")]
    public GameObject TANK_ENEMY;

    //public SoundManager SoundManager;
    public GameObject hole;

    [Header("all for normal shot")]
    public float shootEnergy;
    public Image shootEnergyUI;
    public GameObject bullet;
    public float shotTimer;
    public float shootDelay;
    public GameObject particleShot;
    public int personalDamage;

    [Tooltip("the key for normal shoot")]
    public KeyCode shootKey;

    [Header("all for super shot")]
    public KeyCode superShootKey;
    public int superShotAmmo;
    public int superShotAmmoMax;
    public GameObject superBullet;
    public Text superAmmoText;

    public bool superShotActive;
    public bool flamethrowerActive;
    public bool mineActive;
    public bool turretActive;
    public bool missileActive;

    public GameObject flamethrowerObject;
    public Image flamethrowerBar;
    public float flamethrowerEnergy;

    public float SuperDelay;
    public float SuperDeleyTime;

    public GameObject[] superShots;

    // Start is called before the first frame update
    void Start()
    {
        if (flamethrowerActive == true)
        {
            flamethrowerEnergy = 50;
        }
    }

    // Update is called once per frame
    void Update()
    {
        shootEnergyUI.fillAmount = shootEnergy / 100;
        superAmmoText.text = superShotAmmo.ToString();

        if (flamethrowerActive == true)
        {
            flamethrowerBar.fillAmount = flamethrowerEnergy / 100;
        }

        ControlEnergyValue();

        if (Input.GetKey(shootKey))
        {
            NormalShot();

        }

        else if(Input.GetKeyDown(superShootKey) && superShotActive)
        {
            SuperShot();
        }

        else if (Input.GetKeyDown(superShootKey) && missileActive)
        {
            Missile();
        }

        else if (Input.GetKey(superShootKey) && flamethrowerActive)
        {
            FlameThrower();
        }

        else if (Input.GetKeyUp(superShootKey) && flamethrowerActive)
        {
            flamethrowerObject.SetActive(false);
        }

        else if (Input.GetKeyDown(superShootKey) && mineActive)
        {
            Mine();
        }

        else if (Input.GetKeyDown(superShootKey) && turretActive)
        {
            Turrect();
        }


        else
        { 
            shootEnergy += 0.07f;
            flamethrowerEnergy += 0.02f;
        }
    }

    void NormalShot()
    {
        if (shootEnergy >= 0)
        {
            shootEnergy -= 0.05f;

            if (Time.time >= shotTimer)
            {
                GameObject NormalBullet = Instantiate(bullet, hole.transform.position, hole.transform.rotation);
                NormalBullet.GetComponent<Bullet>().damage += personalDamage;
                shotTimer = Time.time + shootDelay;
                GameObject ShotFlash = Instantiate(particleShot, hole.transform.position, hole.transform.rotation);
                Destroy(ShotFlash, 0.5f);
                //SoundManager.bulletSound.Play();
            }
        }
    }

    void SuperShot()
    {
        if (superShotAmmo >= 1)
        {
            GameObject SuperBullet = Instantiate(superBullet, hole.transform.position, hole.transform.rotation);
            superShotAmmo--;
            GameObject S_ShotFlash = Instantiate(particleShot, hole.transform.position, hole.transform.rotation);
            S_ShotFlash.transform.localScale += new Vector3(2, 2, 2);
            Destroy(S_ShotFlash, 0.5f);
            //SoundManager.bazookaSound.Play();
        }
    }

    void FlameThrower()
    {
        if (flamethrowerEnergy >= 0)
        {
            flamethrowerObject.SetActive(true);
            flamethrowerEnergy -= 0.08f;
        }

        else { flamethrowerObject.SetActive(false); }
    }

    void Mine()
    {
        if (superShotAmmo >= 1)
        {
            GameObject SuperMine = Instantiate(superBullet, gameObject.transform.position, gameObject.transform.rotation);
            superShotAmmo--;
            //SoundManager.mineSound.Play();
        }
    }

    void Turrect()
    {
        if (superShotAmmo >= 1)
        {
            GameObject SuperTurret = Instantiate(superBullet, hole.transform.position + new Vector3(0,-1.5f,0), hole.transform.rotation);
            superShotAmmo--;
            //SoundManager.turretSound.Play();
        }
    }

    void Missile()
    {
        if (superShotAmmo >= 1)
        {
            GameObject SuperMissile = Instantiate(superBullet, hole.transform.position, hole.transform.rotation);
            SuperMissile.GetComponent<Missile>().target = TANK_ENEMY;
            superShotAmmo--;
            GameObject S_ShotFlash = Instantiate(particleShot, hole.transform.position, hole.transform.rotation);
            S_ShotFlash.transform.localScale += new Vector3(2, 2, 2);
            Destroy(S_ShotFlash, 0.5f);
            //SoundManager.missileSound.Play();
        }
    }

    void ControlEnergyValue()
    {
        if (shootEnergy >= 100)
        {
            shootEnergy = 100;
        }

        if (flamethrowerEnergy >= 100)
        {
            flamethrowerEnergy = 100;
        }

        if(flamethrowerActive == true)
        {
            shootEnergyUI.fillAmount = shootEnergy / 100;
        }

        if (Time.time >= SuperDelay && superShotAmmo < superShotAmmoMax)
        {
            superShotAmmo++;
            SuperDelay = Time.time + SuperDeleyTime;
        }
    }

    public void SuperShotActive()
    {
        superShotActive = true;
        flamethrowerActive = false;
        mineActive = false;
        turretActive = false;
        missileActive = false;
        flamethrowerBar.enabled = false;

        superBullet = superShots[0];
        superShotAmmoMax = 6;
        superShotAmmo = superShotAmmoMax;
        SuperDeleyTime = 8;
    }

    public void FlameThrowerActive()
    {
        flamethrowerBar.enabled = true;
        flamethrowerActive = true;
        superShotActive = false;
        mineActive = false;
        turretActive = false;
        missileActive = false;
    }

    public void MineActive()
    {
        mineActive = true;
        flamethrowerBar.enabled = false;
        flamethrowerActive = false;
        superShotActive = false;
        turretActive = false;
        missileActive = false;

        superBullet = superShots[1];
        superShotAmmoMax = 7;
        superShotAmmo = superShotAmmoMax;
        SuperDeleyTime = 5;
    }

    public void TurretActive()
    {
        turretActive = true;
        mineActive = false;
        flamethrowerBar.enabled = false;
        flamethrowerActive = false;
        superShotActive = false;
        missileActive = false;

        superBullet = superShots[2];
        superShotAmmoMax = 3;
        superShotAmmo = superShotAmmoMax;
        SuperDeleyTime = 10;
    }
    public void MissileActive()
    {
        missileActive = true;
        mineActive = false;
        flamethrowerBar.enabled = false;
        flamethrowerActive = false;
        superShotActive = false;
        turretActive = false;

        superBullet = superShots[3];
        superShotAmmoMax = 3;
        superShotAmmo = superShotAmmoMax;
        SuperDeleyTime = 15;
    }





}
