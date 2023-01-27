using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInformationSystem.DAL.DTO
{
    public class ProgramDTO
    {
        public List<ProgramDetailsDTO> Programs { get; set; }
        public List<CohortDetailsDTO> Cohorts { get; set; }
    }
}
