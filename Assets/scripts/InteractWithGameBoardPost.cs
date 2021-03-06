﻿using UnityEngine;

public class InteractWithGameBoardPost : MonoBehaviour 
{
	public GameObject gameController;
	public float playerPieceYOffset;
	// TODO: grab the height from the game object
	public float gamePieceY = 2;

	private Color postColor;
	private int maxPosition = 3;
	private bool didClick = false;
	
	// Unity lifecycle method
	void Start()
	{
		postColor = GetComponent<Renderer>().material.color;
	}

	// Unity lifecycle method
	void OnMouseEnter() 
	{
		changePostToHoverColor();
	}

	// Unity event method
	void OnMouseExit()
	{
		revertPostToInitialColor();
	}

	// Unity event method
	void OnMouseDown() 
	{
		int piecesOnPost = caclulatePiecesOnPost();
		if (piecesOnPost > maxPosition) 
		{
			return;
		}

		Vector3 postPosition = calculateNextPiecePosition();
		string gameBoardPosition = buildGameBoardPositionFromPiecesOnPostAndName();

		gameController.GetComponent<GameController>().willExecutePlayerMove(postPosition, gameBoardPosition);
	}


	// piecesOnPost = level
	// this.name = 'row-column'
	// returns 'level-row-column'
	private string buildGameBoardPositionFromPiecesOnPostAndName()
	{
		int piecesOnPost = caclulatePiecesOnPost();

		return piecesOnPost + "-" + this.name;
	}

	// change the gameBoardPost back to its initial color
	private void revertPostToInitialColor()
	{
		if (!didClick)
		{
			GetComponent<Renderer>().material.color = postColor;
		}
	}

	// change the color of this gameBoardPost
	//
	// this should only be called from OnMouseEnter and is used as a visual cue for the player that shows 
	// what post they are about to play on.
	private void changePostToHoverColor()
	{
		GetComponent<Renderer>().material.color = Color.green;
	}

	// caclulate an x, y, z position in space that a new playerPiece should be located at.
	private Vector3 calculateNextPiecePosition() 
	{
		int piecesOnPost = caclulatePiecesOnPost();
		playerPieceYOffset = (gamePieceY * piecesOnPost) + 0.5f;

		return new Vector3(this.transform.position.x, (0 + playerPieceYOffset), this.transform.position.z);
	}

	// given a string postName of "0-0" representing row-column, ask the GameBoardController how many pieces
	// exist on that specific gameBoardPost 
	private int caclulatePiecesOnPost()
	{
		string[] rowAndColumn = this.name.Split('-');
		int row = int.Parse(rowAndColumn[0]);
		int column = int.Parse(rowAndColumn[1]);
		int piecesOnPost = GameBoardController.findPiecesOnPostForRowAndColumn(row, column);

		return piecesOnPost;
	}
}
