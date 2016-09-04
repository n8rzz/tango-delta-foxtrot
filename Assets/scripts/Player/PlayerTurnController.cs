public static class PlayerTurnController
{
	// private enum player {
	// 	one = 0,
	// 	two = 1
	// }
	private static int playerOne = 0;
	private static int playerTwo = 1;

	public static int activePlayer = 0;


	public static void init()
	{
		activePlayer = 0;
	}

	public static int changeActivePlayer()
	{
		activePlayer = (activePlayer == playerOne) ? playerTwo : playerOne;
		
		return activePlayer;
	}
}
