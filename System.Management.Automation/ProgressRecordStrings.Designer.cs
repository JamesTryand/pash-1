﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.17929
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace System.Management.Automation {
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
    public class ProgressRecordStrings {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal ProgressRecordStrings() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("System.Management.Automation.ProgressRecordStrings", typeof(ProgressRecordStrings).Assembly);
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
        ///   Looks up a localized string similar to Cannot process the argument because {0} may not be a negative value..
        /// </summary>
        public static string ArgMayNotBeNegative {
            get {
                return ResourceManager.GetString("ArgMayNotBeNegative", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Cannot process the argument because {0} may not be null or an empty string value..
        /// </summary>
        public static string ArgMayNotBeNullOrEmpty {
            get {
                return ResourceManager.GetString("ArgMayNotBeNullOrEmpty", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to ParentActivityId cannot be the same as the ActivityId..
        /// </summary>
        public static string ParentActivityIdCantBeActivityId {
            get {
                return ResourceManager.GetString("ParentActivityIdCantBeActivityId", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Cannot set percent because {0} cannot be greater than 100..
        /// </summary>
        public static string PercentMayNotBeMoreThan100 {
            get {
                return ResourceManager.GetString("PercentMayNotBeMoreThan100", resourceCulture);
            }
        }
    }
}
