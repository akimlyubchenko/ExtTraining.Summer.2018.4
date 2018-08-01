using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace No1.Solution
{
    public class PasswordCheckerService
    {
        private SqlRepository repository = new SqlRepository();

        public Tuple<bool, string> VerifyPassword(string password, string user = "USER")
        {
            if (password == null)
                throw new ArgumentException($"{password} is null arg");

            Regex regex = new Regex(@"[a-zA-Z]+[0-9]+_*-*.*");
            if (!regex.IsMatch(password))
            {
                return Tuple.Create(false, $"{password} isn't valid");
            }

            if (user.ToUpper().Contains("ADMIN") || user.ToUpper().Contains("ADMINISTRATION"))
            {
                // check if length more than 10 chars for admins
                if (password.Length >= 15)
                    return Tuple.Create(false, $"{password} length too long");
            }
            else
            {
                // check if length more than 7 chars 
                if (password.Length <= 7)
                    return Tuple.Create(false, $"{password} length too short");

            }

            repository.Create(password);

            return Tuple.Create(true, "Password is Ok. User was created");
        }
    }
}
