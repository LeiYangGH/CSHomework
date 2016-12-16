using System.Collections.Generic;
using System.Linq;
using WpfApp2.Model;

namespace WpfApp2.Presenter
{
    public class MainViewPresenter
    {
        private MainWindow view;
        internal Collection model;

        public MainViewPresenter(MainWindow mainView, Collection collectionModel)
        {
            this.view = mainView;
            this.model = collectionModel;
            mainView.Presenter = this;
        }

        public void OnMainLoad()
        {
            this.ReadFilesAndDisplay();
        }

        public void OnCreateClicked()
        {
            //model
            Collection collectionModel = this.model;

            //view
            CreateNewTutorial create = new CreateNewTutorial();

            //presenter
            CreateViewPresenter presenter = new CreateViewPresenter(this, create, collectionModel);
            create.ShowDialog();
        }

        private string GetTeacherNameById(int id)
        {
            Teacher t = Collection.Teachers.First(x => x._TeacherID == id);
            return t.FullName;
        }

        public string GetSubjectById(int id)
        {
            Subject t = Collection.Subjects.First(x => x._SubjectID == id);
            return t._SubjectName;
        }

        public void ReadFilesAndDisplay()
        {

            Collection.FillCollections();
            List<string> items = new List<string>();
            foreach (var item in Collection.Tutorials)
            {
                items.Add(GetTeacherNameById(item._TeacherID)
                    + "\t    "
                    + GetSubjectById(item._SubjectID)
                    + "\t\t\t " + item._Year
                    + "\t\t "
                    + item._Semester + "\t");
            }
            this.view.UpdateView(items);
        }
    }
}
