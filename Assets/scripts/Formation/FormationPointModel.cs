public class FormationPointModel
{
    public int level;
    public int row;
    public int column;

    public FormationPointModel(int[] playerMove)
    {
        this.level = playerMove[0];
        this.row = playerMove[1];
        this.column = playerMove[2];
    }

    public FormationPointModel(int level, int row, int column)
    {
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
