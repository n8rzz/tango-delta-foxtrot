public static class FormationModelComparator
{
	public static bool isEqual(PointModel point, PointModel comparePoint)
	{
		return point.level == comparePoint.level && 
			point.row == comparePoint.row && 
			point.column == comparePoint.column;
	}
}
