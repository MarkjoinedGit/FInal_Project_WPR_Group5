namespace EnglishCentreManagement.ViewModel
{
    public class StudentViewModel : BaseViewModel
    {
        public StudentViewModel()
        {
            StudentWindow studentWindow = new StudentWindow();
            studentWindow.ShowDialog();
        }

    }
}
