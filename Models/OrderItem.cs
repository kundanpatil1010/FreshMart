namespace ASP.NET_GROCERY_WEB_APP.Models
{
    public class OrderItem
    {
        public int OrderItemId { get; set; }

        public int OrderId { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; } // ✅ Newly added for capturing price per item at order time

        public virtual Product Product { get; set; }

        public virtual Order Order { get; set; }
    }
}
