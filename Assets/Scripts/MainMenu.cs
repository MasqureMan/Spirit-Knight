using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public Texture2D FadingTexture;
	public float FadeSpeed = 0.8f;

	private int DrawDepth = -1000;
	private float Alpha = 1.0f;
	private int FadeDir = -1;

	void OnGUI()
	{
		Alpha += FadeDir * FadeSpeed * Time.deltaTime;
		Alpha = Mathf.Clamp01(Alpha);

		GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, Alpha);
		GUI.depth = DrawDepth;
		GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), FadingTexture);
	}
	
	public float BeginFade(int Direction)
	{
		FadeDir = Direction;
		return(FadeSpeed);
	}

	void OnLevelLoaded()
	{
		BeginFade (-1);
	}
}
