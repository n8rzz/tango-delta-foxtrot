using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour 
{
	public GameObject playerOne;
	public GameObject playerTwo;
	public GameObject turnController;	

	public GameObject masterGameTimeText;
//	public Text elapsedTurnTimeText;

	private int activePlayer;
	private float currentGameTime;
	private float elapsedTurnTime;
	private bool didStart = false;
	private bool isComplete = false;

	private string postname;
	private Vector3 activeGamePost;
	private ArrayList gameHistory = new ArrayList();
	private int[] lastMove = new int[3];
//	private int[, ,] gameBoard = new int[,,] {
//		{
//			{-1, -1, -1, -1},
//			{-1, -1, -1, -1},
//			{-1, -1, -1, -1},
//			{-1, -1, -1, -1}
//		}, {
//			{-1, -1, -1, -1},
//			{-1, -1, -1, -1},
//			{-1, -1, -1, -1},
//			{-1, -1, -1, -1}
//		}, {
//			{-1, -1, -1, -1},
//			{-1, -1, -1, -1},
//			{-1, -1, -1, -1},
//			{-1, -1, -1, -1}
//		}, {
//			{-1, -1, -1, -1},
//			{-1, -1, -1, -1},
//			{-1, -1, -1, -1},
//			{-1, -1, -1, -1}
//		}
//	};

	void Awake()
	{
		Debug.Log("gameController " + GetInstanceID());
	}

	void Start () {
        masterGameTimeText = GameObject.FindGameObjectWithTag("masterGameTime").gameObject;
        turnController = GameObject.FindGameObjectWithTag("turnController").gameObject;
        didStart = true;
		currentGameTime = 0f;
        //		elapsedTurnTime = 0f;  
	}

	void Update() 
	{
		currentGameTime += Time.deltaTime;
//		elapsedTurnTime += Time.deltaTime;
	}

	void FixedUpdate() 
	{
		string masterGameTimeString = transformTime(currentGameTime);
//		string masterTurnTimeString = transformTime(elapsedTurnTime);

		masterGameTimeText.GetComponent<Text>().text = "Game Time: " + masterGameTimeString;
//		elapsedTurnTimeText.text = "Turn Time: " + masterTurnTimeString;
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

		gameHistory.Add(lastMove);
		// perform win checks
		// update currentPlayer
		changeActivePlayer();
		restartTurnTimer();
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

	
	//////////////////////////////////////////////////////////////////
	/// Utility Methods
	//////////////////////////////////////////////////////////////////

	void restartTurnTimer()
	{
//		print ("restart turn timer " + elapsedTurnTime);
//		elapsedTurnTime = 0f;
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
