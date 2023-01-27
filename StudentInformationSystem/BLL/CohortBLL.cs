using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentInformationSystem.DAL.DTO;
using StudentInformationSystem.DAL;
using StudentInformationSystem.DAL.DAO;

namespace StudentInformationSystem.BLL
{
    public class CohortBLL : IBLL<CohortDetailsDTO, CohortDTO>
    {
        CohortDAO cohortdao = new CohortDAO();

        public bool Delete(CohortDetailsDTO entity)
        {
            throw new NotImplementedException();
        }

        public bool GetBack(CohortDetailsDTO entity)
        {
            throw new NotImplementedException();
        }

        public bool Insert(CohortDetailsDTO entity)
        {
            COHORT cohort = new COHORT();
            cohort.a_year = entity.a_year;
            return cohortdao.Insert(cohort);
        }

        public CohortDTO Select()
        {
            CohortDTO dto = new CohortDTO();
            dto.Cohorts = cohortdao.Select();
           
            return dto;
        }

        public bool Update(CohortDetailsDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
