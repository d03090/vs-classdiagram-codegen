using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UMLModule;
using System.Collections.Generic;

namespace UMLModuleTests.PersonAuto
{
   [TestClass]
   public class TestAutoReifen
   {
      [TestMethod]
      [ExpectedException(typeof(UMLOutOfBoundsException))]
      public void InitAutoTooFewReifen1()
      {
         Auto auto1 = new Auto(new HashSet<Reifen>()) { Kennzeichen = "W-111" };
      }

      [TestMethod]
      [ExpectedException(typeof(UMLOutOfBoundsException))]
      public void InitAutoTooFewReifen2()
      {
         Reifen reifen1 = new Reifen() { Id = 1 };
         Reifen reifen2 = new Reifen() { Id = 2 };

         Assert.IsNull(reifen1.Auto);
         Assert.IsNull(reifen2.Auto);

         Auto auto1 = new Auto(new HashSet<Reifen>() { reifen1, reifen2 }) { Kennzeichen = "W-111" };
      }

      [TestMethod]
      public void InitAuto()
      {
         Reifen reifen1 = new Reifen() { Id = 1 };
         Reifen reifen2 = new Reifen() { Id = 2 };
         Reifen reifen3 = new Reifen() { Id = 3 };
         Reifen reifen4 = new Reifen() { Id = 4 };
         Auto auto1 = new Auto(new HashSet<Reifen>() { reifen1, reifen2, reifen3, reifen4 }) { Kennzeichen = "W-111" };

         Assert.IsTrue(reifen1.Auto == auto1);
         Assert.IsTrue(reifen2.Auto == auto1);
         Assert.IsTrue(reifen3.Auto == auto1);
         Assert.IsTrue(reifen4.Auto == auto1);
         Assert.IsTrue(auto1.Reifen.Count == 4);
         Assert.IsTrue(auto1.Reifen.Contains(reifen1));
         Assert.IsTrue(auto1.Reifen.Contains(reifen2));
         Assert.IsTrue(auto1.Reifen.Contains(reifen3));
         Assert.IsTrue(auto1.Reifen.Contains(reifen4));
      }

      [TestMethod]
      [ExpectedException(typeof(UMLOutOfBoundsException))]
      public void InitAutoThenInitNewAutoAndTakeOldReifenShouldThrowException()
      {
         Reifen reifen1 = new Reifen() { Id = 1 };
         Reifen reifen2 = new Reifen() { Id = 2 };
         Reifen reifen3 = new Reifen() { Id = 3 };
         Reifen reifen4 = new Reifen() { Id = 4 };
         Auto auto1 = new Auto(new HashSet<Reifen>() { reifen1, reifen2, reifen3, reifen4 }) { Kennzeichen = "W-111" };

         Assert.IsTrue(reifen1.Auto == auto1);
         Assert.IsTrue(reifen2.Auto == auto1);
         Assert.IsTrue(reifen3.Auto == auto1);
         Assert.IsTrue(reifen4.Auto == auto1);
         Assert.IsTrue(auto1.Reifen.Count == 4);
         Assert.IsTrue(auto1.Reifen.Contains(reifen1));
         Assert.IsTrue(auto1.Reifen.Contains(reifen2));
         Assert.IsTrue(auto1.Reifen.Contains(reifen3));
         Assert.IsTrue(auto1.Reifen.Contains(reifen4));

         Auto auto2 = new Auto(new HashSet<Reifen>() { reifen1, reifen2, reifen3, reifen4 }) { Kennzeichen = "W-111" };
      }

      [TestMethod]
      public void AddReifenToAuto()
      {
         Reifen reifen1 = new Reifen() { Id = 1 };
         Reifen reifen2 = new Reifen() { Id = 2 };
         Reifen reifen3 = new Reifen() { Id = 3 };
         Reifen reifen4 = new Reifen() { Id = 4 };
         Auto auto1 = new Auto(new HashSet<Reifen>() { reifen1, reifen2, reifen3 }) { Kennzeichen = "W-111" };

         Assert.IsNull(reifen4.Auto);
         Assert.IsTrue(auto1.Reifen.Count == 3);

         auto1.AddReifen(reifen4);

         Assert.IsTrue(reifen4.Auto == auto1);
         Assert.IsTrue(reifen4.Auto.Kennzeichen == "W-111");
         Assert.IsTrue(auto1.Reifen.Count == 4);
         Assert.IsTrue(auto1.Reifen.Contains(reifen4));
      }

