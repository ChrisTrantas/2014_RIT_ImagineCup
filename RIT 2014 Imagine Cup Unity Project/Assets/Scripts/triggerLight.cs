using UnityEngine;
using System.Collections;

public class triggerLight : MonoBehaviour {
	public Light[] lights;
	bool triggered = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (triggered) {
			foreach(Light light in lights)
			{
				light.enabled = false;
			}
		}
	}

	void OnTriggerEnter(Collider other) {
		foreach(Light light in lights)
		{
			light.intensity = (Random.Range(0.5));
		}
	}
}
