using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speedOffset;
    public int damage;
    public float timeToDestroy;

    public GameObject hitParticle;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, timeToDestroy);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * speedOffset * Time.deltaTime;
    }

  /*  private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "tank")
        {
            //collision.gameObject.GetComponent<Player>().UpdateHealth(damage);
            GameObject BulletExplosion = Instantiate(hitParticle, gameObject.transform.position + new Vector3(0f,0f,0f), Quaternion.identity);
            Destroy(BulletExplosion, 1f);
            Destroy(gameObject);
        }
    }*/
}
