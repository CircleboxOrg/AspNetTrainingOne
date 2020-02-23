namespace Technicality.AspNetTrainingOne.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using AspNetTrainingOne;

    internal sealed class Configuration : DbMigrationsConfiguration<Technicality.AspNetTrainingOne.TrainingOneContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Technicality.AspNetTrainingOne.TrainingOneContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            //CityId is an identity field
            context.Cities.AddOrUpdate(c => c.CityName,
                new AspNetTrainingOne.City { CityName = "Birmingham", State = "AL" },
                new AspNetTrainingOne.City { CityName = "Mobile", State = "AL" },
                new AspNetTrainingOne.City { CityName = "Montgomery", State = "AL"},
                new AspNetTrainingOne.City { CityName = "Huntsville", State = "AL" },
                new AspNetTrainingOne.City { CityName = "Atlanta", State = "GA"},
                new AspNetTrainingOne.City { CityName = "Savannah", State = "GA"},
                new AspNetTrainingOne.City { CityName = "Jackson", State = "MS" },
                new AspNetTrainingOne.City { CityName = "Biloxi", State = "MS" },
                new AspNetTrainingOne.City { CityName = "New Orleans", State = "LA" },
                new AspNetTrainingOne.City { CityName = "Baton Rouge", State = "LA" },
                new AspNetTrainingOne.City { CityName = "Nashville", State = "TN"},
                new AspNetTrainingOne.City { CityName = "Memphis", State = "TN"},
                new AspNetTrainingOne.City { CityName = "Knoxville", State= "TN"},
                new AspNetTrainingOne.City { CityName = "Chattanooga", State = "TN"},
                new AspNetTrainingOne.City { CityName = "Dallas", State = "TX"},
                new AspNetTrainingOne.City { CityName = "Houston", State = "TX"},
                new AspNetTrainingOne.City { CityName = "Austin", State = "TX"},
                new AspNetTrainingOne.City { CityName = "San Antonio", State = "TX"},
                new AspNetTrainingOne.City { CityName = "Waco", State = "TX"}
                );
        }
    }
}
