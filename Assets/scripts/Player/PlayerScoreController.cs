//
public static class PlayerScoreController
{
	// FIXME: change to enum
	private static int playerOne = 0;
	// private static int playerTwo = 1;

	public static int playerOneScore = 0;
	public static int playerTwoScore = 0;


	//
	public static int getScoreForPlayer(int player)
	{
		return (player == playerOne) ? playerOneScore : playerTwoScore;
	}

	//
	public static void startNewGame()
	{
		return;
	}

	//
	public static void declareWinner(int player)
	{
		if (player == playerOne)
		{
			playerOneScore++;
		} else {
			playerTwoScore++;
		}
	}

	//
	public static void restartTournament()
	{
		playerOneScore = 0;
		playerTwoScore = 0;
	}
}
