using BL.Seguridad;
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
    public partial class FormReporteEquipos : Form
    {
        public FormReporteEquipos()
        {
            InitializeComponent();

            var _equiposBL = new EquiposBL();
            var clienteBL = new ClientesBL();

            var bindingsource1 = new BindingSource();
            bindingsource1.DataSource = _equiposBL.ObtenerEquipos();


            var bindingsource2 = new BindingSource();
            bindingsource2.DataSource = clienteBL.ObtenerClientes();

            var reporte = new ReporteEquipos();
            reporte.Database.Tables["Equipo"].SetDataSource(bindingsource1);
            reporte.Database.Tables["Cliente"].SetDataSource(bindingsource2);

            crystalReportViewer1.ReportSource = reporte;
            crystalReportViewer1.RefreshReport();
        }
    }
}
