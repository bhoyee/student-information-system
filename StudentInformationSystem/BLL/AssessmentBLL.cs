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
    public class AssessmentBLL : IBLL<AssessmentDetailsDTO, AssessmentDTO>
    {
        AssessmentDAO assessmentdao = new AssessmentDAO();
        ProgramDAO programdao = new ProgramDAO();
        ModuleDAO moduledao = new ModuleDAO();

        public bool Delete(AssessmentDetailsDTO entity)
        {
            ASSESSMENT assessment = new ASSESSMENT();
            assessment.Id = entity.Id;
            assessmentdao.Delete(assessment);
            return true;
        }

        public bool GetBack(AssessmentDetailsDTO entity)
        {
            throw new NotImplementedException();
        }

        public bool Insert(AssessmentDetailsDTO entity)
        {
            ASSESSMENT assessment = new ASSESSMENT();
            assessment.Id = entity.Id;
            assessment.Title = entity.title;
            assessment.Max_mark = entity.maxMark;
            assessment.grade = entity.grade;
            assessment.ProgramID = entity.ProgramID;
            assessment.ModuleID = entity.ModuleID;

            return assessmentdao.Insert(assessment);
        }

        public AssessmentDTO Select()
        {

            AssessmentDTO assessmentdto = new AssessmentDTO();
            assessmentdto.Programs = programdao.Select();
            assessmentdto.Modules = moduledao.Select();

            assessmentdto.Assessments = assessmentdao.Select();
            
            return assessmentdto;
        }

        public bool Update(AssessmentDetailsDTO entity)
        {
            ASSESSMENT assessment = new ASSESSMENT();
            assessment.Id = entity.Id;
            assessment.Title = entity.title;
            assessment.Max_mark = entity.maxMark;
            assessment.grade = entity.grade;
            assessment.ProgramID = entity.ProgramID;
            assessment.ModuleID = entity.ModuleID;
           
            return assessmentdao.Update(assessment);
        }


    }
}
