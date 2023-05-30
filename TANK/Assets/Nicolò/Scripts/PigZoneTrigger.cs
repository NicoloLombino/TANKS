using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PigZoneTrigger : MonoBehaviour
{
    public GameObject closeWall;
    public GameObject pigHealth;
    public GameObject pigBoss;
    public GameObject wall2;

    public GameObject text1;
    public GameObject text2;
    public GameObject text3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (pigBoss.GetComponent<Player>().health <= 0)
        {
            closeWall.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "tank")
        {
            closeWall.SetActive(true);
            StartCoroutine(StartZone());
        }
    }

    public IEnumerator StartZone()
    {
        yield return new WaitForSeconds(4);
        text1.SetActive(true);
        Destroy(text1, 3);
        yield return new WaitForSeconds(3);
        text2.SetActive(true);
        Destroy(text2, 3);
        yield return new WaitForSeconds(3);
        text3.SetActive(true);
        yield return new WaitForSeconds(5);
        text3.GetComponent<Image>().color = Color.black;
        text3.GetComponentInChildren<Text>().color = Color.black;
        Destroy(text3, 0.03f);
        yield return new WaitForSeconds(2);
        pigBoss.GetComponent<PigBoss>().enabled = true;
        pigBoss.GetComponent<Player>().enabled = true;
        pigHealth.SetActive(true);
        gameObject.GetComponent<BoxCollider>().enabled = false;
        wall2.GetComponent<BoxCollider>().enabled = false;
    }
}
