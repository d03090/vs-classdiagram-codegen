// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 14.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace DesignerExtension
{
    using Microsoft.VisualStudio.ArchitectureTools.Extensibility.Uml;
    using Microsoft.VisualStudio.Uml.Classes;
    using System;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    
    #line 1 "D:\Schule\_UNI\Bachelorarbeit\vs-classdiagram-codegen\DesignerExtension\CSharpStereotypeHelpers.t4"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "14.0.0.0")]
    public partial class CSharpStereotypeHelpers : CSharpStereotypeHelpersBase
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public virtual string TransformText()
        {
            return this.GenerationEnvironment.ToString();
        }
        
        #line 3 "D:\Schule\_UNI\Bachelorarbeit\vs-classdiagram-codegen\DesignerExtension\CSharpStereotypeHelpers.t4"

    // CSharp profile name
    private static readonly string ProfileName = "CSharpProfile";

    /// <summary>
    /// Get the visibility of the supplied element
    /// </summary>
    /// <param name="namedElement">The element in question</param>
    /// <param name="stereotypeName">The stereotype name</param>
    /// <param name="stereotypePropertyName">The stereotype property name</param>
    /// <returns>public, protected, protected internal, internal, or private</returns>
    private static string Visibility(INamedElement namedElement, string stereotypeName, string stereotypePropertyName)
    {
        switch (namedElement.Visibility)
        {
            case VisibilityKind.Public: return "public ";
            case VisibilityKind.Protected: return "protected ";
            case VisibilityKind.Private: return "private ";
            case VisibilityKind.Package:
            {
                string getVisibility = GetProperty(namedElement, stereotypeName, stereotypePropertyName);
                if(getVisibility == "protectedinternal") 
                {
                    return "protected internal ";
                }
         
                return "internal ";
            }

            default: return string.Empty;
        }
    }

    /// <summary>
    /// Get the visibility of the given method. Note that if the method is not partial
    /// you can't have any access modifier.
    /// </summary>
    /// <param name="method">The method in question</param>
    /// <returns>public, protected, protected internal, internal, or private</returns>
    private static string MethodVisibility(IOperation method)
    {
        if(string.IsNullOrEmpty(MethodPartialOption(method)))
        {
            return Visibility(method, "method", "PackageVisibility");
        }
        else 
        {
            return string.Empty;
        }
    }
    
    /// <summary>
    /// Get the visibility of the given indexer.
    /// </summary>
    /// <param name="indexer">The indexer in question</param>
    /// <returns>public, protected, protected internal, internal, or private</returns>
    private static string IndexerVisibility(IOperation indexer)
    {
        return Visibility(indexer, "indexer", "PackageVisibility");
    }

    /// <summary>
    /// Returns the visibility of the given field.
    /// </summary>
    /// <param name="field">field</param>
    /// <returns>public, protected, protected internal, internal, or private</returns>
    private static string FieldVisibility(IProperty field)
    {
        return Visibility(field, "field", "PackageVisibility");
    }

    /// <summary>
    /// Returns the visibility of the given property.
    /// </summary>
    /// <param name="property">property</param>
    /// <returns>public, protected, protected internal, internal, or private</returns>
    private static string PropertyVisibility(IProperty property)
    {
        return Visibility(property, "property", "PackageVisibility");
    }

    /// <summary>
    /// Returns the visibility of the given property getter
    /// </summary>
    /// <param name="property">The property</param>
    /// <returns>The property getter visibility</returns>
    private static string PropertyGetVisibility(IProperty property)
    {
        string getVisibility = GetProperty(property, "property", "Get");
        return GetterSetterVisibility(getVisibility);
    }

    /// <summary>
    /// Returns the visibility of the given property setter
    /// </summary>
    /// <param name="element">element</param>
    /// <returns>string visibility</returns>
    private static string PropertySetVisibility(IProperty element)
    {
        string getVisibility = GetProperty(element, "property", "Set");
        return GetterSetterVisibility(getVisibility);
    }

    /// <summary>
    /// Returns the visibility of the given indexer's getter
    /// </summary>
    /// <param name="operation">The operation</param>
    /// <returns>The indexer getter visibility</returns>
    private static string IndexerGetVisibility(IOperation operation)
    {
        string getVisibility = GetProperty(operation, "indexer", "Get");
        return GetterSetterVisibility(getVisibility);
    }

    /// <summary>
    /// Returns the visibility of the given indexer's setter
    /// </summary>
    /// <param name="element">element</param>
    /// <returns>The indexer setter visibility</returns>
    private static string IndexerSetVisibility(IOperation element)
    {
        string getVisibility = GetProperty(element, "indexer", "Set");
        return GetterSetterVisibility(getVisibility);
    }

    ///<summary>
    /// Returns the generated visibility for the visibility selected by the user
    ///</summary>
    ///<param name="selectedVisibility">The visibility selected by user for getter or setter</param>
    /// <returns>The getter/setter visibility</returns>
    private static string GetterSetterVisibility(string selectedVisibility)
    {
        //the access modifier keyword 'public' never needs to be generated for the getter or setter, at most it would be redundant
        string getVisibility = selectedVisibility;
        if(getVisibility == "none" || getVisibility == "public") 
        {
            getVisibility = string.Empty;
        }
        else if(getVisibility == "package") 
        {
            getVisibility = "internal";
        }
        else if(getVisibility == "protectedinternal") 
        {
            getVisibility = "protected internal";
        }

        return string.IsNullOrWhiteSpace(getVisibility) ? string.Empty : getVisibility + " ";
    }

    ///<summary>
    /// Returns the keyword of certain stereotype property for the element.
    ///</summary>
    /// <param name="element">The element</param>
    /// <param name="stereotypeName">The stereotype name</param>
    /// <param name="propertyName">The stereotype property name</param>
    /// <param name="keyword">The keyword corresponding to the property name</param>
    /// <returns>The property keyword</returns>
    private static string GetProperty(IElement element, string stereotypeName, string propertyName, string keyword) 
    {
        string property = GetProperty(element, stereotypeName, propertyName);
        if (!string.IsNullOrEmpty(property) && Convert.ToBoolean(property))
        {
            return keyword + " ";
        }

        return string.Empty;
    }

    /// <summary>
    /// Returns the value of a stereotype property
    /// </summary>
    /// <param name="property">stereotype property name</param>
    /// <returns>string value</returns>
    private static string GetProperty(IElement element, string stereotypeName, string property)
    {
        return element.GetStereotypeProperty(ProfileName, stereotypeName, property) ?? string.Empty;
    }

    /// <summary>
    /// Get the default stereotype for the encapsulated UML model element if there is
    /// no stereotype set explicitly;
    /// Get the stereotype that is set if there is only one CSharp stereotype set;
    /// Return null, if there are multiple stereotypes set for the element.
    /// </summary>
    /// <param name="element">the element in question</param>
    /// <returns>The name of the element's stereotype it should apply</returns>
    private static string GetStereotype(IElement element)
    {
        var csharpStereotypes = element.AppliedStereotypes.Where(s => s.Profile == ProfileName);

        if(!csharpStereotypes.Any())
        {
            return GetDefaultStereotype(element);
        }
        else if(csharpStereotypes.Count() == 1) 
        {
            return csharpStereotypes.First() != null ? csharpStereotypes.First().Name : null;
        }

        return null;
    }

    /// <summary>
    /// Get the default stereotype for the encapsulated UML model element (i.e. The name 
    /// of the stereotype implied if the element has no other stereotypes applied).
    /// </summary>
    /// <param name="element">the element in question</param>
    /// <remarks>
    /// The mapping From a type to its default stereotype:
    /// --------------------------------------------------            
    /// IClass          "class"         // IClass never implies "struct" or "delegate"
    /// IEnumeration    "enum"
    /// IDependency     "extends"
    /// IProperty       "property"
    /// IInterface      "interface"
    /// IOperation      "method"        // IOperation never implies "indexer"
    /// IPackage        "namespace"
    /// IPackageImport  "using"
    /// </remarks> 
    /// <returns>The name of the element's default stereotype.  </returns>
    private static string GetDefaultStereotype(IElement element)
    {
        return element.FindImpliedStereotype("CSharpProfile");
    }

    private void WriteFieldClrAttributes(IProperty element)
    {
        WriteClrAttributes(element, "field");
    }

    private void WritePropertyClrAttributes(IProperty element)
    {
        WriteClrAttributes(element, "property");
    }

    private static string FieldVolatileOption(IProperty element) 
    {
        return GetProperty(element, "field", "IsVolatile", "volatile");
    }

    private static string FieldNullableOption(IProperty element) 
    {
        return GetProperty(element, "field", "IsNullable", "?");
    }

    private static string FieldConstOption(IProperty element) 
    {
        return GetProperty(element, "field", "IsConst", "const");
    }

    /// <summary>
    /// Returns the 'unsafe' keword if the supplied property is marked as unsafe.
    /// </summary>
    /// <param name="element">the model element to query</param>
    /// <returns>'unsafe' keyword or empty string</returns>
    private static string PropertyUnsafeOption(IProperty element) 
    {
        return GetProperty(element, "property", "IsUnsafe", "unsafe");
    }

    /// <summary>
    /// Returns the 'unsafe' keword if the supplied interface is marked as unsafe.
    /// </summary>
    /// <param name="element">the model element to query</param>
    /// <returns>'unsafe' keyword or empty string</returns>
    private static string InterfaceUnsafeOption(IInterface element) 
    {
        return GetProperty(element, "interface", "IsUnsafe", "unsafe");
    }

    /// <summary>
    /// Checks whether the property has body according to the "HasBody" stereotype property.
    /// </summary>
    /// <param name="property">the model element to query</param>
    /// <returns>true if the property has body; false otherwise.</returns>
    private static bool PropertyHasBody(IProperty property)
    {
        string hasBodyValue = GetProperty(property, "property", "HasBody");
        bool hasBody = false;
        if(!string.IsNullOrEmpty(hasBodyValue))
        {
            hasBody = Convert.ToBoolean(hasBodyValue);
        }

        return hasBody;
    }
    
    /// <summary>
    /// Checks whether the method has the params parameter according to the "params" stereotype property.
    /// </summary>
    /// <param name="property">the model element to query</param>
    /// <returns>true if the method has the params parameter; false otherwise.</returns>
    private static bool MethodHasParams(IOperation operation) 
    {
        string hasParamsValue = GetProperty(operation, "method", "params");
        bool hasParams = false;
        if(!string.IsNullOrEmpty(hasParamsValue))
        {
            hasParams = Convert.ToBoolean(hasParamsValue);
        }

        return hasParams;
    }

    private static string EventUnsafeOption(IProperty element) 
    {
        return GetProperty(element, "event", "IsUnsafe", "unsafe");
    }

    private void WriteEventClrAttributes(IProperty element)
    {
        WriteClrAttributes(element, "event");
    }

    private void WriteInterfaceClrAttributes(IInterface element)
    {
        WriteClrAttributes(element, "interface");
    }

    private void WriteClassClrAttributes(IClass element)
    {
        WriteClrAttributes(element, "class");
    }

    private void WriteStructClrAttributes(IClass element)
    {
        WriteClrAttributes(element, "struct");
    }

    private void WriteEnumClrAttributes(IEnumeration element)
    {
        WriteClrAttributes(element, "enum");
    }

    private void WriteMethodClrAttributes(IOperation element)
    {
        WriteClrAttributes(element, "method");
    }

    private void WriteIndexerClrAttributes(IOperation element)
    {
        WriteClrAttributes(element, "indexer");
    }

    private static string MethodUnsafeOption(IOperation element) 
    {
        return GetProperty(element, "method", "IsUnsafe", "unsafe");
    }

    private static string IndexerUnsafeOption(IOperation element) 
    {
        return GetProperty(element, "indexer", "IsUnsafe", "unsafe");
    }

    private static string MethodPartialOption(IOperation element) 
    {
        return GetProperty(element, "method", "IsPartial", "partial");
    }

    /// <summary>
    /// Returns the 'partial' keword if the supplied interface is marked as partial.
    /// </summary>
    /// <param name="element">the model element to query</param>
    /// <returns>'partial' keyword or empty string</returns>
    private static string InterfacePartialOption(IInterface element) 
    {
        return GetProperty(element, "interface", "IsPartial", "partial");
    }

    private void WriteClrAttributes(IElement element, string stereotypeName) 
    {
        string attributeList = GetProperty(element, stereotypeName, "ClrAttributes");
        if(!string.IsNullOrEmpty(attributeList))
        {
            string trimChars = "[] \t";
            foreach (string a in attributeList.Split(';'))
            {   
                WriteLine("[" + a.Trim(trimChars.ToCharArray()) + "]");
            }
        }
    }

        
        #line default
        #line hidden
    }
    
    #line default
    #line hidden
    #region Base class
    /// <summary>
    /// Base class for this transformation
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "14.0.0.0")]
    public class CSharpStereotypeHelpersBase
    {
        #region Fields
        private global::System.Text.StringBuilder generationEnvironmentField;
        private global::System.CodeDom.Compiler.CompilerErrorCollection errorsField;
        private global::System.Collections.Generic.List<int> indentLengthsField;
        private string currentIndentField = "";
        private bool endsWithNewline;
        private global::System.Collections.Generic.IDictionary<string, object> sessionField;
        #endregion
        #region Properties
        /// <summary>
        /// The string builder that generation-time code is using to assemble generated output
        /// </summary>
        protected System.Text.StringBuilder GenerationEnvironment
        {
            get
            {
                if ((this.generationEnvironmentField == null))
                {
                    this.generationEnvironmentField = new global::System.Text.StringBuilder();
                }
                return this.generationEnvironmentField;
            }
            set
            {
                this.generationEnvironmentField = value;
            }
        }
        /// <summary>
        /// The error collection for the generation process
        /// </summary>
        public System.CodeDom.Compiler.CompilerErrorCollection Errors
        {
            get
            {
                if ((this.errorsField == null))
                {
                    this.errorsField = new global::System.CodeDom.Compiler.CompilerErrorCollection();
                }
                return this.errorsField;
            }
        }
        /// <summary>
        /// A list of the lengths of each indent that was added with PushIndent
        /// </summary>
        private System.Collections.Generic.List<int> indentLengths
        {
            get
            {
                if ((this.indentLengthsField == null))
                {
                    this.indentLengthsField = new global::System.Collections.Generic.List<int>();
                }
                return this.indentLengthsField;
            }
        }
        /// <summary>
        /// Gets the current indent we use when adding lines to the output
        /// </summary>
        public string CurrentIndent
        {
            get
            {
                return this.currentIndentField;
            }
        }
        /// <summary>
        /// Current transformation session
        /// </summary>
        public virtual global::System.Collections.Generic.IDictionary<string, object> Session
        {
            get
            {
                return this.sessionField;
            }
            set
            {
                this.sessionField = value;
            }
        }
        #endregion
        #region Transform-time helpers
        /// <summary>
        /// Write text directly into the generated output
        /// </summary>
        public void Write(string textToAppend)
        {
            if (string.IsNullOrEmpty(textToAppend))
            {
                return;
            }
            // If we're starting off, or if the previous text ended with a newline,
            // we have to append the current indent first.
            if (((this.GenerationEnvironment.Length == 0) 
                        || this.endsWithNewline))
            {
                this.GenerationEnvironment.Append(this.currentIndentField);
                this.endsWithNewline = false;
            }
            // Check if the current text ends with a newline
            if (textToAppend.EndsWith(global::System.Environment.NewLine, global::System.StringComparison.CurrentCulture))
            {
                this.endsWithNewline = true;
            }
            // This is an optimization. If the current indent is "", then we don't have to do any
            // of the more complex stuff further down.
            if ((this.currentIndentField.Length == 0))
            {
                this.GenerationEnvironment.Append(textToAppend);
                return;
            }
            // Everywhere there is a newline in the text, add an indent after it
            textToAppend = textToAppend.Replace(global::System.Environment.NewLine, (global::System.Environment.NewLine + this.currentIndentField));
            // If the text ends with a newline, then we should strip off the indent added at the very end
            // because the appropriate indent will be added when the next time Write() is called
            if (this.endsWithNewline)
            {
                this.GenerationEnvironment.Append(textToAppend, 0, (textToAppend.Length - this.currentIndentField.Length));
            }
            else
            {
                this.GenerationEnvironment.Append(textToAppend);
            }
        }
        /// <summary>
        /// Write text directly into the generated output
        /// </summary>
        public void WriteLine(string textToAppend)
        {
            this.Write(textToAppend);
            this.GenerationEnvironment.AppendLine();
            this.endsWithNewline = true;
        }
        /// <summary>
        /// Write formatted text directly into the generated output
        /// </summary>
        public void Write(string format, params object[] args)
        {
            this.Write(string.Format(global::System.Globalization.CultureInfo.CurrentCulture, format, args));
        }
        /// <summary>
        /// Write formatted text directly into the generated output
        /// </summary>
        public void WriteLine(string format, params object[] args)
        {
            this.WriteLine(string.Format(global::System.Globalization.CultureInfo.CurrentCulture, format, args));
        }
        /// <summary>
        /// Raise an error
        /// </summary>
        public void Error(string message)
        {
            System.CodeDom.Compiler.CompilerError error = new global::System.CodeDom.Compiler.CompilerError();
            error.ErrorText = message;
            this.Errors.Add(error);
        }
        /// <summary>
        /// Raise a warning
        /// </summary>
        public void Warning(string message)
        {
            System.CodeDom.Compiler.CompilerError error = new global::System.CodeDom.Compiler.CompilerError();
            error.ErrorText = message;
            error.IsWarning = true;
            this.Errors.Add(error);
        }
        /// <summary>
        /// Increase the indent
        /// </summary>
        public void PushIndent(string indent)
        {
            if ((indent == null))
            {
                throw new global::System.ArgumentNullException("indent");
            }
            this.currentIndentField = (this.currentIndentField + indent);
            this.indentLengths.Add(indent.Length);
        }
        /// <summary>
        /// Remove the last indent that was added with PushIndent
        /// </summary>
        public string PopIndent()
        {
            string returnValue = "";
            if ((this.indentLengths.Count > 0))
            {
                int indentLength = this.indentLengths[(this.indentLengths.Count - 1)];
                this.indentLengths.RemoveAt((this.indentLengths.Count - 1));
                if ((indentLength > 0))
                {
                    returnValue = this.currentIndentField.Substring((this.currentIndentField.Length - indentLength));
                    this.currentIndentField = this.currentIndentField.Remove((this.currentIndentField.Length - indentLength));
                }
            }
            return returnValue;
        }
        /// <summary>
        /// Remove any indentation
        /// </summary>
        public void ClearIndent()
        {
            this.indentLengths.Clear();
            this.currentIndentField = "";
        }
        #endregion
        #region ToString Helpers
        /// <summary>
        /// Utility class to produce culture-oriented representation of an object as a string.
        /// </summary>
        public class ToStringInstanceHelper
        {
            private System.IFormatProvider formatProviderField  = global::System.Globalization.CultureInfo.InvariantCulture;
            /// <summary>
            /// Gets or sets format provider to be used by ToStringWithCulture method.
            /// </summary>
            public System.IFormatProvider FormatProvider
            {
                get
                {
                    return this.formatProviderField ;
                }
                set
                {
                    if ((value != null))
                    {
                        this.formatProviderField  = value;
                    }
                }
            }
            /// <summary>
            /// This is called from the compile/run appdomain to convert objects within an expression block to a string
            /// </summary>
            public string ToStringWithCulture(object objectToConvert)
            {
                if ((objectToConvert == null))
                {
                    throw new global::System.ArgumentNullException("objectToConvert");
                }
                System.Type t = objectToConvert.GetType();
                System.Reflection.MethodInfo method = t.GetMethod("ToString", new System.Type[] {
                            typeof(System.IFormatProvider)});
                if ((method == null))
                {
                    return objectToConvert.ToString();
                }
                else
                {
                    return ((string)(method.Invoke(objectToConvert, new object[] {
                                this.formatProviderField })));
                }
            }
        }
        private ToStringInstanceHelper toStringHelperField = new ToStringInstanceHelper();
        /// <summary>
        /// Helper to produce culture-oriented representation of an object as a string
        /// </summary>
        public ToStringInstanceHelper ToStringHelper
        {
            get
            {
                return this.toStringHelperField;
            }
        }
        #endregion
    }
    #endregion
}