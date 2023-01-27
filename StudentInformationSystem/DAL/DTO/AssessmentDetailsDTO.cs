using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInformationSystem.DAL.DTO
{
    public class AssessmentDetailsDTO
    {
        public int Id { get; set; }
        public string title { get; set; }
        public int maxMark { get; set; }
        public string grade { get; set; }
        public int ProgramID { get; set; }
        public int ModuleID { get; set; }
        public string programName { get; set; }
        public string moduleName { get; set; }
     
       
    }
}
