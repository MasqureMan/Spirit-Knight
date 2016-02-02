using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {

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
			transform.Translate(new Vector3(Input.GetAxis("HorizontalPOne") * translation, 0, Input.GetAxis("VerticalPTwo") * translation));
		}
		else if (CanMove == false)
		{
			
		}
	}
}
