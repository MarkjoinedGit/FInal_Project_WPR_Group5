using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf_FinalProject_1._1
{
    class Name
    {
        // Fields
        private string sFirstName;
        private string sLastName;
        // Properties
        public string FirstName
        {
            get { return sFirstName; }
            set { sFirstName = value; }
        }
        public string LastName
        {
            get { return sLastName; }
            set { sLastName = value; }
        }
        // Methods
        public Name(string FirstName, string LastName)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
        }
    }
}