      [TestMethod]
      [ExpectedException(typeof(UMLOutOfBoundsException))]
      public void AddTooManyReifenToAutoShouldThrowException()
      {
         Reifen reifen1 = new Reifen() { Id = 1 };
         Reifen reifen2 = new Reifen() { Id = 2 };
         Reifen reifen3 = new Reifen() { Id = 3 };
         Reifen reifen4 = new Reifen() { Id = 4 };
         Reifen reifen5 = new Reifen() { Id = 5 };
         Auto auto1 = new Auto(new HashSet<Reifen>() { reifen1, reifen2, reifen3, reifen4 }) { Kennzeichen = "W-111" };

         Assert.IsNull(reifen5.Auto);
         Assert.IsTrue(auto1.Reifen.Count == 4);
         Assert.IsTrue(reifen1.Auto == auto1);
         Assert.IsTrue(reifen2.Auto == auto1);
         Assert.IsTrue(reifen3.Auto == auto1);
         Assert.IsTrue(reifen4.Auto == auto1);
         Assert.IsTrue(auto1.Reifen.Contains(reifen1));
         Assert.IsTrue(auto1.Reifen.Contains(reifen2));
         Assert.IsTrue(auto1.Reifen.Contains(reifen3));
         Assert.IsTrue(auto1.Reifen.Contains(reifen4));

         //should throw Exception
         auto1.AddReifen(reifen5);
      }

      [TestMethod]
      public void RemoveReifenFromAuto()
      {
         Reifen reifen1 = new Reifen() { Id = 1 };
         Reifen reifen2 = new Reifen() { Id = 2 };
         Reifen reifen3 = new Reifen() { Id = 3 };
         Reifen reifen4 = new Reifen() { Id = 4 };

         Auto auto1 = new Auto(new HashSet<Reifen>() { reifen1, reifen2, reifen3, reifen4 }) { Kennzeichen = "W-111" };

         Assert.IsTrue(reifen1.Auto == auto1);
         Assert.IsTrue(reifen2.Auto == auto1);
         Assert.IsTrue(reifen3.Auto == auto1);
         Assert.IsTrue(reifen4.Auto == auto1);
         Assert.IsTrue(auto1.Reifen.Count == 4);
         Assert.IsTrue(auto1.Reifen.Contains(reifen1));
         Assert.IsTrue(auto1.Reifen.Contains(reifen2));
         Assert.IsTrue(auto1.Reifen.Contains(reifen3));
         Assert.IsTrue(auto1.Reifen.Contains(reifen4));

         auto1.RemoveReifen(reifen1);

         Assert.IsNull(reifen1.Auto);
         Assert.IsTrue(reifen2.Auto == auto1);
         Assert.IsTrue(reifen3.Auto == auto1);
         Assert.IsTrue(reifen4.Auto == auto1);
         Assert.IsTrue(auto1.Reifen.Count == 3);
         Assert.IsFalse(auto1.Reifen.Contains(reifen1));
         Assert.IsTrue(auto1.Reifen.Contains(reifen2));
         Assert.IsTrue(auto1.Reifen.Contains(reifen3));
         Assert.IsTrue(auto1.Reifen.Contains(reifen4));
      }

