﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace BuildManager.Library.DataBaseModels;

public partial class SetList
{
    public short SetId { get; set; }

    public string SetName { get; set; }

    public string Type { get; set; }

    public string Sources { get; set; }

    public byte? SetMaxEquipCount { get; set; }

    public byte? SetBonusCount { get; set; }

    public string SetBonusDescription { get; set; }

    public int? ItemSlotsId { get; set; }

    public string alias { get; set; }

    public virtual ICollection<SetUsableItemSlots> SetUsableItemSlots { get; set; } = new List<SetUsableItemSlots>();
}