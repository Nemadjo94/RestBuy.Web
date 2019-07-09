using System;
using System.Collections.Generic;
using System.Text;

namespace RestBuy.Entities
{
    public class Order : BaseEntity
    {
        //Params
        int userId;
        DateTime createDate;
        List<OrderItem> orderItems = new List<OrderItem>();

        //Constructors
        private Order() { }

        public Order(int userId)
        {
            this.userId = userId;
            this.createDate = DateTime.Now;
        }

        //Get set
        public int UserId => this.userId;
        public DateTime CreateDate => this.createDate;

        public IReadOnlyCollection<OrderItem> OrderItems => this.orderItems;

        public bool IsConfirmed { get; set; }
    }
}
