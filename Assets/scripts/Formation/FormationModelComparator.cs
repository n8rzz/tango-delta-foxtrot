public static class FormationModelComparator
{
	public static bool isEqual(FormationPointModel point, FormationPointModel comparePoint)
	{
		return point.level == comparePoint.level && 
			point.row == comparePoint.row && 
			point.column == comparePoint.column;
	}
}
