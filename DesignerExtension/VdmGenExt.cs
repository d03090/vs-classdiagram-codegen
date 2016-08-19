using Microsoft.VisualStudio.ArchitectureTools.Extensibility.Uml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignerExtension
{
    public partial class VdmGen
    {
        private IModelStore store;
        public VdmGen(IModelStore s)
        { store = s; }
    }
}
