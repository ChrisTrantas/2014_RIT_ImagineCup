using UnityEngine;
using System.Collections;

public class ShowDialogue : MonoBehaviour {

	GUIContent gUIContent = new GUIContent();
	public GUIStyle gUIStyle = new GUIStyle();
	public bool introDialogueOn;
	public bool enterLvlDialogueOn;
	public bool elevatorPanelDialogueOn;
	public bool lockedRoomDialogueOn;
	public bool endDialogueOn;

	// Use this for initialization
	void Start () {
		introDialogueOn = true;
	}
	
	// Update is called once per frame
	void Update () {
		//show dialogue
		if(introDialogueOn == true)
		{
			gUIContent.text = "Noon, that means lunch time. I guess I should head out.";
		}
		if(enterLvlDialogueOn == true)
		{
			gUIContent.text = "What's going on? There's no floor like this in the building. It's too dark to see the buttons.";
		}
		if(elevatorPanelDialogueOn == true)
		{
			gUIContent.text = "What!? There's some panel here covering up the buttons! That wasn't here before! I bet I " +
				"could get it off with a screwdriver. There might be a maintenance room around here somewhere.";
		}
		if(lockedRoomDialogueOn == true)
		{
			//might move to another script
			gUIContent.text = "This door is locked. It might be the maintenance room. I'll need to find the key.";;
		}
		if(endDialogueOn == true)
		{
			gUIContent.text = "I wonder if that was all just a bizarre nightmare...";
		}

		//stop showing dialogue
		if(introDialogueOn == true && Input.GetKeyDown (KeyCode.E))
		{
			introDialogueOn = false;
		}
		if(enterLvlDialogueOn == true && Input.GetKeyDown (KeyCode.E))
		{
			enterLvlDialogueOn = false;
		}
		if(elevatorPanelDialogueOn == true && Input.GetKeyDown (KeyCode.E))
		{
			elevatorPanelDialogueOn = false;
		}
		if(lockedRoomDialogueOn == true && Input.GetKeyDown (KeyCode.E))
		{
			lockedRoomDialogueOn = false;
		}
		if(endDialogueOn == true && Input.GetKeyDown (KeyCode.E))
		{
			endDialogueOn = false;
		}
	}

	void OnGUI() {
		if (introDialogueOn == true || enterLvlDialogueOn == true || elevatorPanelDialogueOn == true || lockedRoomDialogueOn == true || endDialogueOn == true) {
						GUI.Box (new Rect (Screen.width / 2, 
		                   Screen.height / 2 - gUIStyle.CalcHeight (gUIContent, 120), 
		                   120, gUIStyle.CalcHeight (gUIContent, 120)), 
		         gUIContent, 
		         gUIStyle);
				}
	}
}
