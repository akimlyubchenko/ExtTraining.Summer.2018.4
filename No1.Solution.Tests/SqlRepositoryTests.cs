using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Moq;

namespace No1.Solution.Tests
{
    [TestFixture]
    class SqlRepositoryTests
    {
        // Пытался написать мок 2 часа(ни больше, ни меньше), так ничего и не вышло,потому что
        // не знаю как одновременно и передать стринг как параметр PasswordCheckerService через мок, и
        // вызвать метод SqlRepository.Create() для проверки
        [TestCase("asdASD123_", "user")]
        public void SqlRepository_IfUserPassIsTrue(string pass, string userType)
        {
            var mock = new Mock<PasswordCheckerService>();
            var user1 = new PasswordCheckerService();

            user1.VerifyPassword(pass ,userType);

            //mock.Verify(sr => sr(It.IsAny<string>()));
        }
    }
}
