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

// http://stackoverflow.com/questions/32870002/extension-could-not-be-found-please-make-sure-the-extension-has-been-installed
// https://github.com/zpqrtbnk/Zbu.ModelsBuilder/issues/52
// --> delete C:\Users\Stefan\AppData\Local\Microsoft\VisualStudio\14.0Exp
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

         string indent = "\t";
         // http://stackoverflow.com/questions/1212092/visual-studio-per-solution-indentation-settings
         // https://msdn.microsoft.com/en-us/library/ms165641.aspx?f=255&MSPPError=-2147217396
         // https://msdn.microsoft.com/en-us/library/ms165644.aspx
         Properties props = dte.Properties["TextEditor", "CSharp"];
         if (!(bool)props.Item("InsertTabs").Value)
         {
            indent = "";
            for (short i = 0; i < (short)props.Item("TabSize").Value; i++)
            {
               indent += " ";
            }
         }

         IDiagram diagram = this.DiagramContext.CurrentDiagram;
         IModelStore modelStore = diagram.ModelStore;
         foreach (IClass c in modelStore.AllInstances<IClass>())
         {
            string filename = Path.Combine(Path.GetTempPath(), c.Name + ".cs");

            ClassGen classGen = new ClassGen(c, indent);
            File.WriteAllText(filename, classGen.TransformText());
         }
      }

      private static Project CreateProjectWithRef(Solution4 sln, string solutionDir, string solutionName)
      {
         if (!sln.Projects.Cast<Project>().Any(p => p.Name == solutionName))
         {
            //https://msdn.microsoft.com/en-us/library/ee231205.aspx
            string templatePath = sln.GetProjectTemplate(@"Windows\1033\ClassLibrary\csClassLibrary.vstemplate", "CSharp");

            // returned project is always null, search it afterwards
            sln.AddFromTemplate(templatePath, Path.Combine(solutionDir, solutionName), solutionName, false);
         }

         Project proj = sln.Projects.Cast<Project>().FirstOrDefault(p => p.Name == solutionName);

         try
         {
            proj.ProjectItems.Item("Class1.cs").Delete();
         }
         catch
         {
            // ignore
         }

         try
         {
            proj.ProjectItems.Item("GeneratedCode").Delete();
         }
         catch
         {
            // ignore
         }

         proj.ProjectItems.AddFolder("GeneratedCode");

         try
         {
            proj.ProjectItems.Item("lib").Delete();
         }
         catch
         {
            // ignore
         }

         // TODO add final dll
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
