using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasterEggDoor : MonoBehaviour
{
    public int counter;
    public GameObject particles;
    public GameObject zoneParticles;

    public GameObject easterEggZone;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "bullet")
        {
            GameObject part = Instantiate(particles, new Vector3(-27, 0, 16), Quaternion.identity);
            part.SetActive(true);
            Destroy(other.gameObject);
            Destroy(part, 1);
            counter++;

            if(counter >= 100)
            {
                easterEggZone.SetActive(true);
                zoneParticles.SetActive(true);
                Destroy(zoneParticles, 3);
                Destroy(gameObject,3);
            }
        }
    }
}
