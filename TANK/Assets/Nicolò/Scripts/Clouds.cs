using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clouds : MonoBehaviour
{
    public float rotSpeed;

    void Update()
    {
        transform.eulerAngles += new Vector3(0, rotSpeed * Time.deltaTime, 0);
    }
}
