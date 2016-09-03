﻿using System.Collections.Generic;

public class FormationModel
{
	public string type;
	public List<PointModel> points;


	public FormationModel(string type, List<PointModel> pointsToAdd)
	{
		this.type = type;
		this.points = new List<PointModel>(pointsToAdd);
	}

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
