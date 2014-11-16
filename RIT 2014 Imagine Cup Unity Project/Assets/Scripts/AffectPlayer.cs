using UnityEngine;
using System.Collections;

public class AffectPlayer : MonoBehaviour {

	public Texture2D crosshair;
	Rect positionch;
	bool AlwaysOn = true;

	// Use this for initialization
	void Start ()
	{
		Screen.lockCursor = true;
	}
	
	// Update is called once per frame
	void Update ()
	{
		Screen.lockCursor = true;

	}

	void OnGUI()
	{
		if (AlwaysOn == true)
		{
			GUI.Box (new Rect (Screen.width / 2, Screen.height / 2, 2, 2), crosshair);
		}
	}
}
