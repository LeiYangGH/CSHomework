using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using WpfApp2.Model;


namespace WpfApp2.Presenter
{
    public class CreateViewPresenter
    {
        MainViewPresenter mainViewPresenter;
        private CreateNewTutorial view;
        private Collection model;

        public CreateViewPresenter(MainViewPresenter mainViewPresenter, CreateNewTutorial createView, Collection collectionModel)
        {
            this.mainViewPresenter = mainViewPresenter;
            this.view = createView;
            this.model = collectionModel;
            createView.Presenter = this;
        }

        public void OnMainLoad()
        {
            var q
                 = (from t in Collection.Teachers
                    select new IdNamePair
                    {
                        Id = t._TeacherID,
                        Name = t._FirstName + " " + t._LastName
                    }).ToList();
            this.view.FillIdStringComboBoxes(q, 0);

            q = (from t in Collection.Subjects
                 select new IdNamePair
                 {
                     Id = t._SubjectID,
                     Name = t._SubjectName
                 }).ToList();
            this.view.FillIdStringComboBoxes(q, 1);
            this.view.FillIntComboBoxes();
        }

        public void OnOKClicked(int teacherId, int subjectId, int year, int semester)
        {
            try
            {
                //Append();
                //create object t
                Tutorial t = new Tutorial(teacherId, subjectId, year, semester);
                //pass parameter to collection for updating file use
                Collection.Tutorials.Add(t);
                //Update the tutorial file
                var csv = new StringBuilder();
                //  var newLine = string.Format("{0},{1},{2},{3}", teacherId, subjectId, year, semester, Environment.NewLine);
                var newLine = string.Format("{0},{1},{2},{3}",
                    teacherId, subjectId, year, semester) + Environment.NewLine;
                csv.Append(newLine);
                File.AppendAllText("Tutorial.csv", csv.ToString());    //Append Text to file
                this.view.Close();
            }
            catch
            {
                //catch error
                System.Windows.MessageBox.Show("Please select data", "Error",
                    System.Windows.MessageBoxButton.OK,
                    System.Windows.MessageBoxImage.Error);
            }
            this.mainViewPresenter.ReadFilesAndDisplay();
        }
    }
}
