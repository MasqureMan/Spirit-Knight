using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class TwoPlayersManager : MonoBehaviour {

	public GameObject playerPrefab;
	public GameObject enemyPrefab;
	List<GameObject> players = new List<GameObject>();

	float PlayerSpeed = 0;

	void Update()
	{
		foreach(GameObject player in GameObject.FindObjectsOfType (typeof(GameObject)))
		{
			if(player.tag == "Player" && !players.Contains(player))
				players.Add (player);
			if(player.tag == "Enemy" && !players.Contains(player))
				players.Add(player);
		}

		float translation = PlayerSpeed;

		//if(Input.GetKey(KeyCode.A))
			players[0].transform.Translate(new Vector3(Input.GetAxis("Horizontal") * translation, 0, Input.GetAxis("Vertical") * translation));
		//if(Input.GetKey(KeyCode.D))
		//	players[0].transform.Translate(Vector3.right * speed * Time.deltaTime);
		//if(Input.GetKey (KeyCode.W))
		//	players[0].transform.Translate(Vector3.up * speed * Time.deltaTime);
		//if(Input.GetKey (KeyCode.S))
		//	players[0].transform.Translate (Vector3.down * speed * Time.deltaTime);
		
		//if(Input.GetKey(KeyCode.LeftArrow))
		    //players[1].transform.Translate(new Vector3(Input.GetAxis("Horizontal") * translation, 0, Input.GetAxis("Vertical") * translation));
		//if(Input.GetKey(KeyCode.RightArrow))
			//players[1].transform.Translate(Vector3.right * speed * Time.deltaTime);
		//if(Input.GetKey (KeyCode.UpArrow))
			//players[1].transform.Translate(Vector3.up * speed * Time.deltaTime);
		//if(Input.GetKey (KeyCode.DownArrow))
			//players[1].transform.Translate (Vector3.down * speed * Time.deltaTime);

	}
}
