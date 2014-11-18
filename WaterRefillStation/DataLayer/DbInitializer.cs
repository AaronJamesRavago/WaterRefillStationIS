using System.Collections.Generic;
using System.Data.Entity;
using WaterRefillStation.Model;

namespace WaterRefillStation.DataLayer
{
    public class DbInitializer : DropCreateDatabaseAlways<WaterRefillStationDbContext>
    {
        protected override void Seed(WaterRefillStationDbContext context)
        {

            List<Employee> defaultEmployees = new List<Employee>();

            defaultEmployees.Add(new Employee() { Account = new Account() { UserName = "admin", Password = "admin" }, AdminRights = AdminRights.Admin, FirstName = "Nino", LastName = "Madamba" });
            defaultEmployees.Add(new Employee() { Account = new Account() { UserName = "encoder", Password = "encoder" }, AdminRights = AdminRights.Encoder, FirstName = "Aaron", LastName = "Ravago" });
            defaultEmployees.Add(new Employee() { Account = new Account() { UserName = "viewer", Password = "viewer" }, AdminRights = AdminRights.Viewer, FirstName = "Juan", LastName = "Dela Cruz" });

            foreach (Employee emp in defaultEmployees)
            {
                context.Employees.Add(emp);
            }

            base.Seed(context);
        }
    }
}
