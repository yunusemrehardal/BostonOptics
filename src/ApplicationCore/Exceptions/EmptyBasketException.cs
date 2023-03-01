using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Exceptions
{
    public class EmptyBasketException : Exception
    {
        public EmptyBasketException() : base("Basket cannot be empty.")
        {

        }
    }
}
