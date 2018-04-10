using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionsController : MonoBehaviour {


	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape))
        {
            // If the player wishes to escape...
            SceneManager.LoadScene("Scenes/TitleScene");
        }
	} 
}
