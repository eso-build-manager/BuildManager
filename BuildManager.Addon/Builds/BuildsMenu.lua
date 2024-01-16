Builds = Builds or {}
local BD = Builds

function BD.AddonMenu()

    local menuOptions = {
        type = "panel",
        name = BD.name,
        displayName = BD_DISPLAY_NAME,
        author = BD.author,
        version = BD.version,
        slashCommand = "/bd",
        registerForRefresh = true,
        registerForDefaults = true,
    }

    local dataTable = {
        {
            type = "description",
            text = BD_MENU_DESCRIPTION,
        },
        {
            type = "header",
            name = BD_MENU_OPTIONS_HEADER,
            width = "full",
        },
        {
			type    = "editbox",
			name    = BD_MENU_EDITBOX_NAME,
			tooltip = BD_MENU_EDITBOX_TT,
			default = false,
            isExtraWide = true,
            isMultiline = true,

            getFunc = function() return BD.savedVariables.itemString end,
            setFunc = function(value) BD.savedVariables.itemString = value end,
		},
        {
            type = "button",
            name = BD_BUTTTON_CONVERT_NAME,
            tooltip = BD_BUTTTON_CONVERT_TT,
            func = function(value) BD.Testing() end,
        }
    }

    LAM = LibAddonMenu2
    LAM:RegisterAddonPanel(BD.name .. "Options", menuOptions)
    LAM:RegisterOptionControls(BD.name .. "Options", dataTable)
end