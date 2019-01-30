using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rb;  
    
    [SerializeField]
    private Rigidbody rbGround;    
    [SerializeField]
    private float speed;
    [SerializeField]
    private float sideSpeed;

    public Action onGameOver;
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
         
        if(rb.transform.position.z >= rbGround.transform.localScale.z/2 + rbGround.transform.position.z){             
            rb.transform.position = new Vector3(rbGround.transform.position.x,
                                                rbGround.transform.position.y+1,
                                                rbGround.transform.position.z - rbGround.transform.localScale.z/2); 
        }
    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "Obstacle"){
            this.enabled = false;

            if(onGameOver!=null){
                onGameOver();
            }
        }
        else if(other.gameObject.tag == "JumpObstacle"){
            //rb.MovePosition(rb.transform.position + new Vector3(0,2,0));
        }
    }
    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Coin"){
            score++;
            Debug.Log("Score: "+score);
            if(score%5==0){
                speed+=5;
            }
            Destroy(other.gameObject);
        }
    }
}
