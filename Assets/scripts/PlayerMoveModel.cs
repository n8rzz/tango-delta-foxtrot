using System.Collections;

public class PlayerMoveModel
{
	public int playerNumber;
	public FormationPointModel movePosition;

	public PlayerMoveModel(int playerNumber, string gameBoardPosition)
	{
		this.playerNumber = playerNumber;
		this.movePosition = new FormationPointModel(
			extractBoardPositionFromPostName(gameBoardPosition)
		);
	}

	private int[] extractBoardPositionFromPostName(string postname)
	{
		// todo: optimize, possibly with below strategy
		// string[] test = new string[] {"1", "2", "3", "4", "5"};
		// int[] arr = Array.ConvertAll<string, int>(test, int.Parse);

		int[] gameBoardPosition = new int[3];
		string[] positions = postname.Split('-');

		for (int i = 0; i < positions.Length; i++)
		{
			gameBoardPosition[i] = System.Int32.Parse(positions[i]);
		}

		return gameBoardPosition;
	}
}
