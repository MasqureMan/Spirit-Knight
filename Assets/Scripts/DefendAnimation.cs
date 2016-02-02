using UnityEngine;
using System.Collections;

public class DefendAnimation : MonoBehaviour {

	public void defend()
	{
		GetComponent<Animation>().Play();
	}
}
