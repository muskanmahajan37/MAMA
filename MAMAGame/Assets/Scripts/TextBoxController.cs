using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextBoxController : MonoBehaviour {

    private Text t;
    private string myString;

	// Use this for initialization
	void Start () {
        this.t = GameObject.Find("Canvas/CenterText").GetComponent<Text>();
        if (this.name == "TextBox Jump")
        {
            this.myString = "Use the 'up arrow' key \nor 'w' key to jump";
        } else if (this.name == "TextBox MaxSpeed")
        {
            this.myString = "There is a max speed,\ntry and get to it.\nThere is space";
        }
        else if (this.name == "TextBox Bump")
        {
            this.myString = "Sometimes you'll find a bump.";
        }
        else if (this.name == "TextBox Boost")
        {
            this.myString = "Press 'J' for a quick boost back to full speed.";
        } else if (this.name == "TextBox Charge")
        {
            this.myString = "Your boost bar in the top right charges when you are going fast. Charge it back up.";
        } else if (this.name == "TextBox Baddies")
        {
            this.myString = "Stay out of the baddies vision. If you're too slow you'll be spotted!" +
                "\nDon't worry you can touch them and they won't notice.";
        } else if (this.name == "TextBox End")
        {
            this.myString = "Good luck out there.";
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

 
    void OnTriggerEnter2D(Collider2D other)
    {
        this.t.text = myString;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        this.t.text = "";
    }


}
