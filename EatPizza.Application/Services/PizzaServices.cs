using AutoMapper;
using EatPizza.Application.Models;
using EatPizza.Infrastructure.Context;
using EatPizzaServices.IServices;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace EatPizza.Application.Services
{
    public class PizzaServices : IPizzaServices
    {
        private readonly EatPizzaContext _context;
        private readonly IMapper _mapper;
        public PizzaServices(EatPizzaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<PizzaViewModel>> GetPizzas()
        {
            return await _context.Pizzas.AsNoTracking().Select(b => _mapper.Map<PizzaViewModel>(b)).ToListAsync();
        }

        public async Task<PizzaViewModel> PizzaById(int id)
        {
            return  _mapper.Map<PizzaViewModel>(await _context.Pizzas.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id));
        }
    }
}
