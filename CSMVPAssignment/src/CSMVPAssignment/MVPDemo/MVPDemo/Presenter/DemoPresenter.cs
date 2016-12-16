using MVPDemo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVPDemo.Presenter
{
    public class DemoPresenter
    {
        private DemoModel model;
        private Demoview view;

        public DemoPresenter(DemoModel model, Demoview view)
        {
            this.model = model;
            this.view = view;

            view.Presenter = this;
        }

        public void OnOperand1Change(Int32 operand1)
        {
            model.Operand1 = operand1;
        }

        public void OnOperand2Change(Int32 operand2)
        {
            model.Operand2 = operand2;
        }

        public void OnAddClicked()
        {
            model.Add();
            UpdateView();
        }

        private void UpdateView()
        {
            view.UpdateView(model.Operand1, model.Operand2, model.Result);
        }
    }
}
