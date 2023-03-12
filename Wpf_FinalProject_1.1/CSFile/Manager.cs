using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf_FinalProject_1._1.CSFile
{
    class Manager : Person
    {
        public Manager(Enterprise_Infor enterprise_Infor, Name namePerson, string phoneNum, string gender, string identityCard, string address, DateTime dateBorn) : base(enterprise_Infor, namePerson, phoneNum, gender, identityCard, address, dateBorn)
        {

        }
    }
}
