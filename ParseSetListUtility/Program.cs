using System;
using System.Linq;
using System.Reflection;
using System.Text;
using Buildmanager.Library.Services;
using BuildManager.Library;
using BuildManager.Library.DataBaseModels;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

public class Program
{
    public static async Task Main()
    {
        string workingDirectory = Environment.CurrentDirectory;
        string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.Parent.FullName;
        string setlistcsv = $"{projectDirectory}\\BuildManager.Scripts\\noHeadingsProcessedSetSummaries.txt";

        using (var reader = new StreamReader(setlistcsv))
        {
            var csv = reader.ReadToEnd();

            var itemSetList = csv.Split('[').Where(p => !p.Equals(""));
            foreach (var item in itemSetList)
            {
                var fullSetDetails = item.Split("{");
                var setDetails = fullSetDetails[0].Substring(0, fullSetDetails[0].Length - 1);
                var usableItems = fullSetDetails[1].Substring(0, fullSetDetails[1].Length - 5);
                var setId = Convert.ToInt16(setDetails.Split("*")[0]);

                await InsertSetDetails(setDetails);
                var suits = DetermineSetUsableItems(usableItems, setId);
                await InsertSetUsableItems(suits);
            }
        }
        Console.ReadKey();
    }

    public static async Task InsertSetDetails(string setDetails)
    {
        // you shouldn't name variables acronyms, but i don't want to type that over and over again. sdl = setDetailsList
        var sdl = setDetails.Split("*").Where(p => p != "").ToArray();
        SetList setList = new SetList();
        setList.SetId = Convert.ToInt16(sdl[0]);
        setList.SetName = sdl[1];
        setList.Type = sdl[2];
        setList.Sources = sdl[3];
        setList.SetMaxEquipCount = Convert.ToByte(sdl[4]);
        setList.SetBonusCount = Convert.ToByte(sdl[5]);
        setList.SetBonusDescription = sdl[6];
        var response = await ApiService.CreateSetList(setList);
        Console.WriteLine(response.StatusCode + " " + setList.SetName);

    }

    // Duplicate code could be cleaned up into generic methods.
    public static SetUsableItemSlots DetermineSetUsableItems(string usableItems, short setId)
    {
        SetUsableItemSlots suits = new SetUsableItemSlots();
        suits.SetId = setId;
        BindingFlags bindingAttributes = BindingFlags.IgnoreCase | BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.SetProperty;

        bool hasHeavy = usableItems.Contains("Heavy");
        bool hasAllHeavy = usableItems.Contains("Heavy(All)");
        bool hasMedium = usableItems.Contains("Medium");
        bool hasAllMedium = usableItems.Contains("Medium(All)");
        bool hasLight = usableItems.Contains("Light");
        bool hasAllLight = usableItems.Contains("Light(All)");

        bool hasWeapons = usableItems.Contains("Weapon");
        bool hasAllWeapons = usableItems.Contains("Weapons(All)");
        bool hasShield = usableItems.Contains("Shield");
        bool hasNecklace = usableItems.Contains("Neck");
        bool hasRing = usableItems.Contains("Ring");
        var equipment = usableItems.Split(")");

        if (hasHeavy)
        {
            if (hasAllHeavy)
            {
                suits.HasHeavyBelt = true;
                suits.HasHeavyChest = true;
                suits.HasHeavyGloves = true;
                suits.HasHeavyHead = true;
                suits.HasHeavyPants = true;
                suits.HasHeavyShoulder = true;
            }
            else
            {
                var elements = equipment.Where(p => p.Contains("Heavy")).FirstOrDefault().Split("(")[1].Split('*');
                foreach (var equipmentType in elements)
                {
                    Type t = suits.GetType();
                    PropertyInfo? prop = t.GetProperty($"HasHeavy{equipmentType}", bindingAttributes);
                    if (prop != null)
                    {
                        prop.SetValue(suits, true, null);
                    }
                }
            }
        }
        if (hasMedium)
        {
            if (hasAllMedium)
            {
                suits.HasMediumBelt = true;
                suits.HasMediumChest = true;
                suits.HasMediumGloves = true;
                suits.HasMediumHead = true;
                suits.HasMediumPants = true;
                suits.HasMediumShoulder = true;
            }
            else
            {
                var elements = equipment.Where(p => p.Contains("Medium")).FirstOrDefault().Split("(")[1].Split('*');
                foreach (var equipmentType in elements)
                {
                    Type t = suits.GetType();
                    PropertyInfo? prop = t.GetProperty($"HasMedium{equipmentType}", bindingAttributes);
                    if (prop != null)
                    {
                        prop.SetValue(suits, true, null);
                    }
                }
            }
        }
        if (hasLight)
        {
            if (hasAllLight)
            {
                suits.HasLightBelt = true;
                suits.HasLightChest = true;
                suits.HasLightGloves = true;
                suits.HasLightHead = true;
                suits.HasLightPants = true;
                suits.HasLightShoulder = true;
            }
            else
            {
                var elements = equipment.Where(p => p.Contains("Light")).FirstOrDefault().Split("(")[1].Split('*');
                foreach (var equipmentType in elements)
                {
                    Type t = suits.GetType();
                    PropertyInfo? prop = t.GetProperty($"HasLight{equipmentType}", bindingAttributes);
                    if (prop != null)
                    {
                        prop.SetValue(suits, true, null);
                    }
                }
            }
        }
        if (hasWeapons)
        {
            if (hasAllWeapons)
            {
                suits.HasAxe = true;
                suits.HasDagger = true;
                suits.HasSword = true;
                suits.HasMace = true;

                suits.HasFrost = true;
                suits.HasFlame = true;
                suits.HasLightning = true;
                suits.HasResto = true;

                suits.HasMaul = true;
                suits.HasBattleaxe = true;
                suits.HasGreatsword = true;

            }
            else
            {
                var elements = equipment.Where(p => p.Contains("Weapons")).FirstOrDefault().Split("(")[1].Split('*');
                foreach (var equipmentType in elements)
                {
                    Type t = suits.GetType();
                    PropertyInfo? prop = t.GetProperty($"Has{equipmentType}", bindingAttributes);
                    if (prop != null)
                    {
                        prop.SetValue(suits, true, null);
                    }
                }
            }
        }
        if (hasShield)
        {
            suits.HasShield = true;
        }
        if (hasNecklace)
        {
            suits.HasNecklace = true;
        }
        if (hasRing)
        {
            suits.HasRing = true;
        }
        return suits;
    }


    public static async Task InsertSetUsableItems(SetUsableItemSlots usableItems)
    {
       var response = await ApiService.CreateSetUsableItemSlots(usableItems);
       Console.WriteLine(response.StatusCode + $" SetId: {usableItems.SetId}");
    }
}
