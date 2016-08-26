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
using EnvDTE;
using EnvDTE80;
using Microsoft.VisualStudio.Shell;
using System.IO;
using EnvDTE100;
using VSLangProj140;
using VSLangProj80;

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
        internal SVsServiceProvider ServiceProvider = null;

        [Import]
        public IDiagramContext DiagramContext { get; set; }

        public void QueryStatus(IMenuCommand command)
        {
            // Set command.Visible or command.Enabled to false
            // to disable the menu command.
            command.Visible = command.Enabled = true;
        }

        public string Text
        {
            get { return "Generate Code (with Constraints)"; }
        }

        public void Execute(IMenuCommand command)
        {
            DTE2 dte = (DTE2)ServiceProvider.GetService(typeof(DTE));

            Solution4 sln = (Solution4)dte.Solution;

            string solutionDir = Path.GetDirectoryName(sln.FullName);
            string solutionName = Path.GetFileNameWithoutExtension(sln.FullName) + "Lib";

            Project proj = CreateProjectWithRef(sln, solutionDir, solutionName);      
            





            //// A selection of starting points:
            //IDiagram diagram = this.DiagramContext.CurrentDiagram;
            //foreach (IShape<IElement> shape in diagram.GetSelectedShapes<IElement>())
            //{
            //    IElement element = shape.Element;
            //}
            //IModelStore modelStore = diagram.ModelStore;
            //IModel model = modelStore.Root;
            //foreach (IClass c in modelStore.AllInstances<IClass>())
            //{

            //}

            // Initialize the template with the Model Store.
            //VdmGen generator = new VdmGen(
            //       DiagramContext.CurrentDiagram.ModelStore);
            //// Generate the text and write it.
            //System.IO.File.WriteAllText
            //  (System.IO.Path.Combine(
            //      Environment.GetFolderPath(
            //          Environment.SpecialFolder.Desktop),
            //      "Generated.txt")
            //   , generator.TransformText());
        }

        private static Project CreateProjectWithRef(Solution4 sln, string solutionDir, string solutionName)
        {
            //https://msdn.microsoft.com/en-us/library/ee231205.aspx
            string templatePath = sln.GetProjectTemplate(@"Windows\1033\ClassLibrary\csClassLibrary.vstemplate", "CSharp");

            Project proj = sln.AddFromTemplate(templatePath, Path.Combine(solutionDir, solutionName), solutionName, false);

            proj = sln.Projects.Cast<Project>().FirstOrDefault(p => p.Name == solutionName);

            proj.ProjectItems.Item("Class1.cs").Delete();
            proj.ProjectItems.AddFolder("GeneratedCode");
            proj.ProjectItems.AddFolder("lib").ProjectItems.AddFromFileCopy(@"D:\Schule\_UNI\Bachelorarbeit\vs-classdiagram-codegen\UMLModule\bin\Debug\UMLModule.dll");

            // https://blogs.msdn.microsoft.com/murat/2008/07/30/envdte-adding-a-reference-to-a-project/
            // https://msdn.microsoft.com/en-us/library/vslangproj.references.add.aspx
            VSProject3 vsProj = (VSProject3)proj.Object;
            vsProj.References.Add(Path.Combine(solutionDir, solutionName, "lib", "UMLModule.dll"));

            proj.Save();
            sln.SaveAs(sln.FullName);

            return proj;
        }
    }
}
