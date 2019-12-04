using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ARYA
{
    public partial class menu : Form
    {
        public menu()
        {
            InitializeComponent();
            hideSubMenu();
        }

        private void hideSubMenu()
        {
     
            panelPlaylistSubMenu.Visible = false;
          panelToolsSubMenu.Visible = false;
        }
        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
        }
        private void login()
        {
            var formlogin = new Login();
            
            formlogin.ShowDialog();
        }

  

        private void menu_Load(object sender, EventArgs e)
        {
            login();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
        Application.Exit();
        }


        private void btnMedia_Click_1(object sender, EventArgs e)
        {

            openChildForm(new Clientes());
            hideSubMenu();

           
        }

   

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void btnPlaylist_Click(object sender, EventArgs e)
        {

            

            showSubMenu(panelPlaylistSubMenu);

        }
        #region PlayListManagemetSubMenu
        private void button8_Click(object sender, EventArgs e)
        {
            openChildForm(new OrdenesEquipos());
            hideSubMenu();

        }

        private void button7_Click(object sender, EventArgs e)
        {
           
        }

        #endregion

        private void btnEqualizer_Click(object sender, EventArgs e)
        {
        
        }
        private void btnTools_Click(object sender, EventArgs e)
        {
            showSubMenu(panelToolsSubMenu);
        }
        #region ToolsSubMenu
        private void button13_Click(object sender, EventArgs e)
        {
            openChildForm(new FormReporteClientes());
            hideSubMenu();
        }
        private void button12_Click(object sender, EventArgs e)
        {
            openChildForm(new FormReporteEquipos());
            hideSubMenu();
        }

        #endregion

        private void btnExit_Click_1(object sender, EventArgs e)
        {
            openChildForm(new Tecnicos());
            hideSubMenu();

        }

      

        private void btnHelp_Click(object sender, EventArgs e)
        {
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void panelChildForm_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

            login();
            
        }
        private Form activeForm = null;
        private void openChildForm(Form childForm)
        {
            if (activeForm != null) activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
           childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelChildForm.Controls.Add(childForm);
            panelChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }


    }
}
