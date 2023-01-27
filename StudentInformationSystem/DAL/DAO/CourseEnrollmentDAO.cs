using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentInformationSystem.DAL.DTO;


namespace StudentInformationSystem.DAL.DAO
{
    public class CourseEnrollmentDAO : StudentContext, IDAO<COURSE_ENROLLMENT, CourseEnrollmentDetailsDTO>
    {
        public bool Delete(COURSE_ENROLLMENT entity)
        {
            try
            {
                COURSE_ENROLLMENT course_enrollment = db.COURSE_ENROLLMENT.First(x => x.Id == entity.Id);
                course_enrollment.isDeleted = true;
                course_enrollment.DeletedDate = DateTime.Today;
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

        public bool Insert(COURSE_ENROLLMENT entity)
        {
            try
            {
                db.COURSE_ENROLLMENT.Add(entity);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CourseEnrollmentDetailsDTO> Select()
        {
            try
            {
                List<CourseEnrollmentDetailsDTO> course_enrollment = new List<CourseEnrollmentDetailsDTO>();
                var list = (from c in db.COURSE_ENROLLMENT.Where(x => x.isDeleted == false)
                            join p in db.PROGRAMs on c.ProgramID equals p.Id
                            join ch in db.COHORTs on c.CohortID equals ch.ID
                            join s in db.STUDENTs on c.StudentID equals s.Id
                            join m in db.MODULEs on c.ModuleID equals m.Id
                            join a in db.ASSESSMENTs on c.AssessmentID equals a.Id
                            select new
                            {
                               course_enroID = c.Id,
                                studentID = s.Id,
                                studentName = s.Name,
                                programID = p.Id,
                                programName = p.Title,
                               moduleID = m.Id,
                                moduleTitle = m.Title,
                                cohordName = ch.a_year,
                                cohortID = ch.ID,
                                assessmentID = a.Id,
                                assessmentMaxMark = a.Max_mark,
                                assessmentTitle = a.Title,
                                score = c.Mark
                                
                            }).ToList();
                foreach (var item in list)
                {
                    CourseEnrollmentDetailsDTO dto = new CourseEnrollmentDetailsDTO();
                    dto.Id = item.course_enroID;
                    dto.StudentID = item.studentID;
                    dto.StudentName = item.studentName;
                    dto.ModuleID = item.moduleID;
                    dto.ModuleTitle = item.moduleTitle;
                    dto.ProgramID = item.programID;
                    dto.PrgoramName = item.programName;
                    dto.CohortID = item.cohortID;
                    dto.CohortName = item.cohordName;
                    dto.AssessmentID = item.assessmentID;
                    dto.AssessmentTitle = item.assessmentTitle;
                    dto.AssessmentMaxMark = item.assessmentMaxMark;
                    dto.Mark =  Convert.ToInt32(item.score);



                    course_enrollment.Add(dto);
                   

                }
                return course_enrollment;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update(COURSE_ENROLLMENT entity)
        {
            try
            {
                COURSE_ENROLLMENT course_enrollment = db.COURSE_ENROLLMENT.First(x => x.AssessmentID == entity.AssessmentID);
                course_enrollment.AssessmentID = entity.AssessmentID;
                course_enrollment.StudentID = entity.StudentID;
                course_enrollment.ModuleID = entity.ModuleID;
                course_enrollment.ProgramID = entity.ProgramID;
                course_enrollment.Mark = entity.Mark;
                course_enrollment.CohortID = entity.CohortID;

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
