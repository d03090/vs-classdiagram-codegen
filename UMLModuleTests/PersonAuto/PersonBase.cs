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
   public abstract class PersonBase : UMLBase
   {
      [ConnectedWithRole("_gefahrenVon", AggregationType = AggregationType.None)]
      protected HashSet<Auto> _faehrtMit;

      protected string _name;

      protected PersonBase()
      {
         _faehrtMit = new HashSet<Auto>();
      }

      public void AddFaehrtMit(Auto auto)
      {
         FieldInfo field = this.GetType().GetField("_faehrtMit", System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);

         HashSet<Auto> oldValue = new HashSet<Auto>(_faehrtMit);
         _faehrtMit.Add(auto);

         //bei n-m Beziehung --> UMLNotficationType.ADD
         auto.NotifyChanges(this, oldValue, _faehrtMit, UMLNotficationType.ADD, field.GetCustomAttributes(typeof(ConnectedWithRole), false).Select(x => x as ConnectedWithRole).ToList());
      }

      public void RemoveFaehrtMit(Auto auto)
      {
         FieldInfo field = this.GetType().GetField("_faehrtMit", System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);

         _faehrtMit.Remove(auto);

         auto.NotifyChanges(this, auto, _faehrtMit, UMLNotficationType.DELETE, field.GetCustomAttributes(typeof(ConnectedWithRole), false).Select(x => x as ConnectedWithRole).ToList());
      }
   }
}
