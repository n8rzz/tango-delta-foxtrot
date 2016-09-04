using UnityEngine;
using UnityEngine.UI;

// Responsible only for displaying the player who is currently making a move
// PlayerTurnController is responsible for keeping track of which player that is 
public class PlayerTurnView : MonoBehaviour 
{	
	public GameObject currentPlayerText;


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
	

	// updates the currentTurn text string
	public void updateActivePlayerText(int currentPlayer)
	{
		setCurrentPlayerText(currentPlayer);
	}

	// sets a text string and text color based on the currenPlayer 
	private void setCurrentPlayerText(int currentPlayer)
	{
		currentPlayerText.GetComponent<Text>().text = "Current Player: " + (currentPlayer + 1).ToString();
		currentPlayerText.GetComponent<Text>().color = calculateCurrentPlayerColor(currentPlayer);
	}

	// returns a color based on the currentPlayer. color corresponds to the currentPlayer piece color.
	private Color calculateCurrentPlayerColor(int currentPlayer)
	{
		return (currentPlayer == 0) ? Color.magenta : Color.blue;
	}
}
