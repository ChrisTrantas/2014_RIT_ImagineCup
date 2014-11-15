using UnityEngine;
using System.Collections;

public class TriggerLight : MonoBehaviour {
	public Light[] lights;
	bool triggered = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (triggered) {
			foreach(Light light in lights) {
				if(light.intensity > 0){
					light.intensity -= light.intensity/2* Time.deltaTime;
				}
			}
		}
	}

	void OnTriggerEnter(Collider other) {
		triggered = true;
	}
}