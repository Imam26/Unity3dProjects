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

    public Action onGameOver, onWin;
    
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
         
        onReachTheFinish();
    }

    private void onReachTheFinish(){
        if(rb.transform.position.z >= rbGround.transform.localScale.z/2 + rbGround.transform.position.z){             
            this.enabled = false;
            onWin();
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
            rb.AddForce(Vector3.up*10);
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
