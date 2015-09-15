using UnityEngine;
using System.Collections;

public class GameBoardManager : MonoBehaviour 
{

	protected int madeMovesCount;
	public int MoveCount {
		get { return madeMovesCount; }
	}

	private ArrayList gameHistory = new ArrayList();
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
		Debug.Log("GameBoardManager " + GetInstanceID());
	}

	void Start()
	{
		madeMovesCount = 0;
	}



	public void AddNewMove(int[] lastMove) 
	{
		gameHistory.Add(lastMove);
		madeMovesCount++;
	}

	public int GetMovesCount()
	{
		return madeMovesCount;
	}

	public bool IsWinningMove()
	{
		return false;
	}
}
