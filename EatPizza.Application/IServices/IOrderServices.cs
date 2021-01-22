using EatPizza.Application.Models;
using EatPizza.Application.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EatPizzaServices.IServices
{
    public interface IOrderServices
    {
        Task<List<OrderViewModel>> GetOrdersByCustomer(int id);
        Task<OrderViewModel> GetOrderById(int id);
        Task<Result> AddOrder(OrderViewModel order);
    }
}
