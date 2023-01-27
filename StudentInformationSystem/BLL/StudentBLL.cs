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
    public class StudentBLL : IBLL<StudentDetailsDTO, StudentDTO>
    {
        StudentDAO studentdao = new StudentDAO();
        ProgramDAO programdao = new ProgramDAO();
        CohortDAO cohortdao = new CohortDAO();

        public bool Delete(StudentDetailsDTO entity)
        {
            STUDENT student = new STUDENT();
            student.Id = entity.Id;
            studentdao.Delete(student);
            return true;
        }

        public bool GetBack(StudentDetailsDTO entity)
        {
            throw new NotImplementedException();
        }

        public bool Insert(StudentDetailsDTO entity)
        {
            STUDENT student = new STUDENT();
            student.Id = entity.Id;
            student.Name = entity.name;
            student.ProgramID = entity.ProgramID;
            student.Duration = entity.ProgramDuration;
            student.CohortID = entity.CohortID;
           
            return studentdao.Insert(student);
        }

        public StudentDTO Select()
        {
            StudentDTO studentdto = new StudentDTO();
            studentdto.Students = studentdao.Select();
            studentdto.Programs = programdao.Select();
            studentdto.Cohorts = cohortdao.Select();
          
            return studentdto;

        }

        public bool Update(StudentDetailsDTO entity)
        {
            STUDENT student = new STUDENT();
            student.Id = entity.Id;
            student.Name = entity.name;
            student.Duration = entity.ProgramDuration;
            student.CohortID = entity.CohortID;
            student.ProgramID = entity.ProgramID;

            return studentdao.Update(student);
        }

    }
}
