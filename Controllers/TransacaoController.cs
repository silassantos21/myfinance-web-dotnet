using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using myfinance_web_dotnet.Domain;
using myfinance_web_dotnet.Models;

namespace myfinance_web_dotnet.Controllers
{
    [Route("[controller]")]
    public class TransacaoController : Controller
    {
        private readonly ILogger<TransacaoController> _logger;
        private readonly MyFinanceDbContext _myFinanceDbContext;

        public TransacaoController(
            ILogger<TransacaoController> logger,
            MyFinanceDbContext myFinanceDbContext)
        {
            _logger = logger;
            _myFinanceDbContext = myFinanceDbContext;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var listaTransacao = _myFinanceDbContext.Transacao.Include(x => x.PlanoConta);
            var listaTransacaoModel = new List<TransacaoModel>();

            foreach (var item in listaTransacao)
            {
                var PlanoContaModel = new PlanoContaModel()
                {
                    Id = item.PlanoConta.Id,
                    Descricao = item.PlanoConta.Descricao,
                    Tipo = item.PlanoConta.Tipo
                };
                
                var transacaoModel = new TransacaoModel(){
                    Id = item.Id,
                    Historico = item.Historico,
                    Data = item.Data,
                    Valor = item.Valor,
                    PlanoContaId = item.PlanoContaId,
                    ItemPlanoConta = PlanoContaModel
                };

                listaTransacaoModel.Add(transacaoModel);
            }

            ViewBag.Transacoes = listaTransacaoModel;

            return View();
        }

        [HttpGet]
        [Route("Cadastro")]
        [Route("Cadastro/{id}")]
        public IActionResult Cadastro(int? id)
        {
            var itensPlanoConta = _myFinanceDbContext.PlanoConta;

            var transacaoModel = new TransacaoModel();

            List<SelectListItem> itensPlano = new();
            foreach(var item in itensPlanoConta)
            {
                itensPlano.Add(new SelectListItem() { Text = item.Descricao, Value = item.Id.ToString() });
            }

            transacaoModel.PlanoContas = itensPlano;

            if (id != null)
            {
                var transacao = _myFinanceDbContext.Transacao.Where(x => x.Id == id).FirstOrDefault();
                transacaoModel.Data = transacao.Data;
                transacaoModel.Historico = transacao.Historico;
                transacaoModel.Valor = transacao.Valor;
                transacaoModel.PlanoContaId = transacao.PlanoContaId;
            }


            return View(transacaoModel);
        }

        [HttpPost]
        [Route("Cadastro")]
        [Route("Cadastro/{id}")]
        public IActionResult Cadastro(TransacaoModel input)
        {
            var transacao = new Transacao()
            {
                Id = input.Id,
                Historico = input.Historico,
                Data = input.Data,
                Valor = input.Valor,
                PlanoContaId = input.PlanoContaId
            };

            if (transacao.Id == null)
                _myFinanceDbContext.Transacao.Add(transacao);
            else
            {
                _myFinanceDbContext.Transacao.Attach(transacao);
                _myFinanceDbContext.Entry(transacao).State = EntityState.Modified;
            }

            _myFinanceDbContext.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("Excluir/{id}")]
        public IActionResult Excluir(int id)
        {
            var transacao = new Transacao() { Id = id };
            _myFinanceDbContext.Transacao.Remove(transacao);
            _myFinanceDbContext.SaveChanges();

            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}