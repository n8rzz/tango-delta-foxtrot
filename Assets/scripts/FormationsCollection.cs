using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class FormationsCollection
{
	private Dictionary<string, List<int[][]>> possibleFormations = new Dictionary<string, List<int[][]>>();
	private List<FormationModel> formations = new List<FormationModel>();

	public FormationsCollection()
	{
//		possibleFormations.Add("ROW_NATURAL", FormationBuilder.buildRows("NATURAL"));
//		possibleFormations.Add("ROW_ASCENDING", FormationBuilder.buildRows("ASCENDING"));
//		possibleFormations.Add("ROW_DESCENDING", FormationBuilder.buildRows("DESCENDING"));
//		possibleFormations.Add("COLUMN_NATURAL", FormationBuilder.buildColumns("NATURAL"));
//		possibleFormations.Add("COLUMN_ASCENDING", FormationBuilder.buildColumns("ASCENDING"));
//		possibleFormations.Add("COLUMN_DESCENDING", FormationBuilder.buildColumns("DESCENDING"));
//		possibleFormations.Add("DIAGONAL_NATURAL", FormationBuilder.buildDiagonals("NATURAL"));
//		possibleFormations.Add("DIAGONAL_ASCENDING", FormationBuilder.buildDiagonals("ASCENDING"));
//		possibleFormations.Add("DIAGONAL_DESCENDING", FormationBuilder.buildDiagonals("DESCENDING"));
//		possibleFormations.Add("STACK_NATURAL", FormationBuilder.buildStacks());

//		buildFormationModels();
	}

	void buildFormationModels()
	{
		foreach (var formation in possibleFormations)
		{
			createNewModelsFromFormations(formation.Key, formation.Value);
		}
	}

	void createNewModelsFromFormations(string formationType, List<int[][]> formationList)
	{
//		Debug.Log(formationList.Count + ":" + formationName);
		for (var i = 0; i < formationList.Count; i++)
		{
//			FormationModel formationModel = new FormationModel(formationType, formationList[i]);

//			addFormationToCollection(formationModel);
		}
	}

	void addFormationToCollection(FormationModel formationToAdd)
	{
//		Debug.Log(formationToAdd.formationType);
		
//		formations.Add(formationToAdd);
	}
}
