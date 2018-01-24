using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapaBobs.Persistence
{
    public class OrderRepository
    {
        public static void CreateOrder(DTO.OrderDTO orderDTO)
        {
            //Testing
            var db = new PapaBobsDbEntities();
            var order = ConvertToEntity(orderDTO);
            

            db.Orders.Add(order);
            db.SaveChanges();

        }

        private static Order ConvertToEntity(DTO.OrderDTO orderDTO)
        {
            var order = new Order
            {
                OrderId = orderDTO.OrderId,
                Size = orderDTO.Size,
                Crust = orderDTO.Crust,
                Sausage = orderDTO.Sausage,
                Pepperoni = orderDTO.Pepperoni,
                GreenPeppers = orderDTO.GreenPeppers,
                Onions = orderDTO.Onions,
                Name = orderDTO.Name,
                Address = orderDTO.Address,
                Phone = orderDTO.Phone,
                Zip = orderDTO.Zip,
                TotalCost = orderDTO.TotalCost,
                PaymentType = orderDTO.PaymentType,
                Completed = orderDTO.Completed
             };

            return order;
        }

        public static List<DTO.OrderDTO> GetOrders()
        {
            var db = new PapaBobsDbEntities();
            var orders = db.Orders.Where(p => p.Completed == false).ToList();
            var ordersDTO = convertToDTO(orders);
            return ordersDTO;
        }

        private static List<DTO.OrderDTO> convertToDTO(List<Order> orders)
        {
            var ordersDTO = new List<DTO.OrderDTO>();

            foreach (var order in orders)
            {
                var orderDTO = new DTO.OrderDTO
                {
                    OrderId = order.OrderId,
                    Size = order.Size,
                    Crust = order.Crust,
                    Sausage = order.Sausage,
                    Pepperoni = order.Pepperoni,
                    GreenPeppers = order.GreenPeppers,
                    Onions = order.Onions,
                    Name = order.Name,
                    Address = order.Address,
                    Phone = order.Phone,
                    Zip = order.Zip,
                    TotalCost = order.TotalCost,
                    PaymentType = order.PaymentType,
                    Completed = order.Completed

                };
                ordersDTO.Add(orderDTO);
            }
            return ordersDTO;
               
            }

        public static void CompleteOrder(Guid orderId)
        {
            var db = new PapaBobsDbEntities();
            var order = db.Orders.FirstOrDefault(p => p.OrderId == orderId);
            order.Completed = true;
            db.SaveChanges();
        }
    }
    
}

