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

    public enum SuperShotActive
    {
        Bazooka,
        FlameThrower,
        Mine,
        Turret,
        Missile
    }

    public SuperShotActive superShotActive;

    public Flamethrower flamethrowerObject;
    public Image flamethrowerBar;
    public float flamethrowerEnergy;

    public float SuperDelay;
    public float SuperDeleyTime;

    public GameObject[] superShots;

    private Vector3 flamethrowerAreaStart = new Vector3(2, 2, 0);
    private Vector3 flamethrowerAreaEnd = new Vector3(2, 2, 9);
    private float flamethrowerAreaIncrement;

    private Vector3 flamethrowerCenterStart = new Vector3(0, -0.5f, 0);
    private Vector3 flamethrowerCenterEnd = new Vector3(0, -0.5f, 5);

    private float superShotTimer;

    // Start is called before the first frame update
    void Start()
    {
        if (superShotActive == SuperShotActive.FlameThrower)
        {
            flamethrowerEnergy = 50;
        }
    }

    // Update is called once per frame
    void Update()
    {
        shootEnergyUI.fillAmount = shootEnergy / 100;
        superAmmoText.text = superShotAmmo.ToString();

        if (superShotActive == SuperShotActive.FlameThrower)
        {
            flamethrowerBar.fillAmount = flamethrowerEnergy / 100;
        }

        ControlEnergyValue();

        if (Input.GetKey(shootKey))
        {
            NormalShot();
        }

        // read super shot input, flamethrower in after thoose

        else if(Input.GetKeyDown(superShootKey))
        {
            switch(superShotActive)
            {
                case SuperShotActive.Bazooka:
                    Bazooka();
                    break;
                case SuperShotActive.Mine:
                    Mine();
                    break;
                case SuperShotActive.Turret:
                    Turret();
                    break;
                case SuperShotActive.Missile:
                    Missile();
                    break;
            }
        }
        else if(Input.GetKey(superShootKey) && superShotActive == SuperShotActive.FlameThrower)
        {
            FlameThrower();
        }
        else if (Input.GetKeyUp(superShootKey) && superShotActive == SuperShotActive.FlameThrower)
        {
            StopFlamethrower();
        }

        else
        { 
            shootEnergy += 0.07f;
            flamethrowerEnergy += 0.02f;
            flamethrowerAreaIncrement = 0; 
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
            }
        }
    }

    void Bazooka()
    {
        if (superShotAmmo >= 1)
        {
            GameObject SuperBullet = Instantiate(superBullet, hole.transform.position, hole.transform.rotation);
            superShotAmmo--;
            GameObject S_ShotFlash = Instantiate(particleShot, hole.transform.position, hole.transform.rotation);
            S_ShotFlash.transform.localScale += new Vector3(2, 2, 2);
            Destroy(S_ShotFlash, 0.5f);
        }
    }

    void FlameThrower()
    {
        if (flamethrowerEnergy >= 0)
        {
            flamethrowerObject.gameObject.SetActive(true);
            flamethrowerAreaIncrement += Time.deltaTime;
            float flamethrowerAreaIncrementPercentage = flamethrowerAreaIncrement / 1.5f;
            //float flamethrowerCenterIncrementPercentage = flamethrowerAreaIncrement / 6;
            flamethrowerObject.GetComponent<BoxCollider>().size = Vector3.Lerp(flamethrowerAreaStart, flamethrowerAreaEnd, flamethrowerAreaIncrementPercentage);
            flamethrowerObject.GetComponent<BoxCollider>().center = Vector3.Lerp(flamethrowerCenterStart, flamethrowerCenterEnd, flamethrowerAreaIncrementPercentage);
            flamethrowerEnergy -= 0.06f;          
        }

        else
        {
            StopFlamethrower();
        }
    }

    private void StopFlamethrower()
    {
        flamethrowerObject.gameObject.SetActive(false);
        flamethrowerAreaIncrement = 0;
    }

    void Mine()
    {
        if (superShotAmmo >= 1)
        {
            GameObject SuperMine = Instantiate(superBullet, gameObject.transform.position, gameObject.transform.rotation);
            superShotAmmo--;
        }
    }

    void Turret()
    {
        if (superShotAmmo >= 1)
        {
            GameObject SuperTurret = Instantiate(superBullet, hole.transform.position + new Vector3(0,-1.5f,0), hole.transform.rotation);
            superShotAmmo--;
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

        if(superShotActive == SuperShotActive.FlameThrower)
        {
            shootEnergyUI.fillAmount = shootEnergy / 100;
        }

        if (Time.time >= SuperDelay && superShotAmmo < superShotAmmoMax)
        {
            superShotAmmo++;
            SuperDelay = Time.time + SuperDeleyTime;
        }
    }

    public void BazookaActive()
    {
        superShotActive = SuperShotActive.Bazooka;
        flamethrowerBar.enabled = false;

        superBullet = superShots[0];
        superShotAmmoMax = 6;
        superShotAmmo = superShotAmmoMax;
        SuperDeleyTime = 8;
    }

    public void FlameThrowerActive()
    {
        superShotActive = SuperShotActive.FlameThrower;
        flamethrowerBar.enabled = true;
    }

    public void MineActive()
    {
        superShotActive = SuperShotActive.Mine;
        flamethrowerBar.enabled = false;

        superBullet = superShots[1];
        superShotAmmoMax = 7;
        superShotAmmo = superShotAmmoMax;
        SuperDeleyTime = 5;
    }

    public void TurretActive()
    {
        superShotActive = SuperShotActive.Turret;
        flamethrowerBar.enabled = false;

        superBullet = superShots[2];
        superShotAmmoMax = 3;
        superShotAmmo = superShotAmmoMax;
        SuperDeleyTime = 10;
    }
    public void MissileActive()
    {
        superShotActive = SuperShotActive.Missile;
        flamethrowerBar.enabled = false;

        superBullet = superShots[3];
        superShotAmmoMax = 3;
        superShotAmmo = superShotAmmoMax;
        SuperDeleyTime = 15;
    }





}
