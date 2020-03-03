using studyingProgect.Models;
using System;
using Xunit;

namespace UnitTests
{
    public class UnitTests
    {
        [Fact]
        public void Test1()
        {
            var nomeclature = new Nomenclature();

            Assert.NotEqual(Guid.Empty, nomeclature.Id);
        }

        [Fact]
        public void Test2()
        {
            Assert.True(true);
        }
    }
}
