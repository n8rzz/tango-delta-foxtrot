using System.Collections;

public class PlayerMoveModel
{
	public int playerNumber;
	public PointModel movePosition;

	public PlayerMoveModel(int playerNumber, string gameBoardPosition)
	{
		this.playerNumber = playerNumber;
		this.movePosition = new PointModel(
			extractBoardPositionFromPostName(gameBoardPosition)
		);
	}

	private int[] extractBoardPositionFromPostName(string postname)
	{
		int[] gameBoardPosition = new int[3];
		string[] positions = postname.Split('-');

		for (int i = 0; i < positions.Length; i++)
		{
			gameBoardPosition[i] = System.Int32.Parse(positions[i]);
		}

		return gameBoardPosition;
	}
}
