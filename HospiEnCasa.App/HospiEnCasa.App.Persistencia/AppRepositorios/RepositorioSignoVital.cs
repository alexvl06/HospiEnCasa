using HospiEnCasa.App.Dominio;
using System.Collections.Generic;
using System.Linq;
namespace HospiEnCasa.App.Persistencia
{
    public class  RepositorioSignoVital:IRepositorioSignoVital
    {
        private readonly AppContext _appContext;
        public RepositorioSignoVital(AppContext appContext){
            _appContext=appContext;
        }
        SignoVital IRepositorioSignoVital.AddSignoVital(SignoVital signo)
        {
            var signoAdicionado = _appContext.SignosVitales.Add(signo);
            _appContext.SaveChanges();
            return signoAdicionado.Entity;
        }
    }    
}