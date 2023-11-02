using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
	//Movement
	public float speed;
	public float jump;
	float _moveVelocity;
    //public VectorValue pos;
	//Grounded Vars
	bool _isGrounded = true;

	private bool _canMove = true;

	public bool CanMove
	{
		get { return _canMove; }
		set 
		{ 
			_canMove = value;
			if (!value)
			{
				GetComponent<Rigidbody2D>().velocity = Vector2.zero;
			}
		}
	}

	private void Start()
	{
		//
		// Find Character object from previous scene
		//
		GameObject character = null;
		GameObject copy = null;
		try
		{
			character = GameObject.Find("CharacterM");
			copy = Instantiate(character);
			copy.name = "CharacterM";
		} catch
		{
			character = GameObject.Find("CharacterF");
			copy = Instantiate(character);
			copy.name = "CharacterF";
		}
		character.name = "Character";

		// make root node so DontDestroyOnLoad() works properly
		copy.transform.SetParent(null, true);

		character.transform.SetParent(this.transform);
		
		// set proper scale and position
		character.transform.localScale = Vector3.one;
		character.transform.position = this.transform.position;
		
		// make copy of character to be used in next scene
		copy.transform.localScale = Vector3.zero;
		DontDestroyOnLoad(copy);

		GameLogicScript.Instance.Update();
	}

	void Update()
	{
		if (CanMove)
		{
			//Jumping
			if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
			{
				if (_isGrounded)
				{
					GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jump);
					_isGrounded = false;
				}
			}

			_moveVelocity = 0;

			//Left Right Movement
			if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
			{
				_moveVelocity = -speed;
			}
			if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
			{
				_moveVelocity = speed;
			}

			GetComponent<Rigidbody2D>().velocity = new Vector2(_moveVelocity, GetComponent<Rigidbody2D>().velocity.y);
		}
	}
	//Check if Grounded
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "FloorCollider") _isGrounded = true;
	}
}
