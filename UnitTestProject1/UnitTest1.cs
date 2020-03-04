using FTC_MagazijnManagement.Business;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestVoorraad()
        {
            var c = new Controller();
            var delllaptop = c.AddApparaat("Dell", "Laptop");
            delllaptop.NieuweLevering("3/5", 20);

            Assert.AreEqual(delllaptop.TotaleVoorraad(), 20);

            c.RemoveApparaat(delllaptop.Id);
        }

        [TestMethod]
        public void TestApparaatList()
        {
            var c = new Controller();
            var delllaptop = c.AddApparaat("Dell", "Laptop");

            Assert.AreEqual(c.GetApparaatList().Count, 1);

            c.RemoveApparaat(delllaptop.Id);
        }

        [TestMethod]
        public void TestVoorraaden()
        {
            var c = new Controller();
            var delllaptop = c.AddApparaat("Dell", "Laptop");
            //("3/5", 20);
            delllaptop.NieuweLevering("5/6", 40);

            Assert.AreEqual(delllaptop.TotaleVoorraad(), 60);

            c.RemoveApparaat(delllaptop.Id);
        }

        [TestMethod]
        public void TestUpdate()
        {
            var c = new Controller();
            var delllaptop = c.AddApparaat("Dell", "Laptop");

            delllaptop.Naam = "HP";
            c.UpdateApparaat(delllaptop);

            Assert.AreEqual(c.GetApparaat(delllaptop.Id).Naam, "HP");
        }

        [TestMethod]
        public void TestGetApparaat()
        {
            var c = new Controller();
            var delllaptop = c.AddApparaat("Dell", "Laptop");

            Assert.AreEqual(c.GetApparaat(1), delllaptop);
        }
    }
}