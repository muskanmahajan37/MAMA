using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillWallController : MonoBehaviour {

	
	private LevelController lc;


	// Use this for initialization
	void Start () {
		this.lc = GameObject.FindWithTag("GameController").GetComponent<LevelController>();

	}
	

	private void OnCollisionEnter2D(Collider2D collision) {
		
		if (collision.gameObject.CompareTag("Player")) {
			this.lc.gameOver();
		}
		
	}
}