      [TestMethod]
      [ExpectedException(typeof(UMLOutOfBoundsException))]
      public void RemoveTooManyReifenFromAutoShouldThrowException()
      {
         Reifen reifen1 = new Reifen() { Id = 1 };
         Reifen reifen2 = new Reifen() { Id = 2 };
         Reifen reifen3 = new Reifen() { Id = 3 };
         Reifen reifen4 = new Reifen() { Id = 4 };
         Auto auto1 = new Auto(new HashSet<Reifen>() { reifen1, reifen2, reifen3, reifen4 }) { Kennzeichen = "W-111" };

         Assert.IsTrue(reifen1.Auto == auto1);
         Assert.IsTrue(reifen2.Auto == auto1);
         Assert.IsTrue(reifen3.Auto == auto1);
         Assert.IsTrue(reifen4.Auto == auto1);
         Assert.IsTrue(auto1.Reifen.Count == 4);
         Assert.IsTrue(auto1.Reifen.Contains(reifen1));
         Assert.IsTrue(auto1.Reifen.Contains(reifen2));
         Assert.IsTrue(auto1.Reifen.Contains(reifen3));
         Assert.IsTrue(auto1.Reifen.Contains(reifen4));

         auto1.RemoveReifen(reifen1);

         Assert.IsNull(reifen1.Auto);
         Assert.IsTrue(reifen2.Auto == auto1);
         Assert.IsTrue(reifen3.Auto == auto1);
         Assert.IsTrue(reifen4.Auto == auto1);
         Assert.IsTrue(auto1.Reifen.Count == 3);
         Assert.IsFalse(auto1.Reifen.Contains(reifen1));
         Assert.IsTrue(auto1.Reifen.Contains(reifen2));
         Assert.IsTrue(auto1.Reifen.Contains(reifen3));
         Assert.IsTrue(auto1.Reifen.Contains(reifen4));

         //should throw Exception
         auto1.RemoveReifen(reifen2);
      }

      [TestMethod]
      public void AssignAutoToReifen()
      {
         Reifen reifen1 = new Reifen() { Id = 1 };
         Reifen reifen2 = new Reifen() { Id = 2 };
         Reifen reifen3 = new Reifen() { Id = 3 };
         Reifen reifen4 = new Reifen() { Id = 4 };
         Auto auto1 = new Auto(new HashSet<Reifen>() { reifen1, reifen2, reifen3 }) { Kennzeichen = "W-111" };

         Assert.IsNull(reifen4.Auto);
         Assert.IsTrue(auto1.Reifen.Count == 3);

         reifen4.Auto = auto1;

         Assert.IsTrue(reifen4.Auto == auto1);
         Assert.IsTrue(auto1.Reifen.Count == 4);
         Assert.IsTrue(auto1.Reifen.Contains(reifen4));
      }

      [TestMethod]
      public void AssignAutoToReifenThenAssignOtherAuto()
      {
         Reifen reifen11 = new Reifen() { Id = 11 };
         Reifen reifen12 = new Reifen() { Id = 12 };
         Reifen reifen13 = new Reifen() { Id = 13 };
         Reifen reifen14 = new Reifen() { Id = 14 };

         Reifen reifen21 = new Reifen() { Id = 21 };
         Reifen reifen22 = new Reifen() { Id = 22 };
         Reifen reifen23 = new Reifen() { Id = 23 };
         Auto auto1 = new Auto(new HashSet<Reifen>() { reifen11, reifen12, reifen13 }) { Kennzeichen = "W-111" };
         Auto auto2 = new Auto(new HashSet<Reifen>() { reifen21, reifen22, reifen23 }) { Kennzeichen = "W-111" };

         Assert.IsNull(reifen14.Auto);
         Assert.IsTrue(auto1.Reifen.Count == 3);

         reifen14.Auto = auto1;

         Assert.IsTrue(reifen14.Auto == auto1);
         Assert.IsTrue(auto1.Reifen.Count == 4);
         Assert.IsTrue(auto1.Reifen.Contains(reifen14));

         reifen14.Auto = auto2;

         Assert.IsTrue(auto1.Reifen.Count == 3);
         Assert.IsFalse(auto1.Reifen.Contains(reifen14));
         Assert.IsTrue(reifen14.Auto == auto2);
         Assert.IsTrue(auto2.Reifen.Count == 4);
         Assert.IsTrue(auto2.Reifen.Contains(reifen14));
      }

      [TestMethod]
      [ExpectedException(typeof(UMLOutOfBoundsException))]
      public void AssignTooManyReifenToAutoShouldThrowException()
      {
         Reifen reifen1 = new Reifen() { Id = 1 };
         Reifen reifen2 = new Reifen() { Id = 2 };
         Reifen reifen3 = new Reifen() { Id = 3 };
         Reifen reifen4 = new Reifen() { Id = 4 };
         Reifen reifen5 = new Reifen() { Id = 5 };
         Auto auto1 = new Auto(new HashSet<Reifen>() { reifen1, reifen2, reifen3, reifen4 }) { Kennzeichen = "W-111" };

         Assert.IsTrue(reifen1.Auto == auto1);
         Assert.IsTrue(reifen2.Auto == auto1);
         Assert.IsTrue(reifen3.Auto == auto1);
         Assert.IsTrue(reifen4.Auto == auto1);
         Assert.IsTrue(auto1.Reifen.Count == 4);
         Assert.IsTrue(auto1.Reifen.Contains(reifen1));
         Assert.IsTrue(auto1.Reifen.Contains(reifen2));
         Assert.IsTrue(auto1.Reifen.Contains(reifen3));
         Assert.IsTrue(auto1.Reifen.Contains(reifen4));

         //should throw Exception
         reifen5.Auto = auto1;
      }

