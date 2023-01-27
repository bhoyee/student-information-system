using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInformationSystem.DAL.DAO
{
    interface IDAO<T,K> where T : class where K : class  //T is model class and k is details class
    {
        //abstract method
        List<K> Select(); // this return detail list usng K class 
        bool Insert(T entity);
        bool Update(T entity);
        bool Delete(T entity);
        bool GetBack(int ID);
    }
}
