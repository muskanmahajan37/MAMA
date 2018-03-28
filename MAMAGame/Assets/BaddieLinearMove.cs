using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaddieLinearMove : MonoBehaviour {

    public float deltaX;
    public float deltaY;
    public float timeItWillTake = 5;

    private float elapsed;
    private Vector3 startPos;
    private Vector3 endPos;
    private bool returnHuh;

	// Use this for initialization
	void Start () {
        this.elapsed = 0;
        this.startPos = this.transform.position;
        this.endPos = new Vector3(this.startPos.x + this.deltaX, this.startPos.y + deltaY, this.startPos.z);
        this.returnHuh = false;
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 newPos;
        this.elapsed += Time.deltaTime;
        if (this.returnHuh)
        {
            // If we're returning from the endPos
            newPos = Vector3.Lerp(this.endPos, this.startPos, this.elapsed / this.timeItWillTake);
        } else
        {
            // Else we're going to the endPos
            newPos = Vector3.Lerp(this.startPos, this.endPos, this.elapsed / this.timeItWillTake);
        }

        this.transform.position = newPos;

        if (this.elapsed / this.timeItWillTake >= 1)
        {
            // If we have gone the entire time, then flip the direction of movement
            this.elapsed = 0;
            this.returnHuh = !this.returnHuh;
        }
	}
}
