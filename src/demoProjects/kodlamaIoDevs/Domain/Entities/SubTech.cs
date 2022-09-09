using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class SubTech : Entity
    {
        public int ProgrammingLanguageId { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }

        public virtual ProgrammingLanguage? ProgrammingLanguage { get; set; }
        public SubTech()
        {

        }
        public SubTech(int id, int programmingLanguageId, string name, string ımageUrl) : this()
        {
            Id = id;
            Name = name;
            ProgrammingLanguageId = programmingLanguageId;
            ImageUrl = ımageUrl;

        }
    }
}
