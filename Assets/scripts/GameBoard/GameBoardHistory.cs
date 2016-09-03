using System.Collections;
using System.Collections.Generic;

public static class GameBoardHistory
{
	private static int MIN_MOVES_COUNT = 6;
	private static List<PlayerMoveModel> history = new List<PlayerMoveModel>();
	private static int length;


	public static void addMoveToHistory(PlayerMoveModel moveToAdd)
	{
		history.Add(moveToAdd);
		length = history.Count;
	}

	public static bool isWinPossible()
	{
		return calculateMovesCount() > MIN_MOVES_COUNT;
	}

	public static int calculateMovesCount()
	{
		return length;
	}
}
