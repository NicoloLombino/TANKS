using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [Header("movement")]
    public float speed;
    public float rotateSpeed;
    public GameObject particleSystemMove;
    public bool canMove;

    public KeyCode moveStraight;
    public KeyCode moveBackwards;
    public KeyCode rotateRight;
    public KeyCode rotateLeft;


    [Header("status")]
    public float maxHealth;
    public float health;
    public Image healthUI;
    public GameObject particleExplosion;
    public AudioSource ExplosionSound;




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Rotate();

        if(health <= 0)
        {
            GameObject Explosion = Instantiate(particleExplosion, gameObject.transform.position, Quaternion.identity);
            ExplosionSound.Play();
            canMove = false;
        }
    }

    private void Move()
    {
        if (Input.GetKey(moveStraight) && canMove == true)
        {
            transform.position += transform.forward * speed * Time.deltaTime;
            //particleSystemMove.SetActive(true);
        }

        else if (Input.GetKey(moveBackwards) && canMove == true)
        {
            transform.position -= transform.forward * speed * Time.deltaTime;
            //particleSystemMove.SetActive(true);
        }
        //else { particleSystemMove.SetActive(false); }
    }

    private void Rotate()
    {
        if (Input.GetKey(rotateLeft) && canMove == true)
        {
            transform.Rotate(Vector3.up, rotateSpeed * -1 * Time.deltaTime);
        }

        else if (Input.GetKey(rotateRight) && canMove == true)
        {
            transform.Rotate(Vector3.up, rotateSpeed * 1 * Time.deltaTime);
        }
    }

    public void UpdateHealth()
    {
        healthUI.fillAmount = health / maxHealth;
    }


}
