﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UMLModuleTests.PersonAuto
{
   [TestClass]
   public class TestPersonAuto
   {
      [TestMethod]
      public void InitPerson()
      {
         string personName = "Person1";
         Person person1 = new Person() { Name = personName };

         Assert.IsTrue(person1.Name == personName);
         Assert.IsTrue(person1.FaehrtMit.Count == 0);
      }

      [TestMethod]
      public void InitAuto()
      {
         string autoKZ = "W-111";
         Auto auto1 = new Auto() { Kennzeichen = autoKZ };

         Assert.IsTrue(auto1.Kennzeichen == autoKZ);
         Assert.IsTrue(auto1.GefahrenVon.Count == 0);
      }

      [TestMethod]
      public void AddOneAutoToPerson()
      {
         Person person1 = new Person() { Name = "Person1" };
         Auto auto1 = new Auto() { Kennzeichen = "W-111" };

         Assert.IsTrue(person1.FaehrtMit.Count == 0);
         Assert.IsTrue(auto1.GefahrenVon.Count == 0);

         person1.AddFaehrtMit(auto1);

         Assert.IsTrue(person1.FaehrtMit.Count == 1);
         Assert.IsTrue(person1.FaehrtMit[0] == auto1);
         Assert.IsTrue(auto1.GefahrenVon.Count == 1);
         Assert.IsTrue(auto1.GefahrenVon[0] == person1);
      }

      [TestMethod]
      public void AddTwoAutoToPerson()
      {
         Person person1 = new Person() { Name = "Person1" };
         Auto auto1 = new Auto() { Kennzeichen = "W-111" };
         Auto auto2 = new Auto() { Kennzeichen = "W-222" };

         Assert.IsTrue(person1.FaehrtMit.Count == 0);
         Assert.IsTrue(auto1.GefahrenVon.Count == 0);
         Assert.IsTrue(auto2.GefahrenVon.Count == 0);

         person1.AddFaehrtMit(auto1);

         Assert.IsTrue(person1.FaehrtMit.Count == 1);
         Assert.IsTrue(person1.FaehrtMit[0] == auto1);
         Assert.IsTrue(auto1.GefahrenVon.Count == 1);
         Assert.IsTrue(auto1.GefahrenVon[0] == person1);
         Assert.IsTrue(auto2.GefahrenVon.Count == 0);

         person1.AddFaehrtMit(auto2);

         Assert.IsTrue(person1.FaehrtMit.Count == 2);
         Assert.IsTrue(person1.FaehrtMit[0] == auto1);
         Assert.IsTrue(person1.FaehrtMit[1] == auto2);
         Assert.IsTrue(auto1.GefahrenVon.Count == 1);
         Assert.IsTrue(auto1.GefahrenVon[0] == person1);
         Assert.IsTrue(auto2.GefahrenVon.Count == 1);
         Assert.IsTrue(auto2.GefahrenVon[0] == person1);
      }

      [TestMethod]
      public void AddOneAutoToPersonThenAddItToAnother()
      {
         Person person1 = new Person() { Name = "Person1" };
         Person person2 = new Person() { Name = "Person2" };
         Auto auto1 = new Auto() { Kennzeichen = "W-111" };

         Assert.IsTrue(person1.FaehrtMit.Count == 0);
         Assert.IsTrue(person2.FaehrtMit.Count == 0);
         Assert.IsTrue(auto1.GefahrenVon.Count == 0);

         person1.AddFaehrtMit(auto1);

         Assert.IsTrue(person1.FaehrtMit.Count == 1);
         Assert.IsTrue(person1.FaehrtMit[0] == auto1);
         Assert.IsTrue(person2.FaehrtMit.Count == 0);
         Assert.IsTrue(auto1.GefahrenVon.Count == 1);
         Assert.IsTrue(auto1.GefahrenVon[0] == person1);

         person2.AddFaehrtMit(auto1);

         Assert.IsTrue(person1.FaehrtMit.Count == 1);
         Assert.IsTrue(person1.FaehrtMit[0] == auto1);
         Assert.IsTrue(person2.FaehrtMit.Count == 1);
         Assert.IsTrue(person2.FaehrtMit[0] == auto1);
         Assert.IsTrue(auto1.GefahrenVon.Count == 2);
         Assert.IsTrue(auto1.GefahrenVon[0] == person1);
         Assert.IsTrue(auto1.GefahrenVon[1] == person2);
      }

      [TestMethod]
      public void AddOneAutoToPersonThenAddItToAnother2()
      {
         Person person1 = new Person() { Name = "Person1" };
         Person person2 = new Person() { Name = "Person2" };
         Auto auto1 = new Auto() { Kennzeichen = "W-111" };

         Assert.IsTrue(person1.FaehrtMit.Count == 0);
         Assert.IsTrue(person2.FaehrtMit.Count == 0);
         Assert.IsTrue(auto1.GefahrenVon.Count == 0);

         person1.AddFaehrtMit(auto1);

         Assert.IsTrue(person1.FaehrtMit.Count == 1);
         Assert.IsTrue(person1.FaehrtMit[0] == auto1);
         Assert.IsTrue(person2.FaehrtMit.Count == 0);
         Assert.IsTrue(auto1.GefahrenVon.Count == 1);
         Assert.IsTrue(auto1.GefahrenVon[0] == person1);

         auto1.AddGefahrenVon(person2);

         Assert.IsTrue(person1.FaehrtMit.Count == 1);
         Assert.IsTrue(person1.FaehrtMit[0] == auto1);
         Assert.IsTrue(person2.FaehrtMit.Count == 1);
         Assert.IsTrue(person2.FaehrtMit[0] == auto1);
         Assert.IsTrue(auto1.GefahrenVon.Count == 2);
         Assert.IsTrue(auto1.GefahrenVon[0] == person1);
         Assert.IsTrue(auto1.GefahrenVon[1] == person2);
      }

      [TestMethod]
      public void AddOneAutoToPersonThenRemoveIt()
      {
         Person person1 = new Person() { Name = "Person1" };
         Auto auto1 = new Auto() { Kennzeichen = "W-111" };

         Assert.IsTrue(person1.FaehrtMit.Count == 0);
         Assert.IsTrue(auto1.GefahrenVon.Count == 0);

         person1.AddFaehrtMit(auto1);

         Assert.IsTrue(person1.FaehrtMit.Count == 1);
         Assert.IsTrue(person1.FaehrtMit[0] == auto1);
         Assert.IsTrue(auto1.GefahrenVon.Count == 1);
         Assert.IsTrue(auto1.GefahrenVon[0] == person1);

         person1.RemoveFaehrtMit(auto1);

         Assert.IsTrue(person1.FaehrtMit.Count == 0);
         Assert.IsTrue(auto1.GefahrenVon.Count == 0);
      }

      [TestMethod]
      public void AddOneAutoToPersonThenRemoveIt2()
      {
         Person person1 = new Person() { Name = "Person1" };
         Auto auto1 = new Auto() { Kennzeichen = "W-111" };

         Assert.IsTrue(person1.FaehrtMit.Count == 0);
         Assert.IsTrue(auto1.GefahrenVon.Count == 0);

         person1.AddFaehrtMit(auto1);

         Assert.IsTrue(person1.FaehrtMit.Count == 1);
         Assert.IsTrue(person1.FaehrtMit[0] == auto1);
         Assert.IsTrue(auto1.GefahrenVon.Count == 1);
         Assert.IsTrue(auto1.GefahrenVon[0] == person1);

         auto1.RemoveGefahrenVon(person1);

         Assert.IsTrue(person1.FaehrtMit.Count == 0);
         Assert.IsTrue(auto1.GefahrenVon.Count == 0);
      }

      [TestMethod]
      public void AddOneAutoToPersonThenRemoveItThenAddItAgain()
      {
         Person person1 = new Person() { Name = "Person1" };
         Auto auto1 = new Auto() { Kennzeichen = "W-111" };

         Assert.IsTrue(person1.FaehrtMit.Count == 0);
         Assert.IsTrue(auto1.GefahrenVon.Count == 0);

         person1.AddFaehrtMit(auto1);

         Assert.IsTrue(person1.FaehrtMit.Count == 1);
         Assert.IsTrue(person1.FaehrtMit[0] == auto1);
         Assert.IsTrue(auto1.GefahrenVon.Count == 1);
         Assert.IsTrue(auto1.GefahrenVon[0] == person1);

         person1.RemoveFaehrtMit(auto1);

         Assert.IsTrue(person1.FaehrtMit.Count == 0);
         Assert.IsTrue(auto1.GefahrenVon.Count == 0);

         person1.AddFaehrtMit(auto1);

         Assert.IsTrue(person1.FaehrtMit.Count == 1);
         Assert.IsTrue(person1.FaehrtMit[0] == auto1);
         Assert.IsTrue(auto1.GefahrenVon.Count == 1);
         Assert.IsTrue(auto1.GefahrenVon[0] == person1);
      }

      [TestMethod]
      public void AddOneAutoToPersonThenRemoveItThenAddItAgain2()
      {
         Person person1 = new Person() { Name = "Person1" };
         Auto auto1 = new Auto() { Kennzeichen = "W-111" };

         Assert.IsTrue(person1.FaehrtMit.Count == 0);
         Assert.IsTrue(auto1.GefahrenVon.Count == 0);

         person1.AddFaehrtMit(auto1);

         Assert.IsTrue(person1.FaehrtMit.Count == 1);
         Assert.IsTrue(person1.FaehrtMit[0] == auto1);
         Assert.IsTrue(auto1.GefahrenVon.Count == 1);
         Assert.IsTrue(auto1.GefahrenVon[0] == person1);

         person1.RemoveFaehrtMit(auto1);

         Assert.IsTrue(person1.FaehrtMit.Count == 0);
         Assert.IsTrue(auto1.GefahrenVon.Count == 0);

         auto1.AddGefahrenVon(person1);

         Assert.IsTrue(person1.FaehrtMit.Count == 1);
         Assert.IsTrue(person1.FaehrtMit[0] == auto1);
         Assert.IsTrue(auto1.GefahrenVon.Count == 1);
         Assert.IsTrue(auto1.GefahrenVon[0] == person1);
      }

      [TestMethod]
      public void AddOneAutoToPersonThenRemoveIt2ThenAddItAgain()
      {
         Person person1 = new Person() { Name = "Person1" };
         Auto auto1 = new Auto() { Kennzeichen = "W-111" };

         Assert.IsTrue(person1.FaehrtMit.Count == 0);
         Assert.IsTrue(auto1.GefahrenVon.Count == 0);

         person1.AddFaehrtMit(auto1);

         Assert.IsTrue(person1.FaehrtMit.Count == 1);
         Assert.IsTrue(person1.FaehrtMit[0] == auto1);
         Assert.IsTrue(auto1.GefahrenVon.Count == 1);
         Assert.IsTrue(auto1.GefahrenVon[0] == person1);

         auto1.RemoveGefahrenVon(person1);

         Assert.IsTrue(person1.FaehrtMit.Count == 0);
         Assert.IsTrue(auto1.GefahrenVon.Count == 0);

         person1.AddFaehrtMit(auto1);

         Assert.IsTrue(person1.FaehrtMit.Count == 1);
         Assert.IsTrue(person1.FaehrtMit[0] == auto1);
         Assert.IsTrue(auto1.GefahrenVon.Count == 1);
         Assert.IsTrue(auto1.GefahrenVon[0] == person1);
      }

      [TestMethod]
      public void AddOneAutoToPersonThenRemoveIt2ThenAddItAgain2()
      {
         Person person1 = new Person() { Name = "Person1" };
         Auto auto1 = new Auto() { Kennzeichen = "W-111" };

         Assert.IsTrue(person1.FaehrtMit.Count == 0);
         Assert.IsTrue(auto1.GefahrenVon.Count == 0);

         person1.AddFaehrtMit(auto1);

         Assert.IsTrue(person1.FaehrtMit.Count == 1);
         Assert.IsTrue(person1.FaehrtMit[0] == auto1);
         Assert.IsTrue(auto1.GefahrenVon.Count == 1);
         Assert.IsTrue(auto1.GefahrenVon[0] == person1);

         auto1.RemoveGefahrenVon(person1);

         Assert.IsTrue(person1.FaehrtMit.Count == 0);
         Assert.IsTrue(auto1.GefahrenVon.Count == 0);

         auto1.AddGefahrenVon(person1);

         Assert.IsTrue(person1.FaehrtMit.Count == 1);
         Assert.IsTrue(person1.FaehrtMit[0] == auto1);
         Assert.IsTrue(auto1.GefahrenVon.Count == 1);
         Assert.IsTrue(auto1.GefahrenVon[0] == person1);
      }

      [TestMethod]
      public void AddOneAutoToPersonThenRemoveAWrongOne()
      {
         Person person1 = new Person() { Name = "Person1" };
         Auto auto1 = new Auto() { Kennzeichen = "W-111" };
         Auto auto2 = new Auto() { Kennzeichen = "W-222" };

         Assert.IsTrue(person1.FaehrtMit.Count == 0);
         Assert.IsTrue(auto1.GefahrenVon.Count == 0);
         Assert.IsTrue(auto2.GefahrenVon.Count == 0);

         person1.AddFaehrtMit(auto1);

         Assert.IsTrue(person1.FaehrtMit.Count == 1);
         Assert.IsTrue(person1.FaehrtMit[0] == auto1);
         Assert.IsTrue(auto1.GefahrenVon.Count == 1);
         Assert.IsTrue(auto1.GefahrenVon[0] == person1);
         Assert.IsTrue(auto2.GefahrenVon.Count == 0);

         person1.RemoveFaehrtMit(auto2);

         Assert.IsTrue(person1.FaehrtMit.Count == 1);
         Assert.IsTrue(person1.FaehrtMit[0] == auto1);
         Assert.IsTrue(auto1.GefahrenVon.Count == 1);
         Assert.IsTrue(auto1.GefahrenVon[0] == person1);
         Assert.IsTrue(auto2.GefahrenVon.Count == 0);
      }

      [TestMethod]
      public void AddOnePersonToAuto()
      {
         Person person1 = new Person() { Name = "Person1" };
         Auto auto1 = new Auto() { Kennzeichen = "W-111" };

         Assert.IsTrue(person1.FaehrtMit.Count == 0);
         Assert.IsTrue(auto1.GefahrenVon.Count == 0);

         auto1.AddGefahrenVon(person1);

         Assert.IsTrue(person1.FaehrtMit.Count == 1);
         Assert.IsTrue(person1.FaehrtMit[0] == auto1);
         Assert.IsTrue(auto1.GefahrenVon.Count == 1);
         Assert.IsTrue(auto1.GefahrenVon[0] == person1);
      }
   }
}
