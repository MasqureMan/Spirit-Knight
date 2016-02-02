using UnityEngine;
using System.Collections;

public class HealthBarPlayer : MonoBehaviour {

	public float MaxHealth = 100f;
	public float CurrentHealth = 0f;
	public Transform from;
	public Transform to;
	public Transform Enemy;
	public float speed = 0.1F;
	public float SpawnWait = 100f;
	public float SpawnTimerWait = 100f;
	public GameObject healthbar;
	public bool Attack = false;
	//public Transform Player;
	public GameObject SpawnPoint;
	public GameObject SpawnPoint2;
	//public EnemyAttackAnimation _EnemyAttack;
	public SpawnImpact _SpawnImpactEnemy;
	
	// Use this for initialization
	void Start () 
	{
		CurrentHealth = MaxHealth;
		//InvokeRepeating("DecreaseHealth", 1f, 2f);
	}
	
	void OnTriggerEnter(Collider other)
	{
		if (other.name == "PlayerSword" )//&& Attack == true)
		{
//			_EnemyAttack.GetComponent<AttackAnimation>();
			_SpawnImpactEnemy.GetComponent<SpawnImpact>();
			_SpawnImpactEnemy.InstantiateImpact();
			//Destroy (_SpawnImpactEnemy, 2.0f);
			InvokeRepeating ("DecreaseHealth", 0.1f, 0.1f);
		}
	}
	
	void OnTriggerExit(Collider other)
	{
		if (other.name == "PlayerSword")
		{
			CancelInvoke ("DecreaseHealth");
			Attack = false;
		}
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		
		if (CurrentHealth <= 0)
		{
			CancelInvoke("DecreaseHealth");
			transform.rotation = Quaternion.Lerp(from.rotation, to.rotation, Time.deltaTime * speed);
			//Player.transform.position = SpawnPoint.transform.position;
			//transform.Translate (new Vector3(0, -1, 0) * Time.deltaTime);
			SpawnWait -= 1f;
			SpawnTimerWait -= 1f;
			Revive();
			SpawnTimer ();
			IncreaseHealth();
			Dead ();
		}
		if (CurrentHealth == 10)
		{
			CancelInvoke("IncreaseHealth");
		}
		if(SpawnTimerWait <=0)
		{
			SpawnWait = 100f;
			SpawnTimerWait = 100f;
		}
		Hit ();
	}
	
	void DecreaseHealth()
	{
		CurrentHealth -= 2f;
		float CalcHealth = CurrentHealth / MaxHealth;
		SetHealthBar (CalcHealth);
	}
	
	public void SetHealthBar(float MyHealth)
	{
		healthbar.transform.localScale = new Vector3(MyHealth, healthbar.transform.localScale.y, healthbar.transform.localScale.z);
	}
	
	public void Revive()
	{
		if (SpawnWait <= 0)
		{
			Enemy.transform.Rotate(new Vector3(0, 0, 0));
			//Player.transform.Rotate(new Vector3(0, 0, 0));
			//Player.transform.position = SpawnPoint.transform.position;
			//Player.transform.position = SpawnPoint2.transform.position;
		}
	}
	
	public void Hit()
	{
		/*
		if (Input.GetKeyDown (KeyCode.Z))
		{
			Attack = true;
			print ("Strike!");
		}
*/
		if (Input.GetButton("Fire1"))
		{
			Attack = true;
			print ("Strike!");
		}
	}
	
	void IncreaseHealth()
	{
		if(SpawnWait <= 0)
		{
			CurrentHealth += 10f;
			float CalcHealth = CurrentHealth / MaxHealth;
			SetHealthBar (CalcHealth);
			InvokeRepeating ("IncreaseHealth", 0.1f, 0.1f);
			//Player.transform.position = SpawnPoint.transform.position;
			//Player.transform.position = SpawnPoint2.transform.position;
		}
	}
	
	
	IEnumerator SpawnTimer()
	{
		yield return new WaitForSeconds(SpawnTimerWait);
		//SpawnWait = 100f;
	}
	
	IEnumerator Dead()
	{
		yield return new WaitForSeconds(SpawnWait);
		//Player.transform.position = SpawnPoint.transform.position;
		//Player.transform.position = SpawnPoint2.transform.position;
	}
}
