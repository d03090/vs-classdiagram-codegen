using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMLModuleTests.PersonAuto
{
   public class Person : PersonBase
   {
      public ReadOnlyCollection<Auto> FaehrtMit
      {
         get
         {
            return _faehrtMit.ToList().AsReadOnly();
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
