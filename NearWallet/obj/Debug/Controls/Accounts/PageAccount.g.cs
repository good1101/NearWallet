﻿#pragma checksum "..\..\..\..\Controls\Accounts\PageAccount.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "E7CCCA97A22DED77E46AA927216C5DCC45DB0E47"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using NearWallet.Controls;
using NearWallet.Controls.Accounts;
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


namespace NearWallet.Controls.Accounts {
    
    
    /// <summary>
    /// PageAccount
    /// </summary>
    public partial class PageAccount : NearWallet.Controls.PageControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 31 "..\..\..\..\Controls\Accounts\PageAccount.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel sp_content;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\..\Controls\Accounts\PageAccount.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock tb_idAccount;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\..\Controls\Accounts\PageAccount.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid gr_copyIcon;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\..\..\Controls\Accounts\PageAccount.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid gr_copy;
        
        #line default
        #line hidden
        
        
        #line 69 "..\..\..\..\Controls\Accounts\PageAccount.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lb_balansNear;
        
        #line default
        #line hidden
        
        
        #line 71 "..\..\..\..\Controls\Accounts\PageAccount.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lb_smallBalansUsd;
        
        #line default
        #line hidden
        
        
        #line 82 "..\..\..\..\Controls\Accounts\PageAccount.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lb_stakingNear;
        
        #line default
        #line hidden
        
        
        #line 84 "..\..\..\..\Controls\Accounts\PageAccount.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lb_stakingSmallBalansUSD;
        
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
            System.Uri resourceLocater = new System.Uri("/NearWallet;component/controls/accounts/pageaccount.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Controls\Accounts\PageAccount.xaml"
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
            this.sp_content = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 2:
            this.tb_idAccount = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.gr_copyIcon = ((System.Windows.Controls.Grid)(target));
            
            #line 45 "..\..\..\..\Controls\Accounts\PageAccount.xaml"
            this.gr_copyIcon.PreviewMouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.Copy_PreviewMouseLeftButtonUp);
            
            #line default
            #line hidden
            return;
            case 4:
            this.gr_copy = ((System.Windows.Controls.Grid)(target));
            return;
            case 5:
            this.lb_balansNear = ((System.Windows.Controls.Label)(target));
            return;
            case 6:
            this.lb_smallBalansUsd = ((System.Windows.Controls.Label)(target));
            return;
            case 7:
            this.lb_stakingNear = ((System.Windows.Controls.Label)(target));
            return;
            case 8:
            this.lb_stakingSmallBalansUSD = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
