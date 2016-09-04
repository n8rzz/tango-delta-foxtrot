using System.Collections.Generic;

public class PointModel
{
    private static int ID = 0;
    public int id;
    public int level;
    public int row;
    public int column;

    public PointModel(int[] playerMove)
    {
        ID++;
		this.id = ID;

        this.level = playerMove[0];
        this.row = playerMove[1];
        this.column = playerMove[2];
    }

    public PointModel(int level, int row, int column)
    {
        ID++;
		this.id = ID;

        this.level = level;
        this.row = row;
        this.column = column;
    }

    public bool isPointOnBottomLevel()
    {
        return level == 0;
    }

    public int findLevelBelowPoint()
    {
        return level - 1;
    }
}
