using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TurnController : MonoBehaviour 
{	
	public GameObject currentPlayerText;

	private int currentPlayer;

	void Awake()
	{
        currentPlayerText = GameObject.FindGameObjectWithTag("currentTurn").gameObject;
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

		_setCurrentPlayerText();

		return currentPlayer;
	}
	

	void _setCurrentPlayerText()
	{
//		Color currentPlayerColor = _findCurrentPlayerColor();
		currentPlayerText.GetComponent<Text>().text = "Current Player: " + (currentPlayer + 1).ToString();
		print ("color: " + _findCurrentPlayerColor());
		currentPlayerText.GetComponent<Text>().color = _findCurrentPlayerColor();
	}

	Color _findCurrentPlayerColor()
	{
		// TODO: rplace standard colors with actual RGBA colors
//		Color playerOneMeshColor = new Color(166, 34, 180, 255);
//		Color playerTwoMeshColor = new Color(15, 39, 191, 255);

		if (currentPlayer == 0) 
		{
			return Color.magenta;
		}

		return Color.blue;
	}
}
