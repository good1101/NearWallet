#pragma checksum "..\..\..\..\Controls\Wallet\PageSend.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "C82B3AD15BB7B59478B60D0F2C7848F2F6FB224C"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using MahApps.Metro.Controls;
using NearWallet.Controls;
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
    /// PageSend
    /// </summary>
    public partial class PageSend : NearWallet.Controls.PageControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 9 "..\..\..\..\Controls\Wallet\PageSend.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid grid;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\..\..\Controls\Wallet\PageSend.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tb_accountID;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\..\Controls\Wallet\PageSend.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tb_amount;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\..\Controls\Wallet\PageSend.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lb_usd;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\..\Controls\Wallet\PageSend.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lb_balans;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\..\..\Controls\Wallet\PageSend.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button bt_send;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\..\..\Controls\Wallet\PageSend.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button bt_back;
        
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
            System.Uri resourceLocater = new System.Uri("/NearWallet;component/controls/wallet/pagesend.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Controls\Wallet\PageSend.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal System.Delegate _CreateDelegate(System.Type delegateType, string handler) {
            return System.Delegate.CreateDelegate(delegateType, this, handler);
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
            this.grid = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.tb_accountID = ((System.Windows.Controls.TextBox)(target));
            
            #line 22 "..\..\..\..\Controls\Wallet\PageSend.xaml"
            this.tb_accountID.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.Tb_accountID_TextChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.tb_amount = ((System.Windows.Controls.TextBox)(target));
            
            #line 35 "..\..\..\..\Controls\Wallet\PageSend.xaml"
            this.tb_amount.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.Tb_amount_TextChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.lb_usd = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.lb_balans = ((System.Windows.Controls.Label)(target));
            return;
            case 6:
            this.bt_send = ((System.Windows.Controls.Button)(target));
            
            #line 48 "..\..\..\..\Controls\Wallet\PageSend.xaml"
            this.bt_send.Click += new System.Windows.RoutedEventHandler(this.Bt_send_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.bt_back = ((System.Windows.Controls.Button)(target));
            
            #line 50 "..\..\..\..\Controls\Wallet\PageSend.xaml"
            this.bt_back.Click += new System.Windows.RoutedEventHandler(this.Bt_back_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

