using UnityEngine;
using System.Collections;

public class Player1Victory : MonoBehaviour {

	public float MoveSpeed = 15f;
	public PlayerManager playerManager;

	// Use this for initialization
	void Start () {
		playerManager = FindObjectOfType<PlayerManager>();
	}
	
	// Update is called once per frame
	void Update ()
	{
	}
}
