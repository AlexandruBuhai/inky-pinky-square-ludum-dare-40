using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneOnClick : MonoBehaviour {

	public void LoadPrimary() //Loads the main scene
	{
        SceneManager.LoadScene(1);
    }
    public void LoadTutorial() //Load the tutorial
    {
        SceneManager.LoadScene(3);
    }
    public void LoadMenu() //Load the tutorial
    {
        SceneManager.LoadScene(0);
    }
}
