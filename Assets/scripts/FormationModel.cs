using UnityEngine;
using System.Collections;

public class FormationModel
{
	private string formationType;
	public ArrayList pointList = new ArrayList();

	public FormationModel(string fType, int[][] pointsToAdd)
	{
		formationType = fType;

		_addPointsToPointList(pointsToAdd);
	}

	void _addPointsToPointList(int[][] pointsToAdd)
	{
		for (var i = 0; i < pointsToAdd.GetLength(0); i++)
		{
			pointList.Add(pointsToAdd[i]);	
		}
	}
}
