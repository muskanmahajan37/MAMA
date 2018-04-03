using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallColliderUpdater : MonoBehaviour {

	// Use this for initialization
	void Start () {
        BoxCollider2D coll = this.GetComponent<BoxCollider2D>();
        SpriteRenderer sr = this.GetComponent<SpriteRenderer>();

        coll.size = sr.size;
	}
	
}
