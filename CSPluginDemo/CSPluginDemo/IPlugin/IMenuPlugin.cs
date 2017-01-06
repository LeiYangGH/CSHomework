using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IPlugin
{
    public interface IMenuPlugin
    {
        //void Run();
        //void Exit();
        //void SetTextBox(TextBox tb);
        //void SetMenuStrip(MenuStrip strip);

        Dictionary<string, Action<TextBox>> GetMenus();
    }
}
