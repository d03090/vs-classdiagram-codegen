using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UMLModule;
using UMLModule.Attributes;

namespace UMLModuleTests.HotelZimmer
{
   public abstract class ZimmerBase : UMLBase
   {
      [ConnectedWithRole("_zimmer", AggregationType = AggregationType.Composite)]
      protected Hotel _hotel;

      protected string _name;

      protected ZimmerBase()
      {
      }

      protected virtual Hotel Hotel
      {
         get
         {
            return _hotel;
         }

         set
         {
            FieldInfo field = this.GetType().GetField("_hotel", System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            List<ConnectedWithRole> attributes = field.GetCustomAttributes(typeof(ConnectedWithRole), false).Select(x => x as ConnectedWithRole).ToList();

            Hotel oldValue = _hotel;
            _hotel = value;

            if (oldValue != null)
               oldValue.NotifyChanges(this, oldValue, value, UMLNotficationType.DELETE, attributes);

            if (_hotel != null)
               _hotel.NotifyChanges(this, oldValue, value, UMLNotficationType.ADD, attributes);
         }
      }
   }
}
