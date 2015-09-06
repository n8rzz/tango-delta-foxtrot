﻿using UnityEngine;
using System.Collections;

public class ClickGameBoardPostWithMouse : MonoBehaviour 
{
	public GameController gameController;
	public float playerPieceYOffset;
	public float gamePieceY = 2;

	private Color postColor;
	private int nextPositionOnPost = 0;
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
		if (nextPositionOnPost > maxPosition) 
			return;

		Vector3 postPosition = GetPositionForNewPiece();
		string gameBoardPosition = nextPositionOnPost + "-" + this.name;

		gameController.WillMove(postPosition, gameBoardPosition);
		nextPositionOnPost++;
	}
	  
	void OnMouseUp() 
	{
//		ChangePostColorToOriginal();
	}


	void ChangePostColorToOriginal()
	{
		if (!didClick) 
			GetComponent<Renderer>().material.color = postColor;
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
		playerPieceYOffset = gamePieceY * nextPositionOnPost;

		return new Vector3(this.transform.position.x, (0 + playerPieceYOffset), this.transform.position.z);
	}
}