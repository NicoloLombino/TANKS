using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "bullet")
        {
            GameObject BulletExplosion = Instantiate(other.gameObject.GetComponent<Bullet>().hitParticle, other.gameObject.transform.position, Quaternion.identity);
            Destroy(BulletExplosion, 1f);
            Destroy(other.gameObject);
        }
    }
}
