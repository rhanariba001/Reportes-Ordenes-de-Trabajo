using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Seguridad
{
    public class EquiposBL
    {
        Contexto _contexto;

        public BindingList<Equipo> ListaEquipos { get; set; }


        public EquiposBL()
        {
            _contexto = new Contexto();
        }

        public BindingList<Equipo> ObtenerEquipos() 
        {
            _contexto.Equipos.Include("DetallesEquipo").Load();
            ListaEquipos = _contexto.Equipos.Local.ToBindingList();

            return ListaEquipos;
        }

        public void AgregarEquipo()
        {
            var nuevoEquipo = new Equipo();
            _contexto.Equipos.Add(nuevoEquipo);
        }


        public void RemoverDetallesEquipo(Equipo equipo, DetallesEquipo detallesEquipo)
        {
            if (equipo !=null && detallesEquipo != null )
            {
                equipo.DetallesEquipo.Remove(detallesEquipo);

            }
        }



        public void AgregarDetallesEquipo(Equipo equipo)
        {
            if (equipo!=null)
            {
                var nuevoDetalle = new DetallesEquipo();
                equipo.DetallesEquipo.Add(nuevoDetalle);

            }
        }



        public void CancelarCambios()
        {
            foreach (var item in _contexto.ChangeTracker.Entries())
            {
                item.State = EntityState.Unchanged;
                item.Reload();
            }
        }


        public Resultado GuardarEquipo(Equipo equipo)
        {
            var resultado = Validar(equipo);

            if (resultado.Exitoso == false)

            {
                return resultado;
            }

            _contexto.SaveChanges();
            resultado.Exitoso = true;
            return resultado;
        }


        private Resultado Validar(Equipo equipo)
        {
            var resultado = new Resultado();
            resultado.Exitoso = true;

            return resultado;

        }
    }


    public class Equipo
    {
        public int Id { get; set; }
        public string NoSerie { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Fallas { get; set; }
        public bool Activo { get; set; }
        public byte[] Foto { get; set; }
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public BindingList<DetallesEquipo> DetallesEquipo { get; set; }
        

        public double PrecioEstimado { get; set; }

        public Equipo()
        {
           
            DetallesEquipo = new BindingList<DetallesEquipo>();
            Activo = true;
        }
    }

    public class DetallesEquipo
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public int TecnicoId { get; set; }
        public Tecnico Tecnico { get; set; }
        public DateTime Fecha { get; set; }
        public int TipoId { get; set; }
        public Tipo Tipo { get; set; }


        public DetallesEquipo()
        {
            Fecha = DateTime.Now;
        }

    }


}
