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
				for(int i = 0; i < 60; i++)
				{
					if(i%2 > 0)
					{
					light.intensity = 0;
			
					}
					else
					{
						light.intensity = 100;
					
					}

				}
			}
		}
	}

	void OnTriggerEnter(Collider other) {
		triggered = true;
	}

}