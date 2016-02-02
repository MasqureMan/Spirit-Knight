using UnityEngine;
using System.Collections;

public class LightOrbAnimation : MonoBehaviour {

	public GameObject LightShot;
	public float LightSpeed = 25f;
	//public Transform LightShoot;
	
	// Use this for initialization
	void Start () 
	{

	}

	public void InstantiateLight()
	{
		GameObject CurrentPoint2 = (GameObject)Instantiate(LightShot);
		CurrentPoint2.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
		//this.transform.position += transform.forward * LightSpeed * Time.deltaTime;
		Destroy (CurrentPoint2, 2.0f);
	}
    
}
