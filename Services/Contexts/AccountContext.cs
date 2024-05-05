using PsychTestsMilitary.Models;
using System.Data.Entity;
using System.Linq;

namespace PsychTestsMilitary.Services.Contexts
{
    public class AccountContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<UserAnswers> UserAnswers { get; set; }

        public Account CurrentAccount { get; private set; }

        public AccountContext() : base("AccountsConnection") { }

        public bool CheckOnUniqueAccount(string login)
        {
            CurrentAccount = Accounts.FirstOrDefault(user => user.login.Equals(login));
            return CurrentAccount == null ? false : true;
        }

        public bool CheckOnCorrectPassword(string pass)
        {
            return PasswordHasher.CheckOnPsychPassword(pass, CurrentAccount.Password);
        }
    }
}
