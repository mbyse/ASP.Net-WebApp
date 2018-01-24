using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapaBobs.Persistence
{
    public class PizzaPriceRepository
    {
        public static DTO.PizzaPriceDTO GetPizzaPrices()
        {
            var db = new PapaBobsDbEntities();
            var prices = db.PizzaPrices.First();
            var dto = convertToDTO(prices);
            return dto;
        }

        private static DTO.PizzaPriceDTO convertToDTO(PizzaPrice pizzaPrice)
        {
            var dto = new DTO.PizzaPriceDTO
            {
                SmallSizeCost = pizzaPrice.SmallSizeCost,
                MediumSizeCost = pizzaPrice.MediumSizeCost,
                LargeSizeCost = pizzaPrice.LargeSizeCost,
                ThickCrustCost = pizzaPrice.ThickCrustCost,
                ThinCrustCost = pizzaPrice.ThinCrustCost,
                RegularCrustCost = pizzaPrice.RegularCrustCost,
                SausageCost = pizzaPrice.SausageCost,
                PepperoniCost = pizzaPrice.PepperoniCost,
                OnionsCost = pizzaPrice.OnionsCost,
                GreenPeppersCost = pizzaPrice.GreenPeppersCost
            };

            

            return dto;
        }
    }
}
