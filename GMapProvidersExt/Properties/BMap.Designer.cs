﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace GMapProvidersExt.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "12.0.0.0")]
    internal sealed partial class BMap : global::System.Configuration.ApplicationSettingsBase {
        
        private static BMap defaultInstance = ((BMap)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new BMap())));
        
        public static BMap Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("TMzlZXetCzK9t9fSdKO7v35T")]
        public string ServiceAK {
            get {
                return ((string)(this["ServiceAK"]));
            }
            set {
                this["ServiceAK"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string ServiceSK {
            get {
                return ((string)(this["ServiceSK"]));
            }
            set {
                this["ServiceSK"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("0")]
        public int VerificationMode {
            get {
                return ((int)(this["VerificationMode"]));
            }
            set {
                this["VerificationMode"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("0")]
        public string LoadMapMode {
            get {
                return ((string)(this["LoadMapMode"]));
            }
            set {
                this["LoadMapMode"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("E:\\")]
        public string MapCachePath {
            get {
                return ((string)(this["MapCachePath"]));
            }
            set {
                this["MapCachePath"] = value;
            }
        }
    }
}
