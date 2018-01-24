using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapaBobs.Domain
{
    public class OrderManager
    {
        public static void CreateOrder(DTO.OrderDTO orderDTO)
        {
            // Validation
            if (orderDTO.Name.Trim().Length == 0)
                throw new Exception("Name is required");

            if (orderDTO.Address.Trim().Length == 0)
                throw new Exception("Address is required");

            if (orderDTO.Zip.Trim().Length == 0)
                throw new Exception("Zip Code is required");

            if (orderDTO.Phone.Trim().Length == 0)
                throw new Exception("Phone number is required");

            orderDTO.OrderId = Guid.NewGuid();
            orderDTO.TotalCost = PizzaPriceManager.CalculateCost(orderDTO);
            Persistence.OrderRepository.CreateOrder(orderDTO);

            /* //Test Order:
                        var order = new DTO.OrderDTO();
                        order.OrderId = Guid.NewGuid();
                        order.Size = DTO.Enums.SizeType.Large;
                        order.Crust = DTO.Enums.CrustType.Thick;
                        order.Pepperoni = true;
                        order.Name = "Test";
                        order.Address = "123 Elm";
                        order.Zip = "12345";
                        order.Phone = "555-3210";
                        order.PaymentType = DTO.Enums.PaymentType.Credit;
                        order.TotalCost = 16.50M;
                        */

        }

        public static void CompleteOrder(Guid orderId)
        {
            Persistence.OrderRepository.CompleteOrder(orderId);
        }

        public static object GetOrders()
        {
            return Persistence.OrderRepository.GetOrders();
        }
    }
}
