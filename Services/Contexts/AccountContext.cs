using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PsychTestsMilitary.Models;

namespace PsychTestsMilitary.Services.Contexts
{
    public class AccountContext : DbContext
    {
        public DbSet<Account> Users { get; set; }

        public AccountContext() : base("AccountsConnection") {}
    }
}
