﻿using DesignPatternsCreational.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace DesignPatternsCreational.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        [HttpGet("get-expenses")]
        public IActionResult GetExpenses()
        {
            var composite = new ManagerComposite("Vruck", "Diretor", 100000);

            composite.Add(new Employee("Funcionário 1", "Analista", 300));
            composite.Add(new Employee("Funcionário 2", "Analista", 300));

            var composite2 = new ManagerComposite("Vruck Gerente", "Gerente", 15000);

            composite.Add(composite2);

            composite2.Add(new Employee("Funcionário 3", "Analista", 300));
            composite2.Add(new Employee("Funcionário 4", "Analista", 300));

            return Ok(new
            {
                expensesDirector = composite.GetExpenses(),
                expensesManager = composite2.GetExpenses()
            });
        }
    }
}
