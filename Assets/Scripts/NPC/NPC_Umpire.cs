using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Umpire : MonoBehaviour
{
    //Umpire follows the Ball's location

    //
    private Rigidbody rb;
    private Vector3 movement;
    private float moveSpeed;
    private Renderer rend;
    
    //declares Ball object to follow
    public GameObject ballObj;

    //only moves during Play
    bool canPlay;

    private void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        rend = this.GetComponent<Renderer>();
        rend.material.SetColor("_Color", Color.black);
    }

    private void Update()
    {
        moveSpeed = Random.Range(220f, 275f);
        
        if (ballObj != null)
        {
            //move towards 
            float dist = Vector3.Distance(ballObj.transform.position, transform.position);

            //calculates direction towards target (currently Escort) as an angle between self and target
            Vector3 direction = ballObj.transform.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            direction.Normalize();
            movement = direction;
        }
    }

    private void FixedUpdate()
    {
        //if(canPlay)
        moveCharacter(movement);
    }

    //moves NPC rigidbody towards the target times moveSpeed
    void moveCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + direction * moveSpeed * Time.deltaTime);
    }


}
