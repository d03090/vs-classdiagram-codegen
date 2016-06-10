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
   public class Zimmer : ZimmerBase
   {
      public new virtual Hotel Hotel
      {
         get
         {
            return base.Hotel;
         }

         //reassign not allowed --> Composition
         //set
         //{
         //   base.Hotel = value;
         //}
      }


      public string Name
      {
         get
         {
            return _name;
         }

         set
         {
            _name = value;
         }
      }
      
      public Zimmer(Hotel hotel) : base(hotel)
      {
      }
   }
}
