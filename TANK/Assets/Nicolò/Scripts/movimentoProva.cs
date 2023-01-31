using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimentoProva : MonoBehaviour
{
    CharacterController cc;

    public KeyCode moveStraight;
    public KeyCode moveBackwards;
    public KeyCode rotateRight;
    public KeyCode rotateLeft;

    public float speed;
    public float speedToGive;

    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
       // float movimento = transform.forward.z * speed;
        Vector3 move = new Vector3(speed * Mathf.Cos(gameObject.transform.eulerAngles.y), 0,speed * Mathf.Sin(gameObject.transform.eulerAngles.y));
        //Vector3 move2 = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        cc.Move(transform.forward * speed * Time.smoothDeltaTime - Vector3.up * 9.81f * Time.deltaTime);

        if (Input.GetKey(moveStraight))
        {
            speed = speedToGive;
            //cc.Move(transform.forward * move * Time.deltaTime);
            //cc.Move(transform.forward * speed * Time.smoothDeltaTime + 0 - Vector3.up * 9.81f * Time.deltaTime);
            //cc.Move(move2 * Time.deltaTime * speed);
            //gameObject.transform.forward = move;
        }

        else if (Input.GetKey(moveBackwards))
        {
            speed = -speedToGive;
            //cc.Move(move * Time.deltaTime);
            //gameObject.transform.forward = move;
        }
        else { speed = 0; }

        if (Input.GetKey(rotateLeft))
        {
            transform.Rotate(Vector3.up, 80 * -1 * Time.deltaTime);
        }

        else if (Input.GetKey(rotateRight))
        {
            transform.Rotate(Vector3.up, 80 * 1 * Time.deltaTime);
        }
    }
}
