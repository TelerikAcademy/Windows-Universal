using Parse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyAlumni.Models
{
    public enum Initiative
    {
        SoftwareAcademy = 0,
        SchoolAcademy = 1,
        AlgoAcademy = 2,
        KidsAcademy = 3,
        Any = 4
    }

    public enum Season
    {
        Season2010_2011 = 0,
        Season2011_2012 = 1,
        Season2012_2013 = 2,
        Season2013_2014 = 3,
        Any = 4
    }

    [ParseClassName("Category")]
    public class CategoryModel : ParseObject
    {
        public Initiative Initiative
        {
            get { return (Initiative)this.InitiativeForParse; }
            set { this.InitiativeForParse = (int)value; }
        }

        [ParseFieldName("initiative")]
        public int InitiativeForParse
        {
            get { return GetProperty<int>(); }
            set { SetProperty<int>(value); }
        }

        public Season Season
        {
            get { return (Season)this.SeasonForParse; }
            set { this.SeasonForParse = (int)value; }
        }

        [ParseFieldName("season")]
        public int SeasonForParse
        {
            get { return GetProperty<int>(); }
            set { SetProperty<int>(value); }
        }

        public override bool Equals(object obj)
        {
            var other = obj as CategoryModel;
            if (other == null)
            {
                return false;
            }
            return this.Initiative == other.Initiative &&
                this.Season == other.Season;
        }
    }
}
