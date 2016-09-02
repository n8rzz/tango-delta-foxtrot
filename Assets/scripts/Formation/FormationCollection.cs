using System.Collections.Generic;

public class FormationCollection
{
    public List<FormationModel> formations = new List<FormationModel>();


    public FormationCollection()
    {
        List<FormationModel> possibleFormations = new List<FormationModel>(FormationModelBuilder.buildFormationModelsFromPossibleFormations());

        addFormationListToCollection(possibleFormations);
    }

    private void addFormationListToCollection(List<FormationModel> formationList)
    {
        for (var i = 0; i < formationList.Count; i++)
        {
            addFormationToCollection(formationList[i]);
        }
    }

    private void addFormationToCollection(FormationModel formationToAdd)
    {
        this.formations.Add(formationToAdd);
    }

    public List<FormationModel> filterFormationsForPoint(FormationPointModel point)
    {
        List<FormationModel> filteredFormations = new List<FormationModel>();

        for (var i = 0; i < this.formations.Count; i++)
        {
            FormationModel formation = this.formations[i];

            if (formation.isPointWithinFormation(point))
            {
                filteredFormations.Add(formation);
            }
        }

        return filteredFormations;
    }
}
