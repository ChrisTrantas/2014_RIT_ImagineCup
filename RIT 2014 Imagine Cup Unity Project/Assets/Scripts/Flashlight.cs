using UnityEngine;
using System.Collections;

public class Flashlight : MonoBehaviour {

	public Light spotLight;

	// Use this for initialization
	void Start () {
		spotLight.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown (KeyCode.F) == true){
			spotLight.enabled = !spotLight.enabled;
			Debug.Log("Flashlight toggles");
		}
	}
}