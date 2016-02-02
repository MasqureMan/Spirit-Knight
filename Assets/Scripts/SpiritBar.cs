using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpiritBar : MonoBehaviour {

	public float MaxSpirit = 10f;
	public float CurrentSpirit = 0f;

	public GameObject SpiritsBar;
	
	void Awake () 
	{
		CurrentSpirit = 0f;
		MaxSpirit = 10f;
	}

	void Update () 
	{
	}

	public void IncreaseSpirit()
	{
		CurrentSpirit += 2f;
		float CalcSpirit = CurrentSpirit / MaxSpirit;
		SetSpiritBar (CalcSpirit);
	}

	public void DecreaseSpirit()
	{
		CurrentSpirit -= 0f;
		float CalcSpirit = CurrentSpirit / MaxSpirit;
		SetSpiritBar (CalcSpirit);
		InvokeRepeating ("DecreaseSpirit", 1f, 0.1f);
	}

	public void SetSpiritBar(float MySpirit)
	{
		SpiritsBar.transform.localScale = new Vector3(MySpirit, SpiritsBar.transform.localScale.y, SpiritsBar.transform.localScale.z);
	}
}
