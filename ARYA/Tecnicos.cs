using BL.Seguridad;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ARYA
{
    public partial class Tecnicos : Form
    {
        TecnicosBL _tecnicosBL;
        public Tecnicos()
        {
            
            InitializeComponent();
            _tecnicosBL = new TecnicosBL();
            listaTecnicosBindingSource.DataSource = _tecnicosBL.SeleccionarTecnico();

        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            _tecnicosBL.AgregarTecnico();
            listaTecnicosBindingSource.MoveLast();

            DeshabilitarHabilitarBotones(false);
        }

        private void DeshabilitarHabilitarBotones(bool v)
        {
            bindingNavigatorMoveFirstItem.Enabled = v;
            bindingNavigatorMoveLastItem.Enabled = v;
            bindingNavigatorMovePreviousItem.Enabled = v;
            bindingNavigatorMoveNextItem.Enabled = v;
            bindingNavigatorPositionItem.Enabled = v;
            bindingNavigatorAddNewItem.Enabled = v;
            bindingNavigatorDeleteItem.Enabled = v;

            toolStripButtonCancelar.Visible = !v;

        }

        private void listaTecnicosBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            listaTecnicosBindingSource.EndEdit();

            var tecnico = (Tecnico)listaTecnicosBindingSource.Current;

            if (fotoPictureBox.Image != null)
            {
                tecnico.Foto = Program.imagetoByteArray(fotoPictureBox.Image);
            }
            else
            {
                tecnico.Foto = null;
            }

            var resultado = _tecnicosBL.GuardarTecnico(tecnico);

            if (resultado.Exitoso == true)
            {
                listaTecnicosBindingSource.ResetBindings(false);
                DeshabilitarHabilitarBotones(true);
                MessageBox.Show("Tecnico guardado");
            }
            else
            {
                MessageBox.Show(resultado.Mensaje);
            }
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if (idTextBox.Text != "")
            {
                var resultado = MessageBox.Show("Desea eliminar este registro?", "Eliminar", MessageBoxButtons.YesNo);
                if (resultado == DialogResult.Yes)

                {
                    var id = Convert.ToInt32(idTextBox.Text);
                    Eliminar(id);
                }
            }
        }

        private void Eliminar(int id)
        {

            var resultado = _tecnicosBL.EliminarTecnico(id);

            if (resultado == true)
            {
                listaTecnicosBindingSource.ResetBindings(false);
            }
            else
            {
                MessageBox.Show("Ocurrio un error al eliminar ");
            }
        }

        private void toolStripButtonCancelar_Click(object sender, EventArgs e)
        {

            _tecnicosBL.CancelarCambios();
            DeshabilitarHabilitarBotones(true);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var tecnico = (Tecnico)listaTecnicosBindingSource.Current;

            if (tecnico != null)
            {

                openFileDialog1.ShowDialog();
                var archivo = openFileDialog1.FileName;

                if (archivo != "")
                {
                    var fileInfo = new FileInfo(archivo);
                    var fileStream = fileInfo.OpenRead();

                    fotoPictureBox.Image = Image.FromStream(fileStream);
                }
            }
            else
            {
                MessageBox.Show(" Favor cree un tecnico antes de asignar una foto ");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            fotoPictureBox.Image = null;
        }

        private void idTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
