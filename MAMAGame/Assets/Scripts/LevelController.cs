using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelController : MonoBehaviour {

  public GameObject grody;
  public GameObject tubular;
  private float startTime;
  private Text timer;
  private bool levelOver;

	// Use this for initialization
	void Start () {
    this.levelOver = false;
    this.startTime = Time.time;
    this.timer = GameObject.Find("Canvas/Timer").GetComponent<Text>();
	}


  void Update() {
      if (!this.levelOver) {
          this.timer.text = (Time.time - startTime).ToString("0.00");
          print(this.levelOver);
      }
  }

  public void levelWon()
  {
      this.levelOver = true;
      this.tubular.SetActive(true);
  }

	public void gameOver() {
      this.levelOver = true;
      print(this.levelOver);
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
