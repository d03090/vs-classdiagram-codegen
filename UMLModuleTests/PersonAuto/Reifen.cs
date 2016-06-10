using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMLModuleTests.PersonAuto
{
   public class Reifen:ReifenBase
   {
      public new virtual Auto Auto
      {
         get
         {
            return base.Auto;
         }

         set
         {
            base.Auto = value;
         }
      }


      public int Id
      {
         get
         {
            return _id;
         }

         set
         {
            _id = value;
         }
      }
   }
}
