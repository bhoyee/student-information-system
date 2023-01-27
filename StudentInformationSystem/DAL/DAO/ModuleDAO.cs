using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentInformationSystem.DAL.DTO;

namespace StudentInformationSystem.DAL.DAO
{
    public class ModuleDAO : StudentContext, IDAO<MODULE, ModuleDetailsDTO>
    {
        public bool Delete(MODULE entity)
        {
            try
            {
                MODULE module = db.MODULEs.First(x => x.Id == entity.Id);
                module.isDeleted = true;
                module.DeletedDate = DateTime.Today;
                db.SaveChanges();
                return true;
                // db.STUDENTs.Remove(student);
                // db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool GetBack(int ID)
        {
            throw new NotImplementedException();
        }

        public bool Insert(MODULE entity)
        {
            try
            {
                db.MODULEs.Add(entity);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public List<ModuleDetailsDTO> GetData()
        //{
        //    try
        //    {
        //        List<ModuleDetailsDTO> modules = new List<ModuleDetailsDTO>();
        //        var list = (from m in db.MODULEs.Where(x => x.isDeleted == false)
        //                    join p in db.PROGRAMs on m.ProgramID equals p.Id
        //                    join s in db.STUDENTs on p.Id equals s.ProgramID
        //                    select new
        //                    {
                                
        //                        title = m.Title,
        //                        moduletype = m.ModuleType,
        //                        studentid = s.Id,
        //                        student_prog_duration = s.Duration
                              
        //                    }).ToList();
        //        foreach (var item in list)
        //        {
        //            ModuleDetailsDTO dto = new ModuleDetailsDTO();

        //            dto.id.StudentID = item.studentid;
        //            dto.Stu_prog_duration = item.student_prog_duration;
        //            dto.Title = item.title;
        //            dto.ModuleType = item.moduletype;
                   
        //            modules.Add(dto);

        //        }
        //        return modules;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        public List<ModuleDetailsDTO> Select()
        {
            try
            {
                List<ModuleDetailsDTO> modules = new List<ModuleDetailsDTO>();
                var list = (from p in db.MODULEs.Where(x => x.isDeleted == false)
                            join c in db.PROGRAMs on p.ProgramID equals c.Id
                            select new
                            {
                                moduleID = p.Id,
                                
                                title = p.Title,
                                moduletyoe = p.ModuleType,
                                maxmark = p.Max_mark,
                                programname = c.Title,
                                progrmaID = c.Id
                            }).OrderBy(x => x.title).ToList();
                foreach (var item in list)
                {
                    ModuleDetailsDTO dto = new ModuleDetailsDTO();
                    dto.Id = item.moduleID;
                    dto.Title = item.title;
                    dto.ModuleType = item.moduletyoe;
                    dto.PrgoramName = item.programname;
                    dto.MaxMark = item.maxmark;
                    dto.ProgramID = item.progrmaID;
                    modules.Add(dto);

                }
                return modules;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public bool Update(MODULE entity)
        {
            try
            {
                MODULE module = db.MODULEs.First(x => x.Id == entity.Id);
                module.Title = entity.Title;
                module.ModuleType = entity.ModuleType;
                module.ProgramID = entity.ProgramID;
                module.Max_mark = entity.Max_mark;
              
                db.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
