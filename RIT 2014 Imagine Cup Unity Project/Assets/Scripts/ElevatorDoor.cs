using UnityEngine;
using System.Collections;

public class ElevatorDoor : MonoBehaviour {
	public bool closed = true;
	Vector3 closedPosition;
	public Vector3 direction = Vector3.left;
	public float distance;
	public float duration = 4;

	bool opening, closing;

	// Use this for initialization
	void Start () {
		closedPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (opening) {
			transform.position += direction * distance / 4 * Time.deltaTime;
			if (Vector3.Distance(transform.position, closedPosition) > distance) {
				opening = false;
				closed = false;
			}
		} else if (closing) {
			transform.position -= direction * distance / 4 * Time.deltaTime;
			if ((transform.position - closedPosition).magnitude < 0) {
				closing = false;
				closed = true;
			}
		}
	}

	public void open()	{
		if(closed)
			opening = true;
	}

	public void close(){
		if(!closed)
			closing = true;
	}
}
