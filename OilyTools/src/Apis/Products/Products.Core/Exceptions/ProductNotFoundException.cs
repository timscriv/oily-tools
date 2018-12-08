using OilyTools.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Products.Core.Exceptions
{
    public class ProductNotFoundException: NotFoundException
    {
        public ProductNotFoundException(string name) : base("Product", name)
        {
        }

        public ProductNotFoundException(int id) : base("Product", id)
        {
        }
    }
}
