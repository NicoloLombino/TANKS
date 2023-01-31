using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    //Rigidbody rb;

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
    public GameObject smokeParticles;
    public GameObject fireParticles;
    public GameObject particleExplosion;
    public AudioSource ExplosionSound;
    public GameObject GameOverPanel;




    // Start is called before the first frame update
    void Start()
    {
        //rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Rotate();

        if(health <= 0)
        {
            canMove = false;
            fireParticles.SetActive(true);
            GameOverPanel.SetActive(true);
            ExplosionSound.Play();
        }
    }

    private void Move()
    {
        
        if (Input.GetKey(moveStraight) && canMove == true)
        {
            //rb.AddForce(Vector3.forward * -speed * 10, ForceMode.Force);
            transform.position += transform.forward * speed * Time.deltaTime;
            //rb.AddForce(Vector3.forward * speed * Time.deltaTime);
            //Vector3 velocity = new Vector3(0, 0, speed);
            //rb.velocity = rb.transform.TransformDirection(velocity);
            //particleSystemMove.SetActive(true);
            //Vector3 movement = transform.forward * speed * Time.deltaTime;
            //rb.MovePosition(rb.position + movement);
        }

        else if (Input.GetKey(moveBackwards) && canMove == true)
        {
            //rb.AddForce(Vector3.forward * speed * 10, ForceMode.Force);
            transform.position -= transform.forward * speed * Time.deltaTime;
            //Vector3 angularVel = new Vector3(0, rotateSpeed, 0);
            //rb.angularVelocity = angularVel;
            //particleSystemMove.SetActive(true);
            //Vector3 movement = transform.forward * -speed * Time.deltaTime;
            //rb.MovePosition(rb.position + movement);
        }
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

    public void UpdateHealth(float damage)
    {
        health -= damage;
        healthUI.fillAmount = health / maxHealth;

        if(health <= 0)
        {
            GameObject Explosion = Instantiate(particleExplosion, gameObject.transform.position, Quaternion.identity);
            Destroy(Explosion, 1f);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        /*
        if (other.gameObject.tag == "wall")
        {
            if (Input.GetKey(moveStraight) && canMove == true)
            {
                transform.position -= transform.forward * speed * Time.deltaTime;
                //particleSystemMove.SetActive(true);
            }

            else if (Input.GetKey(moveBackwards) && canMove == true)
            {
                //transform.position += transform.forward * speed * Time.deltaTime;
                //particleSystemMove.SetActive(true);
            }
        }
        */

        if (other.gameObject.tag == "flames")
        {
            float damage = other.GetComponent<Flames>().damage;
            UpdateHealth(damage);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "bullet")
        {
            int damage = other.GetComponent<Bullet>().damage;
            UpdateHealth(damage);
            GameObject BulletExplosion = Instantiate(other.gameObject.GetComponent<Bullet>().hitParticle, other.gameObject.transform.position + new Vector3(0f, 0f, 0f), Quaternion.identity);
            BulletExplosion.transform.parent = gameObject.transform;
            Destroy(BulletExplosion, 1f);
            Destroy(other.gameObject);
        }
    }


}
