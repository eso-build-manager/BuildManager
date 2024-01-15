Builds = Builds or {}
local BD = Builds

BD.name = "Builds"
BD.author = "AB"
BD.version = "0.0.1"
BD.defaults = {}

----------------------------
---### INITIALIZATION ###---
----------------------------
function BD.Init()
    BD.savedVariables = ZO_SavedVars:NewAccountWide("BuildsSavedVariables", 1, nil, BD.defaults)
    BD.AddonMenu()
    d(GetWorldName())
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