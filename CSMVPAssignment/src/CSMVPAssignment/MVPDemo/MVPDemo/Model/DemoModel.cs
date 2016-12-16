using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVPDemo.Model
{
    public class DemoModel
    {
        //data
        public Int32 Operand1 { get; set; }
        public  Int32 Operand2 { get; set; }

        public Int32 Result { get; private set; }

        //business logic
        public void Add()
        {
            Result = Operand1 + Operand2;
        }
    }
}
