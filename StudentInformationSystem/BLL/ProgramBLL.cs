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
    public class ProgramBLL : IBLL<ProgramDetailsDTO, ProgramDTO>
    {
        ProgramDAO dao = new ProgramDAO();
        CohortDAO cohortdao = new CohortDAO();

        public bool Delete(ProgramDetailsDTO entity)
        {
            PROGRAM program = new PROGRAM();
            program.Id = entity.Id;
            dao.Delete(program);
            return true;
        }

        public bool GetBack(ProgramDetailsDTO entity)
        {
            throw new NotImplementedException();
        }

        public bool Insert(ProgramDetailsDTO entity)
        {
           PROGRAM program = new PROGRAM();
            program.Id = entity.Id;
            program.Title = entity.Title;
            program.Duration = entity.Duration;
            program.NumberofModule = entity.NumberofModule;
            program.CohortID = entity.CohortID;
            return dao.Insert(program);
        }

        public ProgramDTO Select()
        {
            ProgramDTO dto = new ProgramDTO();
            dto.Cohorts = cohortdao.Select();
            dto.Programs = dao.Select();
            return dto;
        }

        public bool Update(ProgramDetailsDTO entity)
        {
            PROGRAM program = new PROGRAM();
            program.Id = entity.Id;
            program.Title = entity.Title;
            program.NumberofModule = entity.NumberofModule;
            program.Duration = entity.Duration;
            program.CohortID = entity.CohortID;
         
            return dao.Update(program);
        }
    }
}
