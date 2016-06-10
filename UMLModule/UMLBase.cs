using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UMLModule.Attributes;

namespace UMLModule
{
   public abstract class UMLBase : IUMLNotifications
   {
      public void NotifyChanges(UMLBase sender, object oldValue, object newValue, UMLNotficationType type, List<ConnectedWithRole> connectedRoles)
      {
         foreach (ConnectedWithRole connectedRole in connectedRoles)
         {
            FieldInfo field = this.GetType().GetField(connectedRole.FieldName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            Multiplicity multiplicity = null;
            int? minCount, maxCount;
            if (field != null)
            {
               if (field.FieldType == sender.GetType())
               {
                  switch (type)
                  {
                     case UMLNotficationType.ADD:
                        break;
                     case UMLNotficationType.SET:
                        object ov = field.GetValue(this);

                        field.SetValue(this, sender);

                        sender.NotifyChanges(this, ov, field.GetValue(this), UMLNotficationType.DELETE, field.GetCustomAttributes(typeof(ConnectedWithRole), false).Select(x => x as ConnectedWithRole).ToList());
                        break;
                     case UMLNotficationType.UPDATE:
                        break;
                     case UMLNotficationType.DELETE:
                        field.SetValue(this, null);
                        break;
                     default:
                        break;
                  }

               }
               else
               {
                  dynamic collection = Convert.ChangeType(field.GetValue(this), field.FieldType);

                  //cast von object zum eigentlichen Typ. sonst kann nicht in die generische collection eingefügt werden.
                  dynamic value = Convert.ChangeType(sender, sender.GetType());

                  switch (type)
                  {
                     case UMLNotficationType.ADD:
                        //check multiplicity
                        multiplicity = field.GetCustomAttributes(typeof(Multiplicity), false).FirstOrDefault() as Multiplicity;
                        GetMinMaxCount(multiplicity, out minCount, out maxCount);

                        if (!maxCount.HasValue || collection.Count < maxCount.Value)
                        {
                           collection.Add(value);
                        }
                        else
                        {
                           throw new UMLOutOfBoundsException("UpperBound " + maxCount.Value + " reached!");
                        }
                        break;
                     case UMLNotficationType.SET:
                        break;
                     case UMLNotficationType.UPDATE:
                        break;
                     case UMLNotficationType.DELETE:
                        if (oldValue != null /*&& connectedRole.AggregationType == AggregationType.Composite*/)
                        {
                           dynamic oldCollection = Convert.ChangeType(field.GetValue(oldValue), field.FieldType);

                           //check multiplicity
                           multiplicity = field.GetCustomAttributes(typeof(Multiplicity), false).FirstOrDefault() as Multiplicity;
                           GetMinMaxCount(multiplicity, out minCount, out maxCount);

                           if (!minCount.HasValue || oldCollection.Count > minCount.Value)
                           {
                              oldCollection.Remove(value);
                           }
                           else
                           {
                              throw new UMLOutOfBoundsException("LowerBound " + minCount.Value + " reached!");
                           }
                        }
                        break;
                     default:
                        break;
                  }
               }
            }
         }
      }

      protected void GetMinMaxCount(Multiplicity multiplicity, out int? minCount, out int? maxCount)
      {
         minCount = null;
         maxCount = null;

         if (multiplicity != null)
         {
            if (multiplicity.Value.Contains(".."))
            {
               string[] tmp = multiplicity.Value.Split(new string[] { ".." }, StringSplitOptions.None);

               minCount = int.Parse(tmp[0]);
               if (tmp[1] == "*")
                  maxCount = null;
               else
                  maxCount = int.Parse(tmp[1]);
            }
            else
            {
               if (multiplicity.Value == "*")
                  maxCount = null;
               else
                  maxCount = int.Parse(multiplicity.Value);
            }
         }
      }
   }
}