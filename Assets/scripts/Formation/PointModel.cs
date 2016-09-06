// Provide a definition of a Point and how it relates to the gameBoard.
public class PointModel
{
    private static int ID = 0;
    public int id;

    // Z-axis
    public int level;
    // Y-axis
    public int row;
    // X-axis
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

    // determine if this is located on the bottom level of the gameBoard
    public bool isPointOnBottomLevel()
    {
        return level == 0;
    }

    // find the level below this.level.
    // 
    // this method should not be used by itself and should instead be used in conjunction 
    // with this.isPointOnBottomLevel()
    public int findLevelBelowPoint()
    {
        return level - 1;
    }
}
