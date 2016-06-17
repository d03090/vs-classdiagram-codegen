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
   public abstract class ZimmerBase : UMLBase, IDisposable
   {
      //[Multiplicity("1")] has to be 1, because of Composite
      [ConnectedWithRole("_zimmer", AggregationType = AggregationType.Composite)]
      protected Hotel _hotel;

      protected string _name;

      //braucht man für compositions
      protected bool _disposed = false;

      //kein default constructor, weil ein zimmer nicht ohne hotel existieren darf
      //protected ZimmerBase()
      //{
      //}

      protected ZimmerBase(Hotel hotel)
      {
         //check for composition attribute
         if (hotel == null)
         {
            throw new UMLCompositionViolatedException();
         }

         Hotel = hotel;
      }

      protected virtual Hotel Hotel
      {
         get
         {
            if (_disposed)
            {
               throw new UMLDisposedException("Zimmer is not valid anymore.");
            }

            return _hotel;
         }

         set
         {
            if (_disposed)
            {
               throw new UMLDisposedException("Zimmer is not valid anymore.");
            }

            if (_hotel == null)
            {
               FieldInfo field = this.GetType().GetField("_hotel", System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
               List<ConnectedWithRole> attributes = field.GetCustomAttributes(typeof(ConnectedWithRole), false).Select(x => x as ConnectedWithRole).ToList();

               Hotel oldValue = _hotel;
               _hotel = value;

               //old value can't be null because of composition
               //if (oldValue != null)
               //   oldValue.NotifyChanges(this, oldValue, value, UMLNotficationType.DELETE, attributes);

               _hotel.NotifyChanges(this, oldValue, value, UMLNotficationType.ADD, attributes);
            }
            else
            {
               throw new UMLCompositionViolatedException();
            }
         }
      }

      protected virtual string Name
      {
         get
         {
            if (_disposed)
            {
               throw new UMLDisposedException("Zimmer is not valid anymore.");
            }

            return _name;
         }

         set
         {
            if (_disposed)
            {
               throw new UMLDisposedException("Zimmer is not valid anymore.");
            }

            _name = value;
         }
      }

      public void Dispose()
      {
         if (!_disposed)
         {
            _disposed = true;
         }
      }
   }
}
