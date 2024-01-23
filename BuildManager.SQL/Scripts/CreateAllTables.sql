/****** Object:  Table [Set].[SetList]    Script Date: 1/21/2024 2:09:20 PM ******/
SET ANSI_NULLS ON
GO

create schema [Set]
CREATE TABLE [Set].[SetList](
	[SetId] [smallint] NOT NULL,
	[SetName] [varchar](50) NULL,
	[Type] [varchar](50) NULL,
	[Sources] [varchar](100) NULL,
	[SetMaxEquipCount] [tinyint] NULL,
	[SetBonusCount] [tinyint] NULL,
	[SetBonusDescription] [varchar](max) NULL,
	[ItemSlotsId] [int] NULL,
	[alias] [varchar](max) NULL,
 CONSTRAINT [PK_SetList] PRIMARY KEY CLUSTERED 
(
	[SetId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
)
GO

/****** Object:  Table [Set].[SetUsableItemSlots]    Script Date: 1/21/2024 2:10:57 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [Set].[SetUsableItemSlots](
	[SetUsableItemSlotsId] [int] IDENTITY(1,1) NOT NULL,
	[SetId] [smallint] NULL,
	[HasMediumHead] [bit] NULL,
	[HasMediumShoulder] [bit] NULL,
	[HasMediumChest] [bit] NULL,
	[HasMediumBelt] [bit] NULL,
	[HasMediumGloves] [bit] NULL,
	[HasMediumPants] [bit] NULL,
	[HasLightHead] [bit] NULL,
	[HasLightShoulder] [bit] NULL,
	[HasLightChest] [bit] NULL,
	[HasLightBelt] [bit] NULL,
	[HasLightGloves] [bit] NULL,
	[HasLightPants] [bit] NULL,
	[HasHeavyHead] [bit] NULL,
	[HasHeavyShoulder] [bit] NULL,
	[HasHeavyChest] [bit] NULL,
	[HasHeavyBelt] [bit] NULL,
	[HasHeavyGloves] [bit] NULL,
	[HasHeavyPants] [bit] NULL,
	[HasNecklace] [bit] NULL,
	[HasRing] [bit] NULL,
	[HasFlame] [bit] NULL,
	[HasFrost] [bit] NULL,
	[HasLightning] [bit] NULL,
	[HasResto] [bit] NULL,
	[HasDagger] [bit] NULL,
	[HasSword] [bit] NULL,
	[HasMace] [bit] NULL,
	[HasAxe] [bit] NULL,
	[HasGreatsword] [bit] NULL,
	[HasMaul] [bit] NULL,
	[HasBattleaxe] [bit] NULL,
	[HasShield] [bit] NULL,
 CONSTRAINT [PK_SetUsableItemSlots] PRIMARY KEY CLUSTERED 
(
	[SetUsableItemSlotsId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [Set].[SetUsableItemSlots]  WITH CHECK ADD FOREIGN KEY([SetId])
REFERENCES [Set].[SetList] ([SetId])
GO



