
# Workforce Asset and Training Application

### Forms

The ASP.NET MVC framework provides many conventions and helpers that make building forms easier, and are bound to view models, much the same way that you used Angular to bind form fields in a partial to variables and/or objects in a controller.

## Requirements

You will be building a fairly straightforward, server generated MVC application for performing CRUD operations on the following resources:

* Employees
* Departments
* Computers
* Training Programs

The following relationships must be established.

1. Over time, a computer can belong to many employees, but only one at a time.
1. An employee can attend many training programs.
1. A training program can have many employees attending.
1. Many employees can be assigned to a department, but an employees may only be in one at a time.

Produce the following views.

### Employee Views

1. List employees.
1. Create an employee, and assign to a department.
1. View employee, which shows their department, computer, and any training programs they are attending.
1. Edit employee, which should also allow the user to:
    1. Reassign the employee to a different department
    1. Change which computer they are using from a list of unused computers.
    1. Add and/or remove training programs that the employee is attending.

### Department Views

1. List departments.
1. Create a department.
1. Department details, which should show all employees in that department.

### Computer Views

1. List computers, and be able to delete a computer from the list view.
1. Create a computer.

### Training Program Views

1. List training programs.
1. Create training program.
1. View training program details. This should display any employees that are currently in the training program

### Common Views

1. Basic navigation bar that allows the user to view the list of each type of resource.
1. Footer containing the company name.

