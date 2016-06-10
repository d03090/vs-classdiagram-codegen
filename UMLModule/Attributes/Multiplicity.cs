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
      public int? MinCount = null;
      public int? MaxCount = null;

      public Multiplicity(string value)
      {
         //TODO check for valid value
         Value = value;
         SetMinMaxCount();
      }

      private void SetMinMaxCount()
      {
         if (Value != null)
         {
            if (Value.Contains(".."))
            {
               string[] tmp = Value.Split(new string[] { ".." }, StringSplitOptions.None);

               MinCount = int.Parse(tmp[0]);
               if (tmp[1] == "*")
                  MaxCount = null;
               else
                  MaxCount = int.Parse(tmp[1]);
            }
            else
            {
               if (Value == "*")
                  MaxCount = null;
               else
                  MaxCount = int.Parse(Value);
            }
         }
      }
   }
}
