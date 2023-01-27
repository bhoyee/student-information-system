using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInformationSystem.DAL.DTO
{
    public class StudentDetailsDTO
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string PrgoramName { get; set; }
        public string ProgramDuration { get; set; }
        public string CohortName { get; set; }
        public int ProgramID { get; set; }
        public int CohortID { get; set; }
    }
}
