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
   public abstract class ReifenBase : UMLBase
   {
      [ConnectedWithRole("_reifen", AggregationType = AggregationType.None)]
      protected Auto _auto;

      protected int _id;

      protected virtual Auto Auto
      {
         get
         {
            return _auto;
         }

         set
         {
            FieldInfo field = this.GetType().BaseType.GetField("_auto", System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            List<ConnectedWithRole> attributes = field.GetCustomAttributes(typeof(ConnectedWithRole), false).Select(x => x as ConnectedWithRole).ToList();

            Auto oldValue = _auto;
            _auto = value;

            if (oldValue != null)
               oldValue.NotifyChanges(this, oldValue, UMLNotficationType.DELETE, attributes);

            if (_auto != null)
               _auto.NotifyChanges(this, oldValue, UMLNotficationType.ADD, attributes);
         }
      }
   }

}
