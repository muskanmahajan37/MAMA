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
	public float anchorWeight;
    public float speed;



    private float runTime;

	private bool tryingToDrag;
	private bool dragging;

    private bool direction; // Left <=> false
                            // Right <=> true

    /////////////
    // Below is for dash processing 
    private bool lockMovement;
    private float lockStartTime;
    private float duration;
    private float oldGrav;

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
		
		tryingToDrag = false;
		dragging = false;
        this.lockMovement = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.lockMovement)
        {
            processLockedMovement();
            // Move the player gameObject by dash protocol
            dashMovement();
            return;
        }

        float horiz = Input.GetAxis("Horizontal");
        if (horiz != 0 && Mathf.Abs(rb.velocity.x) < maxSpeed) // If the player is pushing a move button, and we're under max speed.
        {
            this.direction = horiz > 0; // If we press a button, record the direction

            float minTemp = this.minSpeed;
            if (horiz < 0)
            {
                minTemp = minTemp * -1;
            }
            horiz = (horiz * acceleration) + minTemp;
            

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


        bool amGrounded = this.isGrounded();

        
        if (Input.GetKeyUp(KeyCode.LeftShift) || !amGrounded)
        {
            // If you pick up the anchor or you fall off an edge
            this.tryingToDrag = false;
            dragging = false;
            rb.drag = 0;
        }
        else if (Input.GetKey(KeyCode.LeftShift))
        {
            this.tryingToDrag = true;
        }

        // We're using this strange order of logic because if the player
        // presses shift while in air, the game should start dragging 
        // as soon as it can. 
        if (this.tryingToDrag && amGrounded && !dragging)
        {
            rb.drag = anchorWeight;
            dragging = true;
        }
        rb.AddForce(new Vector2(horiz, 0) * speed);
    }

    private void processLockedMovement()
    {
        if (Time.time - this.lockStartTime >= this.duration)
        {
            this.lockMovement = false;
            this.rb.gravityScale = oldGrav;
        }
    }

    private void beginLockMovement(float deltaTime)
    {
        this.lockMovement = true;
        this.lockStartTime = Time.time;
        this.duration = deltaTime;
    }

    public void dash(float dashTime)
    {
        this.beginLockMovement(dashTime);
        this.oldGrav = rb.gravityScale;
        this.rb.gravityScale = 0;
    }

    // Get's called every frame when we're dashing.
    private void dashMovement()
    {
        // Only move horizontally
        float speedAndDir = this.maxSpeed;
        if (!this.direction)
        {
            // If we are moving Left
            speedAndDir *= -1;
        }
        rb.velocity = new Vector2(speedAndDir, 0);
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
