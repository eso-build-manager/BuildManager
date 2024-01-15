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
			type    = "checkbox",
			name    = "Testing",
			tooltip = "Testing",
			default = false,
		},
    }

    LAM = LibAddonMenu2
    LAM:RegisterAddonPanel(BD.name .. "Options", menuOptions)
    LAM:RegisterOptionControls(BD.name .. "Options", dataTable)
end