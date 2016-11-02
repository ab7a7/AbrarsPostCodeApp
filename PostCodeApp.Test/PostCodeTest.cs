using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit;
using NUnit.Framework;
using PostCodeConsoleApp.Models;
using System.Web.Mvc;

namespace PostCodeApp.Test
{
    [TestFixture]
    public class PostCodeTest
    {
        [Test]
        public void checkSetup()
        {
            Assert.True(true);
        }

        [Test]
        [TestCase("$%± ()()", "Junk")]
        [TestCase("XX XXX", "Invalid")]
        [TestCase("A1 9A", "Incorrect inward code length")]
        [TestCase("LS44PL", "No Space")]
        [TestCase("Q1A 9AA", "'Q' in first position")]
        [TestCase("V1A 9AA", "'V' in first position")]
        [TestCase("X1A 9BB", "'X' in first position")]
        [TestCase("LI10 3QP", "'I' in second position")]
        [TestCase("LJ10 3QP", "'J' in second position")]
        [TestCase("LZ10 3QP", "'Z' in second position")]
        [TestCase("A9Q 9AA", "'Q' in third position with 'A9A' structure")]
        [TestCase("AA9C 9AA", "'C' in fourth position with 'AA9A' structure")]
        [TestCase("FY10 4PL", "Area with only single digit districts")]
        [TestCase("SO1 4QQ", "Area with only double digit districts")]
        [TestCase("EC1A 1BB", "None")]
        [TestCase("W1A 0AX", "None")]
        [TestCase("M1 1AE", "None")]
        [TestCase("B33 8TH", "None")]
        [TestCase("CR2 6XH", "None")]
        [TestCase("DN55 1PT", "None")]
        [TestCase("GIR 0AA", "None")]
        [TestCase("SO10 9AA", "None")]
        [TestCase("FY9 9AA", "None")]
        [TestCase("WC1A 9AA", "None")]
        public void validate_postcode(string postCode, string message)
        {
            //Arrange
            var validator = new PostCodeValidator(postCode);
            //Act
            var result = validator.IsValidPostCode();
            //Assert
            Assert.True(result, message);
        }


    }
}
