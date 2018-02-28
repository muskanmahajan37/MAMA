using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSkillController : MonoBehaviour {


    public float flowFillSpeed = 0.1f;
    public int speedNeeded = 100;

    public float maxFlow = 100;
	public float currentFlow;

    public float dashCost = 100;

	private Image fill;

    private bool gainFlowHuh;
    private float startTime;
    private float duration;

	// Use this for initialization
	void Start () {
		this.currentFlow = 100;
		this.fill = GameObject.Find ("Canvas/FillBG/Fill").GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
        if (! gainFlowHuh)
        {
            // If you're not gaining flow, then you can't use skills either
            processTimeout();
            return;
        }

        // Gain flow if you're going fast
        if (this.GetComponent<Rigidbody2D>().velocity.magnitude >= speedNeeded) {
        	currentFlow = Mathf.Min (currentFlow + flowFillSpeed, maxFlow);
        }

        // Try to dash
        if (Input.GetKeyDown(KeyCode.J))
        {
            tryDash();
        }

        redrawFlow();
	}

    // Attempt to dash
    private void tryDash()
    {
        if (this.currentFlow >= dashCost)
        {
            float dashDur = 0.1f;

            this.currentFlow -= dashCost;
            this.GetComponent<PlayerMoveAcc>().dash(dashDur);
            this.gainFlowHuh = false;
            this.duration = dashDur;
            this.startTime = Time.time;
        }
    }

    // Check if this frame => we've waited long enough to get back our skill controller
    private void processTimeout()
    {
        if (Time.time - this.startTime >= duration)
        {
            this.gainFlowHuh = true;
        }
    }

    public void addFlow(float addAmnt)
    {
        currentFlow = Mathf.Min(currentFlow + addAmnt, maxFlow);
    }


	void redrawFlow() {
        RectTransform rt = this.fill.GetComponent<RectTransform>();
        float xSize = (((float)currentFlow) / ((float)maxFlow)) * 100;
        Vector2 newSize = new Vector2(xSize, rt.sizeDelta.y);
        rt.sizeDelta = newSize;
        Vector2 newPos = new Vector2(xSize - 100, rt.localPosition.y);
        rt.localPosition = newPos;
	}
}
