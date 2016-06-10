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

      protected AutoBase()
      {
         _gefahrenVon = new HashSet<Person>();
         _reifen = new HashSet<Reifen>();
      }

      public void AddGefahrenVon(Person person)
      {
         FieldInfo field = this.GetType().GetField("_gefahrenVon", System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);

         HashSet<Person> oldValue = new HashSet<Person>(_gefahrenVon);
         _gefahrenVon.Add(person);

         //bei n-m Beziehung --> UMLNotficationType.ADD
         person.NotifyChanges(this, oldValue, _gefahrenVon, UMLNotficationType.ADD, field.GetCustomAttributes(typeof(ConnectedWithRole), false).Select(x => x as ConnectedWithRole).ToList());
      }

      public void RemoveGefahrenVon(Person person)
      {
         FieldInfo field = this.GetType().GetField("_gefahrenVon", System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);

         _gefahrenVon.Remove(person);

         person.NotifyChanges(this, person, _gefahrenVon, UMLNotficationType.DELETE, field.GetCustomAttributes(typeof(ConnectedWithRole), false).Select(x => x as ConnectedWithRole).ToList());
      }

      public void AddReifen(Reifen reifen)
      {
         FieldInfo field = this.GetType().GetField("_reifen", System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
         Multiplicity multiplicity = field.GetCustomAttributes(typeof(Multiplicity), false).FirstOrDefault() as Multiplicity;
         int? minCount, maxCount;
         GetMinMaxCount(multiplicity, out minCount, out maxCount);

         HashSet<Reifen> oldValue = new HashSet<Reifen>(_reifen);

         if (!maxCount.HasValue || _reifen.Count < maxCount.Value)
         {
            _reifen.Add(reifen);
         }
         else
         {
            throw new UMLOutOfBoundsException("UpperBound " + maxCount.Value + " reached!");
         }

         //bei 1-n Beziehung --> UMLNotficationType.SET
         reifen.NotifyChanges(this, oldValue, _reifen, UMLNotficationType.SET, field.GetCustomAttributes(typeof(ConnectedWithRole), false).Select(x => x as ConnectedWithRole).ToList());
      }

      public void RemoveReifen(Reifen reifen)
      {
         FieldInfo field = this.GetType().GetField("_reifen", System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
         Multiplicity multiplicity = field.GetCustomAttributes(typeof(Multiplicity), false).FirstOrDefault() as Multiplicity;
         int? minCount, maxCount;
         GetMinMaxCount(multiplicity, out minCount, out maxCount);

         if (!minCount.HasValue || _reifen.Count > minCount.Value)
         {
            _reifen.Remove(reifen);
         }
         else
         {
            throw new UMLOutOfBoundsException("LowerBound " + minCount.Value + " reached!");
         }

         reifen.NotifyChanges(this, reifen, _reifen, UMLNotficationType.DELETE, field.GetCustomAttributes(typeof(ConnectedWithRole), false).Select(x => x as ConnectedWithRole).ToList());
      }
   }
}
