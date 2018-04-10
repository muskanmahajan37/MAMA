using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour {



	// Use this for initialization
	void Start () {
		
	}

    public void levelWon()
    {
        GameObject.Find("Canvas/Tubular").SetActive(true);
    }
	
	public void gameOver() {
		print("Game over in LevelController");
        var awayPos = new Vector3(-1000, -1000, -1000);
        GameObject.Find("Player").transform.position =awayPos;
        GameObject.Find("Canvas/Grody").SetActive(true);
	}

    public void restartLevel()
    {
        print("restartLevel GameController");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void quit()
    {
        print("quit GameController");
        Application.Quit();
    }

    public void nextLevel()
    {
        print("nextLevel GameController");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
