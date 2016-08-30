using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FormationModel
{
	public string formationType;
	public List<int[]> pointList = new List<int[]>();

	public FormationModel(string fType, List<int[]> pointsToAdd)
	{
		formationType = fType;
		pointList = pointsToAdd;

//		_addPointsToPointList(pointsToAdd);
	}

//	void _addPointsToPointList(int[][] pointsToAdd)
//	{
//		for (var i = 0; i < pointsToAdd.GetLength(0); i++)
//		{
//			pointList.Add(pointsToAdd[i]);	
//		}
//	}
}
