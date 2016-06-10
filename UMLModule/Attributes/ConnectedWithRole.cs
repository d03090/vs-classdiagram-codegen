using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMLModule.Attributes
{
   [System.AttributeUsage(AttributeTargets.Field)]
   public class ConnectedWithRole : Attribute
   {
      public string FieldName;
      public AggregationType AggregationType;

      public ConnectedWithRole(string fieldName)
      {
         this.FieldName = fieldName;
      }
   }

   public enum AggregationType
   {
      None,
      Shared,
      Composite
   }
}
