using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float moveSpeed = 5; //Player movespeed 
    public float jumpHeight = 5; // Jump Height
    private Rigidbody2D rb; 
    public Transform groundCheck; // Checks the distance from the ground
    public float groundCheckRadius; // The radius of the circle that checks the ground
    public LayerMask whatIsGround; // Checks for groundLayer 
    private bool grounded = false; // is it on the ground
    private bool onTop = false; // is it on top of another square
    public LayerMask player1; //the other 2 squares
    public LayerMask player2;
	private Animator anim; 

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>(); // we initialize the rigidbody
        rb.freezeRotation = true; // we stop the rigid body rotation
		anim = this.GetComponent<Animator>(); // we get the animator
    }

    // Update is called once per frame
    void Update () {
       
        anim.SetFloat("MoveX", Input.GetAxisRaw("Horizontal")); //we get the type of animation
		
    }

    void FixedUpdate() {

        grounded = Physics2D.OverlapCircle(groundCheck.position,groundCheckRadius,whatIsGround); //we check if he is on the ground 
        onTop = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, player1) || Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, player2); //we check if he is on others 
       
        if ((Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) && (grounded || onTop)) // can only  jump if on top or grounded
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpHeight * 1.2f); //magic number I know
            transform.Translate(new Vector3(0f, Input.GetAxisRaw("Vertical") * jumpHeight * Time.deltaTime, 0f)); 

        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y); //right movement
            transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, 0f, 0f));  

        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y); //left movement
            transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, 0f, 0f));  
        }
        if (Input.GetKey(KeyCode.R))
        {
            Death(); //reset
        }

    }

    //Moves the player object to the spawn point
    //Waits a bit for the DeathAnimation
    public void Death()
    {
        
        StartCoroutine(Wait()); 
        GameMaster obj = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>();
        obj.KillPlayer(this);
    }

    public IEnumerator Wait()
    {
        
        //Debug.Log("I don't stop");
        anim.SetBool("DeadAnim", true);
        yield return new WaitForSeconds(1.3f);
        anim.SetBool("DeadAnim", false);
       
    }

}