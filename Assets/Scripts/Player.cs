using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour 
{
	[SerializeField]
	float speed = 2;

	void Start () 
	{
		
	}

	void Update () 
	{
		if(Input.GetKey(KeyCode.A))
			this.transform.Translate(Vector2.left*speed*Time.deltaTime);
		if(Input.GetKey(KeyCode.S))
			this.transform.Translate(Vector2.down*speed*Time.deltaTime);
		if(Input.GetKey(KeyCode.D))
			this.transform.Translate(Vector2.right*speed*Time.deltaTime);
		if(Input.GetKey(KeyCode.W))
			this.transform.Translate(Vector2.up*speed*Time.deltaTime);
	}
}
