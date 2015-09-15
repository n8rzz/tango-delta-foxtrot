using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour 
{
	public GameObject playerOne;
	public GameObject playerTwo;
	public GameObject turnController;
	public GameObject gameBoardManager;
	public GameObject masterGameTimeText;
	public GameObject elapsedTurnTimeText;

	private int activePlayer;
	private float currentGameTime;
	private float elapsedTurnTime;
	public float elapsedTurnTimeLimit = 60.0f; // number of seconds
	private bool didStart = false;
	private bool isComplete = false;
	private enum GamePhase 
	{
		beginning = 16,
		middle = 32,
		end
	};

	private string postname;
	private Vector3 activeGamePost;
	private int[] lastMove = new int[3];


	void Awake()
	{
		Debug.Log("gameController " + GetInstanceID());
	}

	void Start () 
	{
        masterGameTimeText = GameObject.FindGameObjectWithTag("masterGameTime").gameObject;
		elapsedTurnTimeText = GameObject.FindGameObjectWithTag("elapsedTurnTime").gameObject;
        turnController = GameObject.FindGameObjectWithTag("turnController").gameObject;
		gameBoardManager = GameObject.FindGameObjectWithTag("gameBoardManager").gameObject;

        didStart = true;
		currentGameTime = 0f;

		resetTurnTime();
	}

	void Update() 
	{
		currentGameTime += Time.deltaTime;
		elapsedTurnTime -= Time.deltaTime;
	}

	void FixedUpdate() 
	{
		string masterGameTimeString = transformTime(currentGameTime);
		masterGameTimeText.GetComponent<Text>().text = "Game Time: " + masterGameTimeString;

		string elapsedTurnTimeString = transformTime(elapsedTurnTime);
		elapsedTurnTimeText.GetComponent<Text>().text = "Turn Time: " + elapsedTurnTimeString;
	}
	
	
	//////////////////////////////////////////////////////////////////
	/// GameState Methods
	//////////////////////////////////////////////////////////////////

	// we are about to place the piece, do stuff that needs to be done before hand here
	public void WillMove(Vector3 postPosition, string name)
	{
		activeGamePost = postPosition;
		// split at _ and add to new player piece
		postname = name;
		print (postname);

		// disable click handlers on posts
		// is game still true
		// what player is making this move
		// is this move possible
		// calculate vertical offset
		lastMove = extractBoardPositionFromPostName(name);

		_makeMove();
		_didMove();
	}

	// place the player piece in the view on the selected post
	void _makeMove()
	{

		// append to parent
		// add to gameBoard array

		PlacePlayerPieceOnPost();
	
		// initiate wait time for undo

	}

	// we made the move, do stuff that needs to be done after the move is made here
	void _didMove()
	{
		// perform win checks
		var gameValidatorScript = gameBoardManager.GetComponent<GameBoardManager>();

		gameValidatorScript.AddNewMove(lastMove);
		bool isWinningMove = gameValidatorScript.IsWinningMove();
		int currentMovesCount = gameValidatorScript.GetMovesCount();

		print (isWinningMove);
		
			
	
		// update currentPlayer
		changeActivePlayer();
		getGamePhase(currentMovesCount);
		resetTurnTime();
		// enable click handlers on posts
	}


	//////////////////////////////////////////////////////////////////
	/// Manipulation methods
	//////////////////////////////////////////////////////////////////

	/// Instantiates a new game object based on the activePlayer
	/// Adds name to new game object
	/// Adds tag to new game object
	/// Makes new game object a child of the playerMovesContainer
	void PlacePlayerPieceOnPost()
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

	/// <summary>
	/// Changes the active player.
	/// </summary>
	void changeActivePlayer()
	{
        var turnScript = turnController.GetComponent<TurnController>();
        activePlayer = turnScript.changeCurrentPlayer();
	}	

	void resetTurnTime()
	{
		elapsedTurnTime = elapsedTurnTimeLimit;
	}

	
	//////////////////////////////////////////////////////////////////
	/// Utility Methods
	//////////////////////////////////////////////////////////////////

	void getGamePhase(int currentMoveCount)
	{ 
		print ("moves " + currentMoveCount);

		if (currentMoveCount == (int)GamePhase.beginning)
		{
			elapsedTurnTimeLimit *= 1.5f;
		}
		else if (currentMoveCount == (int)GamePhase.middle)
		{
			float originalTimeLimit = elapsedTurnTimeLimit / 1.5f; 
			elapsedTurnTimeLimit = originalTimeLimit * 2;
		}
	}


	int[] extractBoardPositionFromPostName(string postName)
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

	string transformTime(float time) 
	{
		int minutes = Mathf.FloorToInt(time / 60F);
		int seconds = Mathf.FloorToInt(time - minutes * 60);
		string transformedTime = string.Format("{0:0}:{1:00}", minutes, seconds);
		
		return transformedTime;
	}
}
