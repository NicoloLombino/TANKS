using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EasterEggDoor : MonoBehaviour
{
    public int counter;
    public GameObject particles;
    public GameObject zoneParticles;

    public GameObject easterEggZone;
    public GameObject dontStopText;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "bullet")
        {
            GameObject part = Instantiate(particles, new Vector3(-27, 0, 16), Quaternion.identity);
            part.SetActive(true);
            Destroy(other.gameObject);
            Destroy(part, 1);
            counter++;

            if(counter == 40 && dontStopText != null)
            {
                dontStopText.SetActive(true);
            }
            else if (counter == 50 && dontStopText != null)
            {
                dontStopText.GetComponent<Image>().color = Color.black;
                Destroy(dontStopText, 0.03f);
            }
            if (counter >= 100)
            {
                easterEggZone.SetActive(true);
                zoneParticles.SetActive(true);
                Destroy(zoneParticles, 3);
                Destroy(gameObject,3);
            }
        }
    }
}
