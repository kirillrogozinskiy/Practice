using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp
{
    public class EmployeeRepository
    {
        private readonly HrContext _context;

        public EmployeeRepository(HrContext context)
        {
            _context = context;
        }

        public async Task<List<EmployeeModel>> GetEmployeesAsync()
        {
            return await _context.Employees
                .Include(e => e.DepartmentModel)
                .ToListAsync();
        }

        public async Task AddEmployeeAsync(EmployeeModel employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateEmployeeAsync(EmployeeModel employee)
        {
            _context.Employees.Update(employee);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteEmployeeAsync(EmployeeModel employee)
        {
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
        }
    }
}
