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
            var familiarAdicionado = _appContext.FamiliaresDesignados.Add(familiar);
            _appContext.SaveChanges();
            return familiarAdicionado.Entity;
        }
        void IRepositorioFamiliar.DeleteFamiliar(int idFamiliar){
            var familiarEncontrado = _appContext.FamiliaresDesignados.FirstOrDefault(f => f.Id == idFamiliar);
            if(familiarEncontrado==null)
                return;
            _appContext.FamiliaresDesignados.Remove(familiarEncontrado);
            _appContext.SaveChanges();

            
        }
        
        FamiliarDesignado IRepositorioFamiliar.GetFamiliar(int idFamiliar){
            return _appContext.FamiliaresDesignados.FirstOrDefault(f=> f.Id == idFamiliar);
        }
        FamiliarDesignado IRepositorioFamiliar.UpdateFamiliar(FamiliarDesignado familiar){
            var familiarEncontrado = _appContext.FamiliaresDesignados.FirstOrDefault(f => f.Id == familiar.Id);
            if(familiarEncontrado != null){
                familiarEncontrado.Nombre = familiar.Nombre;
                familiarEncontrado.Apellidos = familiar.Apellidos;
                familiarEncontrado.NumeroTelefono = familiar.NumeroTelefono;
                familiarEncontrado.Genero = familiar.Genero;

                familiarEncontrado.Parentesco = familiar.Parentesco;
                familiarEncontrado.Correo =  familiar.Correo;                
            
                
                _appContext.SaveChanges();
            }
            return familiarEncontrado;
                
        }
    }    
}