﻿#pragma checksum "..\..\..\..\MVVM\View\AddModuleView.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "392B3B80893B477BAAE8794515C021A37744CD680B1E57ABD3E5043E6B787E91"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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
using TMA.MVVM.View;
using TMA.MVVM.ViewModel;


namespace TMA.MVVM.View {
    
    
    /// <summary>
    /// AddModuleView
    /// </summary>
    public partial class AddModuleView : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 32 "..\..\..\..\MVVM\View\AddModuleView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtModuleCode;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\..\MVVM\View\AddModuleView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtModuleName;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\..\..\MVVM\View\AddModuleView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtModuleCredits;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\..\..\MVVM\View\AddModuleView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtClassHours;
        
        #line default
        #line hidden
        
        
        #line 67 "..\..\..\..\MVVM\View\AddModuleView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtClassHours_Copy;
        
        #line default
        #line hidden
        
        
        #line 70 "..\..\..\..\MVVM\View\AddModuleView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAddMod;
        
        #line default
        #line hidden
        
        
        #line 89 "..\..\..\..\MVVM\View\AddModuleView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtCurrentMod;
        
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
            System.Uri resourceLocater = new System.Uri("/TMA;component/mvvm/view/addmoduleview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\MVVM\View\AddModuleView.xaml"
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
            this.txtModuleCode = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.txtModuleName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.txtModuleCredits = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.txtClassHours = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.txtClassHours_Copy = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.btnAddMod = ((System.Windows.Controls.Button)(target));
            
            #line 75 "..\..\..\..\MVVM\View\AddModuleView.xaml"
            this.btnAddMod.Click += new System.Windows.RoutedEventHandler(this.btnAddMod_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.txtCurrentMod = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
