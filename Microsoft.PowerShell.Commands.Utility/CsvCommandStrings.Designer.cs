﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.17929
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Microsoft.PowerShell.Commands.Utility {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class CsvCommandStrings {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal CsvCommandStrings() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Microsoft.PowerShell.Commands.Utility.CsvCommandStrings", typeof(CsvCommandStrings).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Cannot append CSV content to the following file: {1}. The appended object does not have a property that corresponds to the following column: {0}. To proceed with mismatched properties, add the -Force switch and retry..
        /// </summary>
        public static string CannotAppendCsvWithMismatchedPropertyNames {
            get {
                return ResourceManager.GetString("CannotAppendCsvWithMismatchedPropertyNames", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to You must specify either the -Path or -LiteralPath parameters, but not both..
        /// </summary>
        public static string CannotSpecifyPathAndLiteralPath {
            get {
                return ResourceManager.GetString("CannotSpecifyPathAndLiteralPath", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to One or more headers were not specified. Default names starting with &quot;H&quot; have been used in place of any missing headers..
        /// </summary>
        public static string UseDefaultNameForUnspecifiedHeader {
            get {
                return ResourceManager.GetString("UseDefaultNameForUnspecifiedHeader", resourceCulture);
            }
        }
    }
}