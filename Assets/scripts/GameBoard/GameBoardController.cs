using System.Collections.Generic;
using System.Linq;

public static class GameBoardController
{
    private static int INVALID_PLAYER = -1;
    private static FormationCollection FormationCollection = new FormationCollection();
    private static int[][][] gameBoard =
    {
        new[] {
            new int[] {INVALID_PLAYER, INVALID_PLAYER, INVALID_PLAYER, INVALID_PLAYER},
            new int[] {INVALID_PLAYER, INVALID_PLAYER, INVALID_PLAYER, INVALID_PLAYER},
            new int[] {INVALID_PLAYER, INVALID_PLAYER, INVALID_PLAYER, INVALID_PLAYER},
            new int[] {INVALID_PLAYER, INVALID_PLAYER, INVALID_PLAYER, INVALID_PLAYER}
        },
        new[] {
            new int[] {INVALID_PLAYER, INVALID_PLAYER, INVALID_PLAYER, INVALID_PLAYER},
            new int[] {INVALID_PLAYER, INVALID_PLAYER, INVALID_PLAYER, INVALID_PLAYER},
            new int[] {INVALID_PLAYER, INVALID_PLAYER, INVALID_PLAYER, INVALID_PLAYER},
            new int[] {INVALID_PLAYER, INVALID_PLAYER, INVALID_PLAYER, INVALID_PLAYER}
        },
        new[] {
            new int[] {INVALID_PLAYER, INVALID_PLAYER, INVALID_PLAYER, INVALID_PLAYER},
            new int[] {INVALID_PLAYER, INVALID_PLAYER, INVALID_PLAYER, INVALID_PLAYER},
            new int[] {INVALID_PLAYER, INVALID_PLAYER, INVALID_PLAYER, INVALID_PLAYER},
            new int[] {INVALID_PLAYER, INVALID_PLAYER, INVALID_PLAYER, INVALID_PLAYER}
        },
        new[] {
            new int[] {INVALID_PLAYER, INVALID_PLAYER, INVALID_PLAYER, INVALID_PLAYER},
            new int[] {INVALID_PLAYER, INVALID_PLAYER, INVALID_PLAYER, INVALID_PLAYER},
            new int[] {INVALID_PLAYER, INVALID_PLAYER, INVALID_PLAYER, INVALID_PLAYER},
            new int[] {INVALID_PLAYER, INVALID_PLAYER, INVALID_PLAYER, INVALID_PLAYER}
        }
    };

    public static int[][][] GameBoard {
        get { return gameBoard; }
    }


    //
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

    //
    public static bool removePlayerAtPoint(PlayerMoveModel moveToRemove) 
    {
        if (findPlayerAtPoint(moveToRemove.point) == moveToRemove.player)
        {
            int level = moveToRemove.point.level;
            int row = moveToRemove.point.row;
            int column = moveToRemove.point.level;
            
            gameBoard[level][row][column] = INVALID_PLAYER;
            
            return true;
        }

        return false;
    }

    //
    public static bool isValidMove(PointModel point)
    {
        if (point.isPointOnBottomLevel())
        {
            return isPointAvailable(point); 
        }

        int level = point.findLevelBelowPoint();
        PointModel comparePoint = new PointModel(level, point.row, point.column);

        return isPointAvailable(point) && (findPlayerAtPoint(comparePoint) != INVALID_PLAYER);
    }

    //
    public static bool isPointAvailable(PointModel point)
    {
        return findPlayerAtPoint(point) == INVALID_PLAYER;
    }

    //
    public static int findPlayerAtPoint(PointModel point)
    {
        int level = point.level;
        int row = point.row;
        int column = point.column;
        int playerAtPoint = gameBoard[level][row][column]; 
        
        return playerAtPoint;
    }

    //
    public static FormationModel findWinningFormation(PlayerMoveModel moveToMake)
    {
        if (GameBoardHistory.isWinPossible())
        {
            List<FormationModel> formations = FormationCollection.filterFormationsForPoint(moveToMake.point);
            List<FormationModel> formation = formations.Where(f => isWinningFormation(moveToMake.player, f.points)).ToList();

            if (formation.Count != 0)
            {
                return formation[0];
            }
        }

        return null;
    }
    
    //
    private static bool isWinningFormation(int player, List<PointModel> formationPoints)
    {
        for (var i = 0; i < formationPoints.Count; i++)
        {
            PointModel point = formationPoints[i];

            if (findPlayerAtPoint(point) != player)
            {
                return false;
            }
        }

        return true;
    }

    //
    public static int findPiecesOnPostForRowAndColumn(int row, int column)
    {
        int count = 0;

        for (var level = 0; level < gameBoard.GetLength(0); level++) 
        {
            PointModel point = new PointModel(level, row, column);

            if (foundPoint != INVALID_PLAYER)
            {
                count++;
            }
        }

        return count;
    }

    //
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
