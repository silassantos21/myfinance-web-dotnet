using myfinance_web_dotnet.Application.ObterPlanoConta;
using myfinance_web_dotnet.Models;
using myfinance_web_dotnet.Services.Interfaces;

namespace myfinance_web_dotnet.Application.CadastrarPlanoConta
{
    public class CadastrarPlanoConta : ICadastrarPlanoConta
    {
        private readonly IPlanoContaService _planoContaService;
        public CadastrarPlanoConta(IPlanoContaService planoContaService)
        {
            _planoContaService = planoContaService;
        }

        public void Cadastrar(PlanoContaModel input)
        {
            _planoContaService.CadastrarPlanoConta(input);
        }
    }
}