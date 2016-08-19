using Microsoft.VisualStudio.ArchitectureTools.Extensibility.Presentation;
using Microsoft.VisualStudio.ArchitectureTools.Extensibility.Uml;
using Microsoft.VisualStudio.Modeling.ExtensionEnablement;
using Microsoft.VisualStudio.Uml.AuxiliaryConstructs;
using Microsoft.VisualStudio.Uml.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignerExtension
{
    // DELETE any of these attributes if the command
    // should not appear in some types of diagram.
    [ClassDesignerExtension]
    //[ActivityDesignerExtension]
    //[ComponentDesignerExtension]
    //[SequenceDesignerExtension]
    //[UseCaseDesignerExtension]
    // [LayerDesignerExtension]

    // All menu commands must export ICommandExtension:
    [Export(typeof(ICommandExtension))]
    public class Extension : ICommandExtension
    {
        [Import]
        public IDiagramContext DiagramContext { get; set; }

        public void QueryStatus(IMenuCommand command)
        { // Set command.Visible or command.Enabled to false
          // to disable the menu command.
            command.Visible = command.Enabled = true;
        }

        public string Text
        {
            get { return "generate vdm"; }
        }

        public void Execute(IMenuCommand command)
        {
            // A selection of starting points:
            IDiagram diagram = this.DiagramContext.CurrentDiagram;
            foreach (IShape<IElement> shape in diagram.GetSelectedShapes<IElement>())
            {
                IElement element = shape.Element;
            }
            IModelStore modelStore = diagram.ModelStore;
            IModel model = modelStore.Root;
            foreach (IElement element in modelStore.AllInstances<IClass>())
            {
            }



            // Initialize the template with the Model Store.
            VdmGen generator = new VdmGen(
                   DiagramContext.CurrentDiagram.ModelStore);
            // Generate the text and write it.
            System.IO.File.WriteAllText
              (System.IO.Path.Combine(
                  Environment.GetFolderPath(
                      Environment.SpecialFolder.Desktop),
                  "Generated.txt")
               , generator.TransformText());
        }
    }
}
