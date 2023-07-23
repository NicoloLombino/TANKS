using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speedOffset;
    public int damage;
    public float timeToDestroy;

    public GameObject hitParticle;

    void Start()
    {
        Destroy(gameObject, timeToDestroy);
    }

    void Update()
    {
        transform.position += transform.forward * speedOffset * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "wall")
        {
            GameObject BulletExplosion = Instantiate(hitParticle, gameObject.transform.position + new Vector3(0f, 0f, 0f), Quaternion.identity);
            Destroy(BulletExplosion, 1f);
        }
    }
}
