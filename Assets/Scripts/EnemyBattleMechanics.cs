using UnityEngine;
using System.Collections;

public class EnemyBattleMechanics : MonoBehaviour {

	public int DarkCool = 50;
	
	public bool CanAttack;
	public bool CanDefend;
	public bool CanDark;
	
	public GameObject ImpactPoint;
	public GameObject DarkOrb;
	public GameObject DarkSword;
	public GameObject DarkSpecial;
	
	public EnemyAttackAnimation _EnemyAttackAnimation;
	public DefendAnimation _DefendAnimation;
	public EnemyHealth _enemyHealth;
	public SpiritBar _spiritBar;

	public AudioSource Source;
	public AudioClip SpecialClip;
	
	void Awake () 
	{
		_enemyHealth = GetComponent<EnemyHealth>();
		_spiritBar = GetComponent<SpiritBar>();
		//_arenaManager.GetComponent<ArenaManager>();
		_EnemyAttackAnimation.GetComponent<EnemyAttackAnimation>();
		_DefendAnimation.GetComponent<DefendAnimation>();
	}
	
	public void InstantiateImpact()
	{
		GameObject CurrentPoint = (GameObject)Instantiate(ImpactPoint);
		CurrentPoint.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);	
		Destroy (CurrentPoint, 0.2f);
	}
	
	public void InstantiateDark()
	{
		GameObject CurrentPoint2 = (GameObject)Instantiate(DarkOrb);
		CurrentPoint2.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
		Destroy (CurrentPoint2, 1.0f);
	}

	public void InstantiateDarkSword()
	{
		if (CanAttack == true)
		{
			float positiony = 2.5f;
			GameObject CurrentPoint3 = (GameObject)Instantiate(DarkSword);
			CurrentPoint3.transform.position = new Vector3(transform.position.x + 1, transform.position.y + positiony, transform.position.z);
			Destroy (CurrentPoint3, 0.3f);
		}
	}

	public void InstantiateDarkSpecial()
	{
		GameObject CurrentPoint3 = (GameObject)Instantiate(DarkSpecial);
		CurrentPoint3.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
		Destroy (CurrentPoint3, 2.0f);
	}
	
	void Update () 
	{
		CoolDark();
		
		if (Input.GetKeyDown("joystick 2 button 0") && CanAttack == true)
		{
			Attacking ();
		}
		
		if (Input.GetKeyDown("joystick 2 button 2") && CanDefend == true)
		{
			Defending ();
		}
		
		if(Input.GetKeyDown("joystick 2 button 1"))
		{
			if(CanDark == false)
			{
			}
			else
			{
				InstantiateDark();
				CanDark = false;
				CoolDownDark();
			}
		}
		
		if(Input.GetKeyDown ("joystick 2 button 3"))//&& CurrentBar >= MaxBar)
		{
			if(_spiritBar.CurrentSpirit >= _spiritBar.MaxSpirit && _enemyHealth.CanSpecial == true)
			{
				Source.clip = SpecialClip;
				Source.Play ();
				_spiritBar.CurrentSpirit = 0;
				_spiritBar.DecreaseSpirit();
				InstantiateDarkSpecial();
				if(_spiritBar.CurrentSpirit <= 0f)
				{
					_spiritBar.CancelInvoke("DecreaseSpirit");
				}	
				_enemyHealth.CanSpecial = false;
			}
		}
	}
	
	IEnumerator CoolDownDark()
	{
		yield return new WaitForSeconds(DarkCool);
	}
	
	void CoolDark()
	{
		if(CanDark == false)
		{
			DarkCool--;
		}
		
		if(DarkCool <= 0)
		{
			CanDark = true;
			DarkCool = 50;
		}
	}
	
	void Defending()
	{
		if(CanDefend == true)
		{
			_DefendAnimation.defend();
			_enemyHealth.CancelInvoke ("DecreaseHealth");
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
}
