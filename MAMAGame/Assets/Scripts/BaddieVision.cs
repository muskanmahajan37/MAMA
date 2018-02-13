using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaddieVision : MonoBehaviour {

    public float alertTime;
    public float flipTime;

    float playerEnterTime;
    private float lastFlipTime;

	// Use this for initialization
	void Start () {
        playerEnterTime = 0.0f;
        this.lastFlipTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
        if (playerEnterTime != 0.0f && Time.time - playerEnterTime > alertTime)
        {
            print("GAME OVER");
            playerEnterTime = Time.time;
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
            playerEnterTime = Time.time;
        }

    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerEnterTime = 0.0f;
        }
    }
}
