using myfinance_web_dotnet.Models;
namespace myfinance_web_dotnet.Application.ObterPlanoConta
{
    public interface IObterPlanoConta
    {
        List<PlanoContaModel> GetListaPlanoContaModel();
    }
}