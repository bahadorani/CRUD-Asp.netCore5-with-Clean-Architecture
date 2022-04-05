using Application.Interfaces;
using Domain.Dtoes;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    public class CustomerController : Controller
    {
        private readonly IUnitOfWorkService _unitofWork;
        public CustomerController(IUnitOfWorkService unitOfWork)
        {
            _unitofWork = unitOfWork;
        }
        public IActionResult Index()
        {
            var customerDto = new CustomerDto {
                CustomerList = _unitofWork.Customer.GetAll(null, null, null).ToList()
            };
            return View(customerDto);
        }
        public IActionResult Upsert(long? Id)
        {
            Customer customer = new Customer();

            try
            {
                if (Id != null)
                {
                    customer = _unitofWork.Customer.Get(Id.GetValueOrDefault());
                }
            }
            catch (Exception e)
            {
               
            }

            return View(customer);
        }
        [HttpPost]
        public IActionResult Upsert(Customer customer)
        {
            try
            {

                if (customer.Id == 0)
                {
                    //New customer                  
                    _unitofWork.Customer.Add(customer);
                }
                else
                {
                    //Edit customer
                    _unitofWork.Customer.Update(customer);
                }
                _unitofWork.Save();


            }
            catch (Exception e)
            {
                
            }

            return RedirectToAction(nameof(Index));
        }
       
        public IActionResult Delete(long id)
        {
            var objFromDb = _unitofWork.Customer.Get(id);

            _unitofWork.Customer.Remove(objFromDb);
            _unitofWork.Save();
            return RedirectToAction(nameof(Index));
        }
    }
}
