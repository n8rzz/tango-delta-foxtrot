public static class PlayerTurnController
{
	// FIXME: change these two properties to an enum
	private static int playerOne = 0;
	private static int playerTwo = 1;

	public static int activePlayer = 0;


	// initialize the activePlayer property to 0. This is accomplished in the class declaration, however, when a game is reset
	// this static class does not get re-initialized. Thus, this method provides a way to do that. This method should be called
	// only from GameController.Start() as part of the usual Unity lifecycle.
	public static void init()
	{
		activePlayer = 0;
	}

	// change the activePlayer. called after a move was successfully placed and a player's turn has finished.
	public static int changeActivePlayer()
	{
		activePlayer = (activePlayer == playerOne) ? playerTwo : playerOne;
		
		return activePlayer;
	}
}
