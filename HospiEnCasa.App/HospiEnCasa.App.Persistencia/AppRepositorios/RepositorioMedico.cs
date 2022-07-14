using HospiEnCasa.App.Dominio;
using System.Collections.Generic;
using System.Linq;
namespace HospiEnCasa.App.Persistencia
{
    public class  RepositorioMedico:IRepositorioMedico
    {
        private readonly AppContext _appContext;
        public RepositorioMedico (AppContext appContext){
            _appContext=appContext;
        }
        Medico IRepositorioMedico.AddMedico(Medico medico){
            var medicoAdicionado = _appContext.Medico.Add(medico);
            _appContext.SaveChanges();
            return medicoAdicionado.Entity;
        }
        void IRepositorioMedico.DeleteMedico(int idMedico){
            var medicoEncontrado = _appContext.medico.FirstOrDefault(m => m.Id == idMedico);
            if(medicoEncontrado==null){
                return;
            }
            _appContext.Medico.Remove(medicoEncontrado);
            _appContext.SaveChanges();  
        }
        IEnumerable<Medico> IRepositorioMedico.GetAllMedicos(){
            return _appContext.Medicos;
        }
        Medico IRepositorioMedico.GetMedico(int idMedico){
            return _appContext.Medicos.FirstOrDefault(m=> m.Id == idMedico);
        }
        Medico IRepositorioMedico.UpdateMedico(Medico medico){
            var medicoEncontrado = _appContext.Medicos.FirstOrDefault(m => m.Id == medico.Id);
            if(medicoEncontrado != null){

                medicoEncontrado.Nombre = medico.Nombre;
                medicoEncontrado.Apellidos = medico.Apellidos;
                medicoEncontrado.NumeroTelefono = medico.NumeroTelefono;
                medicoEncontrado.Genero = medico.Genero;
                medicoEncontrado.Especialidad = medico.Especialidad;
                medicoEncontrado.Codigo = medico.Codigo;
                medicoEncontrado.RegistroRethus = medico.RegistroRethus;              
            
                
                _appContext.SaveChanges();
            }
            return medicoEncontrado;
                
        }
    }    
}