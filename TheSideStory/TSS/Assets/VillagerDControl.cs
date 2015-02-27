using UnityEngine;
using System;
using System.Collections;

public class VillagerDControl : MonoBehaviour {

	//public variables :: editable in Unity
	public float MaxSpeed = 10f;
	public Animator anim;
	public bool waiting = false;
	public bool facingRight = true;
	public Texture HUG;
	public Vector3 LSLoc;
	public bool Key = false;
	public Animator DAnimator;
	public Transform groundCheck;
	public LayerMask whatIsGround; // Layers to be collided with for jump
	public bool grounded = false;
	public float jumpForce = 35f;
	public int jumpCool = 0;

	//private :: editable ONLY in this file
	private float dt;
	private float groundRadius = 0.2f;

	// Use this for initialization
	void Start() {
		anim = GetComponent<Animator>();
	}

	// Unchanging Deltatime
	void FixedUpdate() {
		// ++Gets the current elapsed time from the previous frame++
		// dt = Time.deltaTime;
		if(!waiting){
			// Checks for left/right input to add to movement left and right
			float move = Input.GetAxis("Horizontal");
			grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);

			// Applies the movement vector
			rigidbody2D.velocity = new Vector2(move * MaxSpeed /*++ * dt++*/, rigidbody2D.velocity.y /*++ * dt++*/);
				
			// Dan's Direction
			if(move>0 && !facingRight)
				Flip ();
			else if(move<0 && facingRight)
				Flip ();

			DAnimator.SetFloat("Speed", (Math.Abs(move)));
		}
	}

	// Checks for Jump
	void Update(){
		if(grounded && Input.GetKeyDown(KeyCode.Space) && jumpCool < 0){
			rigidbody2D.AddForce(new Vector2(0,jumpForce));
			jumpCool = 20;
		}
		jumpCool -=1;
		jumpCool%=20;
	}

	// Changes the direction of the sprite
	void Flip(){
		facingRight = !facingRight;
		Vector3 scale = transform.localScale;
		scale.x *=-1;
		transform.localScale = scale;
	}

	// Not fully implemented
	void OnGUI(){
		GUI.backgroundColor = Color.yellow;
		GUI.DrawTexture(new Rect(0,0,Screen.width/5,Screen.width/10), HUG, ScaleMode.StretchToFill, true, 1.0f); // "CharacterHUD"
	}

	// Checks to see if you've picked up the Key object
	public bool HasKey(){
		if(Key){
			return true;
		}
		return false;
	}
}