using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelController : MonoBehaviour {

    public GameObject grody;
    public GameObject tubular;

	// Use this for initialization
	void Start () {
		
	}

    public void levelWon()
    {
        this.tubular.SetActive(true);
    }
	
	public void gameOver() {
		print("Game over in LevelController");
        var awayPos = new Vector3(-1000, -1000, -1000);
        GameObject.Find("Player").transform.position = awayPos;
        this.grody.SetActive(true);
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
