using UnityEngine;
using System.Collections;

public class FadeOut : MonoBehaviour {
	public int fadeSpeed;
	bool inProcess;
	public string levelName;
	public GameObject playerController;

	// Use this for initialization
	void Start () {
		guiTexture.pixelInset = new Rect(-Screen.width/2, -Screen.height/2, Screen.width, Screen.height);
		guiTexture.color = Color.clear;
	}
	
	// Update is called once per frame
	void Update () {
		if(inProcess) {
			guiTexture.enabled = true;
			guiTexture.color = Color.Lerp(guiTexture.color, Color.black, fadeSpeed * Time.deltaTime);

			if(guiTexture.color.a >= .95f) {
				Application.LoadLevel (levelName);
				guiTexture.color = Color.clear;
			}
		}	
	}

	public void FadeToNextLevel() {
		inProcess = true;
	}
}