using UnityEngine;
using System.Collections;

public class AttackAnimation : MonoBehaviour {

	public void attack()
	{
		GetComponent<Animation>().Play();
	}
}
