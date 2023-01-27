using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentInformationSystem.DAL.DTO;

namespace StudentInformationSystem.DAL.DAO
{
    public class AssessmentDAO:StudentContext, IDAO<ASSESSMENT, AssessmentDetailsDTO>
    {
        public bool Delete(ASSESSMENT entity)
        {
            try
            {
                ASSESSMENT assessment = db.ASSESSMENTs.First(x => x.Id == entity.Id);
                assessment.isDeleted = true;
                assessment.DeletedDate = DateTime.Today;
                db.SaveChanges();
                return true;
                // db.STUDENTs.Remove(student);
                // db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            };
        }

        public bool GetBack(int ID)
        {
            throw new NotImplementedException();
        }

        public bool Insert(ASSESSMENT entity)
        {
            try
            {
                db.ASSESSMENTs.Add(entity);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<AssessmentDetailsDTO> Select()
        {
            try
            {
                List<AssessmentDetailsDTO> assessments = new List<AssessmentDetailsDTO>();
                var list = (from s in db.ASSESSMENTs.Where(x => x.isDeleted == false)
                            join p in db.PROGRAMs on s.ProgramID equals p.Id
                            join c in db.MODULEs on s.ModuleID equals c.Id
                            select new
                            {
                                assessmentID = s.Id,
                                title = s.Title,
                                maxMark = s.Max_mark,
                                grade = s.grade,
                                programID = p.Id,
                                moduleID = c.Id,
                                programName = p.Title,
                                moduleName = c.Title
                            }).OrderBy(x => x.assessmentID).ToList();
                foreach (var item in list)
                {
                    AssessmentDetailsDTO dto = new AssessmentDetailsDTO();
                    dto.Id = item.assessmentID;
                    dto.title = item.title;
                    dto.maxMark = item.maxMark;
                    dto.grade = item.grade;
                    dto.ProgramID = item.programID;
                    dto.ModuleID = item.moduleID;
                    dto.programName = item.programName;
                    dto.moduleName = item.moduleName;
                    

                    assessments.Add(dto);

                }
                return assessments;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update(ASSESSMENT entity)
        {
            try
            {
                ASSESSMENT assessment = db.ASSESSMENTs.First(x => x.Id == entity.Id);
                assessment.Id = entity.Id;
                assessment.Title = entity.Title;
                assessment.Max_mark = entity.Max_mark;
                assessment.grade = entity.grade;
                assessment.ProgramID = entity.ProgramID;
                assessment.ModuleID = entity.ModuleID;
               
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
