using EatPizza.Application.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EatPizzaServices.IServices
{
    public interface IPizzaServices
    {
        Task<List<PizzaViewModel>> GetPizzas();
        Task<PizzaViewModel> PizzaById(int id);
    }
}
