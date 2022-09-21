using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1Movement : MonoBehaviour
{
    SoccerGameManager gm;

    [SerializeField] private float runSpeed=25;

    //movement
    Rigidbody rb;

    bool moving;
    enum movement {up, down, left, right, none};
    movement currentmove;

    float maxSpeed=50f;

    //can the player move?
    bool canPlay=false;

    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<SoccerGameManager>();
    }


    void Update()
     {
         CanIPlay();

          moving = false;
          currentmove=movement.none;
    
         if(canPlay){
         if(Input.GetKey(KeyCode.W)){
             moving=true;
             currentmove= movement.up;
         }

         if(Input.GetKey(KeyCode.S)){
             moving=true;
             currentmove=movement.down;  
         }

         if(Input.GetKey(KeyCode.A)){
             moving=true;
             currentmove=movement.left;   
         }

         if(Input.GetKey(KeyCode.D)){
             moving=true;
             currentmove=movement.right;
         }
         }

    }

    void FixedUpdate()
    {
        if(moving){
        switch (currentmove){
            case movement.up:
            transform.Translate(Vector3.forward * runSpeed * Time.deltaTime);
            //rb.AddForce(Vector3.forward * runSpeed);
            break;

            case movement.down:
            transform.Translate(Vector3.back * runSpeed * Time.deltaTime);
            break;

            case movement.left:
            transform.Translate(Vector3.left * runSpeed * Time.deltaTime);
            break;

            case movement.right:
             transform.Translate(Vector3.right * runSpeed * Time.deltaTime);
            break;
        }
        }


    }

    public void CanIPlay()
    {
        canPlay = gm.canPlay;   
    }



}