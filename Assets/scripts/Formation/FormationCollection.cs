using System.Collections.Generic;
using System.Linq;

//
public class FormationCollection
{
    public List<FormationModel> formations = new List<FormationModel>();


    public FormationCollection()
    {
        List<FormationModel> possibleFormations = new List<FormationModel>(FormationModelBuilder.buildFormationModelsFromPossibleFormations());

        addFormationListToCollection(possibleFormations);
    }

    // given a list, loop through each item and add it to this.formations
    private void addFormationListToCollection(List<FormationModel> formationList)
    {
        for (var i = 0; i < formationList.Count; i++)
        {
            addFormationToCollection(formationList[i]);
        }
    }

    // add a single formation to this.formations
    private void addFormationToCollection(FormationModel formationToAdd)
    {
        this.formations.Add(formationToAdd);
    }

    // find all the formations that contain the point
    public List<FormationModel> filterFormationsForPoint(PointModel point)
    {
        List<FormationModel> filteredFormations = formations.Where(formation => formation.isPointWithinFormation(point)).ToList();

        return filteredFormations;
    }
}
