using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TurnController : MonoBehaviour 
{	
	private int currentPlayer;


	void Start()
	{
		currentPlayer = 0;

	}

	public int getCurrentPlayer()
	{
		return currentPlayer;
	}


	public int changeCurrentPlayer()
	{
		if (currentPlayer == 0) {
			currentPlayer = 1;
		}
		else {
			currentPlayer = 0;
		}

		return currentPlayer;
	}
}
