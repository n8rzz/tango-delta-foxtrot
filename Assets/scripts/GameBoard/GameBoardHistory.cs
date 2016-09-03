using System.Collections.Generic;

public static class GameBoardHistory
{
	public static List<PlayerMoveModel> history = new List<PlayerMoveModel>();


	public static void addMoveToHistory(PlayerMoveModel moveToAdd)
	{
		history.Add(moveToAdd);
	}

	public static bool isWinPossible()
	{
		return calculateMovesCount() > 7;
	}

	public static int calculateMovesCount()
	{
		return history.Count;
	}

	// This will filter out the list of ints that are > than 7, Where returns an
	// IEnumerable<T> so a call to ToList is required to convert back to a List<T>.
	// List<int> filteredList = myList.Where( x => x > 7).ToList();
}
