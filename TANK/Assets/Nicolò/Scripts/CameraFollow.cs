using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject tank;
    public Vector3 offset;

    public bool isChild;
    public GameController GC;

    void Update()
    {
        if (GC.isGame == true)
        {
            isChild = true;
            gameObject.transform.parent = tank.transform;
        }
    }
}
