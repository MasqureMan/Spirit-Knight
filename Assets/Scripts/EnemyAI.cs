using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour 
{
	public float EnemySpeed = 5f;
	public float EnemyRotate = 3.0f;
	public float CoolDown = 100f;
	public float speed = 0.1F;
	public bool CanMove = false;
	public bool CanAttack = false;
	public bool CanDefend = false;
	public bool CanDark = false;
	public Transform TargetPlayer;
	public float EnemyMaxHealth = 10f;
	public float EnemyCurrentHealth = 0f;
	public float EnemyMaxSpecial = 10f;
	public float EnemyCurrentSpecial = 0f;
	public float CoolDark = 1f;
	public GameObject EnemySpecialBar;
	public Transform from;
	public Transform to;
	public Transform from2;
	public Transform to2;
	public Transform Enemy;
	public float SpawnWait = 100f;
	public float SpawnTimerWait = 100f;
	public float RestartTimer = 100f;
	public GameObject healthbar;
	public GameObject SpawnPoint;
	public GameObject SpawnPoint2;
	public GameObject ImpactPoint;
	public GameObject DarkOrb;
	public GameObject DarkSword;
	public EnemyAttackAnimation _EnemyAttackAnimation;
	public DefendAnimation _DefendAnimation;
	public SpawnImpact _SpawnImpactEnemy;
	public AudioSource Source;
	public AudioClip PowerUpClip;
	//public RoundsWin _Rounds;

	// Use this for initialization
	void Awake () 
	{
		Source = GetComponent<AudioSource>();
		EnemyCurrentHealth = EnemyMaxHealth;
		EnemyCurrentSpecial = 0f;
		EnemyMaxSpecial = 15f;
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.name == "PlayerSword")
		{
			InstantiateImpact();
			InvokeRepeating ("DecreaseHealth", 0.2f, 1.5f);
			InvokeRepeating ("IncreaseSpecial", 0f, 1f);
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.name == "PlayerSword")
		{
			CancelInvoke ("DecreaseHealth");
			CancelInvoke ("IncreaseSpecial");
		}
	}

	/*
	void OnParticleCollision(GameObject other)
	{
		InvokeRepeating("DecreaseHealth", 0f, 1f);
	}
*/
	// Update is called once per frame
	void FixedUpdate () 
	{
		//Quaternion rotation = Quaternion.LookRotation(Target.position - transform.position);
		CoolDown -= 0.1f;
		EnemyAttack ();
		Timer ();

		//if (Input.GetKeyDown("joystick button 0") && CanAttack == true)
		//{
			//Attack = true;
			//defend = false;
			Attacking ();
		//}
		
		if (Input.GetKeyDown("joystick button 2") && CanDefend == true)
		{
			//Attack = false;
			//defend = true;
			Defending ();
		}
		
		if(Input.GetKeyDown("joystick button 1"))
		{
			if(CoolDark < 3 || CanDark == false)
			{
			}
			else
			{
				InstantiateDark();
			}
			//Attack = false;
			//defend = false;
		}

		if (EnemyCurrentHealth <= 0)
		{
			CancelInvoke("DecreaseHealth");
			CancelInvoke ("IncreaseSpecial");
			transform.rotation = Quaternion.Lerp(from.rotation, to.rotation, Time.deltaTime * speed);
			//Player.transform.position = SpawnPoint.transform.position;
			//transform.Translate (new Vector3(0, -1, 0) * Time.deltaTime);
			SpawnWait -= 1f;
			SpawnTimerWait -= 1f;
			EnemySpeed = 0f;
			EnemyRotate = 1f;
			Revive();
			SpawnTimer ();
			IncreaseHealth();
			CoolDown = 12f;
			DisableColliders();
			Dead ();
		}
		if (EnemyCurrentHealth > 0)
		{
			EnableColliders();
		}
		if(EnemyCurrentSpecial >= EnemyMaxSpecial)
		{
			//SpiritBarFull();
			CancelInvoke ("IncreaseSpecial");
		}
		if(EnemyCurrentSpecial == EnemyMaxSpecial)
		{
			CancelInvoke ("DecreaseSpecial");
		}
		if (EnemyCurrentHealth == 10)
		{
			CancelInvoke("IncreaseHealth");
		}
		if(RestartTimer <= 0)
		{
			RestartTimer = 100f;
		}
		if(CoolDark <= 0)
		{
			CancelInvoke ("DarkDecrease");
			InvokeRepeating ("DarkIncrease", 1f, 1f);
		}
		if(SpawnTimerWait <=0)
		{
			EnemySpeed = 5f;
			EnemyRotate = 1f;
			SpawnWait = 100f;
			SpawnTimerWait = 100f;
		}
	}

	void SpiritBarFull()
	{
		Source.clip = PowerUpClip;
		Source.Play ();
	}

	void DecreaseHealth()
	{
		EnemyCurrentHealth -= 2f;
		float CalcHealth = EnemyCurrentHealth / EnemyMaxHealth;
		SetHealthBar (CalcHealth);
	}

	void DecreaseSpecial()
	{
		EnemyCurrentSpecial -= 2f;
		float CalcSpecial = EnemyCurrentSpecial / EnemyMaxSpecial;
		SetSpecialBar (CalcSpecial);
	}
	
	void IncreaseSpecial()
	{
		EnemyCurrentSpecial += 2f;
		float CalcSpecial = EnemyCurrentSpecial / EnemyMaxSpecial;
		SetSpecialBar (CalcSpecial);
	}
	
	public void SetHealthBar(float MyHealth)
	{
		healthbar.transform.localScale = new Vector3(MyHealth, healthbar.transform.localScale.y, healthbar.transform.localScale.z);
	}

	public void SetSpecialBar(float MySpecial)
	{
		EnemySpecialBar.transform.localScale = new Vector3(MySpecial, EnemySpecialBar.transform.localScale.y, EnemySpecialBar.transform.localScale.z);
	}

	IEnumerator Restart()
	{
		yield return new WaitForSeconds(RestartTimer);
	}
	
	public void Restarter()
	{
		if(RestartTimer <=0)
		{
			CanMove = true;
			//_Rounds.EnemyRounds = 0;
			Enemy.transform.position = SpawnPoint.transform.position;
			Enemy.transform.position = SpawnPoint2.transform.position;
			//_Rounds.PlayerRoundWin.transform.position = new Vector3(36, 15, -18); 
			//_Rounds.PlayerRoundWinTwo.transform.position = new Vector3(34, 15, -18);
			//_Rounds.PlayerVictory.transform.position = new Vector3(12, -39, 25);
		}
	}
	public void Revive()
	{
		if (SpawnWait <= 0)
		{
			transform.rotation = Quaternion.Lerp(from2.rotation, to2.rotation, Time.deltaTime * speed);
			Enemy.transform.position = SpawnPoint.transform.position;
			Enemy.transform.position = SpawnPoint2.transform.position;
		}
	}

	public void InstantiateImpact()
	{
		GameObject CurrentPoint = (GameObject)Instantiate(ImpactPoint);
		CurrentPoint.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
		Destroy (CurrentPoint, 0.2f);
	}

	public void InstantiateDark()
	{
		GameObject CurrentPoint2 = (GameObject)Instantiate (DarkOrb);
		CurrentPoint2.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
		Destroy (CurrentPoint2, 1.0f);
	}

	public void InstantiateDarkSword()
	{
		if(CanAttack == true)
		{
			float positiony = 2.5f;
			GameObject CurrentPoint3 = (GameObject)Instantiate (DarkSword);
			CurrentPoint3.transform.position = new Vector3(transform.position.x + 1, transform.position.y + positiony, transform.position.z);
			Destroy (CurrentPoint3, 0.2f);
		}
	}

	void IncreaseHealth()
	{
		if(SpawnWait <= 0)
		{
			EnemyCurrentHealth += 10f;
			float CalcHealth = EnemyCurrentHealth / EnemyMaxHealth;
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

	void EnemyAttack()
	{
		//float translation = EnemySpeed * Time.deltaTime;

		if(CanMove == true)
		{
			//transform.Translate(new Vector3(Input.GetAxis("Horizontal") * translation, 0, Input.GetAxis("Vertical") * translation));
		}
		else if (CanMove == false)
		{

		}
	}

	void EnableColliders()
	{
		foreach(Collider c4 in GetComponentsInChildren<Collider>())
		{
			c4.enabled = true;
		}
	}
	
	void DisableColliders()
	{
		foreach(Collider c3 in GetComponentsInChildren<Collider>())
		{
			c3.enabled = false;
		}
	}

	void Defending()
	{
		if(CanDefend == true)
		{
			_DefendAnimation.defend ();
		}
	}
	
	void Attacking()
	{
		if(CanAttack == true)
		{
			_EnemyAttackAnimation.Enemyattack();
			InstantiateDarkSword();
		}
	}

	private void Timer()
	{
		if (CoolDown <= 0f)
		{
			CanAttack = true;
			CanDefend = true;
			CanDark = true;
			CanMove = true;
		}
		else if (CoolDown >= 1f)
		{
			CanAttack = false;
			CanDefend = false;
			CanDark = false;
			CanMove = false;
		}
	}

	public void DarkDecrease()
	{
		CoolDark -= 0.1f;
	}
	
	public void DarkIncrease()
	{
		CoolDark += 0.1f;
	}
}
