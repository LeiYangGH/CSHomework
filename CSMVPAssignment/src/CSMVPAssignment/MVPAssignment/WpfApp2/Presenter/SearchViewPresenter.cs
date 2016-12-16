using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp2.Presenter
{
    public class SearchViewPresenter
    {

        private Model.Collection c_model;
        private SearchWindow s_view;


        public SearchViewPresenter(Model.Collection c_model,
                                    SearchWindow s_view)
        {
      
            this.c_model = c_model;
          
            s_view.svPresenter = this;

        }


        //private async Task Search(int id)
        //{
        //    await Task.Run(() =>
        //    {
        //        //declare name as Fullname and pass id parameter
        //        string name = Model.Collection.Teachers.First(x => x._TeacherID == id).FullName;

        //        //show name
        //        MessageBox.Show(name, "This teacher ID will be",
        //            MessageBoxButton.OK, MessageBoxImage.Information);
        //    });




        }
}
