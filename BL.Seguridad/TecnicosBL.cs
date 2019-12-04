using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Seguridad
{
   public class TecnicosBL
    {
        Contexto _contexto;

        public BindingList<Tecnico> ListaTecnicos { get; set; }



        public TecnicosBL()
        {
            _contexto = new Contexto();
            ListaTecnicos = new BindingList<Tecnico>();
        }

        public BindingList<Tecnico> SeleccionarTecnico()
        {
            _contexto.Tecnicos.Load();
            ListaTecnicos = _contexto.Tecnicos.Local.ToBindingList();

            return ListaTecnicos;
        }

        public void CancelarCambios()
        {
            foreach (var item in _contexto.ChangeTracker.Entries())
            {
                item.State = EntityState.Unchanged;
                item.Reload();
            }
        }

        public Resultado GuardarTecnico(Tecnico tecnico)
        {
            var resultado = Validar(tecnico);
            if (resultado.Exitoso == false)
            {
                return resultado;
            }

            _contexto.SaveChanges();

            resultado.Exitoso = true;
            return resultado;
        }

        public void AgregarTecnico()
        {
            var nuevoTecnico = new Tecnico();

            ListaTecnicos.Add(nuevoTecnico);
        }

        public bool EliminarTecnico(int id)
        {
            foreach (var tecnico in ListaTecnicos)
            {
                if (tecnico.Id == id)
                {
                    ListaTecnicos.Remove(tecnico);
                    _contexto.SaveChanges();
                    return true;
                }


            }

            return false;
        }

        private Resultado Validar(Tecnico tecnico)
        {
            var resultado = new Resultado();
            resultado.Exitoso = true;

            if (string.IsNullOrEmpty(tecnico.Nombre) == true)
            {
                resultado.Mensaje = "Ingrese un nombre";
                resultado.Exitoso = false;
            }

            if (string.IsNullOrEmpty(tecnico.Telefono) == true)
            {
                resultado.Mensaje = "Ingrese un Numero de telefono";
                resultado.Exitoso = false;
            }

            if (string.IsNullOrEmpty(tecnico.Direccion) == true)
            {
                resultado.Mensaje = "Por favor ingrese una direccion ";
                resultado.Exitoso = false;
            }


            return resultado;
        }


    }


    public class Tecnico
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string CorreoElectronico { get; set; }
        public byte[] Foto { get; set; }




    }
}



   



