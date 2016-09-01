using System.Collections.Generic;

public class FormationModel
{
	public string formationType;
	public List<FormationPointModel> pointList = new List<FormationPointModel>();


	public FormationModel(string type, List<FormationPointModel> pointsToAdd)
	{
		this.formationType = type;
		this.pointList = new List<FormationPointModel>(pointsToAdd);
	}
}
