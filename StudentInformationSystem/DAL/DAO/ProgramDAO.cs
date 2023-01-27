using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentInformationSystem.DAL.DTO;

namespace StudentInformationSystem.DAL.DAO
{
    public class ProgramDAO :StudentContext, IDAO<PROGRAM, ProgramDetailsDTO>
    {
        public bool Delete(PROGRAM entity)
        {

            try
            {
                PROGRAM program = db.PROGRAMs.First(x => x.Id == entity.Id);
               
                program.isDeleted = true;
                program.DeletedDate = DateTime.Today;
                db.SaveChanges();
                return true;
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

        public bool Insert(PROGRAM entity)
        {
            try
            {
                db.PROGRAMs.Add(entity);
                db.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

         
        public List<ProgramDetailsDTO> Select()
        {
            try
            {
                List<ProgramDetailsDTO> programs = new List<ProgramDetailsDTO>();
                var list = (from p in db.PROGRAMs.Where(x => x.isDeleted == false)
                            join c in db.COHORTs on p.CohortID equals c.ID
                            select new
                            {
                                programID = p.Id,
                                title = p.Title,
                                duration = p.Duration,
                                numberofmodules = p.NumberofModule,
                                cohort = c.a_year,
                                cohortID = c.ID
                            }).OrderBy(x => x.title).ToList();
                foreach(var item in list)
                {
                    ProgramDetailsDTO dto = new ProgramDetailsDTO();
                    dto.Id = item.programID;
                    dto.Title = item.title;
                    dto.Duration = item.duration;
                    dto.NumberofModule = Convert.ToInt32(item.numberofmodules);
                    dto.a_year = item.cohort;
                    dto.CohortID = item.cohortID;
                    programs.Add(dto);

                }
                return programs;
            }
            catch(Exception ex)
            {
                throw ex;
            }
           
            
        }

        public bool Update(PROGRAM entity)
        {
            try
            {
                PROGRAM program = db.PROGRAMs.First(x => x.Id == entity.Id);
                program.Title = entity.Title;
                program.Duration = entity.Duration;
                program.NumberofModule = entity.NumberofModule;
                program.CohortID = entity.CohortID;

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
