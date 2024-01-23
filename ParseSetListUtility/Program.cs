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
    public static void Main()
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
                var setId = Convert.ToInt16(setDetails[0]);
                InsertSetDetails(setDetails).ConfigureAwait(false);
                var suits = DetermineSetUsableItems(usableItems, setId);
                InsertSetUsableItems(suits).ConfigureAwait(false);
            }
        }
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
        //await ApiService.CreateSetList(setList);

    }

    // to be extra we could replace this entire method with some reflection shenangians, but I'd say that that's overengineering. 
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
        return suits;
    }


    public static async Task InsertSetUsableItems(SetUsableItemSlots usableItems)
    {
       // await ApiService.CreateSetUsableItemSlots(usableItems);
    }
}
