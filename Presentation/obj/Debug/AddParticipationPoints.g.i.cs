﻿#pragma checksum "..\..\AddParticipationPoints.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "DF5F689918124C4004F8BABB4901AD7D79DE72C2"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MahApps.Metro.Controls;
using Presentation;
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


namespace Presentation {
    
    
    /// <summary>
    /// AddParticipationPoints
    /// </summary>
    public partial class AddParticipationPoints : MahApps.Metro.Controls.MetroWindow, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\AddParticipationPoints.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lbl_Name;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\AddParticipationPoints.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lbl_Points;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\AddParticipationPoints.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtbx_Points;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\AddParticipationPoints.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_Confirm;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\AddParticipationPoints.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lbl_Add;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\AddParticipationPoints.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_PlussOne;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\AddParticipationPoints.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_MinusOne;
        
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
            System.Uri resourceLocater = new System.Uri("/GSH Manager;component/addparticipationpoints.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\AddParticipationPoints.xaml"
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
            this.lbl_Name = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            this.lbl_Points = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.txtbx_Points = ((System.Windows.Controls.TextBox)(target));
            
            #line 13 "..\..\AddParticipationPoints.xaml"
            this.txtbx_Points.PreviewKeyDown += new System.Windows.Input.KeyEventHandler(this.txtbx_Points_PreviewKeyDown);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btn_Confirm = ((System.Windows.Controls.Button)(target));
            
            #line 14 "..\..\AddParticipationPoints.xaml"
            this.btn_Confirm.Click += new System.Windows.RoutedEventHandler(this.btn_Confirm_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.lbl_Add = ((System.Windows.Controls.Label)(target));
            return;
            case 6:
            this.btn_PlussOne = ((System.Windows.Controls.Button)(target));
            
            #line 16 "..\..\AddParticipationPoints.xaml"
            this.btn_PlussOne.Click += new System.Windows.RoutedEventHandler(this.btn_PlussOne_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.btn_MinusOne = ((System.Windows.Controls.Button)(target));
            
            #line 17 "..\..\AddParticipationPoints.xaml"
            this.btn_MinusOne.Click += new System.Windows.RoutedEventHandler(this.btn_MinusOne_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
