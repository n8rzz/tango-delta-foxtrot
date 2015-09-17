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

	private int activePlayer;
	private float currentGameTime;
	private float elapsedTurnTime;
	private float elapsedTurnTimeLimit = 60.0f; // number of seconds
	private bool didStart = false;
	private bool isComplete = false;
	private enum GamePhase 
	{
		beginning = 16,
		middle = 32,
		end
	};

//	private string postname;
	private Vector3 activeGamePost;
	private int[] lastMove = new int[3];


	void Awake()
	{}

	void Start () 
	{
        masterGameTimeText = GameObject.FindGameObjectWithTag("masterGameTime").gameObject;
		elapsedTurnTimeText = GameObject.FindGameObjectWithTag("elapsedTurnTime").gameObject;
        turnController = GameObject.FindGameObjectWithTag("turnController").gameObject;
		gameBoardManager = GameObject.FindGameObjectWithTag("gameBoardManager").gameObject;
		victoryController = GameObject.FindGameObjectWithTag("victoryController").gameObject;

        didStart = true;
		currentGameTime = 0f;

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

	// we are about to place the piece, do stuff that needs to be done before hand here
	public void WillMove(Vector3 postPosition, string name)
	{
		if (!didStart || isComplete)
		{
			return;
		}


		activeGamePost = postPosition;
		// todo: change to local var
//		postname = name;

		// is game still true
		// is this move possible
		// calculate vertical offset
		lastMove = _extractBoardPositionFromPostName(name);

		_makeMove(name);
		_didMove();
	}

	// place the player piece in the view on the selected post
	void _makeMove(string name)
	{

		_placePlayerPieceOnPost(name);
	
		// initiate wait time for undo
	}

	// we made the move, do stuff that needs to be done after the move is confirmed 
	void _didMove()
	{
		var gameBoardMangerScript = gameBoardManager.GetComponent<GameBoardManager>();
		gameBoardMangerScript.AddNewMove(lastMove, activePlayer);
		int[][][] currentGameBoard = gameBoardMangerScript.GameBoard;
		int currentMovesCount = gameBoardMangerScript.MoveCount;

		// perform win checks
		var victoryControllerScript = victoryController.GetComponent<VictoryController>();
		bool isWinningMove = victoryControllerScript.IsWinningMove(currentGameBoard, lastMove, activePlayer);
//		print (isWinningMove);


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

	
	//////////////////////////////////////////////////////////////////
	/// Utility Methods
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
