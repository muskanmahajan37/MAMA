using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaddieVision : MonoBehaviour {

    public float alertTime;
    public float flipTime;

    float playerEnterTime;
    private bool spottedPlayer;
    private Color origionalColor;
    private float lastFlipTime;
    private LineRenderer lr;

	// Use this for initialization
	void Start () {
        playerEnterTime = 0.0f;
        this.lastFlipTime = Time.time;
        spottedPlayer = false;
        this.origionalColor = this.GetComponent<SpriteRenderer>().color;

        this.lr = GetComponent<LineRenderer>();
        //lr.SetPosition(0, this.transform.position);
        lr.positionCount = this.GetComponent<PolygonCollider2D>().points.Length;
        for (int i  = 0; i < lr.positionCount ; i++)
        {
            Vector3 temp = this.GetComponent<PolygonCollider2D>().points[i % (lr.positionCount - 1)];
            lr.SetPosition(i, temp);
        }
        // Draw the line connecting the first and last point
	}
	
	// Update is called once per frame
	void Update () {
        if (spottedPlayer)
        {
            Color temp = this.GetComponent<SpriteRenderer>().color;
            float red = temp.r + ((Time.time - playerEnterTime) / alertTime) * 0.02f;
            Vector3 colors = new Vector3(red, temp.g, temp.b);
            colors.Normalize();
            temp.r = colors.x;
            temp.g = colors.y;
            temp.b = colors.z;
            this.GetComponent<SpriteRenderer>().color = temp;
            if (Time.time - playerEnterTime > alertTime)
            {
                print("GAME OVER");
                playerEnterTime = Time.time;
            }
        }
        
        
        if (Time.time - lastFlipTime > flipTime)
        {
            Vector3 temp = this.GetComponent<Transform>().localScale;
            temp.x *= -1;
            this.GetComponent<Transform>().localScale = temp;
            this.lastFlipTime = Time.time;
        }

	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // If the player has entered our 'vision' triger
            spottedPlayer = true;
            playerEnterTime = Time.time;
        }

    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            spottedPlayer = false;
            playerEnterTime = 0.0f;
            this.GetComponent<SpriteRenderer>().color = this.origionalColor;
        }
    }
}
