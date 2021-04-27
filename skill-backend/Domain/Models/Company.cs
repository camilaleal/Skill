using Domain.Constants;
using Domain.Contracts.Models;
using Domain.Models.Generic;
using System.Collections.Generic;
using System.ComponentModel;

namespace Domain.Models
{
   public class Company : Entity, IEntity
    {
        [Category(EntityPropertyCategory.Model)]
        public string Image { get; set; }

        [Category(EntityPropertyCategory.Model)]
        public string Name { get; set; }

        [Category(EntityPropertyCategory.Model)]
        public string Description { get; set; }

        [Category(EntityPropertyCategory.LoadRunTime)]
        public int JobsCount { get; set; }

        [Category(EntityPropertyCategory.LoadRunTime)]
        public List<Job> Jobs { get; set; }
    }
}
