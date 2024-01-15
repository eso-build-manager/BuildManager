----------------------------
----### KEYBINDINGS ###-----
----------------------------
local loc_strings = {
    SI_BINDING_NAME_REFRESH_UI = CE_BINDING_RESET,
}

for str_id, str in pairs(loc_strings) do
    ZO_CreateStringId(str_id, str)
    SafeAddVersion(str_id, 1)
end

----------------------------
-------### STRINGS ###------
----------------------------
BD_DISPLAY_NAME = "Builds"

BD_MENU_DESCRIPTION = "TBD"
BD_MENU_OPTIONS_HEADER = "ALSO TBD"