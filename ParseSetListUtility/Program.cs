using System;
using System.Linq;
using System.Text;

public class Program
{
     static void Main()
    {
        string workingDirectory = Environment.CurrentDirectory;
        string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.Parent.FullName;
        List<string> weights = new List<string>{"Medium", "Light", "Heavy" };
        List<string> armorTypes = new List<string> { 
            "Head",
            "Shoulder",
            "Chest",
            "Belt",
            "Gloves",
            "Pants",
        };
        List<string> otherEquipables = new List<string>
        {
            "Necklace",
            "Ring",
            "Flame",
            "Frost",
            "Lightning",
            "Resto",
            "Dagger",
            "Sword",
            "Mace",
            "Axe",
            "Greatsword",
            "Maul",
            "Battleaxe",
            "Shield"
        };
        List<string> DatabaseColumns = new List<string> ();

        foreach (var weight in weights) {
            foreach (var type in armorTypes)
            {
                DatabaseColumns.Add($"Has{weight}{type} bit,");
            }
        }
        foreach (var type in otherEquipables) {
            DatabaseColumns.Add($"Has{type} bit,");
        }
    
        StringBuilder sb = new StringBuilder();
        foreach (var item in DatabaseColumns)
        {
            sb.AppendLine(item);
        }
        File.WriteAllText($"{projectDirectory}\\BuildManager.Scripts\\ItemEquippableTableBuilder.txt", sb.ToString());
    }
}