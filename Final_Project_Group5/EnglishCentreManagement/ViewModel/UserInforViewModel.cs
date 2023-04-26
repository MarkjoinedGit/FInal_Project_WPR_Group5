using EnglishCentreManagement.Database;
using EnglishCentreManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishCentreManagement.ViewModel
{
    public class UserInforViewModel : BaseViewModel
    {

        public Person CrtUser { get; set; }

        public UserInforViewModel() 
        {
            if (CurrentUser.Instance.isStudent())
            {
                CrtUser = CurrentUser.Instance.CurrentStudent;
            }
            else if (CurrentUser.Instance.isTeacher())
            {
                CrtUser = CurrentUser.Instance.CurrentTeacher;
            }
            else if (CurrentUser.Instance.isManager())
            {
                CrtUser = CurrentUser.Instance.CurrentManager;
            }
        }


    }
}
