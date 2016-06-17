using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMLModule.Attributes;

namespace UMLModule
{
   public interface IUMLNotifications
   {
      void NotifyChanges(UMLBase sender, object oldValue, UMLNotficationType type, List<ConnectedWithRole> connectedRoles);
   }

   public enum UMLNotficationType
   {
      ADD,
      SET,
      UPDATE,
      DELETE
   }
}
