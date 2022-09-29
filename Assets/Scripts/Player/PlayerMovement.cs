using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    SoccerGameManager gm;
    private TeamComp team;

    private Renderer rend;
   
    public enum whichPlayer
    {
        Neutral,
        PlayerOne,
        PlayerTwo
    };

    public whichPlayer amI;

    //movement
    Rigidbody rb;
    [SerializeField] private float moveSpeed = 25;
    bool moving;

    private Vector3 Up = new Vector3(0, 0, 100);
    private Vector3 Down = new Vector3(0, 0, -100);
    private Vector3 Left = new Vector3(-100, 0, 0);
    private Vector3 Right = new Vector3(100, 0, 0);
    private Vector3 UpRight = new Vector3(75, 0, 75);
    private Vector3 DownRight = new Vector3(75, 0, -75);
    private Vector3 UpLeft = new Vector3(-75, 0, 75);
    private Vector3 DownLeft = new Vector3(-75, 0, -75);
    private Vector3 moveDir;

    private Vector3 currentSpeed;
    private Vector3 maxSpeed;

    //can the player move?
    bool canPlay = true;

    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<SoccerGameManager>();

        rend = this.GetComponent<Renderer>();

        currentSpeed = rb.velocity;

        switch (amI)
        {

            case (whichPlayer.PlayerOne):
                rend.material.SetColor("_Color", Color.red);
                break;

            case (whichPlayer.PlayerTwo):
                rend.material.SetColor("_Color", Color.blue);
                break;
        }
    }


    void Update()
    {
        if (!canPlay)
        {
            moving = false;
            rb.velocity = Vector3.zero;
        }

        if (canPlay)
        {
            switch (amI)
            {
                //durr

                case (whichPlayer.PlayerOne):
                    
                   // moveDir = new Vector3((Input.GetAxis("Horizontal.Red")), 0, Input.GetAxis("Vertical.Red")).normalized;
                   
                    if (Input.GetKey(KeyCode.W))
                    {
                        moveDir = Up;
                        moving = true;
                    }
                    if (Input.GetKeyUp(KeyCode.W))
                    {
                        moving = false;
                    }
                    
                    
                    if (Input.GetKey(KeyCode.S))
                    {
                        moveDir = Down;
                        moving = true;
                    }
                    if (Input.GetKeyUp(KeyCode.S))
                    {
                        moving = false;
                    }
                    
                    if (Input.GetKey(KeyCode.A))
                    {
                        moveDir = Left;
                        moving = true;
                    }
                    if (Input.GetKeyUp(KeyCode.A))
                    {
                        moving = false;
                    }
                    
                    if (Input.GetKey(KeyCode.D))
                    {
                        moveDir = Right;
                        moving = true;
                    }
                    if (Input.GetKeyUp(KeyCode.D))
                    {
                        moving = false;
                    }
                    if ((Input.GetKey(KeyCode.W)) && (Input.GetKey(KeyCode.D)))
                    {
                        moveDir = UpRight;
                        moving = true;
                    }
                    if ((Input.GetKey(KeyCode.W)) && (Input.GetKey(KeyCode.A)))
                    {
                        moveDir = UpLeft;
                        moving = true;
                    }
                    if ((Input.GetKey(KeyCode.S)) && (Input.GetKey(KeyCode.D)))
                    {
                        moveDir = DownRight;
                        moving = true;
                    }
                    if ((Input.GetKey(KeyCode.S)) && (Input.GetKey(KeyCode.A)))
                    {
                        moveDir = DownLeft;
                        moving = true;
                    }
                   
                    break;

                case (whichPlayer.PlayerTwo):
                    
                    // moveDir = new Vector3((Input.GetAxis("Horizontal.Blue")), 0, Input.GetAxis("Vertical.Blue")).normalized;
                    //
                    // moveDir = P2move;
                    
                    if (Input.GetKey(KeyCode.UpArrow))
                    {
                        moveDir = Up;
                        moving = true;
                    }
                    if (Input.GetKeyUp(KeyCode.UpArrow))
                    {
                        moving = false;
                    }
                    
                    
                    if (Input.GetKey(KeyCode.DownArrow))
                    {
                        moveDir = Down;
                        moving = true;
                    }
                    if (Input.GetKeyUp(KeyCode.DownArrow))
                    {
                        moving = false;
                    }
                    
                    if (Input.GetKey(KeyCode.LeftArrow))
                    {
                        moveDir = Left;
                        moving = true;
                    }
                    if (Input.GetKeyUp(KeyCode.LeftArrow))
                    {
                        moving = false;
                    }
                    
                    if (Input.GetKey(KeyCode.RightArrow))
                    {
                        moveDir = Right;
                        moving = true;
                    }
                    if (Input.GetKeyUp(KeyCode.RightArrow))
                    {
                        moving = false;
                    }
                    if ((Input.GetKey(KeyCode.UpArrow)) && (Input.GetKey(KeyCode.RightArrow)))
                    {
                        moveDir = UpRight;
                        moving = true;
                    }
                    if ((Input.GetKey(KeyCode.UpArrow)) && (Input.GetKey(KeyCode.LeftArrow)))
                    {
                        moveDir = UpLeft;
                        moving = true;
                    }
                    if ((Input.GetKey(KeyCode.DownArrow)) && (Input.GetKey(KeyCode.RightArrow)))
                    {
                        moveDir = DownRight;
                        moving = true;
                    }
                    if ((Input.GetKey(KeyCode.DownArrow)) && (Input.GetKey(KeyCode.LeftArrow)))
                    {
                        moveDir = DownLeft;
                        moving = true;
                    }


                    break;
            }
        }

        if (moving)
            rb.drag = 20;
        else
        {
            moving = false;
            rb.drag = 2500;
        }
    }

    void FixedUpdate()
    {
        if (moving)
        {
            rb.AddForce(moveDir * moveSpeed * Time.deltaTime);
        }
    }
    
    void OnEnable()
    {
        SoccerEventManager.PlayTimeEvent += SwitchPlay;
    }
    

    public void SwitchPlay()
    {
        canPlay = !canPlay;
    }
}