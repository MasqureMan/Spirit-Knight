using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

	public float MaxHealth = 10f;
	public float CurrentHealth = 0f;
	public float speed = 5.0f;

	//public Transform from;
	//public Transform to;

	public bool IsDead;
	public bool CanSpecial;

	public AudioSource Source;
	public AudioClip PowerUpClip;

	public GameObject healthbar;
	public GameObject Player;
	public GameObject SpawnPoint;

	public PlayerMovement _playerMovement;
	public BattleMechanics _battleMechanics;
	public SpiritBar _spiritBar;
	public EnemyHealth _enemyHealth;
	
	void Awake () 
	{
		_playerMovement = GetComponent<PlayerMovement>();
		_enemyHealth.GetComponent<EnemyHealth>();
		_battleMechanics = GetComponent<BattleMechanics>();
		_spiritBar = GetComponent<SpiritBar>();
		CurrentHealth = MaxHealth;
		IsDead = false;
		CanSpecial = false;

		Source = GetComponent<AudioSource>();
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.name == "EnemySword")
		{
			InvokeRepeating ("DecreaseHealth", 0.2f, 1f);
			_battleMechanics.InstantiateImpact();
			_spiritBar.InvokeRepeating ("IncreaseSpirit", 0.2f, 1f);
		}
		
		if (other.name == "EnemyShield")
		{
			_battleMechanics._DefendAnimation.GetComponent<DefendAnimation>();
		}
	}
	
	void OnTriggerExit(Collider other)
	{
		if (other.name == "EnemySword")
		{
			CancelInvoke ("DecreaseHealth");
			_spiritBar.CancelInvoke ("IncreaseSpirit");
		}
	}

	void Update () 
	{
		if (CurrentHealth <= 0 && !IsDead)
		{
			Dead();
			//transform.rotation = Quaternion.Lerp(from.rotation, to.rotation, Time.deltaTime * speed);
			IsDead = true;
			CanSpecial = false;
			CancelInvoke ("DecreaseHealth");
			_battleMechanics.CancelInvoke("IncreaseSpecial");
		}
		else if(CurrentHealth == MaxHealth)
		{
			CancelInvoke("IncreaseHealth");
		}
		else if(_spiritBar.CurrentSpirit >= _spiritBar.MaxSpirit)
		{
			SpiritBarFull();
			_spiritBar.CancelInvoke("IncreaseSpirit");
		}
	}

	void SpiritBarFull()
	{
		CanSpecial = true;
		Source.clip = PowerUpClip;
		Source.Play ();
	}
	
	void IncreaseHealth()
	{
		CurrentHealth += 0.1f;
		float CalcHealth = CurrentHealth / MaxHealth;
		SetHealthBar (CalcHealth);
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

	void Dead()
	{
		DisableColliders();
		_playerMovement.CanMove = false;
		_battleMechanics.CanAttack = false;
		_battleMechanics.CanDefend = false;
		_battleMechanics.CanLight = false;
	  	//transform.rotation = Quaternion.Lerp(from.rotation, to.rotation, Time.deltaTime * speed);
	  	//Destroy (Player);
	}

	public void Revive()
	{
		EnableColliders ();
		//GameObject PlayerAlive = (GameObject)Instantiate(Player);
		//transform.rotation = Quaternion.Lerp(fromTwo.rotation, toTwo.rotation, Time.deltaTime * speed);
		Player.transform.position = SpawnPoint.transform.position;
		//_enemyHealth.Enemy.transform.position = _enemyHealth.SpawnPointEnemy.transform.position;
		CurrentHealth = MaxHealth;
		IsDead = false;
		_playerMovement.CanMove = true;
		_battleMechanics.CanAttack = true;
		_battleMechanics.CanDefend = true;
		_battleMechanics.CanLight = true;

		CurrentHealth += 0f;
		float CalcHealth = CurrentHealth / MaxHealth;
		SetHealthBar (CalcHealth);
		InvokeRepeating ("IncreaseHealth", 1f, 0.1f);

		if(CurrentHealth >= 10f)
		{
			CancelInvoke ("IncreaseHealth");
		}

		_spiritBar.CurrentSpirit -= 0f;
		_spiritBar.InvokeRepeating("DecreaseSpirit", 1f, 0.1f);

		if(_spiritBar.CurrentSpirit <= 0f)
		{
			_spiritBar.CancelInvoke("DecreaseSpirit");
		}

	}

	void EnableColliders()
	{
		foreach(Collider c2 in GetComponentsInChildren<Collider>())
		{
			c2.enabled = true;
		}
	}
	
	void DisableColliders()
	{
		foreach(Collider c in GetComponentsInChildren<Collider>())
		{
			c.enabled = false;
		}
	}
}