      [TestMethod]
      public void UnassignAutoFromReifen()
      {
         Reifen reifen1 = new Reifen() { Id = 1 };
         Reifen reifen2 = new Reifen() { Id = 2 };
         Reifen reifen3 = new Reifen() { Id = 3 };
         Reifen reifen4 = new Reifen() { Id = 4 };
         Auto auto1 = new Auto(new HashSet<Reifen>() { reifen1, reifen2, reifen3, reifen4 }) { Kennzeichen = "W-111" };

         Assert.IsTrue(reifen1.Auto == auto1);
         Assert.IsTrue(reifen2.Auto == auto1);
         Assert.IsTrue(reifen3.Auto == auto1);
         Assert.IsTrue(reifen4.Auto == auto1);
         Assert.IsTrue(auto1.Reifen.Count == 4);
         Assert.IsTrue(auto1.Reifen.Contains(reifen1));
         Assert.IsTrue(auto1.Reifen.Contains(reifen2));
         Assert.IsTrue(auto1.Reifen.Contains(reifen3));
         Assert.IsTrue(auto1.Reifen.Contains(reifen4));

         reifen1.Auto = null;

         Assert.IsNull(reifen1.Auto);
         Assert.IsTrue(reifen2.Auto == auto1);
         Assert.IsTrue(reifen3.Auto == auto1);
         Assert.IsTrue(reifen4.Auto == auto1);
         Assert.IsTrue(auto1.Reifen.Count == 3);
         Assert.IsFalse(auto1.Reifen.Contains(reifen1));
         Assert.IsTrue(auto1.Reifen.Contains(reifen2));
         Assert.IsTrue(auto1.Reifen.Contains(reifen3));
         Assert.IsTrue(auto1.Reifen.Contains(reifen4));
      }

      [TestMethod]
      [ExpectedException(typeof(UMLOutOfBoundsException))]
      public void UnassignTooManyAutoFromReifenShouldThrowException()
      {
         Reifen reifen1 = new Reifen() { Id = 1 };
         Reifen reifen2 = new Reifen() { Id = 2 };
         Reifen reifen3 = new Reifen() { Id = 3 };
         Reifen reifen4 = new Reifen() { Id = 4 };
         Auto auto1 = new Auto(new HashSet<Reifen>() { reifen1, reifen2, reifen3, reifen4 }) { Kennzeichen = "W-111" };

         Assert.IsTrue(reifen1.Auto == auto1);
         Assert.IsTrue(reifen2.Auto == auto1);
         Assert.IsTrue(reifen3.Auto == auto1);
         Assert.IsTrue(reifen4.Auto == auto1);
         Assert.IsTrue(auto1.Reifen.Count == 4);
         Assert.IsTrue(auto1.Reifen.Contains(reifen1));
         Assert.IsTrue(auto1.Reifen.Contains(reifen2));
         Assert.IsTrue(auto1.Reifen.Contains(reifen3));
         Assert.IsTrue(auto1.Reifen.Contains(reifen4));

         reifen1.Auto = null;

         Assert.IsNull(reifen1.Auto);
         Assert.IsTrue(reifen2.Auto == auto1);
         Assert.IsTrue(reifen3.Auto == auto1);
         Assert.IsTrue(reifen4.Auto == auto1);
         Assert.IsTrue(auto1.Reifen.Count == 3);
         Assert.IsFalse(auto1.Reifen.Contains(reifen1));
         Assert.IsTrue(auto1.Reifen.Contains(reifen2));
         Assert.IsTrue(auto1.Reifen.Contains(reifen3));
         Assert.IsTrue(auto1.Reifen.Contains(reifen4));

         //should throw Exception
         reifen2.Auto = null;
      }
   }
}
