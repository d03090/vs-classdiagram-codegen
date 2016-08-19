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

            //https://msdn.microsoft.com/en-us/library/ee231205.aspx
            string templatePath = sln.GetProjectTemplate(@"Windows\1033\ClassLibrary\csClassLibrary.vstemplate", "CSharp");

            Project proj = sln.AddFromTemplate(templatePath, Path.Combine(solutionDir, "huhu"), "huhu", false);

            proj = sln.Projects.Cast<Project>().FirstOrDefault(p => p.Name == "huhu");

            sln.SaveAs(sln.FullName);


            //string vsInstallDir = Path.GetFullPath(Path.Combine(dte.FullName, @"..\..\..\"));

            //string ProjectItemsTemplatePath= dte.Solution.ProjectItemsTemplatePath(VSLangProj.PrjKind.prjKindCSharpProject);
            //dte.Solution.AddFromTemplate(@"C:\Program Files (x86)\Microsoft Visual Studio 14.0\Common7\IDE\ProjectTemplates\CSharp\Windows Root\Windows\1033\ClassLibrary\classlibrary.csproj",
            //    Path.Combine(solutionDir,"huhu"), "myclasslib");

            //// https://msdn.microsoft.com/en-us/library/tz690efs.aspx
            //// https://msdn.microsoft.com/en-us/library/bb164728.aspx
            //object[] parameters = new object[] { EnvDTE.Constants.vsWizardNewProject, "MyConsoleProject", solutionDir, "", false, "", false };

            //EnvDTE.wizardResult res;

            //// Interop type cannot be embedded - http://stackoverflow.com/a/3320279/659254
            //string s = dte.Solution.TemplatePath[VSLangProj.PrjKind.prjKindCSharpProject];


            //res = dte.LaunchWizard(s + "ConsoleApplication.vsz", parameters);










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
    }
}
