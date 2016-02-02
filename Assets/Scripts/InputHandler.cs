using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InputHandler : MonoBehaviour {

	private Camera Cam;
	public float zoomSpeed = 20f;
	public float minZoomFOV = 10f;

	public float Smooth = 1.5f;
	public float Zoom = 10f;
	public float Normal = 20f;

	private Transform PlayerOne;
	private Transform PlayerTwo;

	// Use this for initialization
	void Awake () 
	{
		PlayerOne = GameObject.FindGameObjectWithTag("Player").transform;
		PlayerTwo = GameObject.FindGameObjectWithTag("Enemy").transform;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Cam.fieldOfView > Camera.main.fieldOfView)
		{
			CamZoomOut();
		}
		else if(Cam.fieldOfView > Camera.main.fieldOfView)
		{
			CamZoomOut();
		}
	}

	void CamZoomOut()
	{
		Camera.main.fieldOfView = Mathf.Lerp (Camera.main.fieldOfView, Normal, Time.deltaTime * Smooth);
	}

	void CamZoomIn()
	{
		Cam.fieldOfView -= zoomSpeed/8;
		if (Cam.fieldOfView < minZoomFOV)
		{
			Cam.fieldOfView = minZoomFOV;
		}
	}
}
