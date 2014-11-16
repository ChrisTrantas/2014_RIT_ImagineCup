using UnityEngine;
using System.Collections;

public class PlayerInteraction : MonoBehaviour {

	GUIContent gUIContent = new GUIContent();
	public GUIStyle gUIStyle = new GUIStyle();
	string currentLvl = "Intro";

	private Vector3 vec;
	private PlayerInventory playerInventory;

	// Use this for initialization
	void Start () {
		//audio.loop = false;
		playerInventory = GetComponent<PlayerInventory> ();
	}
	
	// Update is called once per frame
	void Update () {
		print (currentLvl);
		Ray ray;
		RaycastHit hit;
		vec.x = (float)Screen.width / 2;
		vec.y = (float)Screen.height / 2;
		vec.z = 0;

		ray = Camera.main.ScreenPointToRay (vec);

		Debug.DrawRay (ray.origin, ray.direction * 10, Color.cyan);


		if (Physics.Raycast (ray, out hit) && Input.GetKeyDown (KeyCode.E)) {
			//print ("I'm looking at " + hit.transform.name);
			gUIContent.text = "I'm looking at " + hit.transform.name;

			switch(hit.transform.name) {
			case "Panel":
				print(hit);
				FadeOut fadeOut = hit.transform.GetComponentInChildren<FadeOut>();
				print (fadeOut);
				fadeOut.FadeToNextLevel();
				break;

			case "Flashlight":
				playerInventory.giveFlashlight();
				hit.transform.gameObject.SetActive(false);
				break;

			case "MaintenanceKey":
				playerInventory.giveKey("MaintenanceKey");
				hit.transform.gameObject.SetActive(false);
				break;

			case "UsableDoor":
				RotatingDoor rotatingDoor = hit.transform.GetComponent<RotatingDoor>();

				if(rotatingDoor.closed) {
					rotatingDoor.open();
				} 
				else {
					rotatingDoor.close();
				}
				break;

			case "LockedDoor":
				RotatingDoor lockedDoor = hit.transform.GetComponent<RotatingDoor>();

				if (lockedDoor.closed) {
					foreach(string key in playerInventory.keys) {
						lockedDoor.unlock(key);
					}
					lockedDoor.open();
				} else {
					lockedDoor.close();
				}
				break;
			}
		}
	}

	/// <summary>
	/// Raises the GUI event.
	/// </summary>
	void OnGUI() {
		GUI.Box (new Rect (Screen.width /2, 
		                   Screen.height /2 - gUIStyle.CalcHeight (gUIContent, 120), 
		                   120, gUIStyle.CalcHeight (gUIContent, 120)), 
		          gUIContent, 
		         gUIStyle);
	}
}