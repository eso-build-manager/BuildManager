Builds = Builds or {}
local BD = Builds

BD.name = "Builds"
BD.author = "AB"
BD.version = "0.0.1"
BD.defaults = {
    --Tormentor Pauldrons
    ["itemString"] = "|H1:item:102928:363:50:0:0:0:0:0:0:0:0:0:0:0:1:20:0:1:0:10000:0|h|h",
}

----------------------------
---### INITIALIZATION ###---
----------------------------
function BD.Init()
    BD.AddonMenu()
    BD.savedVariables = ZO_SavedVars:NewAccountWide("BuildsSavedVariables", 1, nil, BD.defaults)    
end

function BD.Testing()
    d(GetItemLinkItemId(BD.savedVariables.itemString))
    d(GetItemLinkItemStyle(BD.savedVariables.itemString))
    d(GetItemLinkItemType(BD.savedVariables.itemString))
    d(GetItemLinkItemUseType(BD.savedVariables.itemString))
end

----------------------------
---### ADDON STARTUP ###----
----------------------------
function BD.OnAddOnLoaded(_, addonName)
    if addonName ~= BD.name then return end

    EVENT_MANAGER:UnregisterForEvent(BD.name, EVENT_ADD_ON_LOADED)
    BD.Init()
end 

EVENT_MANAGER:RegisterForEvent(BD.name, EVENT_ADD_ON_LOADED, BD.OnAddOnLoaded)