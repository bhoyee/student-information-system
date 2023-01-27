using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInformationSystem.DAL.DTO
{
    public class ProgramDetailsDTO
    {
        
        public int Id { get; set; }
        public string Title { get; set; }
        public string Duration { get; set; }
        public int NumberofModule { get; set; }
        public string a_year { get; set; }
        public int CohortID { get; set; }
    }
}
