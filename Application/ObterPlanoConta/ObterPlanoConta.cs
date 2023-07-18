using myfinance_web_dotnet.Models;
using myfinance_web_dotnet.Services.Interfaces;

namespace myfinance_web_dotnet.Application.ObterPlanoConta
{
    public class ObterPlanoConta : IObterPlanoConta
    {
        private readonly IPlanoContaService _planoContaService;
        public ObterPlanoConta(IPlanoContaService planoContaService)
        {
            _planoContaService = planoContaService;
        }
        List<PlanoContaModel> IObterPlanoConta.GetListaPlanoContaModel()
        {

            return _planoContaService.ListaPlanoContaModel();
        }
    }
}