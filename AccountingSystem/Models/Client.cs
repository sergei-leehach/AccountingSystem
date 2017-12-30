using AccountingSystem.Models.FrontendModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AccountingSystem.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public DateTime BDay { get; set; }
        public string PhoneNumber { get; set; }

        public IReadOnlyCollection<Order> Orders { get; set; }

        public void SetOrders(IReadOnlyCollection<Order> orders)
        {
            Orders = orders;
        }

        public ClientViewModel MapToClientViewModel(Client client)
        {
            var model = new ClientViewModel { Id = client.Id, FullName = client.FullName };

            return model;
        }

        public ClientCardViewModel MapToClientCardViewModel(Client client, decimal totalAmount)
        {
            var model = new ClientCardViewModel
            {
                Id = client.Id,
                FullName = client.FullName,
                BDay = client.BDay,
                PhoneNumber = client.PhoneNumber,
                Orders = client.Orders.Select(order => order.MapToOrderViewModel(order)),
                TotalAmount = totalAmount
            };

            return model;
        }
    }
}