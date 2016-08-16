using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
///
/// </summary>
public class VictoryController : MonoBehaviour 
{

	private int INVALID_POINT = -100;

	private int[][][] gameBoard;
	private int[] lastMove;
	private int[] initialComparePoint;
	private int[] comparePoint;
	private int[] nextComparePoint;
	private int player;
	private int maxPosition;
	private bool shouldCheckOpposite;

	private int[][] vectorFromPoint = new int[26][] {
		//top left
		new int[3] {0, -1, -1},
		//top
		new int[3] {0, -1, 0},
		//top right
		new int[3] {0, -1, 1},
		//right
		new int[3] {0, 0, 1},
		//bottom right
		new int[3] {0, 1, 1},
		//bottom
		new int[3] {0, 1, 0},
		//bottom left
		new int[3] {0, 1, -1},
		//left
		new int[3] {0, 0, -1},

		//ascending
		new int[3] {1, 0, 0},
		//descending
		new int[3] {-1, 0, 0},
		
		//descending top left
		new int[3] {-1, -1, -1},
		//descending top
		new int[3] {-1, -1, 0},
		//descending top, right
		new int[3] {-1, -1, 1},
		//descending right
		new int[3] {-1, 0, 1},
		
		//descending bottom, right
		new int[3] {-1, 1, 1},
		//descending bottom
		new int[3] {-1, 1, 0},
		//descending bottom, left
		new int[3] {-1, 1, -1},
		//descending left
		new int[3] {-1, 0, -1},

		//ascending top left
		new int[3] {1, -1, -1},
		//ascending top
		new int[3] {1, -1, 0},
		//ascending top, right
		new int[3] {1, -1, 1},
		//ascending right
		new int[3] {1, 0, 1},
		//ascending bottom, right
		new int[3] {1, 1, 1},
		//ascending bottom
		new int[3] {1, 1, 0},
		//ascending bottom, left
		new int[3] {1, 1, -1},
		//ascending left
		new int[3] {1, 0, -1}
	};
		
	void Update () {}
	
	/// <summary>
	///
	/// </summary>
	public bool IsWinningMove(int[][][] currentGameBoard, int[] playerMove, int activePlayer)
	{
		gameBoard = currentGameBoard;
		player = activePlayer;
		lastMove = playerMove;
		maxPosition = currentGameBoard.GetLength(0) - 1;

		return  _isWinningMove();
	}

	////////////////////////////////////////////////////////////////////////
	/// Private Methods
	////////////////////////////////////////////////////////////////////////

	/// <summary>
	///
	/// </summary>
	bool _isWinningMove()
	{
		for (int i = 0; i < vectorFromPoint.GetLength(0); i++) 
		{
			int[] nextComparePoint;
			int[] directionFromPoint = vectorFromPoint[i];
			int moveCounter = 0;
			int playerAtPosition = -1;
			shouldCheckOpposite = true;
			comparePoint = _findNextComparePoint(directionFromPoint, lastMove);

			if (!_isPointValid(comparePoint)) 
			{
				continue;
			}
				
			playerAtPosition = _findPlayerAtPoint(comparePoint);

			while (playerAtPosition == player) 
			{
				moveCounter++;
				playerAtPosition = -1;

				if (moveCounter == maxPosition) 
				{
					return true;
				}

				nextComparePoint = _findNextComparePoint(directionFromPoint, comparePoint);

				if (nextComparePoint[0] == INVALID_POINT || !_isPointValid(nextComparePoint)) {
					break;
				}

				playerAtPosition = _findPlayerAtPoint(nextComparePoint);
				comparePoint = nextComparePoint;
			}
		}

		return false;
	}

	//////////////////////////////////////////////////////////////////
	/// Helper Methods
	//////////////////////////////////////////////////////////////////

	/// <summary>
	///
	/// </summary>
	int[] _findNextComparePoint(int[] direction, int[] comparePoint) 
	{
		int[] nextComparePoint = _findNextPointForDirection(direction, comparePoint);

		if (!_isPointValid(nextComparePoint))
		{
			if (!shouldCheckOpposite) 
			{
				int [] invalidComparePoint = {INVALID_POINT};

				return invalidComparePoint;
			}

			shouldCheckOpposite = false;
			int[] oppositeDirection = _findOppositeDirectionFromLastMove(direction, lastMove);
			nextComparePoint = _findNextPointForDirection(oppositeDirection, lastMove);
		}

		return nextComparePoint;
	}

	/// <summary>
	///
	/// </summary>
	int[] _findNextPointForDirection(int[] direction, int[] point) 
	{
		int level = point[0] + direction[0];
		int row = point[1] + direction[1];
		int cell = point[2] + direction[2];
		int[] nextComparePoint = {level, row, cell};

		return nextComparePoint;
	}

	/// <summary>
	///
	/// </summary>
	int[] _findOppositeDirectionFromLastMove(int[] direction, int[] point) 
	{
		int[] oppositeVector = new int[3];

		for (var j = 0; j < direction.GetLength(0); j++) 
		{
			if (direction[j] == 0) 
			{
				oppositeVector[j] = direction[j];
				continue;
			}

			oppositeVector[j] = direction[j] * -1;
		}

		return oppositeVector;
	}

	/// <summary>
	///
	/// </summary>
	int _findPlayerAtPoint(int[] point)
	{
		int level = point[0];
		int row = point[1];
		int cell = point[2];

		return gameBoard[level][row][cell];
	}

	/// <summary>
	///
	/// </summary>
	bool _isPointValid(int[] point)
	{
		int i;
		int maxPiecePosition = 3;

		for (i = 0; i < point.Length; i++) 
		{
			if (point[i] < 0 || point[i] > maxPiecePosition) 
			{
				return false;
			}
		}

		return true;
	}
}
