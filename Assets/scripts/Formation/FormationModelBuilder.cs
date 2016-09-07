using System.Collections.Generic;

//
public static class FormationModelBuilder
{
    static private int MAX_LENGTH = 4;


    public static List<FormationModel> buildFormationModelsFromPossibleFormations()
    {
        List<FormationModel> formationModelList = new List<FormationModel>();
		
        formationModelList.AddRange(buildRows("NATURAL"));
        formationModelList.AddRange(buildRows("ASCENDING"));
        formationModelList.AddRange(buildRows("DESCENDING"));
        formationModelList.AddRange(buildColumns("NATURAL"));
        formationModelList.AddRange(buildColumns("ASCENDING"));
        formationModelList.AddRange(buildColumns("DESCENDING"));
        formationModelList.AddRange(buildDiagonals("NATURAL"));
        formationModelList.AddRange(buildDiagonals("ASCENDING"));
        formationModelList.AddRange(buildDiagonals("DESCENDING"));
        formationModelList.AddRange(buildStacks());

        return formationModelList;
    }

    private static List<FormationModel> buildRows(string variation)
    {
        List<FormationModel> allRows = new List<FormationModel>();

        switch (variation)
        {
            case "NATURAL":
                for (var level = 0; level < MAX_LENGTH; level++) {
                    for (var row = 0; row < MAX_LENGTH; row++) {
                        List<PointModel> singleRow = new List<PointModel>();

                        for (var cell = 0; cell < MAX_LENGTH; cell++) {
                            PointModel singleCellInRow = new PointModel(level, row, cell);
                            singleRow.Add(singleCellInRow);
                        }

                        FormationModel formationModelForRow = new FormationModel("ROW_NATURAL", singleRow);
                        allRows.Add(formationModelForRow);
                    }
                }

                break;
            case "ASCENDING":
                for (var row = 0; row < MAX_LENGTH; row++) {
                    List<PointModel> singleRow = new List<PointModel>();

                    for (var levelAndCell = 0; levelAndCell < MAX_LENGTH; levelAndCell++) {
                        PointModel singleCellInRow = new PointModel(levelAndCell, row, levelAndCell);
                        singleRow.Add(singleCellInRow);
                    }

                    FormationModel formationModelForRow = new FormationModel("ROW_ASCENDING", singleRow);
                    allRows.Add(formationModelForRow);
                }

                break;
            case "DESCENDING":
                for (var row = 0; row < MAX_LENGTH; row++) {
                    var decrementor = 3;
                    List<PointModel> singleRow = new List<PointModel>();

                    for (var cell = 0; cell < MAX_LENGTH; cell++) {
                        PointModel singleCellInRow = new PointModel(decrementor, row, cell);

                        singleRow.Add(singleCellInRow);
                        decrementor--;
                    }

                    FormationModel formationModelForRow = new FormationModel("ROW_DESCENDING", singleRow);
                    allRows.Add(formationModelForRow);
                }

                break;
            default:
                break;
        }

        return allRows;
    }

    private static List<FormationModel> buildColumns(string variation)
    {
        List<FormationModel> allColumns = new List<FormationModel>();

        switch (variation)
        {
            case "NATURAL":
                for (var level = 0; level < MAX_LENGTH; level++) {
                    for (var column = 0; column < MAX_LENGTH; column++) {
                        List<PointModel> singleColumn = new List<PointModel>();

                        for (var row = 0; row < MAX_LENGTH; row++) {
                            singleColumn.Add(new PointModel(level, row, column));
                        }

                        FormationModel formationModelForColumn = new FormationModel("COLUMN_NATURAL", singleColumn);
                        allColumns.Add(formationModelForColumn);
                    }
                }

                break;
            case "ASCENDING":
                for (var column = 0; column < MAX_LENGTH; column++) {
                    List<PointModel> singleColumn = new List<PointModel>();

                    for (var levelAndRow = 0; levelAndRow < MAX_LENGTH; levelAndRow++) {
                        singleColumn.Add(new PointModel(levelAndRow, levelAndRow, column));
                    }

                    FormationModel formationModelForColumn = new FormationModel("COLUMN_ASCENDING", singleColumn);
                    allColumns.Add(formationModelForColumn);
                }

                break;
            case "DESCENDING":
                for (var column = 0; column < MAX_LENGTH; column++) {
                    var decrementor = 3;
                    List<PointModel> singleColumn = new List<PointModel>();

                    for (var row = 0; row < MAX_LENGTH; row++) {
                        singleColumn.Add(new PointModel(decrementor, column, row));
                        decrementor--;
                    }

                    FormationModel formationModelForColumn = new FormationModel("COLUMN_DESCENDING", singleColumn);
                    allColumns.Add(formationModelForColumn);
                }

                break;
            default:
                break;
        }

        return allColumns;
    }

