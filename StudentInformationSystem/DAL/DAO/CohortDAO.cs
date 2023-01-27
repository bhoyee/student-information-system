using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentInformationSystem.DAL.DTO;

namespace StudentInformationSystem.DAL.DAO
{
    public class CohortDAO : StudentContext, IDAO<COHORT, CohortDetailsDTO>
    {
        public bool Delete(COHORT entity)
        {
            throw new NotImplementedException();
        }

        public bool GetBack(int ID)
        {
            throw new NotImplementedException();
        }

        public bool Insert(COHORT entity)
        {
            try
            {
                db.COHORTs.Add(entity);
                db.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public List<CohortDetailsDTO> Select()
        {
            List<CohortDetailsDTO> cohorts = new List<CohortDetailsDTO>();
            var list = db.COHORTs;
            foreach (var item in list)
            {
                CohortDetailsDTO dto = new CohortDetailsDTO();
                dto.ID = item.ID;
                dto.a_year = item.a_year;
                cohorts.Add(dto);
            }
            return cohorts;
        }

        public bool Update(COHORT entity)
        {
            throw new NotImplementedException();
        }
    }
}
