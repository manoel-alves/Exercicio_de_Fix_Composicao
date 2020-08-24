using System;
using System.Text;
using System.Globalization;
using System.Collections.Generic;
using Exerc_Fix_Composicao.entities.enums;

namespace Exerc_Fix_Composicao.entities
{
    class Order
    {
        public DateTime Moment { get; set; }
        public OrderStatus Status { get; set; }
        public Client Client { get; set; }
        public List<OrderItem> ItemList { get; set; } = new List<OrderItem>();

        public Order()
        {
        }

        public Order(OrderStatus status, Client client)
        {
            Moment = DateTime.Now;
            Status = status;
            Client = client;
        }

        public void AddItem(OrderItem item)
        {
            ItemList.Add(item);
        }

        public void RemoveItem(OrderItem item)
        {
            ItemList.Remove(item);
        }

        public double Total()
        {
            double total = 0;
            foreach (OrderItem obj in ItemList)
            {
                total += obj.SubTotal();
            }
            return total;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("ORDER SUMMARY:");
            sb.AppendLine("Order moment: " + Moment);
            sb.AppendLine("Order Status: " + Status);
            sb.AppendLine("Client: " + Client);
            sb.AppendLine("Order items:");
            foreach (OrderItem obj in ItemList)
            {
                sb.AppendLine(obj.ToString());
            }
            sb.AppendLine("Total price: $" + Total().ToString("F2", CultureInfo.InvariantCulture));
            return sb.ToString();
        }

    }
}
