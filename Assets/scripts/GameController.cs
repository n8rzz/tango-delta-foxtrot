using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour 
{
	public GameObject playerOne;
	public GameObject playerTwo;
	public GameObject turnController;
	public GameObject gameBoardManager;
	public GameObject victoryController;
	public GameObject masterGameTimeText;
	public GameObject elapsedTurnTimeText;
	public GameObject winnerBannerText;

	private FormationsCollection formationsCollection = new FormationsCollection();
	private int activePlayer;
	private float currentGameTime;
	private float elapsedTurnTime;
	private float elapsedTurnTimeLimit = 60.0f; // number of seconds
	private bool didStart = false;
	private bool isComplete = false;
	private enum GamePhase {
		beginning = 16,
		middle = 32,
		end
	};
		
	private Vector3 activeGamePost;
	private int[] moveToMake = new int[3];


	void Start () 
	{
        masterGameTimeText = GameObject.FindGameObjectWithTag("masterGameTime").gameObject;
		elapsedTurnTimeText = GameObject.FindGameObjectWithTag("elapsedTurnTime").gameObject;
		winnerBannerText = GameObject.FindGameObjectWithTag("winnerBanner").gameObject;
        turnController = GameObject.FindGameObjectWithTag("turnController").gameObject;
		gameBoardManager = GameObject.FindGameObjectWithTag("gameBoardManager").gameObject;
		victoryController = GameObject.FindGameObjectWithTag("victoryController").gameObject;

        didStart = true;
		currentGameTime = 0f;
		winnerBannerText.GetComponent<Text>().text = "";

		_resetTurnTime();
	}

	void Update() 
	{
		currentGameTime += Time.deltaTime;
		elapsedTurnTime -= Time.deltaTime;
	}

	void FixedUpdate() 
	{
		string masterGameTimeString = _transformTime(currentGameTime);
		masterGameTimeText.GetComponent<Text>().text = "Game Time: " + masterGameTimeString;

		string elapsedTurnTimeString = _transformTime(elapsedTurnTime);
		elapsedTurnTimeText.GetComponent<Text>().text = "Turn Time: " + elapsedTurnTimeString;
	}
	
	
	//////////////////////////////////////////////////////////////////
	/// GameState Methods
	//////////////////////////////////////////////////////////////////

	// entry into this method comes from InteractWithGameBoardPost.OnMouseDown
	public void willMove(Vector3 postPosition, string name)
	{
		if (!didStart || isComplete)
		{
			return;
		}
			
		activeGamePost = postPosition;
		moveToMake = _extractBoardPositionFromPostName(name);

		_willExecutePlayerMove(name);
		// initiate wait time for undo
		// StartCoroutine(makeUndoMoveAvailable());
		// disable click until timer is up
		_didExecutePlayerMove();
	}

	// place the player piece in the view on the selected post
	void _willExecutePlayerMove(string name)
	{
		_placePlayerPieceOnPost(name);
	}
		
	// we made the move, do stuff that needs to be done after the move is confirmed 
	void _didExecutePlayerMove()
	{
		var gameBoardMangerScript = gameBoardManager.GetComponent<GameBoardManager>();
		var victoryControllerScript = victoryController.GetComponent<VictoryController>();

		gameBoardMangerScript.addNewMove(moveToMake, activePlayer);
		int[][][] currentGameBoard = gameBoardMangerScript.GameBoard;

		// FIXME: remove once GameHistory is implemented
		int currentMovesCount = gameBoardMangerScript.MoveCount;

		// perform win checks
		// FIXME: abstract to method
		bool isWinningMove = victoryControllerScript.IsWinningMove(currentGameBoard, moveToMake, activePlayer);
		if (isWinningMove)
		{
			// do end game things

			isComplete = true;
			// stop timers
			// show winning formation
			_buildWinnerText();
			// show restart button
			return;
		}

		_changeActivePlayer();
		_getGamePhase(currentMovesCount);
		_resetTurnTime();
	}


	//////////////////////////////////////////////////////////////////
	/// Manipulation methods
	//////////////////////////////////////////////////////////////////

	/// Instantiates a new game object based on the activePlayer
	/// Adds name to new game object
	/// Adds tag to new game object
	/// Makes new game object a child of the playerMovesContainer
	void _placePlayerPieceOnPost(string postname)
	{
		if (activePlayer == 0) 
		{
			GameObject newmove = Instantiate(playerOne, activeGamePost, Quaternion.identity) as GameObject;
			newmove.transform.name = "playerone_" + postname;
			newmove.tag = "playerOneMoves";
			newmove.transform.parent = GameObject.FindGameObjectWithTag("playerMovesContainer").transform;
		} 
		else 
		{				
			GameObject newmove = Instantiate(playerTwo, activeGamePost, Quaternion.identity) as GameObject;
			newmove.transform.name = "playertwo_" + postname;
			newmove.tag = "playerOneMoves";
			newmove.transform.parent = GameObject.FindGameObjectWithTag("playerMovesContainer").transform;
		}
	}

	void _changeActivePlayer()
	{
        var turnScript = turnController.GetComponent<TurnController>();
        activePlayer = turnScript.changeCurrentPlayer();
	}	

	void _getGamePhase(int currentMoveCount)
	{  
		if (currentMoveCount == (int)GamePhase.beginning)
		{
			// todo: refactor this to be calculated at start() with an enum
			elapsedTurnTimeLimit *= 1.5f;
		}
		else if (currentMoveCount == (int)GamePhase.middle)
		{
			// todo: shame!
			// todo: refactor this to be calculated at start() with an enum
			float originalTimeLimit = elapsedTurnTimeLimit / 1.5f; 
			elapsedTurnTimeLimit = originalTimeLimit * 2;
		}
	}

	void _resetTurnTime()
	{
		elapsedTurnTime = elapsedTurnTimeLimit;
	}

	void _buildWinnerText()
	{
		winnerBannerText.GetComponent<Text>().text = "Player " + (activePlayer + 1) + " is the winner!";
	}
	
	//////////////////////////////////////////////////////////////////
	/// Helper Methods
	//////////////////////////////////////////////////////////////////
	
	int[] _extractBoardPositionFromPostName(string postname)
	{
		// todo: optimize, possibly with below strategy
		// string[] test = new string[] {"1", "2", "3", "4", "5"};
		// int[] arr = Array.ConvertAll<string, int>(test, int.Parse);

		int[] gameBoardPosition = new int[3];
		string[] locations = postname.Split('-');

		for (int i = 0; i < locations.Length; i++)
		{
			gameBoardPosition[i] = System.Int32.Parse(locations[i]);
		}

		return gameBoardPosition;
	}

	string _transformTime(float time) 
	{
		int minutes = Mathf.FloorToInt(time / 60F);
		int seconds = Mathf.FloorToInt(time - minutes * 60);
		string transformedTime = string.Format("{0:0}:{1:00}", minutes, seconds);
		
		return transformedTime;
	}
}
