using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float PlayerSpeed;
	public bool CanMove;
	
	void Start () 
	{
	}

	void Update () 
	{
		float translation = PlayerSpeed * Time.deltaTime;

		if (CanMove == true)
		{
			transform.Translate(new Vector3(Input.GetAxis("HorizontalPlayer") * translation, 0, Input.GetAxis("VerticalPlayer") * translation));
		}
		else if (CanMove == false)
		{
			
		}
	}
}
