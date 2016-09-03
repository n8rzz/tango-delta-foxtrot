using UnityEngine;
using UnityEngine.UI;

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

		setCurrentPlayerText();
	}
	

	public int getCurrentPlayer()
	{
		return currentPlayer;
	}

	
	public int changeCurrentPlayer()
	{
		currentPlayer = (currentPlayer == 0) ? 1 : 0;

		setCurrentPlayerText();

		return currentPlayer;
	}
	

	private void setCurrentPlayerText()
	{
		currentPlayerText.GetComponent<Text>().text = "Current Player: " + (currentPlayer + 1).ToString();
		currentPlayerText.GetComponent<Text>().color = findCurrentPlayerColor();
	}

	private Color findCurrentPlayerColor()
	{
		return (currentPlayer == 0) ? Color.magenta : Color.blue;
	}
}