    private static List<FormationModel> buildDiagonals(string variation)
    {
        int incrementor = 0;
        int decrementor = 3;
        List<PointModel> topDiagonal = new List<PointModel>();
        List<PointModel> bottomDiagonal = new List<PointModel>();
        List<FormationModel> diagonals = new List<FormationModel>();

        switch (variation) {
            case "NATURAL":
                for (var level = 0; level < MAX_LENGTH; level++) {
                    decrementor = 3;

                    for (var i = 0; i < MAX_LENGTH; i++) {
                        topDiagonal.Add(new PointModel(level, i, i));
                        bottomDiagonal.Add(new PointModel(level, decrementor, i));

                        decrementor--;
                    }

                    FormationModel topNaturalDiagonalFormationToAdd = new FormationModel("DIAGONAL_NATURAL", topDiagonal);
                    FormationModel bottomNaturalDiagonalFormationToAdd = new FormationModel("DIAGONAL_NATURAL", bottomDiagonal);
                    diagonals.Add(topNaturalDiagonalFormationToAdd);
                    diagonals.Add(bottomNaturalDiagonalFormationToAdd);
                }

                break;
            case "ASCENDING":
                for (var i = 0; i < MAX_LENGTH; i++) {
                    topDiagonal.Add(new PointModel(i, i, i));
                    bottomDiagonal.Add(new PointModel(i, decrementor, i));

                    decrementor--;
                }

                FormationModel topAscendingDiagonalFormationToAdd = new FormationModel("DIAGONAL_ASCENDING", topDiagonal);
                FormationModel bottomAscendingDiagonalFormationToAdd = new FormationModel("DIAGONAL_ASCENDING", bottomDiagonal);
                diagonals.Add(topAscendingDiagonalFormationToAdd);
                diagonals.Add(bottomAscendingDiagonalFormationToAdd);

                break;
            case "DESCENDING":
                for (var i = 3; i >= 0; i--) {
                    topDiagonal.Add(new PointModel(i, incrementor, incrementor));
                    bottomDiagonal.Add(new PointModel(i, i, incrementor));

                    incrementor++;
                }

                FormationModel topDescendingDiagonalFormationToAdd = new FormationModel("DIAGONAL_DESCENDING", topDiagonal);
                FormationModel bottomDescendingDiagonalFormationToAdd = new FormationModel("DIAGONAL_DESCENDING", bottomDiagonal);
                diagonals.Add(topDescendingDiagonalFormationToAdd);
                diagonals.Add(bottomDescendingDiagonalFormationToAdd);

                break;
            default:
                break;
        }

        return diagonals;
    }

    private static List<FormationModel> buildStacks()
    {
        List<FormationModel> allStacks = new List<FormationModel>();

        for (var row = 0; row < MAX_LENGTH; row++) {
            for (var cell = 0; cell < MAX_LENGTH; cell++) {
                List<PointModel> singleStack = new List<PointModel>();

                for (var level = 0; level < MAX_LENGTH; level++) {
                    PointModel stack = new PointModel(level, row, cell);
                    singleStack.Add(stack);
                }

                FormationModel singleStackFormationToAdd = new FormationModel("STACK_NATURAL", singleStack);
                allStacks.Add(singleStackFormationToAdd);
            }
        }

        return allStacks;
    }
}
