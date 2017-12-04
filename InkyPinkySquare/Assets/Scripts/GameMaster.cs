using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour {

    public static GameMaster instance;

    // Use this for initialization
    void Start () {
        if (instance == null) {
            instance = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>();
        }
        Debug.Log("I am alive");
    }

    public Transform playerPrefab;
    public Transform spawnPoint;
    public float spawnDelay = 0.4f;
    private int deathCounter = -1;

    public void RespawnPlayer(PlayerController player) {

        var rb = player.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector3(0, 0, 0);
        instance.StartCoroutine(instance.WaitForSpawn(player));

        deathCounter++;


    }

    public void KillPlayer(PlayerController player)
    {
        instance.RespawnPlayer(player);  
    }

    public IEnumerator WaitForSpawn(PlayerController player)
    {
        yield return new WaitForSeconds(0.1f);
        if(player.name == "Inky")
            Debug.Log("I am a motherfucker that doesn't need no rules! Fuck physics!");
      
        player.transform.position = spawnPoint.position;
    }
}