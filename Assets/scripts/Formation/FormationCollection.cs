using System.Collections.Generic;

public class FormationCollection
{
    public List<FormationModel> formations = new List<FormationModel>();

// 	// This will filter out the list of ints that are > than 7, Where returns an
// 	// IEnumerable<T> so a call to ToList is required to convert back to a List<T>.
// 	// List<int> filteredList = myList.Where( x => x > 7).ToList();

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

    public List<FormationModel> filterFormationsForPoint(PointModel point)
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
