using System;
using System.Windows;
using CSMVPAssignment.Model;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using CSMVPAssignment.ViewModel;

namespace CSMVPAssignment.View
{
    public partial class CreateNewTutorial : Window
    {
        public CreateNewTutorial()
        {
            this.InitializeComponent();
            var tutorial = new Tutorial(
                Repository.AllTeachers[0],
                Repository.AllSubjects[0],
                2016,
                2);
            this.TutorialVM = new TutorialViewModel(tutorial);
            this.DataContext = this.TutorialVM;
        }

        public TutorialViewModel TutorialVM { get; set; }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }

}