using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flames : MonoBehaviour
{
    public float damage;
    [SerializeField]
    float timeToDestroyAfterDamage = 5;

    private float timerToDestroy = 0;
    internal float startDamage;
    private Vector3 startSize;

    // Start is called before the first frame update
    void Start()
    {
        startDamage = damage;
        startSize = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        timerToDestroy += Time.deltaTime;
        if(timerToDestroy >= timeToDestroyAfterDamage)
        {
            timerToDestroy = 0;
            damage = startDamage;
            transform.localScale = startSize;
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "tank")
        {
            other.gameObject.GetComponentInParent<Player>().UpdateHealth(damage);
        }

        if(other.gameObject.tag == "Flamethrower")
        {
            timerToDestroy = 0;
            int flameTimer = Random.Range(1, 21);
            if (flameTimer >= 18)
            {
                damage += 0.0005f;
                if(gameObject.transform.localScale.x > startSize.x * 2)
                {
                    transform.localScale += new Vector3(0.01f, 0.01f, 0.01f);
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Flamethrower")
        {
            damage = startDamage;
        }
    }
}
