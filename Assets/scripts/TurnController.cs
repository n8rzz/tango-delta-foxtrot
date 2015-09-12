using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TurnController : MonoBehaviour 
{	
	public Text currentPlayerText;

	private int currentPlayer;

	void Awake()
	{
		Debug.Log("turnController " + GetInstanceID());
	}

	void Start()
	{
		currentPlayer = 0;
		_setCurrentPlayerText();
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
		_setCurrentPlayerText();

		return currentPlayer;
	}

	//
	void _setCurrentPlayerText()
	{
		Debug.Log (currentPlayerText);
		print("set " + currentPlayer);
		currentPlayerText.text = "Current Player: " + (currentPlayer + 1).ToString();
	}
}
