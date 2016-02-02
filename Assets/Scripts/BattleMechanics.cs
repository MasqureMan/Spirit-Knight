using UnityEngine;
using System.Collections;

public class BattleMechanics : MonoBehaviour {

	public int LightCool = 50;

	public bool CanAttack;
	public bool CanDefend;
	public bool CanLight;

	public GameObject ImpactPoint;
	public GameObject LightOrb;
	public GameObject LightSword;
	public GameObject LightSpecial;

	public AudioSource Source;
	public AudioClip SpecialClip;

	public AttackAnimation _AttackAnimation;
	public DefendAnimation _DefendAnimation;
	public PlayerHealth _playerHealth;
	public SpiritBar _spiritBar;
	
	void Awake () 
	{
		Source = GetComponent<AudioSource>();
		_playerHealth = GetComponent<PlayerHealth>();
		_spiritBar = GetComponent<SpiritBar>();
		_AttackAnimation.GetComponent<AttackAnimation>();
		_DefendAnimation.GetComponent<DefendAnimation>();
	}

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

	public void InstantiateLightSpecial()
	{
		GameObject CurrentPoint3 = (GameObject)Instantiate(LightSpecial);
		CurrentPoint3.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
		Destroy (CurrentPoint3, 2.0f);
	}

	void Update () 
	{
		CoolLight();

		if (Input.GetKeyDown("joystick 1 button 0") && CanAttack == true)
		{
			Attacking ();
		}
		
		if (Input.GetKeyDown("joystick 1 button 2") && CanDefend == true)
		{
			Defending ();
		}
		
		if(Input.GetKeyDown("joystick 1 button 1"))
		{
			if(CanLight == false)
			{
			}
			else
			{
				InstantiateLight();
				CanLight = false;
				CoolDownLight();
			}
		}

		if(Input.GetKeyDown ("joystick 1 button 3"))//&& CurrentBar >= MaxBar)
		{
			if(_spiritBar.CurrentSpirit >= _spiritBar.MaxSpirit && _playerHealth.CanSpecial == true)
			{
				Source.clip = SpecialClip;
				Source.Play ();
				InstantiateLightSpecial();
				_spiritBar.CurrentSpirit = 0;
				_spiritBar.DecreaseSpirit();
				if(_spiritBar.CurrentSpirit <= 0f)
				{
					_spiritBar.CancelInvoke("DecreaseSpirit");
				}	
				_playerHealth.CanSpecial = false;
			}
		}
	}

	IEnumerator CoolDownLight()
	{
		yield return new WaitForSeconds(LightCool);
	}

	void CoolLight()
	{
		if(CanLight == false)
		{
			LightCool--;
		}

		if(LightCool <= 0)
		{
			CanLight = true;
			LightCool = 50;
		}
	}

	void Defending()
	{
		if(CanDefend == true)
		{
			_DefendAnimation.defend();
			_playerHealth.CancelInvoke ("DecreaseHealth");
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
}
