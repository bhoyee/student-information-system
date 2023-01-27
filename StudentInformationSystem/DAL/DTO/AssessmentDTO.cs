using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInformationSystem.DAL.DTO
{
   public class AssessmentDTO
    {
        public List<AssessmentDetailsDTO> Assessments { get; set; }
        public List<ModuleDetailsDTO> Modules { get; set; }
        public List<ProgramDetailsDTO> Programs { get; set; }
        
    }
}