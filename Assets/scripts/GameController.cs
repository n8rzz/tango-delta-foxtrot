using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour 
{
	private float currentGameTime;
	private float elapsedTurnTime;
	private float elapsedTurnTimeLimit = 60.0f;
	private bool didStart = false;
	private bool isComplete = false;
	private enum GamePhase {
		beginning = 16,
		middle = 32,
		end
	};

	public GameObject playerOne;
	public GameObject playerTwo;
	public GameObject turnController;
	public GameObject masterGameTimeText;
	public GameObject elapsedTurnTimeText;
	public GameObject winnerBannerText;


	// Unity lifecycle method
	void Start () 
	{
		// reset the PlayerTurnController, this is only helpful when a game gets reset or restarted
		PlayerTurnController.init();

        masterGameTimeText = GameObject.FindGameObjectWithTag("masterGameTime").gameObject;
		elapsedTurnTimeText = GameObject.FindGameObjectWithTag("elapsedTurnTime").gameObject;
		winnerBannerText = GameObject.FindGameObjectWithTag("winnerBanner").gameObject;
        turnController = GameObject.FindGameObjectWithTag("turnController").gameObject;
		winnerBannerText.GetComponent<Text>().text = "";
		currentGameTime = 0f;
		didStart = true;

		resetTurnTime();
	}

	// Unity lifecycle method
	void Update() 
	{
		// TODO: move this time logic to another class
		currentGameTime += Time.deltaTime;
		elapsedTurnTime -= Time.deltaTime;
	}

	// Unity lifecycle method
	void FixedUpdate() 
	{
		if (isComplete) {
			return;
		}

		string masterGameTimeString = formatTimeToHumanReadable(currentGameTime);
		masterGameTimeText.GetComponent<Text>().text = "Game Time: " + masterGameTimeString;

		string elapsedTurnTimeString = formatTimeToHumanReadable(elapsedTurnTime);
		elapsedTurnTimeText.GetComponent<Text>().text = "Turn Time: " + elapsedTurnTimeString;
	}
	
	//////////////////////////////////////////////////////////////////
	//////////////////////////////////////////////////////////////////

	// entry into this method comes from InteractWithGameBoardPost.OnMouseDown
	// this method kicks off all operations that need to happen when a player clicks a game post.
	public void willExecutePlayerMove(Vector3 postPosition, string postName)
	{
		if (!didStart || isComplete)
		{
			return;
		}

		// int currentPlayer = PlayerTurnController.activePlayer;
		PlayerMoveModel playerMove = new PlayerMoveModel(postName);

		executePlayerMove(playerMove, postPosition, postName);
		// TODO: undo last move should go here 
		// 		initiate wait time for undo
		// 		StartCoroutine(makeUndoMoveAvailable());
		// 		disable click until timer is up
		didExecutePlayerMove(postName, playerMove);
	}

	//////////////////////////////////////////////////////////////////
	//////////////////////////////////////////////////////////////////

	// place player piece in the view on the selected post
	private void executePlayerMove(PlayerMoveModel playerMove, Vector3 postPosition, string postName)
	{
		GameBoardController.addPlayerAtPoint(playerMove);
		placePlayerPieceOnPost(postPosition, postName, playerMove.player);
	}
		
	// perform system cleanups and updates after a move has been made successfully
	// check for a win and stop the game if one is found.
	private void didExecutePlayerMove(string postName, PlayerMoveModel playerMove)
	{
		GameBoardHistory.addMoveToHistory(playerMove);
		
		FormationModel winningFormation = GameBoardController.findWinningFormation(playerMove);
		if (winningFormation != null)
		{
			// do end game things
			isComplete = true;
			// show winning formation
			buildWinnerText();
			
			return;
		}

		changeActivePlayer();
		calculateGamePhase();
		resetTurnTime();
	}

	/// Instantiates a new game object based on the activePlayer
	/// Adds name to new game object
	/// Adds tag to new game object
	/// Makes new game object a child of the playerMovesContainer
	private void placePlayerPieceOnPost(Vector3 activeGamePost, string postname, int currentPlayer)
	{
		if (currentPlayer == 0) 
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

	// change the current player
	private void changeActivePlayer()
	{
		var playerTurnView = turnController.GetComponent<TurnController>();
        int currentPlayer = PlayerTurnController.changeActivePlayer();
		playerTurnView.changeActivePlayerText(currentPlayer);
	}	

	// reset the turn time
	// this method should only be called after changing the activePlayer
	private void resetTurnTime()
	{
		elapsedTurnTime = elapsedTurnTimeLimit;
	}

	// calculateGamePhase
	// more advanced games require a longer turn timer
	private void calculateGamePhase()
	{  
		int currentMoveCount = GameBoardHistory.calculateMovesCount();

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

	// build a string, to be displayed in the UI, consisting of the player numbber and the fact that they are a winner.
	private void buildWinnerText()
	{
		int currentPlayer = PlayerTurnController.activePlayer;
		winnerBannerText.GetComponent<Text>().text = "Player " + (currentPlayer + 1) + " is the winner!";
	}

	// format float into a human readable mm:ss time
	private string formatTimeToHumanReadable(float time) 
	{
		int minutes = Mathf.FloorToInt(time / 60F);
		int seconds = Mathf.FloorToInt(time - minutes * 60);
		string humanReadableTime = string.Format("{0:0}:{1:00}", minutes, seconds);
		
		return humanReadableTime;
	}
}
