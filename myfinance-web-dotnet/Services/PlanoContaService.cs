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
            var item = BuscarRegistro(id);
            myFinanceDbContext.Attach(item);
            myFinanceDbContext.Remove(item);
            myFinanceDbContext.SaveChanges();
        }

        public List<PlanoConta> ListarRegistros()
        {
            var lista = myFinanceDbContext.PlanoConta.ToList();
            return lista;
        }

        public PlanoConta BuscarRegistro(int id)
        {
            var planoConta = myFinanceDbContext.PlanoConta.Where(x => x.Id == id).First();

            return planoConta;
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
    }
}