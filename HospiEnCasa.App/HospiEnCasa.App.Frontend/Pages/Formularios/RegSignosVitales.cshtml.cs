using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HospiEnCasa.App.Dominio;
using HospiEnCasa.App.Persistencia;

namespace HospiEnCasa.App.Frontend.Pages
{
    public class RegSignosVitalesModel : PageModel
    {
         private IRepositorioPaciente repositorioPaciente = new RepositorioPaciente(new Persistencia.AppContext());
         private IRepositorioSignoVital repositorioSignoVital = new RepositorioSignoVital(new Persistencia.AppContext());

         public Paciente paciente {get;set;}
         public int? IdPaciente {get;set;}

         public SignoVital oximetria {get;set;}
         public SignoVital freqRespiratoria {get;set;}
         public SignoVital freqCardiaca {get;set;}
         public SignoVital temperatura {get;set;}
         public SignoVital sistolica {get;set;}
         public SignoVital diastolica {get;set;}
         public SignoVital glicemia {get;set;}

        public void OnGet(int? idPaciente)
        {
           if(idPaciente.HasValue){
                int IdPaciente = idPaciente.Value;
                paciente=repositorioPaciente.GetPaciente(IdPaciente);
                oximetria=new SignoVital
                {
                    Signo=TipoSigno.saturacionOxigeno,
                    pacienteId=paciente.Id,
                    paciente=paciente
                    
                };
                freqRespiratoria=new SignoVital
                {
                    Signo=TipoSigno.frecuenciaRespiratoria,
                    pacienteId=paciente.Id,
                    paciente=paciente
                };
                freqCardiaca=new SignoVital
                {
                    Signo=TipoSigno.frecuenciaCardiaca,
                    pacienteId=paciente.Id,
                    paciente=paciente
                };
                temperatura=new SignoVital
                {
                    Signo=TipoSigno.temperaturaCorporal,
                    pacienteId=paciente.Id,
                    paciente=paciente
                };
                sistolica=new SignoVital
                {
                    Signo=TipoSigno.sistolica,
                    pacienteId=paciente.Id,
                    paciente=paciente
                };
                diastolica=new SignoVital
                {
                    Signo=TipoSigno.diastolica,
                    pacienteId=paciente.Id,
                    paciente=paciente
                };
                glicemia=new SignoVital
                {
                    Signo=TipoSigno.glicemia,
                    pacienteId=paciente.Id,
                    paciente=paciente
                };
                

            }
                      
        }
        public void OnPost()
        {
            /*            
            oximetria=repositorioSignoVital.AddSignoVital(oximetria);
            freqRespiratoria=repositorioSignoVital.AddSignoVital(freqRespiratoria);
            freqCardiaca=repositorioSignoVital.AddSignoVital(freqCardiaca);
            sistolica=repositorioSignoVital.AddSignoVital(sistolica);
            diastolica=repositorioSignoVital.AddSignoVital(diastolica);
            glicemia=repositorioSignoVital.AddSignoVital(glicemia);*/

        }
    }
}
