using System;
using System.Globalization;
using Exerc_Fix_Composicao.entities;
using Exerc_Fix_Composicao.entities.enums;

namespace Exerc_Fix_Composicao
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Enter client data:");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Birth Date (DD/MM/YYYY): ");
            DateTime birthday = DateTime.Parse(Console.ReadLine());

            Client client = new Client(name, email, birthday);

            Console.WriteLine();

            Console.WriteLine("Enter order data:");
            Console.Write("Status: ");
            OrderStatus status = Enum.Parse<OrderStatus>(Console.ReadLine());

            Order order = new Order(status, client);

            Console.Write("How many itens to this order: ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine();
                Console.WriteLine("Enter #{0} item data:", i + 1);
                Console.Write("Product name: ");
                string prodName = Console.ReadLine();
                Console.Write("Product price: ");
                double price = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Quantity: ");
                int quant = int.Parse(Console.ReadLine());

                Product product = new Product(prodName, price);
                OrderItem item = new OrderItem(quant, product);
                order.AddItem(item);

            }

            Console.WriteLine();
            Console.WriteLine(order);

            

        }
    }
}
