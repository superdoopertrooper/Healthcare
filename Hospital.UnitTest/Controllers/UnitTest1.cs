using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Hospital.UnitTest.Controllers
{
    [TestClass]
    public class ClinicControllerUnitTest
    {
        [TestMethod]
        public void WhenNothingHasHappened()
        {
            Hospital.WebAPI.Controllers.ClinicController clinicController = new WebAPI.Controllers.ClinicController();

        }
    }
}
