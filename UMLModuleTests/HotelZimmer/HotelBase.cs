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
      [Multiplicity("*")]
      [ConnectedWithRole("_hotel", AggregationType = AggregationType.None)]
      protected HashSet<Zimmer> _zimmer;

      protected string _name;

      protected HotelBase()
      {
         _zimmer = new HashSet<Zimmer>();
      }

      //public void AddZimmer(Zimmer zimmer)
      //{
      //   FieldInfo field = this.GetType().GetField("_zimmer", System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);

      //   HashSet<Zimmer> oldValue = new HashSet<Zimmer>(_zimmer);
      //   _zimmer.Add(zimmer);

      //   //bei 1-n Beziehung --> UMLNotficationType.SET
      //   zimmer.NotifyChanges(this, oldValue, _zimmer, UMLNotficationType.SET, field.GetCustomAttributes(typeof(ConnectedWithRole), false).Select(x => x as ConnectedWithRole).ToList());
      //}

      public Zimmer AddZimmer()
      {
         Zimmer ret = null;

         FieldInfo field = this.GetType().GetField("_zimmer", System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
         Multiplicity multiplicity = field.GetCustomAttributes(typeof(Multiplicity), false).FirstOrDefault() as Multiplicity;

         if (CheckMultiplicity(multiplicity, _zimmer.Count + 1))
         {
            //HotelBase is abstract. "this" has to be at least a Hotel
            ret = new Zimmer((Hotel)this);
            _zimmer.Add(ret);
         }
         else
         {
            throw new UMLOutOfBoundsException((_zimmer.Count + 1) + " out of bounds: " + multiplicity.Value);
         }

         return ret;
      }

      public void RemoveZimmer(Zimmer zimmer)
      {
         if (_zimmer.Contains(zimmer))
         {
            FieldInfo field = this.GetType().GetField("_zimmer", System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            Multiplicity multiplicity = field.GetCustomAttributes(typeof(Multiplicity), false).FirstOrDefault() as Multiplicity;

            if (CheckMultiplicity(multiplicity, _zimmer.Count - 1))
            {
               _zimmer.Remove(zimmer);
            }
            else
            {
               throw new UMLOutOfBoundsException((_zimmer.Count - 1) + " out of bounds: " + multiplicity.Value);
            }

            zimmer.NotifyChanges(this, zimmer, _zimmer, UMLNotficationType.DELETE, field.GetCustomAttributes(typeof(ConnectedWithRole), false).Select(x => x as ConnectedWithRole).ToList());

            //for compositions. zimmer can't exist without hotel
            zimmer.Dispose();
         }
      }
   }
}
