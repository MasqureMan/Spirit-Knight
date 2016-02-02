using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

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
	public GameObject Enemy;
	public GameObject SpawnPointEnemy;

	public PlayerHealth _playerHealth;
	public EnemyAttackAnimation _enemyAttackAnimation;
	public EnemyMovement _enemyMovement;
	public EnemyBattleMechanics _enemybattleMechanics;
	public SpiritBar _spiritBar;
	
	void Awake () 
	{
		_playerHealth.GetComponent<PlayerHealth>();
		_enemyAttackAnimation.GetComponent<EnemyAttackAnimation>();
		_enemyMovement = GetComponent<EnemyMovement>();
		_enemybattleMechanics = GetComponent<EnemyBattleMechanics>();
		_spiritBar = GetComponent<SpiritBar>();
		CurrentHealth = MaxHealth;
		IsDead = false;
		CanSpecial = false;
		
		Source = GetComponent<AudioSource>();
	}
	
	void OnTriggerEnter(Collider other)
	{
		if (other.name == "PlayerSword")
		{
			InvokeRepeating ("DecreaseHealth", 0.1f, 0.2f);
			_enemybattleMechanics.InstantiateImpact();
			_spiritBar.InvokeRepeating ("IncreaseSpirit", 0.2f, 1f);
		}
		
		if (other.name == "PlayerShield")
		{
			_enemybattleMechanics._DefendAnimation.GetComponent<DefendAnimation>();
		}
	}
	
	void OnTriggerExit(Collider other)
	{
		if (other.name == "PlayerSword")
		{
			CancelInvoke ("DecreaseHealth");
			//_spiritBar.CancelInvoke ("IncreaseSpirit");
		}
	}
	
	void Update () 
	{
		//Attacking();
		if (CurrentHealth <= 0 && !IsDead)
		{
			Dead();
			//transform.rotation = Quaternion.Lerp(from.rotation, to.rotation, Time.deltaTime * speed);
			IsDead = true;
			CanSpecial = false;
			CancelInvoke ("DecreaseHealth");
			_enemybattleMechanics.CancelInvoke("IncreaseSpecial");
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
		_enemyMovement.CanMove = false;
		_enemybattleMechanics.CanAttack = false;
		_enemybattleMechanics.CanDefend = false;
		_enemybattleMechanics.CanDark = false;
		//transform.rotation = Quaternion.Lerp(from.rotation, to.rotation, Time.deltaTime * speed);
		//Destroy (Player);
	}
	
	public void Revive()
	{
		EnableColliders ();
		//GameObject PlayerAlive = (GameObject)Instantiate(Player);
		//transform.rotation = Quaternion.Lerp(fromTwo.rotation, toTwo.rotation, Time.deltaTime * speed);
		Enemy.transform.position = SpawnPointEnemy.transform.position;
		//_playerHealth.Player.transform.position = _playerHealth.SpawnPoint.transform.position;
		CurrentHealth = MaxHealth;
		IsDead = false;
		_enemyMovement.CanMove = true;
		_enemybattleMechanics.CanAttack = true;
		_enemybattleMechanics.CanDefend = true;
		_enemybattleMechanics.CanDark = true;
		
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
