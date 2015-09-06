using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameLabelView : MonoBehaviour 
{
	public Text guiGameTime;
	public int textBoxPadding = 20;
	public int textBoxHeight = 20;
	public int textBoxWidth = 100;

	private float gameTime;
	private float alignLeft;
	private float alignCenter;
	private float alignRight;

	// Use this for initialization
	void Start () 
	{
	}
	
	// Update is called once per frame
	void Update () 
	{
//		gameTime += Time.deltaTime;
		alignLeft = textBoxPadding;
		alignCenter = (Screen.width / 2) + (textBoxPadding / 2);
		alignRight = Screen.width - (textBoxWidth + textBoxPadding);
	}




	void OnGUI() 
	{
		// the following methods have been extracted from OnGUI because they are being called
		//  from the GameController.OnGUI() method.
		// delegateOnGUI

	}

	// show players
	// update active player


	public void delegateOnGUI(float masterGameTime, float masterTurnTime)
	{
//		string time = transformTime(masterGameTime);
//		string turnTime = transformTime(masterTurnTime);
	

//		GUI.Label(new Rect(alignCenter, 5, textBoxWidth, textBoxHeight), "Game Time: " + time);
//		guiGameTime.text = "Game Time: " + time;
//		print ("Game Time: " + time);
	}


	public void refreshActivePlayer(int playerId)
	{
//		GUI.Label(new Rect(alignRight, (5 + textBoxHeight), textBoxWidth, (textBoxWidth * 2)), "Player " + playerId.ToString());
	}

	//////////////////////////////////////////////////////////////////
	/// Utlity Methods
	//////////////////////////////////////////////////////////////////

//	string transformTime(float time) 
//	{
//		int minutes = Mathf.FloorToInt(time / 60F);
//		int seconds = Mathf.FloorToInt(time - minutes * 60);
//		string transformedTime = string.Format("{0:0}:{1:00}", minutes, seconds);
//
//		return transformedTime;
//	}
}
