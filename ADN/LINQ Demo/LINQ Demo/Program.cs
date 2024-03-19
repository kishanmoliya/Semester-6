// See https://aka.ms/new-console-template for more information
using LINQ_Demo;
main();
void main()
{
    var context = new ApplicationDBContext();
    //1. Display data of all employees.
    /*var q1 = context.Employee.Select(x => x.FirstName);
    foreach (var employee in q1)
    {
        Console.WriteLine("\n {0}", employee);
    }*/

    //2. Select ActNo, FirstName and Salary of all employees to a new class and display it.
    var q2 = context.Employee.Select(x => x);
    foreach (var employee in q2)
    {
        Console.WriteLine("\n {0}, {1}", employee.FirstName, employee.LastName);
    }
}