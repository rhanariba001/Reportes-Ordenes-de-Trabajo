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
    public partial class OrdenesEquipos : Form
    {
        EquiposBL _equiposBL;
        ClientesBL _clientes;
        TiposBL _tipos;
        TecnicosBL _tecnico;

        public OrdenesEquipos()
        {
            InitializeComponent();

            _equiposBL = new EquiposBL();
            listaEquiposBindingSource.DataSource = _equiposBL.ObtenerEquipos();

            _clientes = new ClientesBL();
            listaClientesBindingSource.DataSource = _clientes.ObtenerClientes();

            _tipos = new TiposBL();
            listaTiposBindingSource.DataSource = _tipos.ObtenerTipos();

            _tecnico = new TecnicosBL();
            listaTecnicosBindingSource.DataSource = _tecnico.SeleccionarTecnico();
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            _equiposBL.AgregarEquipo();
            listaClientesBindingSource.MoveLast();

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

        private void listaEquiposBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            listaEquiposBindingSource.EndEdit();

            var equipo = (Equipo)listaEquiposBindingSource.Current;

            var resultado = _equiposBL.GuardarEquipo(equipo);

            if (resultado.Exitoso== true)
            {
                listaEquiposBindingSource.ResetBindings(false);
                DeshabilitarHabilitarBotones(true);
                MessageBox.Show("Guardado");
            }
            else
            {
                MessageBox.Show(resultado.Mensaje);

            }

        }

        private void toolStripButtonCancelar_Click(object sender, EventArgs e)
        {
            
            _equiposBL.CancelarCambios();
            DeshabilitarHabilitarBotones(true);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var equipo = (Equipo)listaEquiposBindingSource.Current;

            _equiposBL.AgregarDetallesEquipo(equipo);

            DeshabilitarHabilitarBotones(false);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var equipo = (Equipo)listaEquiposBindingSource.Current;

            var detallesEquipo = (DetallesEquipo)detallesEquipoBindingSource.Current;

            _equiposBL.RemoverDetallesEquipo(equipo, detallesEquipo);

            DeshabilitarHabilitarBotones(true);
        }


        private void OrdenesEquipos_Load(object sender, EventArgs e)
        {

        }

        private void detallesEquipoDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            var equipo = (Equipo)listaEquiposBindingSource.Current;

            if (equipo != null)
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
                MessageBox.Show(" Favor cree un equipo antes de asignar una foto ");
            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            fotoPictureBox.Image = null;
        }
    }
}
