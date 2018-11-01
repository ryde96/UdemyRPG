using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	// Public variables
	public Rigidbody2D theRB;
	public float moveSpeed;

	public Animator playerAnimator;

	public string areaTransitionName;

	public static PlayerController instance;
	
	// Private variables
	
	// Use this for initialization
	void Start ()
	{
		if (instance == null)
		{
			instance = this;
		}
		else
		{
			Destroy(gameObject);
		}
		
		
		DontDestroyOnLoad(gameObject);
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		// Enable us to move the player with "WASD" or arrows
		theRB.velocity = new Vector2(
			Input.GetAxisRaw("Horizontal"),
			Input.GetAxisRaw("Vertical")
			) * moveSpeed;
		
		playerAnimator.SetFloat("moveX", theRB.velocity.x);
		playerAnimator.SetFloat("moveY", theRB.velocity.y);

		if (Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1 ||
			Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1)
		{
			playerAnimator.SetFloat("lastMoveX", Input.GetAxisRaw("Horizontal"));
			playerAnimator.SetFloat("lastMoveY", Input.GetAxisRaw("Vertical"));
		}
	}
	
	
}
