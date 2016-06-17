using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UMLModule;
using UMLModule.Attributes;

namespace UMLModuleTests.PersonAuto
{
   public abstract class AutoBase : UMLBase
   {
      [ConnectedWithRole("_faehrtMit", AggregationType = AggregationType.None)]
      protected HashSet<Person> _gefahrenVon;

      [Multiplicity("3..4")]
      [ConnectedWithRole("_auto", AggregationType = AggregationType.None)]
      protected HashSet<Reifen> _reifen;

      protected string _kennzeichen;

      //wegen Multiplizitätsattribut muss Auto immer mit 3..4 Reifen existieren --> kein default konstruktor
      //protected AutoBase()
      //{
      //   _gefahrenVon = new HashSet<Person>();

      //   //wegen Multiplizitätsattribut muss Auto immer mit 3..4 Reifen existieren
      //   //_reifen = new HashSet<Reifen>();
      //}

      //wegen Multiplizitätsattribut muss Auto immer mit 3..4 Reifen existieren
      protected AutoBase(HashSet<Reifen> reifen)
      {
         _gefahrenVon = new HashSet<Person>();

         FieldInfo field = this.GetType().BaseType.GetField("_reifen", System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
         Multiplicity multiplicity = field.GetCustomAttributes(typeof(Multiplicity), false).FirstOrDefault() as Multiplicity;
         if (CheckMultiplicity(multiplicity, reifen.Count))
         {
            _reifen = reifen;

            // set auto for reifen
            foreach (var r in _reifen)
            {
               //bei 1-n Beziehung --> UMLNotficationType.SET
               r.NotifyChanges(this, r.Auto, UMLNotficationType.SET, field.GetCustomAttributes(typeof(ConnectedWithRole), false).Select(x => x as ConnectedWithRole).ToList());
            }
         }
         else
         {
            throw new UMLOutOfBoundsException((reifen.Count) + " out of bounds: " + multiplicity.Value);
         }
      }

      public void AddGefahrenVon(Person person)
      {
         FieldInfo field = this.GetType().BaseType.GetField("_gefahrenVon", System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);

         HashSet<Person> oldValue = new HashSet<Person>(_gefahrenVon);
         _gefahrenVon.Add(person);

         //bei n-m Beziehung --> UMLNotficationType.ADD
         person.NotifyChanges(this, oldValue, UMLNotficationType.ADD, field.GetCustomAttributes(typeof(ConnectedWithRole), false).Select(x => x as ConnectedWithRole).ToList());
      }

      public void RemoveGefahrenVon(Person person)
      {
         FieldInfo field = this.GetType().BaseType.GetField("_gefahrenVon", System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);

         _gefahrenVon.Remove(person);

         person.NotifyChanges(this, person, UMLNotficationType.DELETE, field.GetCustomAttributes(typeof(ConnectedWithRole), false).Select(x => x as ConnectedWithRole).ToList());
      }

      public void AddReifen(Reifen reifen)
      {
         FieldInfo field = this.GetType().BaseType.GetField("_reifen", System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
         Multiplicity multiplicity = field.GetCustomAttributes(typeof(Multiplicity), false).FirstOrDefault() as Multiplicity;

         HashSet<Reifen> oldValue = new HashSet<Reifen>(_reifen);

         if (CheckMultiplicity(multiplicity, _reifen.Count + 1))
         {
            _reifen.Add(reifen);
         }
         else
         {
            throw new UMLOutOfBoundsException((_reifen.Count + 1) + " out of bounds: " + multiplicity.Value);
         }

         //bei 1-n Beziehung --> UMLNotficationType.SET
         reifen.NotifyChanges(this, oldValue, UMLNotficationType.SET, field.GetCustomAttributes(typeof(ConnectedWithRole), false).Select(x => x as ConnectedWithRole).ToList());
      }

      public void RemoveReifen(Reifen reifen)
      {
         FieldInfo field = this.GetType().BaseType.GetField("_reifen", System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
         Multiplicity multiplicity = field.GetCustomAttributes(typeof(Multiplicity), false).FirstOrDefault() as Multiplicity;

         if (CheckMultiplicity(multiplicity, _reifen.Count - 1))
         {
            _reifen.Remove(reifen);
         }
         else
         {
            throw new UMLOutOfBoundsException((_reifen.Count - 1) + " out of bounds: " + multiplicity.Value);
         }

         reifen.NotifyChanges(this, reifen, UMLNotficationType.DELETE, field.GetCustomAttributes(typeof(ConnectedWithRole), false).Select(x => x as ConnectedWithRole).ToList());
      }
   }
}
