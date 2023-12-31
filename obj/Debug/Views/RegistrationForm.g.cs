﻿#pragma checksum "..\..\..\Views\RegistrationForm.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "381544377C3091362324579BF6BCD845E6CEC20CB2EA0967C5F285BED840C30A"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
using PsychTestsMilitary.Services;
using PsychTestsMilitary.ViewModels;
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


namespace PsychTestsMilitary.ViewModels {
    
    
    /// <summary>
    /// RegistrationForm
    /// </summary>
    public partial class RegistrationForm : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 39 "..\..\..\Views\RegistrationForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox surname;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\Views\RegistrationForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox name;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\Views\RegistrationForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox fname;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\Views\RegistrationForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox gender;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\..\Views\RegistrationForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox login;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\..\Views\RegistrationForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker birthday;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\..\Views\RegistrationForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox job;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\..\Views\RegistrationForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox spec;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\..\Views\RegistrationForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox rank;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\..\Views\RegistrationForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button registrationButton;
        
        #line default
        #line hidden
        
        
        #line 64 "..\..\..\Views\RegistrationForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button backButton;
        
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
            System.Uri resourceLocater = new System.Uri("/PsychTestsMilitary;component/views/registrationform.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Views\RegistrationForm.xaml"
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
            this.surname = ((System.Windows.Controls.TextBox)(target));
            
            #line 39 "..\..\..\Views\RegistrationForm.xaml"
            this.surname.Loaded += new System.Windows.RoutedEventHandler(this.Loaded);
            
            #line default
            #line hidden
            
            #line 39 "..\..\..\Views\RegistrationForm.xaml"
            this.surname.GotFocus += new System.Windows.RoutedEventHandler(this.FocusOn);
            
            #line default
            #line hidden
            
            #line 39 "..\..\..\Views\RegistrationForm.xaml"
            this.surname.LostFocus += new System.Windows.RoutedEventHandler(this.FocusOff);
            
            #line default
            #line hidden
            return;
            case 2:
            this.name = ((System.Windows.Controls.TextBox)(target));
            
            #line 40 "..\..\..\Views\RegistrationForm.xaml"
            this.name.Loaded += new System.Windows.RoutedEventHandler(this.Loaded);
            
            #line default
            #line hidden
            
            #line 40 "..\..\..\Views\RegistrationForm.xaml"
            this.name.GotFocus += new System.Windows.RoutedEventHandler(this.FocusOn);
            
            #line default
            #line hidden
            
            #line 40 "..\..\..\Views\RegistrationForm.xaml"
            this.name.LostFocus += new System.Windows.RoutedEventHandler(this.FocusOff);
            
            #line default
            #line hidden
            return;
            case 3:
            this.fname = ((System.Windows.Controls.TextBox)(target));
            
            #line 41 "..\..\..\Views\RegistrationForm.xaml"
            this.fname.Loaded += new System.Windows.RoutedEventHandler(this.Loaded);
            
            #line default
            #line hidden
            
            #line 41 "..\..\..\Views\RegistrationForm.xaml"
            this.fname.GotFocus += new System.Windows.RoutedEventHandler(this.FocusOn);
            
            #line default
            #line hidden
            
            #line 41 "..\..\..\Views\RegistrationForm.xaml"
            this.fname.LostFocus += new System.Windows.RoutedEventHandler(this.FocusOff);
            
            #line default
            #line hidden
            return;
            case 4:
            this.gender = ((System.Windows.Controls.ComboBox)(target));
            
            #line 42 "..\..\..\Views\RegistrationForm.xaml"
            this.gender.Loaded += new System.Windows.RoutedEventHandler(this.Loaded);
            
            #line default
            #line hidden
            
            #line 42 "..\..\..\Views\RegistrationForm.xaml"
            this.gender.GotFocus += new System.Windows.RoutedEventHandler(this.FocusOn);
            
            #line default
            #line hidden
            
            #line 42 "..\..\..\Views\RegistrationForm.xaml"
            this.gender.LostFocus += new System.Windows.RoutedEventHandler(this.FocusOff);
            
            #line default
            #line hidden
            return;
            case 5:
            this.login = ((System.Windows.Controls.TextBox)(target));
            
            #line 47 "..\..\..\Views\RegistrationForm.xaml"
            this.login.Loaded += new System.Windows.RoutedEventHandler(this.Loaded);
            
            #line default
            #line hidden
            
            #line 47 "..\..\..\Views\RegistrationForm.xaml"
            this.login.GotFocus += new System.Windows.RoutedEventHandler(this.FocusOn);
            
            #line default
            #line hidden
            
            #line 47 "..\..\..\Views\RegistrationForm.xaml"
            this.login.LostFocus += new System.Windows.RoutedEventHandler(this.FocusOff);
            
            #line default
            #line hidden
            return;
            case 6:
            this.birthday = ((System.Windows.Controls.DatePicker)(target));
            
            #line 48 "..\..\..\Views\RegistrationForm.xaml"
            this.birthday.SelectedDateChanged += new System.EventHandler<System.Windows.Controls.SelectionChangedEventArgs>(this.DataChanged);
            
            #line default
            #line hidden
            return;
            case 7:
            this.job = ((System.Windows.Controls.TextBox)(target));
            
            #line 49 "..\..\..\Views\RegistrationForm.xaml"
            this.job.Loaded += new System.Windows.RoutedEventHandler(this.Loaded);
            
            #line default
            #line hidden
            
            #line 49 "..\..\..\Views\RegistrationForm.xaml"
            this.job.GotFocus += new System.Windows.RoutedEventHandler(this.FocusOn);
            
            #line default
            #line hidden
            
            #line 49 "..\..\..\Views\RegistrationForm.xaml"
            this.job.LostFocus += new System.Windows.RoutedEventHandler(this.FocusOff);
            
            #line default
            #line hidden
            return;
            case 8:
            this.spec = ((System.Windows.Controls.TextBox)(target));
            
            #line 50 "..\..\..\Views\RegistrationForm.xaml"
            this.spec.Loaded += new System.Windows.RoutedEventHandler(this.Loaded);
            
            #line default
            #line hidden
            
            #line 50 "..\..\..\Views\RegistrationForm.xaml"
            this.spec.GotFocus += new System.Windows.RoutedEventHandler(this.FocusOn);
            
            #line default
            #line hidden
            
            #line 50 "..\..\..\Views\RegistrationForm.xaml"
            this.spec.LostFocus += new System.Windows.RoutedEventHandler(this.FocusOff);
            
            #line default
            #line hidden
            return;
            case 9:
            this.rank = ((System.Windows.Controls.TextBox)(target));
            
            #line 51 "..\..\..\Views\RegistrationForm.xaml"
            this.rank.Loaded += new System.Windows.RoutedEventHandler(this.Loaded);
            
            #line default
            #line hidden
            
            #line 51 "..\..\..\Views\RegistrationForm.xaml"
            this.rank.GotFocus += new System.Windows.RoutedEventHandler(this.FocusOn);
            
            #line default
            #line hidden
            
            #line 51 "..\..\..\Views\RegistrationForm.xaml"
            this.rank.LostFocus += new System.Windows.RoutedEventHandler(this.FocusOff);
            
            #line default
            #line hidden
            return;
            case 10:
            this.registrationButton = ((System.Windows.Controls.Button)(target));
            
            #line 52 "..\..\..\Views\RegistrationForm.xaml"
            this.registrationButton.Click += new System.Windows.RoutedEventHandler(this.ButtonClicked);
            
            #line default
            #line hidden
            return;
            case 11:
            this.backButton = ((System.Windows.Controls.Button)(target));
            
            #line 64 "..\..\..\Views\RegistrationForm.xaml"
            this.backButton.Click += new System.Windows.RoutedEventHandler(this.ButtonClicked);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

