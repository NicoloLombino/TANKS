using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PigHeadProtector : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "bullet")
        {
            Destroy(other.gameObject);
        }
    }
}
