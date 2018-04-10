using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void startGame()
    {
        print("nextLevel GameController");
        SceneManager.LoadScene("Scenes/Tutorial");
    }

    public void options()
    {
        SceneManager.LoadScene("Scenes/Options");
    }

    public void quit()
    {
        print("quit GameController");
        Application.Quit();
    }
}
