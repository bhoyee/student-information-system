using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInformationSystem.DAL.DTO
{
    public class CourseEnrollmentDetailsDTO
    {
        public int Id { get; set; }
        public int StudentID { get; set; }
        public int CohortID { get; set; }
        public int ProgramID { get; set; }
        public int ModuleID{ get; set; }
        public string PrgoramName { get; set; }
        public string CohortName { get; set; }
        public string StudentName { get; set; }
        public string ModuleTitle { get; set; }
        public string Grade { get; set; }
        public int Mark { get; set; }
        public int AssessmentID { get; set; }
        public string AssessmentTitle { get; set; }
        public int AssessmentMaxMark { get; set; }
        

    }
}
