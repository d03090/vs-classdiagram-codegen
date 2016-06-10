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
   public abstract class HotelBase : UMLBase
   {
      [ConnectedWithRole("_hotel", AggregationType = AggregationType.None)]
      protected HashSet<Zimmer> _zimmer;

      protected string _name;

      protected HotelBase()
      {
         _zimmer = new HashSet<Zimmer>();
      }

      public void AddZimmer(Zimmer zimmer)
      {
         FieldInfo field = this.GetType().GetField("_zimmer", System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);

         HashSet<Zimmer> oldValue = new HashSet<Zimmer>(_zimmer);
         _zimmer.Add(zimmer);

         //bei 1-n Beziehung --> UMLNotficationType.SET
         zimmer.NotifyChanges(this, oldValue, _zimmer, UMLNotficationType.SET, field.GetCustomAttributes(typeof(ConnectedWithRole), false).Select(x => x as ConnectedWithRole).ToList());
      }

      public void RemoveZimmer(Zimmer zimmer)
      {
         FieldInfo field = this.GetType().GetField("_zimmer", System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);

        _zimmer.Remove(zimmer);

         zimmer.NotifyChanges(this, zimmer, _zimmer, UMLNotficationType.DELETE, field.GetCustomAttributes(typeof(ConnectedWithRole), false).Select(x => x as ConnectedWithRole).ToList());
      }
   }
}
