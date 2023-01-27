using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentInformationSystem.DAL.DTO;

namespace StudentInformationSystem.DAL.DAO
{
    public class StudentDAO : StudentContext, IDAO<STUDENT, StudentDetailsDTO>
    {
        public bool Delete(STUDENT entity)
        {
            try
            {
                STUDENT student = db.STUDENTs.First(x => x.Id == entity.Id);
                student.isDeleted = true;
                student.DeletedDate = DateTime.Today;
                db.SaveChanges();
                return true;
               // db.STUDENTs.Remove(student);
               // db.SaveChanges();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public bool GetBack(int ID)
        {
            throw new NotImplementedException();
        }

        public bool Insert(STUDENT entity)
        {

            try
            {
                db.STUDENTs.Add(entity);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<StudentDetailsDTO> Select()
        {
            try
            {
                List<StudentDetailsDTO> students = new List<StudentDetailsDTO>();
                var list = (from s in db.STUDENTs.Where(x=>x.isDeleted==false)
                            join p in db.PROGRAMs on s.ProgramID equals p.Id
                            join c in db.COHORTs on s.CohortID equals c.ID
                            select new
                            {
                                studentID = s.Id,
                                studentName = s.Name,
                                programDuration = s.Duration,
                                programName = p.Title,
                                cohordName = c.a_year,
                                cohortID  = c.ID,
                                programID = p.Id
                            }).OrderBy(x => x.studentName).ToList();
                foreach (var item in list)
                {
                    StudentDetailsDTO dto = new StudentDetailsDTO();
                    dto.Id = item.studentID;
                    dto.name = item.studentName;
                    dto.ProgramDuration = item.programDuration;
                    dto.PrgoramName = item.programName;
                    dto.CohortName = item.cohordName;
                    dto.ProgramID = item.programID;
                    dto.CohortID = item.cohortID;
                
                    students.Add(dto);

                }
                return students;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update(STUDENT entity)
        {
            try
            {
                STUDENT student = db.STUDENTs.First(x => x.Id == entity.Id);
                student.Name = entity.Name;
                student.Duration = entity.Duration;
                student.CohortID = entity.CohortID;
                student.ProgramID = entity.ProgramID;
                db.SaveChanges();
                return true;

            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
