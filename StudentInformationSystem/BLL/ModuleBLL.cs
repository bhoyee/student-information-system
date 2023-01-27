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
    public class ModuleBLL : IBLL<ModuleDetailsDTO, ModuleDTO>
    {
        ModuleDAO moduledao = new ModuleDAO();
        ProgramDAO programdao = new ProgramDAO();
        StudentDAO studentdao = new StudentDAO();

        public bool Delete(ModuleDetailsDTO entity)
        {
            MODULE module = new MODULE();
            module.Id = entity.Id;
            moduledao.Delete(module);
            return true;
        }

        public bool GetBack(ModuleDetailsDTO entity)
        {
            throw new NotImplementedException();
        }

        public bool Insert(ModuleDetailsDTO entity)
        {
            MODULE module = new MODULE();
            module.Id = entity.Id;
            module.Title = entity.Title;
            module.ModuleType = entity.ModuleType;
            module.Max_mark = entity.MaxMark;
            module.ProgramID = entity.ProgramID;
          
            return moduledao.Insert(module);
        }

        public ModuleDTO Select()
        {
            ModuleDTO dto = new ModuleDTO();
            dto.Programs = programdao.Select();
            dto.Modules = moduledao.Select();

           // dto.Students = studentdao.Select();
            return dto;

        }

        public bool Update(ModuleDetailsDTO entity)
        {
            MODULE module = new MODULE();
            module.Id = entity.Id;
            module.Title = entity.Title;
            module.ModuleType = entity.ModuleType;
            module.ProgramID = entity.ProgramID;
            module.Max_mark = entity.MaxMark;

            return moduledao.Update(module);
       
        }
    }
}
