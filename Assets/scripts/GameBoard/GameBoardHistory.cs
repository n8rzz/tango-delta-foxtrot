using System.Collections.Generic;
using System.Linq;

public static class GameBoardHistory
{
	private static int MIN_MOVES_COUNT = 6;
	private static List<PlayerMoveModel> history = new List<PlayerMoveModel>();
	private static int length;


	// add a PlayerMoveModel to history List
	public static void addMoveToHistory(PlayerMoveModel moveToAdd)
	{
		history.Add(moveToAdd);
		length = history.Count;
	}

	// if history contains less than the MIN_MOVES_COUNT, a win is not yet mathmatically possible
	public static bool isWinPossible()
	{
		return movesCount() > MIN_MOVES_COUNT;
	}

	// return the current length of history
	public static int movesCount()
	{
		return length;
	}

	// find the last item in history
	public static PlayerMoveModel findLastPlayerMove()
	{
		return history.Last();
	}

	// remove the last move from history, update length to reflect change in size.
	public static bool removeLastMoveFromHistory()
	{
		history.RemoveAt(length - 1);
		length = history.Count;

		return true;
	}
}
