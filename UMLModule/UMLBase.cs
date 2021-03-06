﻿using System;
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

                        if (CheckMultiplicity(multiplicity, collection.Count + 1))
                        {
                           collection.Add(value);
                        }
                        else
                        {
                           throw new UMLOutOfBoundsException((collection.Count + 1) + " out of bounds: " + multiplicity.Value);
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

                           if (CheckMultiplicity(multiplicity, oldCollection.Count - 1))
                           {
                              oldCollection.Remove(value);
                           }
                           else
                           {
                              throw new UMLOutOfBoundsException((oldCollection.Count - 1) + " out of bounds: " + multiplicity.Value);
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

      protected bool CheckMultiplicity(Multiplicity multiplicity, int count)
      {
         return (!multiplicity.MinCount.HasValue || multiplicity.MinCount.Value <= count)
            && (!multiplicity.MaxCount.HasValue || multiplicity.MaxCount.Value >= count);
      }
   }
}