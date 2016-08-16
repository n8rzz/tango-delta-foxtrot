using UnityEngine;
using System.Collections;

public class GameBoardManager : MonoBehaviour 
{

	protected int madeMovesCount;
	public int MoveCount {
		get { return madeMovesCount; }
	}


	private ArrayList gameHistory = new ArrayList();
	protected int[][][] gameBoard = 
	{
		new[] {
			new int[] {-1, -1, -1, -1},
			new int[] {-1, -1, -1, -1},
			new int[] {-1, -1, -1, -1},
			new int[] {-1, -1, -1, -1}
		}, 
		new[] {
			new int[] {-1, -1, -1, -1},
			new int[] {-1, -1, -1, -1},
			new int[] {-1, -1, -1, -1},
			new int[] {-1, -1, -1, -1}
		}, 
		new[] {
			new int[] {-1, -1, -1, -1},
			new int[] {-1, -1, -1, -1},
			new int[] {-1, -1, -1, -1},
			new int[] {-1, -1, -1, -1}
		}, 
		new[] {
			new int[] {-1, -1, -1, -1},
			new int[] {-1, -1, -1, -1},
			new int[] {-1, -1, -1, -1},
			new int[] {-1, -1, -1, -1}
		}
	};
	public int[][][] GameBoard {
		get { return gameBoard; }
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

		gameBoard[level][row][cell] = player;

		gameHistory.Add(lastMove);
		madeMovesCount++;
	}

	public int GetMovesCount()
	{
		return madeMovesCount;
	}
	
}
