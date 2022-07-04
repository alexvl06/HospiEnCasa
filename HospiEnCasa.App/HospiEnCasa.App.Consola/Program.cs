using System;
using HospiEnCasa.App.Dominio;
using HospiEnCasa.App.Persistencia;

namespace HospiEnCasa.App.Consola
{
    class Program
    {
        private static IRepositorioPaciente _repoPaciente = new RepositorioPaciente(new Persistencia.AppContext());

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World! Entity Framework");
            AddPaciente();
        }
        private static void AddPaciente()
        {
            var paciente = new Paciente
            {
                Nombre = "Pepito",
                Apellidos = "Perez Prieto",
                NumeroTelefono = "3000000000",
                Genero = Genero.masculino,
                Direccion = "Calle 8",
                Longitud = 9.54F,
                Latitud = 45.55F,
                Ciudad = "Santa Marta",
                FechaNacimiento = new DateTime(1972, 11, 08)
            };
            _repoPaciente.AddPaciente(paciente);
        }
    }
}
