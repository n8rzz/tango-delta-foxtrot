using System.Collections.Generic;

public class FormationModel
{
	private static int ID = 0;
	public int id;

	public string type;
	public List<PointModel> points;


	public FormationModel(string type, List<PointModel> pointsToAdd)
	{
		ID++;
		this.id = ID;
		this.type = type;
		this.points = new List<PointModel>(pointsToAdd);
	}

	// FIXME: Optimize the loops
	// given a comparePoint, determine if that point is within this model's points.
	public bool isPointWithinFormation(PointModel comparePoint)
	{
		for (var i = 0; i < this.points.Count; i++)
		{
			PointModel point = this.points[i];

			if (FormationModelComparator.isEqual(point, comparePoint))
			{
				return true;
			}
		}
		
		return false;
	}
}
