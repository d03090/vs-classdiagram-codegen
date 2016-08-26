using Microsoft.VisualStudio.Uml.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignerExtension
{
   public partial class ClassGen
   {
      public string WarningHeader
      {
         get
         {
            return "auto generated class\nregenerating the code, will lose made changes.";
         }
      }

      private IClass _class;
      private string _indent;
      private string _namespace;

      public ClassGen(IClass c, string indent)
      {
         _class = c;
         _indent = indent;

         _namespace = String.Join(".", GetNamespace(c.Namespace).Select(p => p.Name));
      }

      private IEnumerable<INamespace> GetNamespace(INamespace ns)
      {
         if (ns == null || ns.Namespace == null)
            return Enumerable.Empty<INamespace>();

         return Enumerable.Union<INamespace>(GetNamespace(ns.Namespace), new[] { ns });
      }
   }
}
