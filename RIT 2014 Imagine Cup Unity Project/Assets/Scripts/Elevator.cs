using UnityEngine;
using System.Collections;

public class Elevator : MonoBehaviour {

	// Use this for initialization
	void Start () {
		//audio.loop = false;
	}
	
	// Update is called once per frame
	void Update () {
		Ray ray;
		RaycastHit hit;
		ray = Camera.main.ScreenPointToRay (Input.mousePosition);

		Debug.DrawRay (ray.origin, ray.direction * 10, Color.cyan);


		if (Physics.Raycast (ray, out hit)) {
			print ("I'm looking at " + hit.transform.name);
			if(hit.transform.name == "Panel")
			{
				GoingDown ();
			}
		}

	}

	void GoingDown(){
		//Check Mesh Colliders with Character Controller

		//Check Keypressed

		//If 'e' then close the door

		if(Input.GetKeyDown (KeyCode.E) == true ) 	
		{
						//Turn Off Directional Light

						// Play sound maybe?
						//audio.loop = true;
						// Load the next scene
						Application.LoadLevel ("1st Level");
						//Object.DontDestroyOnLoad (CharacterController);
						// if load is done turn on light and open door
		}
	
		}
}
