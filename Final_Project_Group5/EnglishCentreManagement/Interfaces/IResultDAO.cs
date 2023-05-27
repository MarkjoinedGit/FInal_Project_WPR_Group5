using EnglishCentreManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishCentreManagement.Interfaces
{
    public interface IResultDAO
    {
        void Delete(string idTest);
        void UpdateTestResultByList(List<TestResult> results);
        List<TestResult> getResultByIdTest(string idTest);
        List<TestResult> getListResultTest(Student student);
    }
}
