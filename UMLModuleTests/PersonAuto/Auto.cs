using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMLModuleTests.PersonAuto
{
   public class Auto : AutoBase
   {
      public ReadOnlyCollection<Person> GefahrenVon
      {
         get
         {
            return _gefahrenVon.ToList().AsReadOnly();
         }
      }
      public ReadOnlyCollection<Reifen> Reifen
      {
         get
         {
            return _reifen.ToList().AsReadOnly();
         }
      }

      public string Kennzeichen
      {
         get
         {
            return _kennzeichen;
         }

         set
         {
            _kennzeichen = value;
         }
      }

      //wegen Multiplizitätsattribut muss Auto immer mit 3..4 Reifen existieren
      public Auto(HashSet<Reifen> reifen) : base(reifen)
      {
      }
   }
}
