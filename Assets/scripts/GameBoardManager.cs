using UnityEngine;
using System.Collections;

public class GameBoardManager : MonoBehaviour 
{

	protected int madeMovesCount;
	public int MoveCount {
		get { return madeMovesCount; }
	}


	private ArrayList gameHistory = new ArrayList();
	protected int[,,] gameBoard = new int[,,] {
		{
			{-1, -1, -1, -1},
			{-1, -1, -1, -1},
			{-1, -1, -1, -1},
			{-1, -1, -1, -1}
		}, {
			{-1, -1, -1, -1},
			{-1, -1, -1, -1},
			{-1, -1, -1, -1},
			{-1, -1, -1, -1}
		}, {
			{-1, -1, -1, -1},
			{-1, -1, -1, -1},
			{-1, -1, -1, -1},
			{-1, -1, -1, -1}
		}, {
			{-1, -1, -1, -1},
			{-1, -1, -1, -1},
			{-1, -1, -1, -1},
			{-1, -1, -1, -1}
		}
	};
	public int[,,] GameBoard {
		get { return gameBoard; }
	}


	void Awake()
	{

	}

	void Start()
	{
		madeMovesCount = 0;
	}



	public void AddNewMove(int[] lastMove, int player) 
	{
		int level = lastMove[0];
		int row = lastMove[1];
		int cell = lastMove[2];

		gameBoard[level, row, cell] = player;
		print (player + " : " + gameBoard[level, row, cell] + "  |#|  [" + level + ", " + row + ", " + cell + "]" );

		gameHistory.Add(lastMove);
		madeMovesCount++;
	}

	public int GetMovesCount()
	{
		return madeMovesCount;
	}

	public bool IsWinningMove()
	{
		// entry point to victory checking
		// victory check will return true for a win and false for no win

		bool status = _isVictoryMove();

		return status;
	}

	bool _isVictoryMove()
	{
		return false;
	}
}
