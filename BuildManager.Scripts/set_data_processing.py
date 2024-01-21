# Source: https://esoitem.uesp.net/viewlog.php?record=setSummary
# Usage: Download table from above link and save as .xlsx via Excel's save from web feature
# Command: 'python set_data_processing.py <path>'
# Purpose: Process set data from UESP into the format used by the build manager's database

def process(path):
    try:
        setTable = pd.read_excel(path)
    except Exception as e:
        print(e)
        return
    
    # Rename gameId column to setId to play nicer with our database
    setTable.rename(columns={'gameId': 'setId'}, inplace=True)
    
    # Remove unnecessary columns
    try:
        setTable = setTable.drop(columns=["Column1", "itemCount", "Internal ID", "2", "setBonusDesc1", "setBonusDesc2", 
                                          "setBonusDesc3", "setBonusDesc4", "setBonusDesc5", "setBonusDesc6", "setBonusDesc7"])
    except Exception as e:
        print(f"Could not drop columns: {e}")
        
    # Add an 'alias' column to the end
    # Given ']' delimiter as it's the final column
    setTable["alias"] = "]"
    
    # Deliminate setId/itemSlots for database storage
    # F-strings don't work here for whatever reason
    setTable.itemSlots = '{' + setTable.itemSlots + '}'
    setTable.itemSlots = setTable.itemSlots.str.replace(" ", "*")
    setTable.setId = '[' + setTable.setId.astype(str)       
        
    # Save processed set data
    try:
        if os.path.exists("ProcessedSetSummaries.csv"):
            os.remove("ProcessedSetSummaries.csv")
        if os.path.exists("ProcessedSetSummaries.txt"):   
            os.remove("ProcessedSetSummaries.txt")
            
        setTable.to_csv("ProcessedSetSummaries.csv", index=False)
        setTable.to_csv("ProcessedSetSummaries.txt", sep="*", index=False)
        print("Saved set data to 'ProcessedSetSummaries.csv and ProcessedSetSummaries.txt'")
    except Exception as e:
        print(f"Failed to save processed set data: {e}")   
    
    return

if __name__ == "__main__":
    import os
    import sys
    import pandas as pd
    
    if len(sys.argv) != 2:
        print("Usage: python set_data_processing.py <path>")
        sys.exit(1)
        
    path = sys.argv[1]
    process(path)