using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vnsf.Data.Entities
{
    public class Education 
    {
        public static Education Create(string specialization, string program, string university, int duration, MonthYear startdate, MonthYear enddate)
        {
            return new Education()
            {
                Id = Guid.NewGuid(),
                Specialization = specialization,
                ProgramDescription = program,
                EducationPlace = university,
                Duration = duration,
                StartDate = startdate,
                EndDate = enddate
            };
        }

        public Guid Id { get; set; }
        public EducationLevel Level { get; set; }
        public string Specialization { get; set; }
        public string ProgramDescription { get; set; }
        public string EducationPlace { get; set; }
        public int Duration { get; set; }
        public MonthYear StartDate { get; set; }
        public MonthYear EndDate { get; set; }
        

        public virtual UserProfile Profile { get; set; }

    }
}
