using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMLModule.Attributes
{
   [System.AttributeUsage(AttributeTargets.Field)]
   public class Multiplicity : Attribute
   {
      public string Value = "*";

      public Multiplicity(string value)
      {
         Value = value;
      }
   }
}
