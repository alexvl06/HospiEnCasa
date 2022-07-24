using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HospiEnCasa.App.Dominio;
using HospiEnCasa.App.Persistencia;
using System.Globalization;

namespace HospiEnCasa.App.Frontend.Pages
{
    public class RegSignosVitalesModel : PageModel
    {
         private IRepositorioPaciente repositorioPaciente = new RepositorioPaciente(new Persistencia.AppContext());
         private IRepositorioSignoVital repositorioSignoVital = new RepositorioSignoVital(new Persistencia.AppContext());
        
        [BindProperty]
         public Paciente paciente {get;set;}
         public int? IdPaciente {get;set;}
        [BindProperty]
         public SignoVital oximetria {get;set;}
         [BindProperty]
         public SignoVital freqRespiratoria {get;set;}
         [BindProperty]
         public SignoVital freqCardiaca {get;set;}
         [BindProperty]
         public SignoVital temperatura {get;set;}
         [BindProperty]
         public SignoVital sistolica {get;set;}
         [BindProperty]
         public SignoVital diastolica {get;set;}
         [BindProperty]
         public SignoVital glicemia {get;set;}

        public void OnGet(int? idPaciente)
        {
           if(idPaciente.HasValue){
                int IdPaciente = idPaciente.Value;
                paciente=repositorioPaciente.GetPaciente(IdPaciente);
                oximetria=new SignoVital
                {
                    Signo=TipoSigno.saturacionOxigeno,
                    pacienteId=IdPaciente,                    
                   
                    
                };
                freqRespiratoria=new SignoVital
                {
                    Signo=TipoSigno.frecuenciaRespiratoria,
                    pacienteId=IdPaciente,
                   
                };
                freqCardiaca=new SignoVital
                {
                    Signo=TipoSigno.frecuenciaCardiaca,
                    pacienteId=IdPaciente,
                    
                };
                temperatura=new SignoVital
                {
                    Signo=TipoSigno.temperaturaCorporal,
                    pacienteId=IdPaciente,
                    
                };
                sistolica=new SignoVital
                {
                    Signo=TipoSigno.sistolica,
                    pacienteId=IdPaciente,
                   
                };
                diastolica=new SignoVital
                {
                    Signo=TipoSigno.diastolica,
                    pacienteId=IdPaciente,
                    
                };
                glicemia=new SignoVital
                {
                    Signo=TipoSigno.glicemia,
                    pacienteId=IdPaciente,
                    
                };
                

            }
                      
        }
        public IActionResult OnPost(string temp)
        {
            DateTime ahora = DateTime.Now;
           if(oximetria.Valor.HasValue)
           {
                
                oximetria.FechaHora=ahora;
                oximetria=repositorioSignoVital.AddSignoVital(oximetria);
           }
           if(freqRespiratoria.Valor.HasValue)
           {
                freqRespiratoria.FechaHora=ahora;
                freqRespiratoria=repositorioSignoVital.AddSignoVital(freqRespiratoria);
           }
           if(freqCardiaca.Valor.HasValue)
           {
                freqCardiaca.FechaHora=ahora;
                freqCardiaca=repositorioSignoVital.AddSignoVital(freqCardiaca);
           }
           if(temperatura.Valor.HasValue)
           {
                temperatura.FechaHora=ahora;
                temperatura=repositorioSignoVital.AddSignoVital(temperatura);
           }
           if(sistolica.Valor.HasValue)
           {
                sistolica.FechaHora=ahora;
                sistolica=repositorioSignoVital.AddSignoVital(sistolica);
           }
           if(diastolica.Valor.HasValue)
           {
                diastolica.FechaHora=ahora;
                diastolica=repositorioSignoVital.AddSignoVital(diastolica);
           }
           if(glicemia.Valor.HasValue)
           {
               glicemia.FechaHora=ahora;
               glicemia=repositorioSignoVital.AddSignoVital(glicemia);
           
           }
            
            
            return Page();
            


        }
    }
}
