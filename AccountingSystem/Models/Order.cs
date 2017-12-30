using AccountingSystem.Models.FrontendModels;
using System;

namespace AccountingSystem.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int Number { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }

        public OrderViewModel MapToOrderViewModel(Order order)
        {
            var model = new OrderViewModel
            {
                Id = order.Id,
                Number = order.Number,
                Date = order.Date,
                Amount = order.Amount
            };

            return model;
        }
    }
}