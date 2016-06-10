using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMLModuleTests.HotelZimmer
{
   public class Hotel : HotelBase
   {
      public ReadOnlyCollection<Zimmer> Zimmer
      {
         get
         {
            return _zimmer.ToList().AsReadOnly();
         }
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
   }
}
