using System.Collections.Generic;

public class FormationCollection
{
    public List<FormationModel> formations = new List<FormationModel>();


    public FormationCollection()
    {
        List<FormationModel> possibleFormations = new List<FormationModel>(FormationModelBuilder.buildFormationModelsFromPossibleFormations());

        addFormationListToCollection(possibleFormations);
    }

    void addFormationListToCollection(List<FormationModel> formationList)
    {
        for (var i = 0; i < formationList.Count; i++)
        {
            addFormationToCollection(formationList[i]);
        }
    }

    void addFormationToCollection(FormationModel formationToAdd)
    {
        this.formations.Add(formationToAdd);
    }
}
