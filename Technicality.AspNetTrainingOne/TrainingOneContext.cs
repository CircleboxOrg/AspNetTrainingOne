using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Technicality.AspNetTrainingOne
{
    public class TrainingOneContext : DbContext
    {
        
        public virtual DbSet<City> Cities { get; set; }
    }
}