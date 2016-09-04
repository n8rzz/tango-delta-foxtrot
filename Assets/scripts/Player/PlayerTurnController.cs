public static class PlayerTurnController
{
	// private enum player {
	// 	one = 0,
	// 	two = 1
	// }
	
	private static int playerOne = 0;
	private static int playerTwo = 1;

	public static int activePlayer;


	public static int init()
	{
		activePlayer = 0;

		return activePlayer;
	}

	public static int changeActivePlayer()
	{
		return (activePlayer == playerOne) ? playerTwo : playerOne;
	}
}
