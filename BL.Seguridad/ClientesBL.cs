using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Seguridad
{
     public class ClientesBL
    {
        Contexto _contexto;

        public BindingList<Cliente> ListaClientes { get; set; }

        public ClientesBL()
        {
            _contexto = new Contexto();
            ListaClientes = new BindingList<Cliente>();


        }

        public Resultado GuardarCliente(Cliente cliente)
        {
            var resultado = Validar(cliente);

            if (resultado.Exitoso == false)

            {
                return resultado;
            }

            _contexto.SaveChanges();

            resultado.Exitoso = true;
            return resultado;
        }

        public void CancelarCambios()
        {
            foreach (var item in _contexto.ChangeTracker.Entries())
            {
                item.State = EntityState.Unchanged;
                item.Reload();
            }
        }




        public void AgregarCliente()
        {
            var nuevocliente = new Cliente();
            ListaClientes.Add(nuevocliente);

        }

        public bool EliminarCliente(int id)
        {
            foreach (var cliente in ListaClientes)
            {
                if (cliente.Id == id)
                {
                    ListaClientes.Remove(cliente);

                    _contexto.SaveChanges();
                    return true;

                }


            }

            return false;
        }

        private Resultado Validar(Cliente cliente)
        {
            var resultado = new Resultado();
            resultado.Exitoso = true;

            if (string.IsNullOrEmpty(cliente.Nombre) == true)
            {
                resultado.Mensaje = "Ingrese un nombre";
                resultado.Exitoso = false;
            }

            else if (string.IsNullOrEmpty(cliente.Telefono) == true)
            {
                resultado.Mensaje = "Ingrese un Numero de telefono";
                resultado.Exitoso = false;
            }

            else if (string.IsNullOrEmpty(cliente.Direcion) == true)
            {
                resultado.Mensaje = "Por favor ingrese una direccion ";
                resultado.Exitoso = false;
            }
            return resultado;

        }

        public BindingList<Cliente> ObtenerClientes()
        {
            _contexto.Clientes.Load();//cargarDatos

            ListaClientes = _contexto.Clientes.Local.ToBindingList();
            return ListaClientes;
        }



        //buscador
        public BindingList<Cliente> ObtenerClientes(string buscar)
        {
            var query = _contexto.Clientes.Where(p => p.Nombre.ToLower().Contains(buscar.ToLower()) == true).ToList();
            
            var resultado = new BindingList<Cliente>(query);

            return resultado;
        }

    }


    //ClaseModelo
    public class Cliente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Direcion { get; set; }
        public string CorreoElectronico { get; set; }


    }
    public class Resultado
    {
        public bool Exitoso { get; set; }
        public string Mensaje { get; set; }
    }
}
