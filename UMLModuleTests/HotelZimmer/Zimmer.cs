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


      public new virtual string Name
      {
         get
         {
            return base.Name;
         }

         set
         {
            base.Name = value;
         }
      }

      public Zimmer(Hotel hotel) : base(hotel)
      {
      }
   }
}
