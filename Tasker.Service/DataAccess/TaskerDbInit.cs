using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasker.Service.Models;

namespace Tasker.Service.DataAccess
{
    public class TaskerDbInit : DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            InitialData(context);
            base.Seed(context);
        }

        private void InitialData(ApplicationDbContext context)
        {

        }
    }
}
