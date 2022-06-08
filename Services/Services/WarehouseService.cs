using Model;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class WarehouseService : IWarehouseService
    {
        
        public IList<Warehouse> GetWarehouses()
        {
            return new List<Warehouse>()
            {
                new Warehouse() { Id = 1, Name = "Warehouse1"},
                new Warehouse() { Id = 1, Name = "Warehouse1"},
                new Warehouse() { Id = 1, Name = "Warehouse1"}
            };
        }

        public bool CreateWarehouse()
        {
            throw new NotImplementedException();
        }
    }
}
