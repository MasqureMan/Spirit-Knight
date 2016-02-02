using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {

	public float speed;
	public RectTransform HealthTransform;
	//public float jumpSpeed = 8.0F;
	private float cachedY;
	private float MinXValue;
	private float MaxXValue;
	private int CurrentHealth;


	//private int currentHealth
	//{
	//	get { return CurrentHealth; }
	//	set {
	//		CurrentHealth = value;
	//		HandleHealth();
	//	}
	//}

	public int MaxHealth;
	public Text HealthText;
	public float CoolDown = 100f;
	private bool OnCD;
	private bool CanMove = false;

	//public Image VisualHealth;

	// Use this for initialization
	void Start () {
		//cachedY = HealthTransform.position.y;
		//MaxXValue = HealthTransform.position.x;
		//MinXValue = HealthTransform.position.x - HealthTransform.rect.width;
		//CurrentHealth = MaxHealth;
		//OnCD = false;

	}

	// Update is called once per frame
	void Update () {
	    
		CoolDown -= 0.1f;
		Timer();
		HandleMovement();
	}

	private void HandleMovement()
	{

		float translation = speed * Time.deltaTime;
		//float translation2 = jumpSpeed * Time.deltaTime;
		if (CanMove == true)
		{
			//Timer ();
			transform.Translate(new Vector3(Input.GetAxis("Horizontal") * translation, 0, Input.GetAxis("Vertical") * translation));

			if (Input.GetKeyDown (KeyCode.Space))
			{
				transform.Translate(Vector3.left);
			}

		}
		else if (CanMove == false)
		{

		}
		//transform.Translate(new Vector3(Input.GetAxis ("Jump") * translation2));
	}

	private void Timer()
	{
		if (CoolDown <= 0f)
		{
			//CancelInvoke("CoolDown");
			CanMove = true;
		}
	}
}
	/*
	private void HandleHealth(){

		HealthText.text = "Health: " + CurrentHealth;

		float currentXValue = MapValues(CurrentHealth, 0, MaxHealth, MinXValue, MaxXValue);

		HealthTransform.position = new Vector3(currentXValue, cachedY);

		if(CurrentHealth > MaxHealth /2)
		{
			VisualHealth.color = new Color32((byte)MapValues(CurrentHealth, MaxHealth / 2, MaxHealth, 255, 0), 255, 0, 255);
		}
		else
		{
			VisualHealth.color = new Color32(255, (byte)MapValues(CurrentHealth, 0, MaxHealth / 2, 0, 255), 0, 255);
		}
	}

	IEnumerator CoolDownDmg()
	{
		OnCD = true;
		yield return new WaitForSeconds(CoolDown);
		OnCD = false;
	} 

	void OnTriggerStay(Collider other)
	{
		if (other.name == "Enemy" || other.name == "Player")
			//Debug.Log("Getting damaged");
			if (!OnCD && CurrentHealth > 0)
				{
				  StartCoroutine(CoolDownDmg());
				  currentHealth -= 1;
				}
		    if (CurrentHealth <= 0)
			print("DEAD!");
		else
		{

		}
	}

	private float MapValues(float x, float inMin, float inMax, float outMin, float outMax){

		return (x - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
	}
    
}
*/