using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowText : MonoBehaviour {

	
	public Text textAbove;
    private string text1 = "This is Square.\nTo see his friends, touch the spikes.";
	private string text2 = "Oh, look, it's Pinky!\nTry to die again!";
	private string text3 = "Oh, look, it's Inky! \nSquare has only two friends.";
	private int cnt = 0;

	// Use this for initialization
	void Start () {
        textAbove.text = text1;

	}

	void OnTriggerEnter2D(Collider2D c)
	{
		if (cnt == 0) {
			textAbove.text = text2;

		}
		else if (cnt >= 1) {
			textAbove.text = text3;
		}
		cnt++;

	}
}
