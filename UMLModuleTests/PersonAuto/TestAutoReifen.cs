﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UMLModule;

namespace UMLModuleTests.PersonAuto
{
   [TestClass]
   public class TestAutoReifen
   {
      [TestMethod]
      public void AddReifenToAuto()
      {
         Reifen reifen1 = new Reifen() { Id = 1 };
         Auto auto1 = new Auto() { Kennzeichen = "W-111" };

         Assert.IsNull(reifen1.Auto);
         Assert.IsTrue(auto1.Reifen.Count == 0);

         auto1.AddReifen(reifen1);

         Assert.IsTrue(reifen1.Auto == auto1);
         Assert.IsTrue(auto1.Reifen.Count == 1);
         Assert.IsTrue(auto1.Reifen[0] == reifen1);
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
         Auto auto1 = new Auto() { Kennzeichen = "W-111" };

         Assert.IsNull(reifen1.Auto);
         Assert.IsNull(reifen2.Auto);
         Assert.IsNull(reifen3.Auto);
         Assert.IsNull(reifen4.Auto);
         Assert.IsNull(reifen5.Auto);
         Assert.IsTrue(auto1.Reifen.Count == 0);

         auto1.AddReifen(reifen1);
         auto1.AddReifen(reifen2);
         auto1.AddReifen(reifen3);
         auto1.AddReifen(reifen4);

         Assert.IsTrue(reifen1.Auto == auto1);
         Assert.IsTrue(reifen2.Auto == auto1);
         Assert.IsTrue(reifen3.Auto == auto1);
         Assert.IsTrue(reifen4.Auto == auto1);
         Assert.IsTrue(auto1.Reifen.Count == 4);
         Assert.IsTrue(auto1.Reifen[0] == reifen1);
         Assert.IsTrue(auto1.Reifen[1] == reifen2);
         Assert.IsTrue(auto1.Reifen[2] == reifen3);
         Assert.IsTrue(auto1.Reifen[3] == reifen4);

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
         Auto auto1 = new Auto() { Kennzeichen = "W-111" };

         Assert.IsNull(reifen1.Auto);
         Assert.IsNull(reifen2.Auto);
         Assert.IsNull(reifen3.Auto);
         Assert.IsNull(reifen4.Auto);
         Assert.IsTrue(auto1.Reifen.Count == 0);

         auto1.AddReifen(reifen1);
         auto1.AddReifen(reifen2);
         auto1.AddReifen(reifen3);
         auto1.AddReifen(reifen4);

         Assert.IsTrue(reifen1.Auto == auto1);
         Assert.IsTrue(reifen2.Auto == auto1);
         Assert.IsTrue(reifen3.Auto == auto1);
         Assert.IsTrue(reifen4.Auto == auto1);
         Assert.IsTrue(auto1.Reifen.Count == 4);
         Assert.IsTrue(auto1.Reifen[0] == reifen1);
         Assert.IsTrue(auto1.Reifen[1] == reifen2);
         Assert.IsTrue(auto1.Reifen[2] == reifen3);
         Assert.IsTrue(auto1.Reifen[3] == reifen4);

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
         Auto auto1 = new Auto() { Kennzeichen = "W-111" };

         Assert.IsNull(reifen1.Auto);
         Assert.IsNull(reifen2.Auto);
         Assert.IsNull(reifen3.Auto);
         Assert.IsNull(reifen4.Auto);
         Assert.IsTrue(auto1.Reifen.Count == 0);

         auto1.AddReifen(reifen1);
         auto1.AddReifen(reifen2);
         auto1.AddReifen(reifen3);
         auto1.AddReifen(reifen4);

         Assert.IsTrue(reifen1.Auto == auto1);
         Assert.IsTrue(reifen2.Auto == auto1);
         Assert.IsTrue(reifen3.Auto == auto1);
         Assert.IsTrue(reifen4.Auto == auto1);
         Assert.IsTrue(auto1.Reifen.Count == 4);
         Assert.IsTrue(auto1.Reifen[0] == reifen1);
         Assert.IsTrue(auto1.Reifen[1] == reifen2);
         Assert.IsTrue(auto1.Reifen[2] == reifen3);
         Assert.IsTrue(auto1.Reifen[3] == reifen4);

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
         Auto auto1 = new Auto() { Kennzeichen = "W-111" };

         Assert.IsNull(reifen1.Auto);
         Assert.IsTrue(auto1.Reifen.Count == 0);

         reifen1.Auto = auto1;

         Assert.IsTrue(reifen1.Auto == auto1);
         Assert.IsTrue(auto1.Reifen.Count == 1);
         Assert.IsTrue(auto1.Reifen[0] == reifen1);
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
         Auto auto1 = new Auto() { Kennzeichen = "W-111" };

         Assert.IsNull(reifen1.Auto);
         Assert.IsNull(reifen2.Auto);
         Assert.IsNull(reifen3.Auto);
         Assert.IsNull(reifen4.Auto);
         Assert.IsNull(reifen5.Auto);
         Assert.IsTrue(auto1.Reifen.Count == 0);

         reifen1.Auto = auto1;
         reifen2.Auto = auto1;
         reifen3.Auto = auto1;
         reifen4.Auto = auto1;

         Assert.IsTrue(reifen1.Auto == auto1);
         Assert.IsTrue(reifen2.Auto == auto1);
         Assert.IsTrue(reifen3.Auto == auto1);
         Assert.IsTrue(reifen4.Auto == auto1);
         Assert.IsTrue(auto1.Reifen.Count == 4);
         Assert.IsTrue(auto1.Reifen[0] == reifen1);
         Assert.IsTrue(auto1.Reifen[1] == reifen2);
         Assert.IsTrue(auto1.Reifen[2] == reifen3);
         Assert.IsTrue(auto1.Reifen[3] == reifen4);

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
         Auto auto1 = new Auto() { Kennzeichen = "W-111" };

         Assert.IsNull(reifen1.Auto);
         Assert.IsNull(reifen2.Auto);
         Assert.IsNull(reifen3.Auto);
         Assert.IsNull(reifen4.Auto);
         Assert.IsTrue(auto1.Reifen.Count == 0);

         reifen1.Auto = auto1;
         reifen2.Auto = auto1;
         reifen3.Auto = auto1;
         reifen4.Auto = auto1;

         Assert.IsTrue(reifen1.Auto == auto1);
         Assert.IsTrue(reifen2.Auto == auto1);
         Assert.IsTrue(reifen3.Auto == auto1);
         Assert.IsTrue(reifen4.Auto == auto1);
         Assert.IsTrue(auto1.Reifen.Count == 4);
         Assert.IsTrue(auto1.Reifen[0] == reifen1);
         Assert.IsTrue(auto1.Reifen[1] == reifen2);
         Assert.IsTrue(auto1.Reifen[2] == reifen3);
         Assert.IsTrue(auto1.Reifen[3] == reifen4);

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
         Auto auto1 = new Auto() { Kennzeichen = "W-111" };

         Assert.IsNull(reifen1.Auto);
         Assert.IsNull(reifen2.Auto);
         Assert.IsNull(reifen3.Auto);
         Assert.IsNull(reifen4.Auto);
         Assert.IsTrue(auto1.Reifen.Count == 0);

         reifen1.Auto = auto1;
         reifen2.Auto = auto1;
         reifen3.Auto = auto1;
         reifen4.Auto = auto1;

         Assert.IsTrue(reifen1.Auto == auto1);
         Assert.IsTrue(reifen2.Auto == auto1);
         Assert.IsTrue(reifen3.Auto == auto1);
         Assert.IsTrue(reifen4.Auto == auto1);
         Assert.IsTrue(auto1.Reifen.Count == 4);
         Assert.IsTrue(auto1.Reifen[0] == reifen1);
         Assert.IsTrue(auto1.Reifen[1] == reifen2);
         Assert.IsTrue(auto1.Reifen[2] == reifen3);
         Assert.IsTrue(auto1.Reifen[3] == reifen4);

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
