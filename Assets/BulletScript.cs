using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    Rigidbody2D rigidbody;
    public float bulletSpeed = 100;
    public GameObject bombEffect;
    public Transform Bulletdir;
    AudioSource audioSource;
    RocketCannonScript rocketCannon;
    float potential;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        rocketCannon = GameObject.Find("rocketCannon").GetComponent<RocketCannonScript>();
        potential = rocketCannon.whileAimTime;
        
        if (potential > 4){
            rigidbody.AddForce(transform.right*bulletSpeed*4f*2.5f);
        }
        else{
            rigidbody.AddForce(transform.right*bulletSpeed*potential*2.5f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.right = GetComponent<Rigidbody2D>().velocity;
        if (transform.position.x > 30){
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D (Collision2D other){
        rigidbody.AddForce(-transform.right*bulletSpeed*potential*2.5f);
        rigidbody.constraints = RigidbodyConstraints2D.FreezeAll; 
        Instantiate(bombEffect, transform.position, transform.rotation);
        audioSource.Play();
        Destroy(gameObject, 5);
    }
}