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
    public class CourseEnrollmentBLL : IBLL<CourseEnrollmentDetailsDTO, CourseEnrollmentDTO>
    {

        CourseEnrollmentDAO courseenrollmentdao = new CourseEnrollmentDAO();
        public bool Delete(CourseEnrollmentDetailsDTO entity)
        {
            throw new NotImplementedException();
        }


        StudentDAO studentdao = new StudentDAO();
        ProgramDAO programdao = new ProgramDAO();
        CohortDAO cohortdao = new CohortDAO();
        ModuleDAO moduledao = new ModuleDAO();
        AssessmentDAO assessmentdao = new AssessmentDAO();

        public bool GetBack(CourseEnrollmentDetailsDTO entity)
        {
            throw new NotImplementedException();
        }

        public bool Insert(CourseEnrollmentDetailsDTO entity)
        {
            COURSE_ENROLLMENT course_enrollment = new COURSE_ENROLLMENT();

           

            course_enrollment.StudentID = entity.StudentID;
            course_enrollment.ModuleID = entity.ModuleID;
            course_enrollment.ProgramID = entity.ProgramID;
            course_enrollment.CohortID = entity.CohortID;
            course_enrollment.AssessmentID = entity.AssessmentID;
;
        course_enrollment.Mark = entity.Mark;

            return courseenrollmentdao.Insert(course_enrollment);
        }

        public CourseEnrollmentDTO Select()
        {
           
            CourseEnrollmentDTO course_enrollt = new CourseEnrollmentDTO();
            course_enrollt.Students = studentdao.Select();
            course_enrollt.Modules = moduledao.Select();
            course_enrollt.Programs = programdao.Select();
            course_enrollt.Cohorts = cohortdao.Select();
            course_enrollt.Assessments = assessmentdao.Select();

            course_enrollt.CourseEnrollments = courseenrollmentdao.Select();
           
            return course_enrollt;
        }

        public bool Update(CourseEnrollmentDetailsDTO entity)
        {
            COURSE_ENROLLMENT course_enrollmnt = new COURSE_ENROLLMENT();
            course_enrollmnt.StudentID = entity.StudentID;
            course_enrollmnt.ProgramID = entity.ProgramID;
            course_enrollmnt.ModuleID = entity.ModuleID;
            course_enrollmnt.Mark = entity.Mark;
            course_enrollmnt.AssessmentID = entity.AssessmentID;
            course_enrollmnt.CohortID = entity.CohortID;


            return courseenrollmentdao.Update(course_enrollmnt);
        }
    }
}
