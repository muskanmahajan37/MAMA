using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    public float minSpeed;
    public float acceleration;
    public float maxSpeed;
    public float jumpHeight;
    public int extraDoubleJumps = 0;

    private float runTime;

    private Transform GroundCheck;
    private Rigidbody2D rb;
    private int jumpCharges;

	// Use this for initialization
	void Start () {
        this.rb = this.GetComponent<Rigidbody2D>();
        this.GroundCheck = this.transform.Find("GroundCheck");
        if (this.GroundCheck == null)
            Debug.LogError("PlayerMovecs: We need GroundCheck to define down/ if we're on the ground");
        jumpCharges = extraDoubleJumps;

        this.runTime = 0.0f;
	}

    // Update is called once per frame
    void Update () {

        float horiz = Input.GetAxis("Horizontal");
        float vert = rb.velocity.y;
        if (horiz != 0) // If the player is pushign a move button
        {
            this.runTime = Mathf.Min(this.runTime + Time.deltaTime, maxSpeed);

            float minTemp = this.minSpeed;
            if (horiz < 0)
            {
                minTemp = minTemp * -1;
            }
            horiz = (horiz * acceleration * runTime) + minTemp;

        } else
        {
            this.runTime = 0.0f;
        }

        // Check for ver movement/ jump inputs
        if (Input.GetKeyDown(KeyCode.Space) ||
            Input.GetKeyDown(KeyCode.W) ||
            Input.GetKeyDown(KeyCode.UpArrow))
        {
            print(jumpCharges);
            if (this.isGrounded())
            {
                vert = jumpHeight;
                jumpCharges = extraDoubleJumps;
            }
            else if(jumpCharges > 0)
            {
                vert = jumpHeight;
                jumpCharges--;
            }
        }
        
        rb.velocity = new Vector2(horiz, vert);

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
