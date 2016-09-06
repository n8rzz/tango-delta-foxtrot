public class PlayerMoveModel
{ 
	private static int ID = 0;

	public int id;
	public int player;
	public PointModel point;


	public PlayerMoveModel(string gameBoardPosition)
	{
		ID++;
		this.id = ID;
		this.player = PlayerTurnController.activePlayer;
		
		addPoint(gameBoardPosition);
	}

	public PlayerMoveModel(int player, string gameBoardPosition)
	{
		ID++;
		this.id = ID;
		this.player = player;
		
		addPoint(gameBoardPosition);
	}

	// add a point to this instance
	// originally split from the postname, gameBoardPosition is passed in as a string '0-0-0'
	// this string is run through a translator and returned as an int[] [0, 0, 0]
	private void addPoint(string gameBoardPosition)
	{
		 PointModel pointToAdd = new PointModel(translatePostNameToBoardPosition(gameBoardPosition));
		 this.point = pointToAdd;
	}

	// translate the string position to an int[3]
	private int[] translatePostNameToBoardPosition(string postname)
	{
		int[] gameBoardPosition = new int[3];
		string[] positions = postname.Split('-');

		for (int i = 0; i < positions.Length; i++)
		{
			gameBoardPosition[i] = System.Int32.Parse(positions[i]);
		}

		return gameBoardPosition;
	}

	// translate the current int[3] points to a string that can be used to locate a gameObject 
	// playerone_0-0-0
	// playertwo_0-0-0
	public string translateBoardPositionToPieceName()
	{
		string playerName = (player == 0) ? "playerone" : "playertwo";

		return playerName + "_" + point.level + "-" + point.row + "-" + point.column;
	}
}
