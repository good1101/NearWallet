﻿#pragma checksum "..\..\..\..\Controls\Wallet\PageResultSending.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "30824D012ECDF745D3451B6F62325E80D26DB4E2"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using NearWallet.Controls.Wallet;
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


namespace NearWallet.Controls.Wallet {
    
    
    /// <summary>
    /// PageResultSending
    /// </summary>
    public partial class PageResultSending : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\..\..\Controls\Wallet\PageResultSending.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lb_result;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\..\Controls\Wallet\PageResultSending.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Documents.Run rn_amount;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\..\Controls\Wallet\PageResultSending.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Documents.Run rn_price;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\..\Controls\Wallet\PageResultSending.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Documents.Run rn_toId;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\..\Controls\Wallet\PageResultSending.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button bt_continue;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\..\Controls\Wallet\PageResultSending.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button bt_view;
        
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
            System.Uri resourceLocater = new System.Uri("/NearWallet;component/controls/wallet/pageresultsending.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Controls\Wallet\PageResultSending.xaml"
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
            
            #line 7 "..\..\..\..\Controls\Wallet\PageResultSending.xaml"
            ((NearWallet.Controls.Wallet.PageResultSending)(target)).IsVisibleChanged += new System.Windows.DependencyPropertyChangedEventHandler(this.UserControl_IsVisibleChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.lb_result = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.rn_amount = ((System.Windows.Documents.Run)(target));
            return;
            case 4:
            this.rn_price = ((System.Windows.Documents.Run)(target));
            return;
            case 5:
            this.rn_toId = ((System.Windows.Documents.Run)(target));
            return;
            case 6:
            this.bt_continue = ((System.Windows.Controls.Button)(target));
            
            #line 23 "..\..\..\..\Controls\Wallet\PageResultSending.xaml"
            this.bt_continue.Click += new System.Windows.RoutedEventHandler(this.Bt_continue_Click_1);
            
            #line default
            #line hidden
            return;
            case 7:
            this.bt_view = ((System.Windows.Controls.Button)(target));
            
            #line 25 "..\..\..\..\Controls\Wallet\PageResultSending.xaml"
            this.bt_view.Click += new System.Windows.RoutedEventHandler(this.Bt_view_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
