using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToMenuScript : MonoBehaviour {
    
    void OnTriggerEnter2D(Collider2D c)
    {
        SceneManager.LoadScene(4);
       //Application.LoadLevel("GoToMenu");
    }

}
