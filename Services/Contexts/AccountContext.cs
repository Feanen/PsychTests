using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using PsychTestsMilitary.Models;

namespace PsychTestsMilitary.Services.Contexts
{
    public class AccountContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<UserAnswers> UserAnswers { get; set; }

        public AccountContext() : base("AccountsConnection") {}

        public bool CheckOnUniqueAccount(string login)
        {
            foreach (Account user in this.Accounts)
            {
                if (user.login.Equals(login))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
