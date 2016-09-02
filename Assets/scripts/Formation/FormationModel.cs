using System.Collections.Generic;

public class FormationModel
{
	public string formationType;
	public List<FormationPointModel> points;


	public FormationModel(string type, List<FormationPointModel> pointsToAdd)
	{
		this.formationType = type;
		this.points = new List<FormationPointModel>(pointsToAdd);
	}

	public bool isPointWithinFormation(FormationPointModel comparePoint)
	{
		for (var i = 0; i < this.points.Count; i++)
		{
			FormationPointModel point = this.points[i];

			if (FormationModelComparator.isEqual(point, comparePoint))
			{
				return true;
			}
		}
		
		return false;
	}
}
