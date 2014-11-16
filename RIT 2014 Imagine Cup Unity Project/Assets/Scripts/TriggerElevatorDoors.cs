using UnityEngine;
using System.Collections;

public class TriggerElevatorDoors : MonoBehaviour {
	public GameObject[] elevatorDoors;
	public float delay;
	public bool openDoor;
	bool triggered = false;
	float timer = 0;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (triggered) {
			timer += Time.deltaTime;
			if(timer > delay){
				if(openDoor){
					foreach(GameObject elevatorDoor in elevatorDoors){
						elevatorDoor.GetComponent<ElevatorDoor>().open();
						triggered = false;
						timer = 0;
					}
				}
				else {
					foreach(GameObject elevatorDoor in elevatorDoors){
						elevatorDoor.GetComponent<ElevatorDoor>().close();
						triggered = false;
						timer = 0;
					}
				}
			}
		}
	}

	void OnTriggerEnter(Collider other) {
		triggered = true;
	}
}
