using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveProva : MonoBehaviour
{
    public WheelCollider wc;
    public float wcSpeed;

    // Start is called before the first frame update
    void Start()
    {
        //wc = GetComponent<WheelCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            wc.motorTorque = wcSpeed;
        }
        else { wc.motorTorque = 0; }
    }
}
