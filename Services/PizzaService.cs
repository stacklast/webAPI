using webAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace webAPI.Services
{
    public static class PizzaService
    {
        static List<Pizza> Pizzas { get; set; }

        static int NextId = 3;

        static PizzaService()
        {
            Pizzas = new List<Pizza>
            {
                new Pizza { Id = 1, Name = "Unknown", IsGutenFree = true },
                new Pizza { Id = 2, Name = "Italiana", IsGutenFree = false }
            };
        }

        public static List<Pizza> GetAll() => Pizzas;

        public static Pizza Get(int Id) => Pizzas.FirstOrDefault(x => x.Id == Id);

        public static void Add(Pizza pizza)
        {
            pizza.Id = NextId++;
            Pizzas.Add(pizza);
        }

        public static void Delete(int id)
        {
            var pizza = Get(id);
            if(pizza is null)
                return;

            Pizzas.Remove(pizza);
        }
        
        public static void Update(Pizza pizza)
        {
            var index = Pizzas.FindIndex(p => p.Id == pizza.Id);
            if(index == -1)
                return;

            Pizzas[index] = pizza;
        }
    }
}
