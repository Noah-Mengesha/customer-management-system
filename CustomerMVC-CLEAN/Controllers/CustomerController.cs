using Microsoft.AspNetCore.Mvc;
using CustomerClassLibrary;

namespace CustomerMVC.Controllers
{
    public class CustomerController : Controller
    {
        private readonly CustomerRepository repository =
            new CustomerRepository();

        public IActionResult Index()
        {
            var customers = repository.GetAllCustomers();
            return View(customers);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Customer customer)
        {
            repository.Add(customer);
            return RedirectToAction("Index");
        }
        public IActionResult Details(int id)
        {
            var customer = repository.GetCustomer(id);
            return View(customer);
        }
        public IActionResult Edit(int id)
        {
            var customer = repository.GetCustomer(id);
            return View(customer);
        }

        [HttpPost]
        public IActionResult Edit(Customer customer)
        {
            repository.Update(customer);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var customer = repository.GetCustomer(id);
            return View(customer);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            repository.Delete(id);
            return RedirectToAction("Index");
        }

    }
}