using System.Collections;
using System.Collections.Generic;

public class PlayerMoveModel
{ 
	public int player;
	public PointModel point;

	public PlayerMoveModel(int player, string gameBoardPosition)
	{
		this.player = player;
		
		addPoint(gameBoardPosition);
	}

	private void addPoint(string gameBoardPosition)
	{
		 PointModel pointToAdd = new PointModel(extractBoardPositionFromPostName(gameBoardPosition));
		 this.point = pointToAdd;
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
