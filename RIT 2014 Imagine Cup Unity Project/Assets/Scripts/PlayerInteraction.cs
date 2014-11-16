using UnityEngine;
using System.Collections;

public class PlayerInteraction : MonoBehaviour {

	GUIContent gUIContent = new GUIContent();
	public GUIStyle gUIStyle = new GUIStyle();
	string currentLvl = "Intro";

	private Vector3 vec;

	// Use this for initialization
	void Start () {
		//audio.loop = false;

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


		if (Physics.Raycast (ray, out hit)) {
			//print ("I'm looking at " + hit.transform.name);
			gUIContent.text = "I'm looking at " + hit.transform.name;

			if(hit.transform.name == "Panel" && Input.GetKeyDown (KeyCode.E)) {
				print(hit);
				FadeOut fadeOut = hit.transform.GetComponentInChildren<FadeOut>();
				print (fadeOut);
				fadeOut.FadeToNextLevel();
			} 
			else if(hit.transform.name == "Flashlight" && Input.GetKeyDown (KeyCode.E) )	{
				GetComponent<PlayerInventory>().giveFlashlight();
				hit.transform.gameObject.SetActive(false);
			} 
			else if(hit.transform.name == "UsableDoor" && Input.GetKeyDown (KeyCode.E) )	{
				if(hit.transform.GetComponent<RotatingDoor>().closed) {
					hit.transform.GetComponent<RotatingDoor>().open();
				} 
				else {
					hit.transform.GetComponent<RotatingDoor>().close();
				}
			}
		}
	}

	void OnGUI() {
		GUI.Box (new Rect (Screen.width /2, 
		                   Screen.height /2 - gUIStyle.CalcHeight (gUIContent, 120), 
		                   120, gUIStyle.CalcHeight (gUIContent, 120)), 
		          gUIContent, 
		         gUIStyle);
	}

	void GoingDown() {
		//Check Mesh Colliders with Character Controller

		//Check Keypressed

		//If 'e' then close the door


			// Load the next scene
			if(currentLvl == "Intro") {
				currentLvl = "Start";

			} if(currentLvl == "Start") {
				currentLvl = "1st Level";			
			} else if(currentLvl == "1st Level") {
				currentLvl = "3rd Level";
			}
			// if load is done turn on light and open door

	}
}