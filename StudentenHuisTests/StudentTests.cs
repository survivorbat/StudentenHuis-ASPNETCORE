using StudentenHuis.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace StudentenHuisTests
{
    public class StudentTests
    {
        [Fact]
        public void SavesMealsProperly()
        {
            Student TestStudent = new Student()
            {
                ID = 0,
                Firstname = "Arno",
                Lastname = "Broeders",
                Email = "a.broeders@avans.nl",
                Telephonenumber = "06827492" 
            };
            Assert.Equal(0, TestStudent.ID);
            Assert.Equal("Arno", TestStudent.Firstname);
            Assert.Equal("Broeders", TestStudent.Lastname);
            Assert.Equal("a.broeders@avans.nl", TestStudent.Email);
        }
    }
}
