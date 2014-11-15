using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerInventory : MonoBehaviour {
	/// <summary>
	/// Set true if the player has the flashlight.
	/// </summary>
	public bool hasFlashlight = false;
	/// <summary>
	/// Set true if the player has the screwdriver.
	/// </summary>
	public bool hasScrewdriver = false;
	/// <summary>
	/// List of the keys the player has.
	/// </summary>
	public List<string> keys; 
	public GameObject flashlight;
	public GameObject screwdriver;

	// Use this for initialization
	void Start () {
		Transform playerCameraTransform = transform.FindChild ("Main Camera");
		
		flashlight = (GameObject)Instantiate (flashlight);
		flashlight.transform.parent = playerCameraTransform.transform;
		flashlight.transform.localPosition = new Vector3 (0.3035695F, -0.1987281F, -0.1443494F);
		flashlight.transform.localRotation =  Quaternion.Euler(76.58533F, 248.2707F, 229.9082F);


		if (hasFlashlight)
			showFlashlight ();
		else
			hideFlashlight ();
	}
	
	// Update is called once per frame
	void Update () {

		//Debug: Press G to automatically give flashlight
		if (Input.GetKeyDown (KeyCode.G) == true) {
			giveFlashlight();
		}
	}

	void OnGUI() {
		GUIContent content = new GUIContent ("Instructor"
						+ "\nFlashlight: " + hasFlashlight
						+ "\nScrewdriver: " + hasScrewdriver);
		foreach (string key in keys)
						content.text += "\n" + key;
		GUIStyle style = new GUIStyle ();
		style.fixedWidth = 120;
		float height = style.CalcHeight (content, 120);
		GUI.Box (new Rect (10, 10, 120, height), content, style);
	}

	public void giveKey(string name){
		keys.Add (name);
	}

	public bool checkForKey(string name) {
		return keys.Contains (name);
	}

	public void giveFlashlight()
	{
		hasFlashlight = true;
		showFlashlight ();
	}

	void showFlashlight() {
		flashlight.SetActive(true);
	}

	void hideFlashlight (){
		flashlight.SetActive(false);
	}

	public void giveScrewdriver()
	{
		hasScrewdriver = true;
		showScrewdriver ();
	}
	
	void showScrewdriver() {
		screwdriver.SetActive(true);
	}
	
	void hideScrewdriver (){
		screwdriver.SetActive(false);
	}
}