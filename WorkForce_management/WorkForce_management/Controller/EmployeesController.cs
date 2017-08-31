using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WorkForce_management.Models;
using WorkForce_management.Models.ViewModels;

namespace WorkForce_management.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly WorkForce_managementContext _context;

        public EmployeesController(WorkForce_managementContext context)
        {
            _context = context;
        }

        // GET: Employees
        public async Task<IActionResult> Index()
        {
            var workForce_managementContext = _context.Employee.Include(e => e.Department);
            return View(await workForce_managementContext.ToListAsync());
        }

        // GET: Employees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employee
                .Include(e => e.Department)
                .Include(e => e.EmployeeComputers)
                .Include(e => e.TrainingProgramEmployee)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (employee == null)

            {
                return NotFound();
            }
            EmployeeDetailViewModel EmployeeDetailViewModel = new EmployeeDetailViewModel();
            foreach (var TrainingProgram in employee.TrainingProgramEmployee)
            {
                var Training = _context.TrainingProgram.SingleOrDefault(t => t.Id == TrainingProgram.TrainingId);
                EmployeeDetailViewModel.TrainingPrograms.Add(Training);


            }
            foreach (var Computer in employee.EmployeeComputers)
            {
                var EmployeeComputers = _context.Computer.SingleOrDefault(c => c.Id == Computer.ComputerId);
                EmployeeDetailViewModel.Computers.Add(EmployeeComputers);
            }
            EmployeeDetailViewModel.Employee = employee;
            return View(EmployeeDetailViewModel);
        }

        // GET: Employees/Create
        public IActionResult Create()
        {
            ViewData["DepartmentId"] = new SelectList(_context.Department, "Id", "DepartmentName");
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,DepartmentId,StartDate")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["DepartmentId"] = new SelectList(_context.Department, "Id", "DepartmentName", employee.DepartmentId);
            return View(employee);
        }

        // GET: Employees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var viewModel = new EmployeeEditViewModel();
            viewModel.employee = await _context.Employee.SingleOrDefaultAsync(m => m.Id == id);
            viewModel.Computer = new List<int>();
            viewModel.TrainingProgramEmployee = new List<int>();
            if (viewModel.employee == null)
            {
                return NotFound();
            }
            ViewData["ComputerId"] = new SelectList(_context.Computer, "Id", "ComputerMake");

            ViewData["TrainingProgramId"] = new SelectList(_context.TrainingProgram, "Id", "TraingingProgramName");

            ViewData["DepartmentId"] = new SelectList(_context.Department, "Id", "DepartmentName", viewModel.employee.DepartmentId);


            return View(viewModel);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EmployeeEditViewModel viewModel)
        {
            if (id != viewModel.employee.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(viewModel.employee);

                    foreach (int ProgramId in viewModel.TrainingProgramEmployee)
                    {

                        var employee = await _context.Employee
                        .Include(e => e.Department)
                        .Include(e => e.EmployeeComputers)
                        .Include(e => e.TrainingProgramEmployee)
                        .SingleOrDefaultAsync(m => m.Id == id);

                        var query = employee.TrainingProgramEmployee.Where(x => x.TrainingId.Equals(ProgramId));

                        if (query.Count() == 0)
                        {
                            
                            TrainingProgramEmployee TrainingProgramEmployee = new TrainingProgramEmployee()
                            {
                                EmployeeId = viewModel.employee.Id,
                                TrainingId = _context.TrainingProgram.SingleOrDefault(t => t.Id == ProgramId).Id

                            };
                            _context.Add(TrainingProgramEmployee);
                        }
                        
                
                    }
                    
                    
                        foreach (int ComputerId in viewModel.Computer)
                        {
                            EmployeeComputer Computer = new EmployeeComputer()
                            {
                                EmployeeId = viewModel.employee.Id,
                                ComputerId = _context.Computer.SingleOrDefault(c => c.Id == ComputerId).Id

                            };
                            _context.Add(Computer);
                        }


                    await _context.SaveChangesAsync();




                    return RedirectToAction("Index");
                    
                }

                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(viewModel.employee.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
               
            }
            ViewData["DepartmentId"] = new SelectList(_context.Department, "Id", "DepartmentName", viewModel.employee.DepartmentId);
            return View(viewModel);
        }

        // GET: Employees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employee
                .Include(e => e.Department)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employee = await _context.Employee.SingleOrDefaultAsync(m => m.Id == id);
            _context.Employee.Remove(employee);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employee.Any(e => e.Id == id);
        }
    }
}
