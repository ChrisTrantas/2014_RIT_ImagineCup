using UnityEngine;
using System.Collections;

public class ElevatorDoor : MonoBehaviour {
	public bool closed = true;
	Vector3 closedPosition, openPosition;
	public Vector3 direction = Vector3.left;
	public float distance;
	public float duration = 4;
	float timer = 0;

	float currentDistance;
	bool opening, closing;

	// Use this for initialization
	void Start () {
		closedPosition = transform.localPosition;
		openPosition = direction * distance + closedPosition;
	}
	
	// Update is called once per frame
	void Update () {
		if (opening) {
			timer += Time.deltaTime;
			transform.localPosition = direction * distance / duration * timer + closedPosition;
			if (timer > duration) {
				opening = false;
			}
		} else if (closing) {
			print (timer);
			timer += Time.deltaTime;
			transform.localPosition = openPosition - direction * distance / duration * timer ;
			if (timer > duration) {
				closing = false;
				closed = true;
			}
		}
	}

	public void open()	{
		if (closed) {
			opening = true;
			closed = false;
			timer = 0;
		}
	}

	public void close(){
		if (!closed) {
			closed =true;
			closing = true;
			timer = 0;
		}
	}
}

