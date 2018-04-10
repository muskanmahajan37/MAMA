using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashAnimator : MonoBehaviour {

    public List<Sprite> dashSprites;

    private int curIndex; 
    private float lastChange;
    private float animationSpeed = 0.1f;

    private void Start()
    {
        this.lastChange = Time.time;
        this.curIndex = 0;
    }

    // Update is called once per frame
    void Update () {

        if (this.GetComponent<PlayerMoveAcc>().isDashing)
        {
            print("player is dashing");
            if (Time.time - lastChange > animationSpeed)
            {
                lastChange = Time.time;
                this.curIndex = (this.curIndex + 1) % dashSprites.Count;

                SpriteRenderer sr = this.GetComponent<SpriteRenderer>();

                sr.sprite = dashSprites[curIndex];
            }
        }
	}
}
