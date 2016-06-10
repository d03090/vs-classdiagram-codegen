using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UMLModule;

namespace UMLModuleTests.HotelZimmer
{
   [TestClass]
   public class TestHotelZimmer
   {
      [TestMethod]
      public void InitHotel()
      {
         string hotelName = "HotelName";
         Hotel hotel1 = new Hotel() { Name = hotelName };

         Assert.IsTrue(hotel1.Name == hotelName);
         Assert.IsTrue(hotel1.Zimmer.Count == 0);
      }

      [TestMethod]
      [ExpectedException(typeof(UMLCompositionViolatedException))]
      public void InitZimmerAloneShouldThrowException()
      {
         string zimmerName = "ZimmerName";
         Zimmer zimmer1 = new Zimmer(null) { Name = zimmerName };

         Assert.IsTrue(zimmer1.Name == zimmerName);
         Assert.IsNull(zimmer1.Hotel);
      }

      [TestMethod]
      public void AddOneZimmerToHotel()
      {
         Hotel hotel1 = new Hotel() { Name = "Hotel#1" };
         Assert.IsTrue(hotel1.Zimmer.Count == 0);

         Zimmer zimmer1 = new Zimmer(hotel1) { Name = "Zimmer#1" };

         Assert.IsTrue(hotel1.Zimmer.Count == 1);
         Assert.IsTrue(hotel1.Zimmer[0] == zimmer1);
         Assert.IsTrue(zimmer1.Hotel == hotel1);
      }

      [TestMethod]
      public void AddTwoZimmerToHotel()
      {
         Hotel hotel1 = new Hotel() { Name = "Hotel#1" };
         Assert.IsTrue(hotel1.Zimmer.Count == 0);

         Zimmer zimmer1 = new Zimmer(hotel1) { Name = "Zimmer#1" };
         Assert.IsTrue(hotel1.Zimmer.Count == 1);
         Assert.IsTrue(zimmer1.Hotel == hotel1);

         Zimmer zimmer2 = hotel1.AddZimmer(hotel1);
         Assert.IsTrue(hotel1.Zimmer.Count == 2);
         Assert.IsTrue(hotel1.Zimmer[0] == zimmer1);
         Assert.IsTrue(hotel1.Zimmer[1] == zimmer2);
         Assert.IsTrue(zimmer1.Hotel == hotel1);
         Assert.IsTrue(zimmer2.Hotel == hotel1);
      }

      [TestMethod]
      public void AddOneZimmerToHotelThenRemoveIt()
      {
         Hotel hotel1 = new Hotel() { Name = "Hotel#1" };
         Assert.IsTrue(hotel1.Zimmer.Count == 0);

         Zimmer zimmer1 = new Zimmer(hotel1) { Name = "Zimmer#1" };
         Assert.IsTrue(hotel1.Zimmer.Count == 1);
         Assert.IsTrue(hotel1.Zimmer[0] == zimmer1);
         Assert.IsTrue(zimmer1.Hotel == hotel1);

         hotel1.RemoveZimmer(zimmer1);

         Assert.IsTrue(hotel1.Zimmer.Count == 0);
         Assert.IsNull(zimmer1.Hotel);
      }

      [TestMethod]
      public void AddOneZimmerToHotelThenRemoveItThenAddAnotherOne()
      {
         Hotel hotel1 = new Hotel() { Name = "Hotel#1" };
         Assert.IsTrue(hotel1.Zimmer.Count == 0);

         Zimmer zimmer1 = new Zimmer(hotel1) { Name = "Zimmer#1" };
         Assert.IsTrue(hotel1.Zimmer.Count == 1);
         Assert.IsTrue(hotel1.Zimmer[0] == zimmer1);
         Assert.IsTrue(zimmer1.Hotel == hotel1);

         hotel1.RemoveZimmer(zimmer1);
         Assert.IsTrue(hotel1.Zimmer.Count == 0);
         Assert.IsNull(zimmer1.Hotel);

         Zimmer zimmer2 = hotel1.AddZimmer(hotel1);
         Assert.IsTrue(hotel1.Zimmer.Count == 1);
         Assert.IsTrue(hotel1.Zimmer[0] == zimmer2);
         Assert.IsTrue(zimmer2.Hotel == hotel1);
      }

      [TestMethod]
      public void AddOneZimmerToHotelThenRemoveItThenAddAnotherOne2()
      {
         Hotel hotel1 = new Hotel() { Name = "Hotel#1" };
         Assert.IsTrue(hotel1.Zimmer.Count == 0);

         Zimmer zimmer1 = new Zimmer(hotel1) { Name = "Zimmer#1" };
         Assert.IsTrue(hotel1.Zimmer.Count == 1);
         Assert.IsTrue(hotel1.Zimmer[0] == zimmer1);
         Assert.IsTrue(zimmer1.Hotel == hotel1);

         hotel1.RemoveZimmer(zimmer1);
         Assert.IsTrue(hotel1.Zimmer.Count == 0);
         Assert.IsNull(zimmer1.Hotel);

         Zimmer zimmer2 = new Zimmer(hotel1) { Name = "Zimmer#2" };
         Assert.IsTrue(hotel1.Zimmer.Count == 1);
         Assert.IsTrue(hotel1.Zimmer[0] == zimmer2);
         Assert.IsTrue(zimmer2.Hotel == hotel1);
      }

      [TestMethod]
      public void AddOneZimmerToHotelThenRemoveAWrongOne()
      {
         Hotel hotel1 = new Hotel() { Name = "Hotel#1" };
         Assert.IsTrue(hotel1.Zimmer.Count == 0);

         Hotel hotel2 = new Hotel() { Name = "Hotel#2" };
         Assert.IsTrue(hotel2.Zimmer.Count == 0);

         Zimmer zimmer1 = new Zimmer(hotel1) { Name = "Zimmer#1" };
         Assert.IsTrue(hotel1.Zimmer.Count == 1);
         Assert.IsTrue(hotel1.Zimmer[0] == zimmer1);
         Assert.IsTrue(zimmer1.Hotel == hotel1);

         Zimmer zimmer2 = new Zimmer(hotel2) { Name = "Zimmer#2" };
         Assert.IsTrue(hotel2.Zimmer.Count == 1);
         Assert.IsTrue(hotel2.Zimmer[0] == zimmer2);
         Assert.IsTrue(zimmer2.Hotel == hotel2);

         hotel1.RemoveZimmer(zimmer2);
         Assert.IsTrue(hotel1.Zimmer.Count == 1);
         Assert.IsTrue(hotel1.Zimmer[0] == zimmer1);
         Assert.IsTrue(zimmer1.Hotel == hotel1);
         Assert.IsTrue(hotel2.Zimmer.Count == 1);
         Assert.IsTrue(hotel2.Zimmer[0] == zimmer2);
         Assert.IsTrue(zimmer2.Hotel == hotel2);
      }
   }
}
