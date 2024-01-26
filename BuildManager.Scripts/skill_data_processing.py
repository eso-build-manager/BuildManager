# Source: https://esoitem.uesp.net/viewlog.php?record=skillTree
# Usage: Download table from above link and save as .xlsx via Excel's save from web feature
# Command: 'python skill_data_processing.py <path>'
# Purpose: Process skill data from UESP into the format used by the build manager's database

def process(path):
    skillTable = pd.DataFrame()
    try:
        file = pd.ExcelFile(path)
              
        for sheet in file.sheet_names:
            temp = pd.read_excel(path, sheet_name=sheet)
            skillTable = pd.concat([skillTable, temp], axis=0, ignore_index=True)
        
    except Exception as e:
        print(e)
        return
    
    # Drop passives entirely
    skillTable = skillTable[skillTable.type != "Passive"]    
    # Drop Column1 and id
    skillTable = skillTable.drop(columns=["Column1", "id", "icon", "learnedLevel", "rank", "maxRank"])    
    # Repurpose '2' for image path
    skillTable.rename(columns={'abilityId': 'skillId', '2': 'imgPath'}, inplace=True)
    
    # Filter out all partially leveled skills. Leaves 1 entry for base skill and 1 for each morph
    toDropIndex = []
    prevName = ""
    for i, row in skillTable.iterrows():
        name = row["name"]
        if name == prevName:
            toDropIndex.append(i - 1)
            
        prevName = name
                
    skillTable = skillTable.drop(toDropIndex)
    
    # Set imgPath strings and append ']' delimiter
    skillTable.imgPath = skillTable.apply(lambda row: f"/Resources/images/skills/{row['name']}]", axis=1)
    skillTable.imgPath = skillTable.imgPath.str.replace(" ", "_")
    
    # Prepend '[' delimiter
    skillTable.skillId = '[' + skillTable.skillId.astype(str)
    
    # Save skill data
    try:
        if os.path.exists("ProcessedSkillSummaries.csv"):
            os.remove("ProcessedSkillSummaries.csv")
        if os.path.exists("ProcessedSkillSummaries.txt"):   
            os.remove("ProcessedSkillSummaries.txt")
            
        skillTable.to_csv("ProcessedSkillSummaries.csv", index=False)
        skillTable.to_csv("ProcessedSkillSummaries.txt", sep="*", index=False)
        print("Saved set data to 'ProcessedSkillSummaries.csv and ProcessedSkillSummaries.txt'")
    except Exception as e:
        print(f"Failed to save processed set data: {e}")   
    
    return

if __name__ == "__main__":
    import os
    import sys
    import pandas as pd
    
    if len(sys.argv) != 2:
        print("Usage: python skill_data_processing.py <path>")
        sys.exit(1)
        
    path = sys.argv[1]
    process(path)