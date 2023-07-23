using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{
    public float damage;
    public GameObject explosion;

    public float timer;
    public float timerToActive;

    void Update()
    {
        timer += Time.deltaTime;

        if(timer >= timerToActive)
        {
            gameObject.GetComponent<BoxCollider>().enabled = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "tank")
        {
            other.gameObject.GetComponentInParent<Player>().UpdateHealth(damage);
            GameObject Kaboom = Instantiate(explosion, gameObject.transform.position, gameObject.transform.rotation);
            Destroy(Kaboom, 2f);
            Destroy(gameObject);
        }
    }
}
