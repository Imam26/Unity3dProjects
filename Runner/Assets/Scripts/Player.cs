using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rb;    
    [SerializeField]
    private float speed;
    [SerializeField]
    private float sideSpeed;
    [SerializeField]
    private float score = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(0,0,speed*Time.deltaTime);
        if(Input.GetKey("a")){
            rb.AddForce(-sideSpeed*Time.deltaTime,0,speed*Time.deltaTime);
        }          
        else if(Input.GetKey("d")){
            rb.AddForce(sideSpeed*Time.deltaTime,0,speed*Time.deltaTime);
        }            
    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "Obstacle"){
            this.enabled = false;
        }
    }
    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Coin"){
            score++;
            Debug.Log("Score: "+score);
            Destroy(other.gameObject);
        }
    }
}
