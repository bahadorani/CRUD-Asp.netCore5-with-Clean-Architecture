using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
   public class UnitOfWorkService: IUnitOfWorkService
    {
        private readonly IDataBaseContext _context;
        public UnitOfWorkService(IDataBaseContext context)
        {
            _context = context;
            Customer = new CustomerService(_context);
        }

        public ICustomerService Customer { get; private set; }


        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
