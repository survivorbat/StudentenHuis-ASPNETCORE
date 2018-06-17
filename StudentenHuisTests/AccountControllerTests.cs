using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Moq;
using StudentenHuis.Controllers;
using StudentenHuis.Models;
using System;
using System.Collections.Generic;
using Xunit;

namespace StudentenHuisTests
{
    public class AccountsControllerTests
    {
        [Fact]
        public void IndexReturnsListOfItems()
        {
            Mock<IUserRepository> UserMock = new Mock<IUserRepository>();

            ApplicationUser User = new ApplicationUser() { Firstname = "Arno", Lastname = "Broeders" };
            ApplicationUser User1 = new ApplicationUser() { Firstname = "Robin", Lastname = "Schellius" };
            ApplicationUser User2 = new ApplicationUser() { Firstname = "Rick", Lastname = "Lambrechts" };

            UserMock.Setup(m => m.Users).Returns(new List<ApplicationUser>()
            {
                User,
                User1,
                User2
            });

            AccountController users = new AccountController(null, null, UserMock.Object);
            List<ApplicationUser> list = users.Index().ViewData.Model as List<ApplicationUser>;
            Assert.Equal(3, list.Count);
            Assert.Equal("Arno", list[0].Firstname);
            Assert.Equal("Broeders", list[0].Lastname);
        }
    }
}
