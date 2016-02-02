using UnityEngine;
using System.Collections;

public class ShieldClash : MonoBehaviour {

	public AudioSource Source;
	
	// Use this for initialization
	public void Awake () {
		Source = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerEnter(Collider other)
	{
		if(other.name == "EnemySword")
		{
			Source.Play();
		}
	}
}
