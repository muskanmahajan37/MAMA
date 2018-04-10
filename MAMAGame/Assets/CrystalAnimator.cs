using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalAnimator : MonoBehaviour {

    public List<Sprite> crystalSprites;

    private int currentIndex;
    private float lastChange;
    private float timeBetweenFrameChange = 0.1f;

	// Use this for initialization
	void Start () {
        this.lastChange = Time.time;
        this.currentIndex = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time - lastChange > this.timeBetweenFrameChange)
        {
            this.lastChange = Time.time;
            this.currentIndex = (currentIndex + 1) % this.crystalSprites.Count;
            this.GetComponent<SpriteRenderer>().sprite = crystalSprites[currentIndex];
        }
	}
}
