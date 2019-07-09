using System;
using System.Collections.Generic;
using System.Text;

namespace RestBuy.Entities
{
    public class Supplier : BaseEntity
    {
        //Params
        public string Name { get; set; }

        //Constructors
        private Supplier() { }

        public Supplier(string name)
        {
            this.Name = name;
        }
    }
}
