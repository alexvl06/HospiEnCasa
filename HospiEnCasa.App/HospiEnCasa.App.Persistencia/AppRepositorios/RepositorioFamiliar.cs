using HospiEnCasa.App.Dominio;
using System.Collections.Generic;
using System.Linq;
namespace HospiEnCasa.App.Persistencia
{
    public class  RepositorioFamiliar:IRepositorioFamiliar
    {
        private readonly AppContext _appContext;
        public RepositorioFamiliar(AppContext appContext){
            _appContext=appContext;
        }
        FamiliarDesignado IRepositorioFamiliar.AddFamiliar(FamiliarDesignado familiar){
            /*var pacienteAdicionado = _appContext.Pacientes.Add(paciente);
            _appContext.SaveChanges();
            return pacienteAdicionado.Entity;*/
        }
        void IRepositorioFamiliar.DeleteFamiliar(int idFamiliar){
            /*var pacienteEncontrado = _appContext.Pacientes.FirstOrDefault(p => p.Id == idPaciente);
            if(pacienteEncontrado==null)
                return;
            _appContext.Pacientes.Remove(pacienteEncontrado);
            _appContext.SaveChanges();

            */
        }
        
        FamiliarDesignado IRepositorioFamiliar.GetFamiliar(int idFamiliar){
            //return _appContext.Pacientes.FirstOrDefault(p=> p.Id == idPaciente);
        }
        FamiliarDesignado IRepositorioFamiliar.UpdateFamiliar(FamiliarDesignado familiar){
            /*var pacienteEncontrado = _appContext.Pacientes.FirstOrDefault(p => p.Id == paciente.Id);
            if(pacienteEncontrado != null){
                pacienteEncontrado.Nombre = paciente.Nombre;
                pacienteEncontrado.Apellidos = paciente.Apellidos;
                pacienteEncontrado.NumeroTelefono = paciente.NumeroTelefono;
                pacienteEncontrado.Genero = paciente.Genero;
                pacienteEncontrado.Direccion = paciente.Direccion;
                pacienteEncontrado.Latitud = paciente.Latitud;
                pacienteEncontrado.Longitud = paciente.Longitud;
                pacienteEncontrado.Ciudad =  paciente.Ciudad;
                pacienteEncontrado.FechaNacimiento = paciente.FechaNacimiento;
                pacienteEncontrado.FamiliarDesignado = paciente.FamiliarDesignado;
                pacienteEncontrado.Enfermera = paciente.Enfermera;
                pacienteEncontrado.Medico = paciente.Medico;
                pacienteEncontrado.Historia = paciente.Historia;                
            
                
                _appContext.SaveChanges();
            }
            return pacienteEncontrado;
                */
        }
    }    
}