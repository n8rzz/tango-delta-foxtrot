﻿using UnityEngine;

public class InteractWithGameBoardPost : MonoBehaviour 
{
	public GameObject gameController;
//	public GameObject gameBoardController;
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
		ChangePostColorToHover();
	}

	void OnMouseExit()
	{
		ChangePostColorToOriginal();
	}

	void OnMouseDown() 
	{
		// FIXME: gameBoardController.isValidMove
		if (piecesOnPost > maxPosition) 
			return;

		Vector3 postPosition = GetPositionForNewPiece();
		string gameBoardPosition = piecesOnPost + "-" + this.name;

		gameController.GetComponent<GameController>().willExecutePlayerMove(postPosition, gameBoardPosition);
		// FIXME: remove after ln: 36 is implemented
		piecesOnPost++;
	}
	  
	void OnMouseUp() 
	{}

	void ChangePostColorToOriginal()
	{
		if (!didClick)
		{
			GetComponent<Renderer>().material.color = postColor;
		}
	}

	void ChangePostColorToHover()
	{
		GetComponent<Renderer>().material.color = Color.green;
	}

	void ChangePostColorToActive()
	{
		GetComponent<Renderer>().material.color = Color.yellow;
	}

	private Vector3 GetPositionForNewPiece() 
	{
		playerPieceYOffset = (gamePieceY * piecesOnPost) + 0.5f;
//		playerPieceYOffset = gamePieceY * piecesOnPost;

		return new Vector3(this.transform.position.x, (0 + playerPieceYOffset), this.transform.position.z);
	}
}
