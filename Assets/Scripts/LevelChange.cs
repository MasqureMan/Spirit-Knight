using UnityEngine;
using System.Collections;

public class LevelChange : MonoBehaviour {

	public Texture Background;

	public float GuiPositionY;
	public float GuiPositionY1;
	
	public float GuiPositionX;
	public float GuiPositionX1;

	void Update()
	{
		if(Input.GetKeyDown("joystick 1 button 0"))
		{
			//float FadeTime = GameObject.Find ("Menu").GetComponent<MainMenu>().BeginFade(1);
			//yield return new WaitForSeconds(FadeTime);
			GUI.Button(new Rect(Screen.width * GuiPositionX, Screen.height * GuiPositionY, Screen.width * .2f , Screen.height * .1f), "");
			Application.LoadLevel("DemoScene");
		}
	}


	void OnGUI()
	{
		GUI.DrawTexture(new Rect(0,0,Screen.width,Screen.height),Background);
		
		if(GUI.Button(new Rect(Screen.width * GuiPositionX, Screen.height * GuiPositionY, Screen.width * .2f , Screen.height * .1f),"Start Game"))
		{
			//Application.LoadLevel("DemoScene");
		}
		/*
		if(GUI.Button(new Rect(Screen.width * GuiPositionX1, Screen.height * GuiPositionY1, Screen.width * .2f, Screen.height * .1f),"Leave"))
		{
			Application.Quit();
		}
*/
	}
}
