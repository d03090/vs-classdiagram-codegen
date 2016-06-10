using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMLModule
{
   public class UMLOutOfBoundsException : Exception
   {
      public new string Message { get; set; }

      public UMLOutOfBoundsException()
      {

      }

      public UMLOutOfBoundsException(string message)
      {
         this.Message = message;
      }
   }
}
