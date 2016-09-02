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


    public static bool addPlayerAtPoint(int player, FormationPointModel point)
    {
        if (!isValidMove(point)) {
            return false;
        }

        gameBoard[point.level][point.row][point.column] = player;

        return true;
    }

    public static bool isValidMove(FormationPointModel point)
    {
        if (point.isPointOnBottomLevel())
        {
            return isPointAvailable(point); 
        }

        int level = point.findLevelBelowPoint();
        FormationPointModel comparePoint = new FormationPointModel(level, point.row, point.column);

        return isPointAvailable(point) && (findPlayerForPoint(comparePoint) != INVALID_PLAYER);
    }

    public static bool isPointAvailable(FormationPointModel point)
    {
        return findPlayerForPoint(point) == INVALID_PLAYER;
    }

    public static int findPlayerForPoint(FormationPointModel point)
    {
        int level = point.level;
        int row = point.row;
        int column = point.column;
        int playerAtPoint = gameBoard[level][row][column]; 
        
        return playerAtPoint;
    }

    // public static void addToHistory(int player, FormationPointModel point)
    // {
    //     this.gameHistory.addPlayerMoveToHistory(player, point);
    // }

    public static FormationModel findWinningFormation(int player, FormationPointModel point)
    {
        // if (gameHistory.Count > 7)
        // {
            List<FormationModel> formations = FormationCollection.filterFormationsForPoint(point);

            for (var i = 0; i < formations.Count; i++)
            {
                FormationModel formation = formations[i];

                if (isWinningFormation(player, formations[i].points))
                {
                    return formation;
                }
            }
        // }

        return null;
    }

    private static bool isWinningFormation(int player, List<FormationPointModel> formationPoints)
    {
        for (var i = 0; i < formationPoints.Count; i++)
        {
            FormationPointModel point = formationPoints[i];

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
