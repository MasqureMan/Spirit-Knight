﻿using UnityEngine;
using System.Collections;

public class StartBattle : MonoBehaviour {

	public float MoveSpeed = 15f;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.Translate (new Vector3(0, -1, 0) * MoveSpeed * Time.deltaTime);
	}
}
