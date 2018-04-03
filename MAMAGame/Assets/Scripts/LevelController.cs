using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour {



	// Use this for initialization
	void Start () {
		
	}
	
	public void gameOver() {
		print("Game over in LevelController");

		//Destroy(GameObject.FindWithTag("Player"));

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        

	}
}
