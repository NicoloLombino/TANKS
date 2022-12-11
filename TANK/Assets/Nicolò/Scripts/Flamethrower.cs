using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flamethrower : MonoBehaviour
{
    public float damage;
    public GameObject flames;
    public float flameTimer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
       if (other.gameObject.tag == "tank")
       {
            other.gameObject.GetComponent<Player>().UpdateHealth(damage);
            flameTimer = Random.Range(1, 20);
            if (flameTimer >= 17)
            {
                GameObject FlamesObj = Instantiate(flames, other.gameObject.transform.position + new Vector3(0f,1.15f, -0.75f), other.gameObject.transform.rotation);
                FlamesObj.transform.parent = other.gameObject.transform;
            }
       }
    }
}
