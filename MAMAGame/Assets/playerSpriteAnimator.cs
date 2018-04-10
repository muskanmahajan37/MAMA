using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerSpriteAnimator : MonoBehaviour {

    public Sprite idle;
    public List<Sprite> runAni;
    public List<Sprite> glowAni;
    public float animationSpeed;


    private float lastChange;
    private int curSpriteIndex;
    private float alpha;
    private float maxSpeed;
    private Rigidbody2D rb;
    SpriteRenderer glowSr;
    SpriteRenderer sr;

    // Use this for initialization
    void Start()
    {
        this.curSpriteIndex = 0;
        this.glowSr = this.transform.Find("Glow").GetComponent<SpriteRenderer>();
        this.sr = GetComponent<SpriteRenderer>();
        this.rb = this.GetComponent<Rigidbody2D>();
        this.maxSpeed = this.GetComponent<PlayerMoveAcc>().maxSpeed;
        this.alpha = 1 - (Mathf.Abs(rb.velocity.magnitude) / maxSpeed);
        this.lastChange = Time.time;
    }
	
	// Update is called once per frame
	void Update ()
    {
        
        if (this.rb.velocity.x != 0)
        {
            // If we are moving then update make us run
            this.runAnimation();
        } else
        {
            // Else we're not moving so stand still
            this.sr.sprite = this.idle;
        }
    }

    private void runAnimation()
    {
        // If it is time to change our animation then do so
        if (Time.time - lastChange >= animationSpeed)
        {
            this.lastChange = Time.time;
            curSpriteIndex = (curSpriteIndex + 1) % runAni.Count;
            this.sr.sprite = this.runAni[curSpriteIndex];

            // Now also update the glow animations
            this.glowSr.sprite = this.glowAni[curSpriteIndex];
        }

        // Update our alpha based on our speed
        this.alpha = 1 - (Mathf.Abs(this.rb.velocity.magnitude) / this.maxSpeed);

        Color tempColor = this.sr.color;
        tempColor.a = this.alpha;
        this.sr.color = tempColor;

        // Now at the same time make the Glow child become less transparent
        tempColor = this.transform.Find("Glow").GetComponent<SpriteRenderer>().color;
        tempColor.a = (Mathf.Abs(this.rb.velocity.x) / this.maxSpeed);
        glowSr.color = tempColor;

    }
}
