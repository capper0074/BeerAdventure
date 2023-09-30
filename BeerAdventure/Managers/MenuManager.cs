using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeerAdventure.Character;
using BeerAdventure.Sections;

namespace BeerAdventure.Managers;

public static class MenuManager
{
    static Section DisplaySection(Player player)
    {
        if (player != null)
        {
            Section section = player.CurrentSection;

            return section;
        }
        return null;
    }

    static List<Choice> DisplayChoices(Section section)
    {
        List<Choice> choicesList = new List<Choice>();
        if (section != null)
        {
            if (section.Choices != null)
                foreach (Choice choice in section.Choices)
                {
                    choicesList.Add(choice);
                }
            else
            {
                Choice emptyChoice = new();
                emptyChoice.Description = "There appears to be no choices";
                choicesList.Add(emptyChoice);
            }
        }
        return choicesList;
    }
}


