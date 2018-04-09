using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level3TextBox : MonoBehaviour {

    private Text t;
    private string myString;

    // Use this for initialization
    void Start()
    {
        this.t = GameObject.Find("Canvas/CenterText").GetComponent<Text>();
        if (this.name == "TextBox GoFast")
        {
            this.myString = "Better go fast, these guys are sensitive";
        }
    }

    // Update is called once per frame
    void Update()
    {

    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            this.t.text = myString;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            this.t.text = "";
        }
    }
}
