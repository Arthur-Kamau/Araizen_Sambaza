﻿#pragma checksum "..\..\Ui_Register.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "796D19E94269B1434B901CEA6240FCFB75F3C5B2"
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
    /// Ui_Register
    /// </summary>
    public partial class Ui_Register : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\Ui_Register.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label Status;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\Ui_Register.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox name;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\Ui_Register.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image IsNameOk;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\Ui_Register.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox email;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\Ui_Register.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image IsemailOk;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\Ui_Register.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox mypassword;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\Ui_Register.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image IspasswordOk;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\Ui_Register.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox mypasswordconfirm;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\Ui_Register.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image IsConfirmPasswordOk;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\Ui_Register.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button submit;
        
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
            System.Uri resourceLocater = new System.Uri("/Sambaza;component/ui_register.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Ui_Register.xaml"
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
            this.name = ((System.Windows.Controls.TextBox)(target));
            
            #line 15 "..\..\Ui_Register.xaml"
            this.name.KeyUp += new System.Windows.Input.KeyEventHandler(this.name_KeyUp);
            
            #line default
            #line hidden
            return;
            case 3:
            this.IsNameOk = ((System.Windows.Controls.Image)(target));
            return;
            case 4:
            this.email = ((System.Windows.Controls.TextBox)(target));
            
            #line 20 "..\..\Ui_Register.xaml"
            this.email.KeyUp += new System.Windows.Input.KeyEventHandler(this.email_KeyUp);
            
            #line default
            #line hidden
            return;
            case 5:
            this.IsemailOk = ((System.Windows.Controls.Image)(target));
            return;
            case 6:
            this.mypassword = ((System.Windows.Controls.PasswordBox)(target));
            
            #line 25 "..\..\Ui_Register.xaml"
            this.mypassword.KeyUp += new System.Windows.Input.KeyEventHandler(this.password_KeyUp);
            
            #line default
            #line hidden
            return;
            case 7:
            this.IspasswordOk = ((System.Windows.Controls.Image)(target));
            return;
            case 8:
            this.mypasswordconfirm = ((System.Windows.Controls.PasswordBox)(target));
            
            #line 30 "..\..\Ui_Register.xaml"
            this.mypasswordconfirm.KeyUp += new System.Windows.Input.KeyEventHandler(this.mypasswordconfirm_KeyUp);
            
            #line default
            #line hidden
            return;
            case 9:
            this.IsConfirmPasswordOk = ((System.Windows.Controls.Image)(target));
            return;
            case 10:
            this.submit = ((System.Windows.Controls.Button)(target));
            
            #line 33 "..\..\Ui_Register.xaml"
            this.submit.Click += new System.Windows.RoutedEventHandler(this.submit_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

