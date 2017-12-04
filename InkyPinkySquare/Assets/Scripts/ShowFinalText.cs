using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowFinalText : MonoBehaviour {

	public Text textAbove;
	private string text5 = "You're all set, go get them!";

	// Use this for initialization
	void Start () {

	}
	void OnTriggerEnter2D(Collider2D c)
	{
		textAbove.text = text5;
	}
}
