using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMoveAcc : MonoBehaviour
{

    public float minSpeed;
    public float acceleration;
    public float maxSpeed;
    public float jumpHeight;
    public int extraDoubleJumps = 0;

    public float speed;

    private float runTime;

    private Transform GroundCheck;
    private Rigidbody2D rb;
    private int jumpCharges;

    // Use this for initialization
    void Start()
    {
        this.rb = this.GetComponent<Rigidbody2D>();
        this.GroundCheck = this.transform.Find("GroundCheck");
        if (this.GroundCheck == null)
            Debug.LogError("PlayerMovecs: We need GroundCheck to define down/ if we're on the ground");
        jumpCharges = extraDoubleJumps;

        this.runTime = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {

        float horiz = Input.GetAxis("Horizontal");
        //float vert = rb.velocity.y;
        if (horiz != 0 && Mathf.Abs(rb.velocity.x) < maxSpeed) // If the player is pushing a move button, and we're under max speed.
        {

            float minTemp = this.minSpeed;
            if (horiz < 0)
            {
                minTemp = minTemp * -1;
            }
            horiz = (horiz * acceleration) + minTemp;
            
            print(horiz);

        } else if(horiz == 0) // If the move button isn't pressed
        {
            this.runTime = 0.0f;

        } else if(Mathf.Abs(rb.velocity.x) >= maxSpeed)
        {
            float maxSpeedTemp = maxSpeed;
            if (rb.velocity.x < 0)
            {
                maxSpeedTemp *= -1;
            }
            Vector2 temp = new Vector2(maxSpeedTemp, rb.velocity.y);
            rb.velocity = temp;
            print("!!!!! OverMaxSpeed");
        }

        float vert = rb.velocity.y;
        // Check for ver movement/ jump inputs
        if (Input.GetKeyDown(KeyCode.Space) ||
            Input.GetKeyDown(KeyCode.W) ||
            Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (this.isGrounded())
            {
                vert = jumpHeight;
                jumpCharges = extraDoubleJumps;
            }
            else if (jumpCharges > 0)
            {
                vert = jumpHeight;
                jumpCharges--;
            }
            Vector2 temp = rb.velocity;
            temp.y = vert;
            rb.velocity = temp;

        }

        rb.AddForce(new Vector2(horiz, 0) * speed);
    }

    private bool isGrounded()
    {
        float distToGround = 0.1f; // The length of the ray, from the GroundCheck
                                   // Make this longer so you can jump while further
                                   // away from the ground
        bool result = Physics2D.Raycast(this.GroundCheck.position,
                                        Vector2.down,
                                        distToGround,
                                        LayerMask.GetMask("Ground"));
        return result;
    }


}
