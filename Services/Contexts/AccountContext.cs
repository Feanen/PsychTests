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

        public Account CurrentAccount { get; private set; }

        public AccountContext() : base("AccountsConnection") {}

        public bool CheckOnUniqueAccount(string login)
        {
            CurrentAccount = this.Accounts.FirstOrDefault(user => user.login.Equals(login));
            return CurrentAccount == null ? false : true;
        }

        public bool CheckOnCorrectPassword(string pass)
        {
            return PasswordHasher.CheckOnPsychPassword(pass, CurrentAccount.Password);
        }
    }
}
