using UnityEngine;
using System.Collections;

public class GameBoardManager : MonoBehaviour 
{

	protected int madeMovesCount;
	public int MoveCount {
		get { return madeMovesCount; }
	}

	// FIXME: move to new class GameHistory
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
		// FIXME: remove once GameHistory is implemented
		madeMovesCount = 0;
	}
	

	public void addNewMove(int[] moveToMake, int player) 
	{
		int level = moveToMake[0];
		int row = moveToMake[1];
		int cell = moveToMake[2];

		gameBoard[level][row][cell] = player;

		gameHistory.Add(moveToMake);
		// FIXME: remove once GameHistory is implemented
		madeMovesCount++;
	}

	public int GetMovesCount()
	{
		// FIXME: this should return the current length of the GameHistory arrayList.
		// FIXME: refactor once GameHistory is implemented.
		return madeMovesCount;
	}
	
}
