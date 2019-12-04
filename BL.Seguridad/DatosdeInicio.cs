using BL.Seguridad;
using System.Data.Entity;

namespace BL.Seguridad
{
    internal class DatosdeInicio : CreateDatabaseIfNotExists<Contexto>
    {
        protected override void Seed(Contexto contexto)
        {
            //usuarios
            var usuarioAdmin = new Usuario();
            usuarioAdmin.Nombre = " admin";
            usuarioAdmin.Contrasena = "123";

            contexto.Usuarios.Add(usuarioAdmin);
            //talleres
            var Tipo1 = new Tipo();
            Tipo1.Descripcion = " Sin Revisar ";
            contexto.Tipos.Add(Tipo1);

            var Tipo2 = new Tipo();
            Tipo2.Descripcion = " En taller ";
            contexto.Tipos.Add(Tipo2);

            var Tipo3 = new Tipo();
            Tipo3.Descripcion = " En esperando ";
            contexto.Tipos.Add(Tipo3);

            var Tipo4 = new Tipo();
            Tipo4.Descripcion = " Entregado ";
            contexto.Tipos.Add(Tipo4);



            //tecnicos
            var tecnico1 = new Tecnico();
            tecnico1.Nombre = "Kevin Valladares";
            tecnico1.Telefono = "345324643";
            tecnico1.Direccion = "Sps 3 calle 4 ave.";
            tecnico1.CorreoElectronico = "kvls@gmail.com";

            contexto.Tecnicos.Add(tecnico1);


            var tecnico2 = new Tecnico();
            tecnico2.Nombre = "Carlos Lopez";
            tecnico2.Telefono = "99298990";
            tecnico2.Direccion = "Sps Barrio Medina 2 calle";
            tecnico2.CorreoElectronico = "robt@gmail.com";
            contexto.Tecnicos.Add(tecnico2);


            base.Seed(contexto);


        }
    }
}