using UnityEngine;
using System.Collections;

public class SpawnImpact : MonoBehaviour {

	public GameObject ImpactPoint;

	// Use this for initialization
	void Start () 
	{
		//InstantiateImpact();   
	}

	public void InstantiateImpact()
	{
		GameObject CurrentPoint = (GameObject)Instantiate(ImpactPoint);
		CurrentPoint.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
	}

	// Update is called once per frame
	void Update () {
	
	}
}
