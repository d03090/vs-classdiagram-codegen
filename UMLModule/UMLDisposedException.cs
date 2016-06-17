using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMLModule
{
   public class UMLDisposedException : Exception
   {
      public new string Message { get; set; }

      public UMLDisposedException()
      {

      }

      public UMLDisposedException(string message)
      {
         this.Message = message;
      }
   }
}
