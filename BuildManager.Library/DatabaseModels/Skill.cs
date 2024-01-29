using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildManager.Library.DatabaseModels
{
    public partial class Skill
    {
        public int SkillId { get; set; }
        public string SkillTypeName { get; set;}
        public string BaseName { get; set;}
        public string Name { get; set; }
        public string Type { get; set;}
        public string Cost { get; set;}
        public short? SkillIndex { get; set; }
        public string Description { get; set;}
        public string ImagePath { get; set; }
    }
}
