using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf_FinalProject_1._1.CSFile
{
    class Manager : Person
    {
        public Manager(Name namePerson, string phoneNum, string gender, string identityCard, string address, DateTime dateBorn) : base(namePerson, phoneNum, gender, identityCard, address, dateBorn)
        {
        }
        public Manager(Enterprise_Infor enterprise_Infor) : base(enterprise_Infor) { }
    }
}
