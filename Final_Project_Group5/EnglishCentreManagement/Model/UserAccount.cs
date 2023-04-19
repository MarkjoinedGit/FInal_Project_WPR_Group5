using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishCentreManagement.Model
{
    public class UserAccount
    {
        public string Username { get;set; }
        public string Displayname { get; set; }
        public byte[] ProfilePicture { get; set; }
    }
}
