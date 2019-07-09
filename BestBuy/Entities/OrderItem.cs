using System;
using System.Collections.Generic;
using System.Text;

namespace RestBuy.Entities
{
    public class OrderItem : BaseEntity
    {
        //Params
        int productId;
        int quantity;
        decimal price;

        //Constructors
        private OrderItem() { }

        public OrderItem(int productId, int quantity, decimal price)
        {
            this.productId = productId;
            this.quantity = quantity;
            this.price = price;
        }

        //Get Set
        public int ProductId => this.productId;
        public int Quantity => this.quantity;
        public decimal Price => this.price;
    }
}
