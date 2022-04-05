using Application.Interfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class CustomerService : RepositoryService<Customer>, ICustomerService
    {
        private readonly IDataBaseContext _db;
        public CustomerService(IDataBaseContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Customer customer)
        {
            var objFromDb = _db.Customer.FirstOrDefault(s => s.Id == customer.Id);

            objFromDb.Firstname = customer.Firstname;
            objFromDb.Lastname = customer.Lastname;
            objFromDb.BankAccountNumber = customer.BankAccountNumber;
            objFromDb.DateOfBirth = customer.DateOfBirth;
            objFromDb.PhoneNumber = customer.PhoneNumber;
            objFromDb.Email = customer.Email;

            _db.SaveChanges();
        }
    }
}
