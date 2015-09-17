using UnityEngine;
using System.Collections;

public class VictoryController : MonoBehaviour 
{

	private int[][][] gameBoard;

	private int player;
	private int maxPosition = 4;
	
	private int[] lastMove;
	private int[] initialComparePoint;
	private int[] comparePoint;

	private int moveCounter;
	private int playerAtPosition;
	private bool willCheckInverse;
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
	

	public bool IsWinningMove(int[][][] currentGameBoard, int[] playerMove, int activePlayer)
	{
		gameBoard = currentGameBoard;
		player = activePlayer;
		lastMove = playerMove;

		print (player + " : [" + lastMove[0] + ", " + lastMove[1] + ", " + lastMove[2] + "]");

		bool status = _isWinningMove();

		return status;
	}

	////////////////////////////////////////////////////////////////////////
	/// Private Methods
	////////////////////////////////////////////////////////////////////////

	bool _isWinningMove()
	{
		for (int i = 0; i < vectorFromPoint.GetLength(0); i++) 
		{
			int[] directionFromPoint = vectorFromPoint[i];

			moveCounter = 0;
			willCheckInverse = true;
			initialComparePoint = _getNextPointAlongVector(directionFromPoint, lastMove);

			if (!_isPointValid(initialComparePoint)) {
				continue;
			}


			playerAtPosition = _getPlayerAtPoint(initialComparePoint);


			while (playerAtPosition == player) 
			{
				playerAtPosition = -1;
				moveCounter++;

				print (playerAtPosition + ":" + moveCounter + ":" + maxPosition);

				if (moveCounter == maxPosition) 
				{
					print ("WINNER!!");
					return true;
				}

				comparePoint = _getNextPointAlongVector(directionFromPoint, initialComparePoint);

				if (!_isPointValid(comparePoint) && willCheckInverse) {
					print ("willCheckInverse");
					comparePoint = _getOppositeVector(directionFromPoint);
				}

				if (!_isPointValid(comparePoint) && ! willCheckInverse) 
				{
					break;
				}


				playerAtPosition = _getPlayerAtPoint(comparePoint);
			}

		}

		return false;
	}



	int[] _getNextPointAlongVector(int[] directionFromPoint, int[] point)
	{
		int[] comparePoint = new int[3];

		for (int i = 0; i < point.GetLength(0); i++) {
			comparePoint[i] = point[i] + directionFromPoint[i];
		}

		return comparePoint;
	}

	int[] _getOppositeVector(int[] vector)
	{
		int i;
		int[] oppositeVector = new int[3];

		for (i = 0; i < vector.Length; i++) 
		{
			oppositeVector[i] = vector[i] * -1;
		}

		willCheckInverse = false;
		return oppositeVector;
	}

	int _getPlayerAtPoint(int[] point)
	{
		int level = point[0];
		int row = point[1];
		int cell = point[2];

//		print ("gameBoard " + gameBoard[level][row][cell]);

		return gameBoard[level][row][cell];
	}

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
