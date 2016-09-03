using System.Collections;
using System.Collections.Generic;

public static class GameBoardController
{

    private static int INVALID_PLAYER = -1;
    static FormationCollection FormationCollection = new FormationCollection();
    // GameHistory gameHistory = new GameHistory();
    static int[][][] gameBoard =
    {
        new[] {
            new int[] {-1, -1, -1, -1},
            new int[] {-1, -1, -1, -1},
            new int[] {-1, -1, -1, -1},
            new int[] {-1, -1, -1, -1}
        },
        new[] {
            new int[] {-1, -1, -1, -1},
            new int[] {-1, -1, -1, -1},
            new int[] {-1, -1, -1, -1},
            new int[] {-1, -1, -1, -1}
        },
        new[] {
            new int[] {-1, -1, -1, -1},
            new int[] {-1, -1, -1, -1},
            new int[] {-1, -1, -1, -1},
            new int[] {-1, -1, -1, -1}
        },
        new[] {
            new int[] {-1, -1, -1, -1},
            new int[] {-1, -1, -1, -1},
            new int[] {-1, -1, -1, -1},
            new int[] {-1, -1, -1, -1}
        }
    };

    static public int[][][] GameBoard {
        get { return gameBoard; }
    }


    public static bool addPlayerAtPoint(PlayerMoveModel moveToMake)
    {
        if (!isValidMove(moveToMake.point)) {
            return false;
        }

        int level = moveToMake.point.level;
        int row = moveToMake.point.row;
        int column = moveToMake.point.column;

        gameBoard[level][row][column] = moveToMake.player;

        return true;
    }

    public static bool isValidMove(PointModel point)
    {
        if (point.isPointOnBottomLevel())
        {
            return isPointAvailable(point); 
        }

        int level = point.findLevelBelowPoint();
        PointModel comparePoint = new PointModel(level, point.row, point.column);

        return isPointAvailable(point) && (findPlayerForPoint(comparePoint) != INVALID_PLAYER);
    }

    public static bool isPointAvailable(PointModel point)
    {
        return findPlayerForPoint(point) == INVALID_PLAYER;
    }

    public static int findPlayerForPoint(PointModel point)
    {
        int level = point.level;
        int row = point.row;
        int column = point.column;
        int playerAtPoint = gameBoard[level][row][column]; 
        
        return playerAtPoint;
    }

    public static void addToHistory(int player, string point, PlayerMoveModel moveToMake)
    {
        // FIXME: moveToAdd should be a passed param of type PlayerMoveModel
        PlayerMoveModel moveToAdd = new PlayerMoveModel(player, point);
        // FIXME: Passing moveToMake causes a failure to find System.Collections.Generic
        GameBoardHistory.addMoveToHistory(moveToAdd);
    }

    public static FormationModel findWinningFormation(PlayerMoveModel moveToMake)
    {
        if (GameBoardHistory.isWinPossible())
        {
            List<FormationModel> formations = FormationCollection.filterFormationsForPoint(moveToMake.point);

            for (var i = 0; i < formations.Count; i++)
            {
                FormationModel formation = formations[i];

                if (isWinningFormation(moveToMake.player, formations[i].points))
                {
                    return formation;
                }
            }
        }

        return null;
    }

    private static bool isWinningFormation(int player, List<PointModel> formationPoints)
    {
        for (var i = 0; i < formationPoints.Count; i++)
        {
            PointModel point = formationPoints[i];

            if (findPlayerForPoint(point) != player)
            {
                return false;
            }
        }

        return true;
    }

    public static void resetGameBoard() 
    {
        for (var level = 0; level < gameBoard.GetLength(0); level++) 
        {
            for (var row = 0; row < gameBoard.GetLength(0); row++) 
            {
                for (var column = 0; column < gameBoard.GetLength(0); column++) 
                {
                    gameBoard[level][row][column] = INVALID_PLAYER;
                }

            }
        }
    }
}
