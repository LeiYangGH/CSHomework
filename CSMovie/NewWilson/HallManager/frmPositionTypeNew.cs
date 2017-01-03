using Model;
using System.Windows.Forms;

namespace HallManager
{
    public partial class frmPositionTypeNew : Form
    {
        public PositionType PositionType { get; set; }

        public frmPositionTypeNew(PositionType type)
        {
            InitializeComponent();
            PositionType = type;
        }

        private void txtPositionTypeNew_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                frmMain frm = this.Owner as frmMain;
                PositionType.Name = this.txtPositionTypeNew.Text;
                DialogResult = DialogResult.OK;
            }
            else if (e.KeyCode == Keys.Escape)
            {
                DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

    }
}
