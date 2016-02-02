using UnityEngine;
using System.Collections;

public class EnemyShieldClash : MonoBehaviour {

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
		if(other.name == "PlayerSword")
		{
			Source.Play();
		}
	}
}
