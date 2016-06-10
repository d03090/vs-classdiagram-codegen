using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
      public void InitZimmer()
      {
         string zimmerName = "ZimmerName";
         Zimmer zimmer1 = new Zimmer() { Name = zimmerName };

         Assert.IsTrue(zimmer1.Name == zimmerName);
         Assert.IsNull(zimmer1.Hotel);
      }

      [TestMethod]
      public void AddOneZimmerToHotel()
      {
         Hotel hotel1 = new Hotel() { Name = "Hotel#1" };
         Zimmer zimmer1 = new Zimmer() { Name = "Zimmer#1" };

         Assert.IsTrue(hotel1.Zimmer.Count == 0);
         Assert.IsNull(zimmer1.Hotel);

         hotel1.AddZimmer(zimmer1);

         Assert.IsTrue(hotel1.Zimmer.Count == 1);
         Assert.IsTrue(hotel1.Zimmer[0] == zimmer1);
         Assert.IsTrue(zimmer1.Hotel == hotel1);
      }

      [TestMethod]
      public void AddTwoZimmerToHotel()
      {
         Hotel hotel1 = new Hotel() { Name = "Hotel#1" };
         Zimmer zimmer1 = new Zimmer() { Name = "Zimmer#1" };
         Zimmer zimmer2 = new Zimmer() { Name = "Zimmer#2" };

         Assert.IsTrue(hotel1.Zimmer.Count == 0);
         Assert.IsNull(zimmer1.Hotel);

         hotel1.AddZimmer(zimmer1);

         Assert.IsTrue(hotel1.Zimmer.Count == 1);
         Assert.IsTrue(zimmer1.Hotel == hotel1);

         hotel1.AddZimmer(zimmer2);

         Assert.IsTrue(hotel1.Zimmer.Count == 2);
         Assert.IsTrue(hotel1.Zimmer[0] == zimmer1);
         Assert.IsTrue(hotel1.Zimmer[1] == zimmer2);
         Assert.IsTrue(zimmer1.Hotel == hotel1);
         Assert.IsTrue(zimmer2.Hotel == hotel1);
      }

      [TestMethod]
      public void AddOneZimmerToHotelThenAddItToAnother()
      {
         Hotel hotel1 = new Hotel() { Name = "Hotel#1" };
         Hotel hotel2 = new Hotel() { Name = "Hotel#2" };
         Zimmer zimmer1 = new Zimmer() { Name = "Zimmer#1" };

         Assert.IsTrue(hotel1.Zimmer.Count == 0);
         Assert.IsTrue(hotel2.Zimmer.Count == 0);
         Assert.IsNull(zimmer1.Hotel);

         hotel1.AddZimmer(zimmer1);

         Assert.IsTrue(hotel1.Zimmer.Count == 1);
         Assert.IsTrue(hotel1.Zimmer[0] == zimmer1);
         Assert.IsTrue(zimmer1.Hotel == hotel1);
         Assert.IsTrue(hotel2.Zimmer.Count == 0);

         hotel2.AddZimmer(zimmer1);

         Assert.IsTrue(hotel1.Zimmer.Count == 0);
         Assert.IsTrue(zimmer1.Hotel == hotel2);
         Assert.IsTrue(hotel2.Zimmer.Count == 1);
         Assert.IsTrue(hotel2.Zimmer[0] == zimmer1);
      }

      [TestMethod]
      public void AddOneZimmerToHotelThenAddItToAnother2()
      {
         Hotel hotel1 = new Hotel() { Name = "Hotel#1" };
         Hotel hotel2 = new Hotel() { Name = "Hotel#2" };
         Zimmer zimmer1 = new Zimmer() { Name = "Zimmer#1" };

         Assert.IsTrue(hotel1.Zimmer.Count == 0);
         Assert.IsTrue(hotel2.Zimmer.Count == 0);
         Assert.IsNull(zimmer1.Hotel);

         hotel1.AddZimmer(zimmer1);

         Assert.IsTrue(hotel1.Zimmer.Count == 1);
         Assert.IsTrue(hotel1.Zimmer[0] == zimmer1);
         Assert.IsTrue(zimmer1.Hotel == hotel1);
         Assert.IsTrue(hotel2.Zimmer.Count == 0);

         zimmer1.Hotel = hotel2;

         Assert.IsTrue(hotel1.Zimmer.Count == 0);
         Assert.IsTrue(zimmer1.Hotel == hotel2);
         Assert.IsTrue(hotel2.Zimmer.Count == 1);
         Assert.IsTrue(hotel2.Zimmer[0] == zimmer1);
      }

      [TestMethod]
      public void AddOneZimmerToHotelThenRemoveIt()
      {
         Hotel hotel1 = new Hotel() { Name = "Hotel#1" };
         Zimmer zimmer1 = new Zimmer() { Name = "Zimmer#1" };

         Assert.IsTrue(hotel1.Zimmer.Count == 0);
         Assert.IsNull(zimmer1.Hotel);

         hotel1.AddZimmer(zimmer1);

         Assert.IsTrue(hotel1.Zimmer.Count == 1);
         Assert.IsTrue(hotel1.Zimmer[0] == zimmer1);
         Assert.IsTrue(zimmer1.Hotel == hotel1);

         hotel1.RemoveZimmer(zimmer1);

         Assert.IsTrue(hotel1.Zimmer.Count == 0);
         Assert.IsNull(zimmer1.Hotel);
      }

      [TestMethod]
      public void AddOneZimmerToHotelThenRemoveIt2()
      {
         Hotel hotel1 = new Hotel() { Name = "Hotel#1" };
         Zimmer zimmer1 = new Zimmer() { Name = "Zimmer#1" };

         Assert.IsTrue(hotel1.Zimmer.Count == 0);
         Assert.IsNull(zimmer1.Hotel);

         hotel1.AddZimmer(zimmer1);

         Assert.IsTrue(hotel1.Zimmer.Count == 1);
         Assert.IsTrue(hotel1.Zimmer[0] == zimmer1);
         Assert.IsTrue(zimmer1.Hotel == hotel1);

         zimmer1.Hotel = null;

         Assert.IsTrue(hotel1.Zimmer.Count == 0);
         Assert.IsNull(zimmer1.Hotel);
      }

      [TestMethod]
      public void AddOneZimmerToHotelThenRemoveItThenAddItAgain()
      {
         Hotel hotel1 = new Hotel() { Name = "Hotel#1" };
         Zimmer zimmer1 = new Zimmer() { Name = "Zimmer#1" };

         Assert.IsTrue(hotel1.Zimmer.Count == 0);
         Assert.IsNull(zimmer1.Hotel);

         hotel1.AddZimmer(zimmer1);

         Assert.IsTrue(hotel1.Zimmer.Count == 1);
         Assert.IsTrue(hotel1.Zimmer[0] == zimmer1);
         Assert.IsTrue(zimmer1.Hotel == hotel1);

         hotel1.RemoveZimmer(zimmer1);

         Assert.IsTrue(hotel1.Zimmer.Count == 0);
         Assert.IsNull(zimmer1.Hotel);

         hotel1.AddZimmer(zimmer1);

         Assert.IsTrue(hotel1.Zimmer.Count == 1);
         Assert.IsTrue(hotel1.Zimmer[0] == zimmer1);
         Assert.IsTrue(zimmer1.Hotel == hotel1);
      }

      [TestMethod]
      public void AddOneZimmerToHotelThenRemoveItThenAddItAgain2()
      {
         Hotel hotel1 = new Hotel() { Name = "Hotel#1" };
         Zimmer zimmer1 = new Zimmer() { Name = "Zimmer#1" };

         Assert.IsTrue(hotel1.Zimmer.Count == 0);
         Assert.IsNull(zimmer1.Hotel);

         hotel1.AddZimmer(zimmer1);

         Assert.IsTrue(hotel1.Zimmer.Count == 1);
         Assert.IsTrue(hotel1.Zimmer[0] == zimmer1);
         Assert.IsTrue(zimmer1.Hotel == hotel1);

         hotel1.RemoveZimmer(zimmer1);

         Assert.IsTrue(hotel1.Zimmer.Count == 0);
         Assert.IsNull(zimmer1.Hotel);

         zimmer1.Hotel = hotel1;

         Assert.IsTrue(hotel1.Zimmer.Count == 1);
         Assert.IsTrue(hotel1.Zimmer[0] == zimmer1);
         Assert.IsTrue(zimmer1.Hotel == hotel1);
      }

      [TestMethod]
      public void AddOneZimmerToHotelThenRemoveIt2ThenAddItAgain()
      {
         Hotel hotel1 = new Hotel() { Name = "Hotel#1" };
         Zimmer zimmer1 = new Zimmer() { Name = "Zimmer#1" };

         Assert.IsTrue(hotel1.Zimmer.Count == 0);
         Assert.IsNull(zimmer1.Hotel);

         hotel1.AddZimmer(zimmer1);

         Assert.IsTrue(hotel1.Zimmer.Count == 1);
         Assert.IsTrue(hotel1.Zimmer[0] == zimmer1);
         Assert.IsTrue(zimmer1.Hotel == hotel1);

         zimmer1.Hotel = null;

         Assert.IsTrue(hotel1.Zimmer.Count == 0);
         Assert.IsNull(zimmer1.Hotel);

         hotel1.AddZimmer(zimmer1);

         Assert.IsTrue(hotel1.Zimmer.Count == 1);
         Assert.IsTrue(hotel1.Zimmer[0] == zimmer1);
         Assert.IsTrue(zimmer1.Hotel == hotel1);
      }

      [TestMethod]
      public void AddOneZimmerToHotelThenRemoveIt2ThenAddItAgain2()
      {
         Hotel hotel1 = new Hotel() { Name = "Hotel#1" };
         Zimmer zimmer1 = new Zimmer() { Name = "Zimmer#1" };

         Assert.IsTrue(hotel1.Zimmer.Count == 0);
         Assert.IsNull(zimmer1.Hotel);

         hotel1.AddZimmer(zimmer1);

         Assert.IsTrue(hotel1.Zimmer.Count == 1);
         Assert.IsTrue(hotel1.Zimmer[0] == zimmer1);
         Assert.IsTrue(zimmer1.Hotel == hotel1);

         zimmer1.Hotel = null;

         Assert.IsTrue(hotel1.Zimmer.Count == 0);
         Assert.IsNull(zimmer1.Hotel);

         zimmer1.Hotel = hotel1;

         Assert.IsTrue(hotel1.Zimmer.Count == 1);
         Assert.IsTrue(hotel1.Zimmer[0] == zimmer1);
         Assert.IsTrue(zimmer1.Hotel == hotel1);
      }

      [TestMethod]
      public void AddOneZimmerToHotelThenRemoveAWrongOne()
      {
         Hotel hotel1 = new Hotel() { Name = "Hotel#1" };
         Zimmer zimmer1 = new Zimmer() { Name = "Zimmer#1" };
         Zimmer zimmer2 = new Zimmer() { Name = "Zimmer#2" };

         Assert.IsTrue(hotel1.Zimmer.Count == 0);
         Assert.IsNull(zimmer1.Hotel);
         Assert.IsNull(zimmer2.Hotel);

         hotel1.AddZimmer(zimmer1);

         Assert.IsTrue(hotel1.Zimmer.Count == 1);
         Assert.IsTrue(hotel1.Zimmer[0] == zimmer1);
         Assert.IsTrue(zimmer1.Hotel == hotel1);
         Assert.IsNull(zimmer2.Hotel);

         hotel1.RemoveZimmer(zimmer2);

         Assert.IsTrue(hotel1.Zimmer.Count == 1);
         Assert.IsTrue(hotel1.Zimmer[0] == zimmer1);
         Assert.IsTrue(zimmer1.Hotel == hotel1);
         Assert.IsNull(zimmer2.Hotel);
      }

      [TestMethod]
      public void SetHotelFromZimmer()
      {
         Hotel hotel1 = new Hotel() { Name = "Hotel#1" };
         Zimmer zimmer1 = new Zimmer() { Name = "Zimmer#1" };

         Assert.IsTrue(hotel1.Zimmer.Count == 0);
         Assert.IsNull(zimmer1.Hotel);

         zimmer1.Hotel = hotel1;

         Assert.IsTrue(hotel1.Zimmer.Count == 1);
         Assert.IsTrue(hotel1.Zimmer[0] == zimmer1);
         Assert.IsTrue(zimmer1.Hotel == hotel1);
      }

      [TestMethod]
      public void SetHotelFromZimmerAndChangeIt()
      {
         Hotel hotel1 = new Hotel() { Name = "Hotel#1" };
         Hotel hotel2 = new Hotel() { Name = "Hotel#2" };
         Zimmer zimmer1 = new Zimmer() { Name = "Zimmer#1" };

         Assert.IsTrue(hotel1.Zimmer.Count == 0);
         Assert.IsTrue(hotel2.Zimmer.Count == 0);
         Assert.IsNull(zimmer1.Hotel);

         zimmer1.Hotel = hotel1;

         Assert.IsTrue(hotel1.Zimmer.Count == 1);
         Assert.IsTrue(hotel1.Zimmer[0] == zimmer1);
         Assert.IsTrue(zimmer1.Hotel == hotel1);
         Assert.IsTrue(hotel2.Zimmer.Count == 0);

         zimmer1.Hotel = hotel2;

         Assert.IsTrue(hotel1.Zimmer.Count == 0);
         Assert.IsTrue(zimmer1.Hotel == hotel2);
         Assert.IsTrue(hotel2.Zimmer.Count == 1);
         Assert.IsTrue(hotel2.Zimmer[0] == zimmer1);
      }

      [TestMethod]
      public void SetHotelFromZimmerAndChangeItThenChangeItBack()
      {
         Hotel hotel1 = new Hotel() { Name = "Hotel#1" };
         Hotel hotel2 = new Hotel() { Name = "Hotel#2" };
         Zimmer zimmer1 = new Zimmer() { Name = "Zimmer#1" };

         Assert.IsTrue(hotel1.Zimmer.Count == 0);
         Assert.IsTrue(hotel2.Zimmer.Count == 0);
         Assert.IsNull(zimmer1.Hotel);

         zimmer1.Hotel = hotel1;

         Assert.IsTrue(hotel1.Zimmer.Count == 1);
         Assert.IsTrue(hotel1.Zimmer[0] == zimmer1);
         Assert.IsTrue(zimmer1.Hotel == hotel1);
         Assert.IsTrue(hotel2.Zimmer.Count == 0);

         zimmer1.Hotel = hotel2;

         Assert.IsTrue(hotel1.Zimmer.Count == 0);
         Assert.IsTrue(zimmer1.Hotel == hotel2);
         Assert.IsTrue(hotel2.Zimmer.Count == 1);
         Assert.IsTrue(hotel2.Zimmer[0] == zimmer1);

         zimmer1.Hotel = hotel1;

         Assert.IsTrue(hotel1.Zimmer.Count == 1);
         Assert.IsTrue(hotel1.Zimmer[0] == zimmer1);
         Assert.IsTrue(zimmer1.Hotel == hotel1);
         Assert.IsTrue(hotel2.Zimmer.Count == 0);
      }
   }
}
