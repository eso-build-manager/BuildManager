using System;
using System.Linq;
using System.Reflection;
using System.Text;
using Buildmanager.Library.Services;
using BuildManager.Library.DatabaseModels;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

public class ParseSkillUtility
{
    public ParseSkillUtility()
    {
        ParseSkill();
    }

    public static async Task ParseSkill()
    {
        string workingDirectory = Environment.CurrentDirectory;
        string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.Parent.FullName;
        string Skillcsv = $"{projectDirectory}\\BuildManager.Scripts\\ProcessedSkillSummaries.txt";

        using (var reader = new StreamReader(Skillcsv))
        {
            var csv = reader.ReadToEnd();

            var itemSkill = csv.Split('[').Where(p => !p.Equals(""));
            var count = 0;
            foreach (var item in itemSkill)
            {
                count++;
                var list = item.Split("*");


                Skill skill = ParseSkill(list);
                await InsertSkill(skill);
            }
            Console.WriteLine($"Total Skills Imported (should be 780): {count}");
        }
        Console.ReadKey();
    }

    public static Skill ParseSkill(string[] list)
    {
        var skill = new Skill();
        skill.SkillId = Convert.ToInt32(list[0]);
        skill.SkillTypeName = list[1];
        skill.BaseName = list[2];
        skill.Name = list[3];
        skill.Type = list[4];
        skill.Cost = list[5];
        skill.SkillIndex = Convert.ToInt16(list[6]);
        skill.Description = list[7];
        skill.ImagePath = list[8];

        return skill;
    }


    public static async Task InsertSkill(Skill skill)
    {
        var response = await ApiService.GetAllSetUsableItemSlotss();
        //Console.WriteLine(response.StatusCode + $"skillName: {skill.Name} skillId: {skill.SkillId}");
    }
}
