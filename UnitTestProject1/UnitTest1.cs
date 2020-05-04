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
            c.AddLevering(delllaptop.Id, "(3,5)", 20);

            Assert.AreEqual(delllaptop.TotaleVoorraad(), 20);

            c.RemoveApparaat(4);
        }

        [TestMethod]
        public void TestApparaatList()
        {
            var c = new Controller();
            var delllaptop = c.AddApparaat("Dell", "Laptop");

            Assert.AreEqual(c.GetApparaatList().Count, 4);

            c.RemoveApparaat(delllaptop.Id);
        }

        [TestMethod]
        public void TestVoorraaden()
        {
            var c = new Controller();
            var delllaptop = c.AddApparaat("Dell", "Laptop");
            c.AddLevering(delllaptop.Id, "(3,5)", 20);
            c.AddLevering(delllaptop.Id, "(5,6)", 40);

            Assert.AreEqual(delllaptop.TotaleVoorraad(), 60);

            c.RemoveApparaat(delllaptop.Id);
        }

        [TestMethod]
        public void TestUpdate()
        {
            var c = new Controller();
            var delllaptop = c.AddApparaat("Dell", "Laptop");

            delllaptop.Naam = "HP";
            //c.UpdateApparaat(delllaptop);

            Assert.AreEqual(c.GetApparaat(delllaptop.Id).Naam, "HP");

            c.RemoveApparaat(delllaptop.Id);
        }

        [TestMethod]
        public void TestGetApparaat()
        {
            var c = new Controller();
            var delllaptop = c.AddApparaat("Dell", "Laptop");

            Assert.AreEqual(c.GetApparaat(4), delllaptop);

            c.RemoveApparaat(delllaptop.Id);
        }
    }
}