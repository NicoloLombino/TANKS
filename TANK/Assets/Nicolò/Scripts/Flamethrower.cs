using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flamethrower : MonoBehaviour
{
    public float damage;
    public Flames flames;

    public GameObject tankOwner;

    void Update()
    {
        gameObject.transform.position = tankOwner.transform.position /*+ new Vector3(0, 0f, 2)*/;
        gameObject.transform.eulerAngles = tankOwner.transform.eulerAngles;
    }

    private void OnTriggerStay(Collider other)
    {
       if (other.gameObject.tag == "tank" && other.gameObject != tankOwner)
       {
            bool flameCreated = false;

            if (!flameCreated)
            {
                other.gameObject.GetComponent<Player>().flamethrowerHitFlames.gameObject.SetActive(true);
                //flames.transform.parent = other.gameObject.transform;
                //flames.transform.position += new Vector3(0f,1.15f, -0.75f);
                flameCreated = true;
            }
            other.gameObject.GetComponentInParent<Player>().UpdateHealth(damage);
        }
    }
}
