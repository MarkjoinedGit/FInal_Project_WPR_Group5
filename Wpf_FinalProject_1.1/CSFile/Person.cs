using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf_FinalProject_1._1.CSFile
{
    class Person
    {
        // Fields
        protected Enterprise_Infor EfEnter_Infor;
        // ... personal information
        protected Name NmPerson;
        protected string sPhoneNum;
        protected string sGender;
        protected string sIdentityCard;
        protected string sPermanentResidence;
        protected string sAddress;
        protected DateTime dtDateBorn;
        // Properties
        public Enterprise_Infor Enter_Infor
        {
            get { return EfEnter_Infor; }
            set { EfEnter_Infor = value; }
        }
        public Name NamePerson
        {
            get { return NmPerson; }
            set { NmPerson = value; }
        }
        public string PhoneNum
        {
            get { return sPhoneNum; }
            set { sPhoneNum = value; }
        }
        public string Gender
        {
            get { return sGender; }
            set { sGender = value; }
        }
        public string IdentityCard
        {
            get { return sIdentityCard; }
            set { IdentityCard = value; }
        }
        public string Address
        {
            get { return sAddress; }
            set { sAddress = value; }
        }
        public DateTime DateBorn
        {
            get { return dtDateBorn; }
            set { dtDateBorn = value; }
        }
        public Person(Name namePerson, string phoneNum, string gender, string identityCard, string address, DateTime dateBorn)
        {
            NamePerson = namePerson;
            PhoneNum = phoneNum;
            Gender = gender;
            IdentityCard = identityCard;
            Address = address;
            DateBorn = dateBorn;
        }
        public Person(Enterprise_Infor enter_Infor)
        {
            Enter_Infor = enter_Infor;
        }
    }
}
