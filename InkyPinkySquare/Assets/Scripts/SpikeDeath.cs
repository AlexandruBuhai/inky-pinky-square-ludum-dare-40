using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeDeath : MonoBehaviour {

    private PlayerController player; //the sqares
    private PlayerController player2;
    private PlayerController player3;
    private int deathCounter = 1; //death counter, at which death are you 

    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerController>  ();
        player2 = GameObject.FindGameObjectWithTag("Player2").GetComponent<PlayerController> ();
        player3 = GameObject.FindGameObjectWithTag("Player3").GetComponent<PlayerController> ();
//        Debug.Log(player.name);
//        Debug.Log(player2.name);
//        Debug.Log(player3.name);
    }
    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.CompareTag ("Player") || c.CompareTag("Player2") || c.CompareTag("Player3") ){ // if you are a player
                                                                                               //that goes through the trigger reduce your velocity and then respawn at the sspwan point
            this.DeathAnimation();
            var rb = player.GetComponent<Rigidbody2D>();
            rb.velocity = new Vector3(0, 0, 0);
            var rb2 = player2.GetComponent<Rigidbody2D>();
            rb2.velocity = new Vector3(0, 0, 0);
            var rb3 = player3.GetComponent<Rigidbody2D>();
            rb3.velocity = new Vector3(0, 0, 0);
        }

    }

    void DeathAnimation() //Checks the deathCounter and spawns the squares accordingly
    {
        //yield return new WaitForSeconds(0.4f);

        if (deathCounter == 0) //
        {
            player.Death ();
            deathCounter++;
        }
        else if (deathCounter == 1)
        {
            player.Death ();
            player2.Death();
            deathCounter++;

        }
        else if (deathCounter == 2)
        {
            player.Death ();
            player2.Death();
            StartCoroutine(WaitForInky());

            deathCounter++;

        }
        else if (deathCounter >= 3)
        {
            player.Death ();
            player2.Death();
            StartCoroutine(WaitForInky());
      
            deathCounter++;
            Debug.Log("Game ended!");           
        }
    }

    public IEnumerator WaitForInky()
    {
        yield return new WaitForSeconds(0.2f);
        player3.Death();
        player3.Death();
       
    }
}