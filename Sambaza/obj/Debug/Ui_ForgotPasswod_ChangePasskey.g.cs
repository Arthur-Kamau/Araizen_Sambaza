﻿#pragma checksum "..\..\Ui_ForgotPasswod_ChangePasskey.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2B045948FC0E1F203BC7FC6677AF28A3C0C53A5D"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Sambaza;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace Sambaza {
    
    
    /// <summary>
    /// Ui_ForgotPasswod_ChangePasskey
    /// </summary>
    public partial class Ui_ForgotPasswod_ChangePasskey : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 14 "..\..\Ui_ForgotPasswod_ChangePasskey.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label Status;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\Ui_ForgotPasswod_ChangePasskey.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox Passkey;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\Ui_ForgotPasswod_ChangePasskey.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image IsPasskeyOk;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\Ui_ForgotPasswod_ChangePasskey.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox PasskeyConfirm;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\Ui_ForgotPasswod_ChangePasskey.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image IsConfirmPasskeyOk;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\Ui_ForgotPasswod_ChangePasskey.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Submit;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Sambaza;component/ui_forgotpasswod_changepasskey.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Ui_ForgotPasswod_ChangePasskey.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.Status = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            this.Passkey = ((System.Windows.Controls.PasswordBox)(target));
            
            #line 18 "..\..\Ui_ForgotPasswod_ChangePasskey.xaml"
            this.Passkey.KeyUp += new System.Windows.Input.KeyEventHandler(this.Passkey_KeyUp);
            
            #line default
            #line hidden
            return;
            case 3:
            this.IsPasskeyOk = ((System.Windows.Controls.Image)(target));
            return;
            case 4:
            this.PasskeyConfirm = ((System.Windows.Controls.PasswordBox)(target));
            
            #line 25 "..\..\Ui_ForgotPasswod_ChangePasskey.xaml"
            this.PasskeyConfirm.KeyUp += new System.Windows.Input.KeyEventHandler(this.PasskeyConfirm_KeyUp);
            
            #line default
            #line hidden
            return;
            case 5:
            this.IsConfirmPasskeyOk = ((System.Windows.Controls.Image)(target));
            return;
            case 6:
            this.Submit = ((System.Windows.Controls.Button)(target));
            
            #line 30 "..\..\Ui_ForgotPasswod_ChangePasskey.xaml"
            this.Submit.Click += new System.Windows.RoutedEventHandler(this.Submit_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
