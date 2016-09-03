using UnityEngine;

public class InteractWithGameBoardPost : MonoBehaviour 
{
	public GameObject gameController;
	public float playerPieceYOffset;
	// TODO: grab the height from the game object
	public float gamePieceY = 2;

	private Color postColor;
	private int piecesOnPost = 0;
	private int maxPosition = 3;
	private bool didClick = false;
	

	void Start()
	{
		postColor = GetComponent<Renderer>().material.color;
	}

	void OnMouseEnter() 
	{
		changePostToHoverColor();
	}

	void OnMouseExit()
	{
		revertPostToInitialColor();
	}

	void OnMouseDown() 
	{
		// FIXME: gameBoardController.isValidMove
		if (piecesOnPost > maxPosition) 
		{
				return;
		}

		Vector3 postPosition = calculateNextPiecePosition();
		string gameBoardPosition = buildGameBoardPositionFromPiecesOnPostAndName();

		gameController.GetComponent<GameController>().willExecutePlayerMove(postPosition, gameBoardPosition);
		piecesOnPost++;
	}

	// piecesOnPost = level
	// this.name = 'row-column'
	// returns 'level-row-column'
	private string buildGameBoardPositionFromPiecesOnPostAndName()
	{
		return piecesOnPost + "-" + this.name;
	}

	private void revertPostToInitialColor()
	{
		if (!didClick)
		{
			GetComponent<Renderer>().material.color = postColor;
		}
	}

	private void changePostToHoverColor()
	{
		GetComponent<Renderer>().material.color = Color.green;
	}

	private Vector3 calculateNextPiecePosition() 
	{
		playerPieceYOffset = (gamePieceY * piecesOnPost) + 0.5f;
//		playerPieceYOffset = gamePieceY * piecesOnPost;

		return new Vector3(this.transform.position.x, (0 + playerPieceYOffset), this.transform.position.z);
	}
}
