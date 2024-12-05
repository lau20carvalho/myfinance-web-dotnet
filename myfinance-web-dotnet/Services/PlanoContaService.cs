using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using myfinance_web_dotnet.Domain;
using myfinance_web_dotnet.Infrastructure;

namespace myfinance_web_dotnet.Services
{
    public class PlanoContaService(MyFinanceDbContext myFinanceDbContext) : IPlanoContaService
    {

        public void Excluir(int id)
        {
            throw new NotImplementedException();
        }

        public List<PlanoConta> ListarRegistros()
        {
            var lista = myFinanceDbContext.PlanoConta.ToList();
            return lista;
        }

        public void Salvar(PlanoConta planoConta)
        {
            var dBSet = myFinanceDbContext.PlanoConta;
            if (planoConta.Id == null)
            {
                dBSet.Add(planoConta);
            }
            else
            {
                dBSet.Attach(planoConta);
                myFinanceDbContext.Entry(planoConta).State = EntityState.Modified;
            }
            myFinanceDbContext.SaveChanges();
        }
        public PlanoConta Buscar(int id)
        {
            var planoConta = myFinanceDbContext.PlanoConta.Find(id);

            return planoConta ?? throw new ObjectDisposedException("Objeto não encontrado");
        }
    }
}