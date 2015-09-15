using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TurnController : MonoBehaviour 
{	
	public GameObject currentPlayerText;
	public GameObject elapsedTurnTimeText;

	private int currentPlayer;
	private float elapsedTurnTime;

	void Awake()
	{
        currentPlayerText = GameObject.FindGameObjectWithTag("currentTurn").gameObject;
		elapsedTurnTimeText = GameObject.FindGameObjectWithTag("elapsedTurnTime").gameObject;
	}

	void Start()
	{
		currentPlayer = 0;
		elapsedTurnTime = 0f;
		_setCurrentPlayerText();
	}

	void Update()
	{
		elapsedTurnTime += Time.deltaTime;
	}


	void FixedUpdate()
	{
		string elapsedTurnTimeString = transformTime(elapsedTurnTime);

		elapsedTurnTimeText.GetComponent<Text>().text = "Turn Time: " + elapsedTurnTimeString;

	}

	public int getCurrentPlayer()
	{
		return currentPlayer;
	}

	
	public int changeCurrentPlayer()
	{
		if (currentPlayer == 0) 
		{
			currentPlayer = 1;
		}
		else 
		{
			currentPlayer = 0;
		}

		print(currentPlayer);
		_resetElapsedTrunTime();
		_setCurrentPlayerText();

		return currentPlayer;
	}

	void _resetElapsedTrunTime()
	{
		elapsedTurnTime = 0f;
	}

	void _setCurrentPlayerText()
	{
		Debug.Log (currentPlayerText);
		print("set " + currentPlayer);
		currentPlayerText.GetComponent<Text>().text = "Current Player: " + (currentPlayer + 1).ToString();
	}

	// todo: duplicated method.  this needs to be moved to a utility class
	string transformTime(float time) 
	{
		int minutes = Mathf.FloorToInt(time / 60F);
		int seconds = Mathf.FloorToInt(time - minutes * 60);
		string transformedTime = string.Format("{0:0}:{1:00}", minutes, seconds);
		
		return transformedTime;
	}
}
