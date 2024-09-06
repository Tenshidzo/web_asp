using Microsoft.AspNetCore.Mvc;
using System.Linq;
using web_asp.Models;

namespace web_asp.Controllers
{
    public class CustomersController : Controller
    {
        private static readonly List<Customer> customers = new List<Customer>{
            new Customer { Id = 1, FirstName = "John", LastName = "Doe", Email = "john@example.com" },
            new Customer { Id = 2, FirstName = "Jane", LastName = "Doe", Email = "jane@example.com" }
        };

        // Index: Отображение списка клиентов
        public IActionResult Index()
        {
            foreach (var customer in customers)
            {
                Console.WriteLine($"Customer Id: {customer.Id}, Name: {customer.FirstName} {customer.LastName}");
            }
            return View(customers);
        }

        // Details: Отображение деталей клиента по Id
        public IActionResult Details(int id)
        {
            Console.WriteLine($"Received Id: {id}");
            var customer = customers.FirstOrDefault(c => c.Id == id);
            if (customer == null)
            {
                Console.WriteLine($"Customer with Id {id} not found.");
                return NotFound();
            }
            return View(customer);
        }

        // Create: Форма для создания клиента
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // Обработка данных формы для добавления клиента
        [HttpPost]
        public IActionResult Create(Customer customer)
        {
            if (ModelState.IsValid)
            {
                customer.Id = customers.Count + 1;
                customers.Add(customer);
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }

        // Edit: Форма для редактирования клиента
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var customer = customers.Find(c => c.Id == id);
            if (customer == null) return NotFound();
            return View(customer);
        }

        // Обработка данных формы для обновления клиента
        [HttpPost]
        public IActionResult Edit(Customer updatedCustomer)
        {
            if (ModelState.IsValid)
            {
                var customer = customers.Find(c => c.Id == updatedCustomer.Id);
                if (customer == null) return NotFound();
                customer.FirstName = updatedCustomer.FirstName;
                customer.LastName = updatedCustomer.LastName;
                customer.Email = updatedCustomer.Email;
                return RedirectToAction(nameof(Index));
            }
            return View(updatedCustomer);
        }

        // Delete: Подтверждение удаления клиента
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var customer = customers.Find(c => c.Id == id);
            if (customer == null) return NotFound();
            return View(customer);
        }

        // Обработка данных формы для удаления клиента
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var customer = customers.Find(c => c.Id == id);
            if (customer == null) return NotFound();
            customers.Remove(customer);
            return RedirectToAction(nameof(Index));
        }
    }
}
