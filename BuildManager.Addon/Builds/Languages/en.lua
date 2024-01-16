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

BD_MENU_EDITBOX_NAME = "Item String"
BD_MENU_EDITBOX_TT = "Input item string for converstion to item ID"

BD_BUTTTON_CONVERT_NAME = "Convert"
BD_BUTTTON_CONVERT_TT = "Convert item string to item ID"