using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Core.Entities.Base
{
    public class BaseEntity
    {

        //Poner todas las propiedades que se utilizan en las demas entidades, se puede fechas 
        public int Id { get; set; }

        public DateTime Date { get; set; }
    }
}
