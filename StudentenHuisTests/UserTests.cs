using StudentenHuis.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace StudentenHuisTests
{
    public class UserTests
    {
        [Fact]
        public void DoesFullNameWork()
        {
            var User = new ApplicationUser()
            {
                Firstname = "Arno",
                Middlename = "",
                Lastname = "Broeders"
            };
            Assert.Equal("Arno  Broeders", User.Fullname());
        }
    }
}
