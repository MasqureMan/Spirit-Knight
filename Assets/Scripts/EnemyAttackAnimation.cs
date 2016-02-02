using UnityEngine;
using System.Collections;

public class EnemyAttackAnimation : MonoBehaviour {

	public void Enemyattack()
	{
		GetComponent<Animation>().Play();
	}
}
