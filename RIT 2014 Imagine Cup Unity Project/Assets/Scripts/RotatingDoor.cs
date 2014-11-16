using UnityEngine;
using System.Collections;

public class RotatingDoor : MonoBehaviour {
	public bool closed = true;
	/// <summary>
	/// How far, in degrees, the door spins open.
	/// </summary>
	public float angleDistance;
	public float duration = 4;

	bool opening, closing;
	public GameObject pivot;
	float currentAngle;

	// Use this for initialization
	void Start () {
		currentAngle = transform.rotation.eulerAngles.y;
	}
	
	// Update is called once per frame
	void Update () {
		print(transform.rotation.eulerAngles.y);
		if (opening) {
			transform.RotateAround (pivot.transform.position, Vector3.up, angleDistance / duration * Time.deltaTime);
			if(transform.rotation.eulerAngles.y > angleDistance + currentAngle){
				opening = false;
			}
		} else if (closing) {
			transform.RotateAround (pivot.transform.position, Vector3.up, -angleDistance / duration * Time.deltaTime);
			if (transform.rotation.eulerAngles.y < currentAngle) {
				closing = false;
			}
		}
	}
	
	public void open()	{
		if (closed) {
			opening = true;
			closed = false;
		}
	}
	
	public void close(){
		if (!closed) {
			closed = true;
			closing = true;
		}
	}	
}