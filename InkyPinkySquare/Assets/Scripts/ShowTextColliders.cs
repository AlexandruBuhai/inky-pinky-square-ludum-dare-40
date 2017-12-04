using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowTextColliders : MonoBehaviour {

	public Text textAbove;
	private string text4 = "All the squares move like one, use walls to stop their movements and keep them together.";
	// Use this for initialization
	void Start () {
		
	}


	void OnTriggerEnter2D(Collider2D c)
	{
		textAbove.text = text4;
	}
}
