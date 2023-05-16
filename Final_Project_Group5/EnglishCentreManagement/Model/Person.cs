using EnglishCentreManagement.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.Windows.Documents;

namespace EnglishCentreManagement.Model
{
    public class Person : IValueObject
    {
        private Enterprise_Infor enter_Infor = new Enterprise_Infor();
        private string namePerson;
        private DateTime dateBorn;
        private string gender;
        private string address;
        private string phoneNum;
        private string identityCard;
        private string bankNumber;
        private double rankLevel;

        public Enterprise_Infor Enter_Infor { get => enter_Infor; set => enter_Infor = value; }
        public string NamePerson { get => namePerson; set => namePerson = value; }
        public DateTime DateBorn { get => dateBorn; set => dateBorn = value; }
        public string Gender { get => gender; set => gender = value; }
        public string Address { get => address; set => address = value; }
        public string PhoneNum { get => phoneNum; set => phoneNum = value; }
        public string IdentityCard { get => identityCard; set => identityCard = value; }
        public string BankNumber { get => bankNumber; set => bankNumber = value; }
        public double RankLevel { get => rankLevel; set => rankLevel = value; }

        public Person()
        {
            namePerson = "";
            gender = "";
            address = "";
            phoneNum = "";
            identityCard = "";
            bankNumber = "";
        }

        public Person(Enterprise_Infor Enter_Infor, string NamePerson, DateTime DateBorn, string Gender, string Address, string PhoneNum, string IdentityCard, string BankNumber, double RankLevel)
        {
            this.enter_Infor = Enter_Infor;
            this.namePerson = NamePerson;
            this.dateBorn = DateBorn;
            this.gender = Gender;
            this.address = Address;
            this.phoneNum = PhoneNum;
            this.identityCard = IdentityCard;
            this.bankNumber = BankNumber;
            this.rankLevel = RankLevel;
        }

        public Person(string Enter_Infor_ID, string NamePerson, DateTime DateBorn, string Gender, string Address, string PhoneNum, string IdentityCard, string BankNumber, double RankLevel)
        {
            this.enter_Infor.ID = Enter_Infor_ID;
            this.namePerson = NamePerson;
            this.dateBorn = DateBorn;
            this.gender = Gender;
            this.address = Address;
            this.phoneNum = PhoneNum;
            this.identityCard = IdentityCard;
            this.bankNumber = BankNumber;
            this.rankLevel = RankLevel;
        }
        public bool IsHaveNullValue()
        {
            if (String.IsNullOrEmpty(this.Enter_Infor.ID.Trim()) || String.IsNullOrEmpty(this.Enter_Infor.UserName.Trim()) || String.IsNullOrEmpty(this.Enter_Infor.Password.Trim()) ||
                String.IsNullOrEmpty(this.Enter_Infor.Email.Trim()) ||
                String.IsNullOrEmpty(this.NamePerson.Trim()) || String.IsNullOrEmpty(this.DateBorn.ToString().Trim()) || String.IsNullOrEmpty(this.Gender.Trim()) || String.IsNullOrEmpty(this.Address.Trim()) || String.IsNullOrEmpty(this.PhoneNum.Trim()) || String.IsNullOrEmpty(this.IdentityCard.Trim()) || String.IsNullOrEmpty(this.RankLevel.ToString().Trim())) return true;
            return false;
        }
        public ObservableCollection<string> ListGender()
        {
            ObservableCollection<string> list=new ObservableCollection<string>();
            list.Add("Nam");
            list.Add("Nữ");
            return list;
        }
        public ObservableCollection<double> ListRankLevel() 
        {
            ObservableCollection<double> list = new ObservableCollection<double>();
            list.Add(0);
            list.Add(0.5);
            list.Add(1);
            list.Add(1.5);
            list.Add(2);
            list.Add(2.5); 
            list.Add(3);
            list.Add(3.5); 
            list.Add(4);
            list.Add(4.5); 
            list.Add(5);
            list.Add(5.5);
            list.Add(6);
            list.Add(6.5);
            list.Add(7);
            list.Add(7.5);
            list.Add(8);
            list.Add(8.5); 
            list.Add(9);
            return list;
        }
    }
}
