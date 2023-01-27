using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInformationSystem.DAL.DTO
{
    public class CourseEnrollmentDTO
    {
        public List<CourseEnrollmentDetailsDTO> CourseEnrollments { get; set; }
        public List<ModuleDetailsDTO> Modules { get; set; }
        public List<ProgramDetailsDTO> Programs { get; set; }
        public List<CohortDetailsDTO> Cohorts { get; set; }
        public List<StudentDetailsDTO> Students { get; set; }
        public List<AssessmentDetailsDTO> Assessments { get; set; }
    }
}
