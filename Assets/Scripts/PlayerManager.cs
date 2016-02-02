using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerManager : MonoBehaviour 
{
	//public float MaxHealth = 100f;
	//public float CurrentHealth = 0f;
	//public float MaxBar = 10f;
	//public float CurrentBar = 0f;
	//public Transform from;
	//public Transform to;
	//public Transform from2;
	//public Transform to2;
	//public float speed = 0.1F;
	//public float PlayerSpeed = 5f;
	public float SpawnWait = 100f;
	public float SpawnTimerWait = 100f;
	public float RestartTimer = 100f;
	public float LightSpeed = 15f;
	public float CoolLight = 1f;
	//public GameObject healthbar;
	//public GameObject SpecialBar;
	//public bool CanAttack = false;
	//public bool CanDefend = false;
	//public bool CanLight = false;
	//public Transform Player;
	//public GameObject SpawnPoint;
	//public GameObject SpawnPoint2;
	public float CoolDown = 100f;
	private bool OnCD;
	//private bool CanMove = false;
	//public AttackAnimation _AttackAnimation;
	//public DefendAnimation _DefendAnimation;
	//public SpawnImpact _SpawnImpact;
	public EnemyAI _EnemyAI;
	//public GameObject ImpactPoint;
	//public GameObject LightOrb;
	//public GameObject LightSword;
	//public AudioSource Source;
	//public ParticleSystem Particles;
	//public ParticleCollisionEvent[] collisionEvents;
	//public AudioClip PowerUpClip;
	public RoundsWin _Rounds;

	void Awake () 
	{
		//_SpawnImpact.GetComponent<SpawnImpact>();
		//_SpawnImpact.InstantiateImpact();
		//Source = GetComponent<AudioSource>();
		//CurrentHealth = MaxHealth;
		//CurrentBar = 0f;
		//MaxBar = 10f;
		//Particles = GetComponent<ParticleSystem>();
		//collisionEvents = new ParticleCollisionEvent[16];
	    //List<AudioSource> = new List<AudioSource>();
		//InvokeRepeating("DecreaseHealth", 1f, 2f);
	}
	/*
	void OnTriggerEnter(Collider other)
	{
		if (other.name == "EnemySword")//&& Attack == true)
		{
			//_AttackAnimation.GetComponent<AttackAnimation>();
			//_Rounds = GetComponent<RoundsWin>();
			//InstantiateImpact();
			//InvokeRepeating ("DecreaseHealth", 0.2f, 1.5f);
			//InvokeRepeating ("IncreaseSpecial", 0f, 2f);
		}

		if (other.name == "EnemyShield")
		{
			//_DefendAnimation.GetComponent<DefendAnimation>();
		}
	}
    
	void OnTriggerExit(Collider other)
	{
		if (other.name == "EnemySword")
		{
			//CancelInvoke ("DecreaseHealth");
			//CancelInvoke ("IncreaseSpecial");
		}
	}

	void OnParticleCollision(GameObject other)
	{

	}
    */
	// Update is called once per frame
	void FixedUpdate () 
	{
		CoolDown -= 0.1f;
		Timer();
		//HandleMovement();
		/*
		if (Input.GetKeyDown("joystick button 0") && CanAttack == true)
		{
			Attacking ();
		}

		if (Input.GetKeyDown("joystick button 2") && CanDefend == true)
		{
			Defending ();
		}

		if(Input.GetKeyDown("joystick button 1"))
		{
			if(CoolLight < 3 || CanLight == false)
			{
			}
			else
			{
	          InstantiateLight();
			}
			//Attack = false;
			//defend = false;
		}

		if(Input.GetKeyDown ("joystick button 3") && CurrentBar >= MaxBar)
		{
			print ("Special!!!");
			CurrentBar = 0;
		}
		
		if (CurrentHealth <= 0)
		{
			CancelInvoke("DecreaseHealth");
			CancelInvoke ("IncreaseSpecial");
			transform.rotation = Quaternion.Lerp(from.rotation, to.rotation, Time.deltaTime * speed);
			//Player.transform.position = SpawnPoint.transform.position;
			//transform.Translate (new Vector3(0, -1, 0) * Time.deltaTime);
			SpawnWait -= 1f;
			SpawnTimerWait -= 1f;
			Revive();
			SpawnTimer ();
			IncreaseHealth();
			DecreaseSpecial();
			Dead ();
			CanAttack = false;
			CanDefend = false;
			CanLight = false;
			CoolDown = 12f;
			DisableColliders();
			_Rounds.EnemyRounds++;
		}
		if (_Rounds.EnemyRounds == 1)
		{
			_Rounds.EnemyRoundWin.transform.position = new Vector3(303, -53, 3);
		}
		if (_Rounds.EnemyRounds == 2)
		{
			_Rounds.EnemyRoundWinTwo.transform.position = new Vector3(350, -53, 3);
			_Rounds.EnemyVictory.transform.position = new Vector3(12, -48, 25);
			CanMove = false;
			RestartTimer -= 1f;
			Restarter();
		}

		if(CurrentBar == MaxBar)
		{
			//SpiritBarFull();
			CancelInvoke ("IncreaseSpecial");
		}
		if(CurrentBar <= MaxBar)
		{
			CancelInvoke ("DecreaseSpecial");
		}

		if (CurrentHealth > 0)
		{
			EnableColliders();
		}
		if (CurrentHealth == MaxHealth)
		{
			CancelInvoke("IncreaseHealth");
		}

		if(RestartTimer <= 0)
		{
			CurrentHealth += 10f;
			CurrentBar -= 10f;
			InvokeRepeating ("DecreaseSpecial", 0.1f, 0.1f);
			InvokeRepeating ("IncreaseHealth", 0.1f, 0.1f);
			RestartTimer = 100f;
		}
		if(CoolLight <= 0)
		{
			CancelInvoke ("LightDecrease");
			InvokeRepeating ("LightIncrease", 1f, 1f);
		}
		if(CoolLight >= 3)
		{
			CancelInvoke ("LightIncrease");
		}
		if(SpawnTimerWait <= 0)
		{
			SpawnWait = 100f;
			SpawnTimerWait = 100f;
		}
		*/
	}

	/*
	public void InstantiateImpact()
	{
		GameObject CurrentPoint = (GameObject)Instantiate(ImpactPoint);
		CurrentPoint.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);

		Destroy (CurrentPoint, 0.2f);
	}

	public void InstantiateLight()
	{
		GameObject CurrentPoint2 = (GameObject)Instantiate(LightOrb);
		CurrentPoint2.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
		Destroy (CurrentPoint2, 1.0f);
		InvokeRepeating ("LightDecrease", 0.5f, 0.1f);
	}

	public void InstantiateSword()
	{
	    if (CanAttack == true)
		{
			float positiony = 2.5f;
			GameObject CurrentPoint3 = (GameObject)Instantiate(LightSword);
			CurrentPoint3.transform.position = new Vector3(transform.position.x + 1, transform.position.y + positiony, transform.position.z);
			Destroy (CurrentPoint3, 0.3f);
		}
	}
	
	private void HandleMovement()
	{
		
		float translation = PlayerSpeed * Time.deltaTime;
		//float translation2 = jumpSpeed * Time.deltaTime;
		if (CanMove == true)
		{
			transform.Translate(new Vector3(Input.GetAxis("Horizontal") * translation, 0, Input.GetAxis("Vertical") * translation));

		}
		else if (CanMove == false)
		{

		}
		//transform.Translate(new Vector3(Input.GetAxis ("Jump") * translation2));
	}
	void SpiritBarFull()
	{
		Source.clip = PowerUpClip;
		Source.Play ();
	}
	
	void DecreaseHealth()
	{
		CurrentHealth -= 2f;
		float CalcHealth = CurrentHealth / MaxHealth;
		SetHealthBar (CalcHealth);
	}

	void DecreaseSpecial()
	{
		if(SpawnWait <= 0)
		{
			CurrentSpecial -= 10f;
			float CalcSpecial = CurrentBar / MaxBar;
			SetSpecialBar (CalcSpecial);
			InvokeRepeating ("DecreaseSpecial", 0.1f, 0.1f);
		}
	}

	void IncreaseSpecial()
	{
		CurrentBar += 2f;
		float CalcSpecial = CurrentBar / MaxBar;
		SetSpecialBar (CalcSpecial);
	}

	public void SetHealthBar(float MyHealth)
	{
		healthbar.transform.localScale = new Vector3(MyHealth, healthbar.transform.localScale.y, healthbar.transform.localScale.z);
	}
    */
	//public void SetSpecialBar(float MySpecial)
	//{
	//	SpecialBar.transform.localScale = new Vector3(MySpecial, SpecialBar.transform.localScale.y, SpecialBar.transform.localScale.z);
	//}

	public void Revive()
	{
		if (SpawnWait <= 0)
		{
			//Enemy.transform.Rotate(new Vector3(0, 0, 0));
			//transform.rotation = Quaternion.Lerp(from2.rotation, to2.rotation, Time.deltaTime * speed);
			//Player.transform.position = SpawnPoint.transform.position;
			//Player.transform.position = SpawnPoint2.transform.position;
		}
	}

	void IncreaseHealth()
	{
		if(SpawnWait <= 0)
		{
			//CurrentHealth += 10f;
			//float CalcHealth = CurrentHealth / MaxHealth;
			//SetHealthBar (CalcHealth);
			//CanMove = true;
			//InvokeRepeating ("IncreaseHealth", 0.1f, 0.1f);
			//Player.transform.position = SpawnPoint.transform.position;
			//Player.transform.position = SpawnPoint2.transform.position;
		}
	}

	IEnumerator SpawnTimer()
	{
		yield return new WaitForSeconds(SpawnTimerWait);
		//SpawnWait = 100f;
	}

	IEnumerator Restart()
	{
		yield return new WaitForSeconds(RestartTimer);
	}

	public void Restarter()
	{
		if (RestartTimer <= 0)
		{
			//CanMove = true;
			//_Rounds.PlayerRounds = 0;
			//_Rounds.EnemyRounds = 0;
			 //Player.transform.position = SpawnPoint.transform.position;
			 //Player.transform.position = SpawnPoint2.transform.position;
			//_Rounds.EnemyRoundOne.transform.position = new Vector3(36, 15, -18);
			//_Rounds.EnemyRoundTwo.transform.position = new Vector3(34, 15, -18); 
			//_Rounds.EnemyVictory.transform.position = new Vector3(12, -39, 25);
		}
	}

	/*
	void Defending()
	{
		if(CanDefend == true)
		{
			_DefendAnimation.defend ();
			CancelInvoke ("DecreaseHealth");
		}
	}

	void Attacking()
	{
		if(CanAttack == true)
		{
			_AttackAnimation.attack();
			InstantiateSword();
		}
	}
	*/
	private void Timer()
	{
		if (CoolDown <= 0f)
		{
			CoolDown -= 0f;
			//CancelInvoke("CoolDown");
			//CanAttack = true;
			//CanDefend = true;
			//CanLight = true;
			//CanMove = true;
		}
		else if (CoolDown >= 1f)
		{
			//CanAttack = false;
			//CanDefend = false;
			//CanLight = false;
			//CanMove = false;
		}
	}

	public void LightDecrease()
	{
		CoolLight -= 0.1f;
	}

	public void LightIncrease()
	{
		CoolLight += 0.1f;
	}

	IEnumerator Dead()
	{
		yield return new WaitForSeconds(SpawnWait);
		//Player.transform.position = SpawnPoint.transform.position;
		//Player.transform.position = SpawnPoint2.transform.position;
	}
}
