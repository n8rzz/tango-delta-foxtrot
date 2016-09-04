using UnityEngine;
using UnityEngine.UI;

public class TurnController : MonoBehaviour 
{	
	public GameObject currentPlayerText;

	private int currentPlayer;


	// Unity lifecycle method
	void Awake()
	{
        currentPlayerText = GameObject.FindGameObjectWithTag("currentTurn").gameObject;
	}

	// Unity lifecycle method
	void Start()
	{
		int currentPlayer = PlayerTurnController.activePlayer;
		setCurrentPlayerText(currentPlayer);
	}
	

	public void changeActivePlayerText(int currentPlayer)
	{
		setCurrentPlayerText(currentPlayer);
	}

	private void setCurrentPlayerText(int currentPlayer)
	{
		currentPlayerText.GetComponent<Text>().text = "Current Player: " + (currentPlayer + 1).ToString();
		currentPlayerText.GetComponent<Text>().color = findCurrentPlayerColor();
	}

	private Color findCurrentPlayerColor()
	{
		return (currentPlayer == 0) ? Color.magenta : Color.blue;
	}
}
