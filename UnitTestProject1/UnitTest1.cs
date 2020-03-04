using FTC_MagazijnManagement.Business;

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
        }

        [TestMethod]
        public void TestApparaatList()
        {
            var c = new Controller();
            var delllaptop = c.AddApparaat("Dell", "Laptop");

            Assert.AreEqual(c.GetapparaatList().Count, 1);
        }

        [TestMethod]
        public void TestVoorraaden()
        {
            var c = new Controller();
            var delllaptop = c.AddApparaat("Dell", "Laptop");
            delllaptop.NieuweLevering("3/5", 20);
            delllaptop.NieuweLevering("5/6", 40);

            Assert.AreEqual(delllaptop.TotaleVoorraad(), 60);
        }

        [TestMethod]
        public void TestUpdate()
        {
            var c = new Controller();
            var delllaptop = c.AddApparaat("Dell", "Laptop");

            delllaptop.Naam = "HP";
            c.Updateapparaat(delllaptop);

            Assert.AreEqual(c.Getapparaat(delllaptop.Id).Naam, "HP");
        }

        [TestMethod]
        public void TestGetApparaat()
        {
            var c = new Controller();
            var delllaptop = c.AddApparaat("Dell", "Laptop");

            Assert.AreEqual(c.Getapparaat(1), delllaptop);
        }
    }
}