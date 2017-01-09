﻿#pragma checksum "C:\Users\danie\documents\visual studio 2017\Projects\FlashCards\FlashCards\CreateFlashCard.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "B45CE0DA666C31785883662DAF26E22E"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FlashCards
{
    partial class CreateFlashCard : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        private static class XamlBindingSetters
        {
            public static void Set_Windows_UI_Xaml_Controls_InkToolbar_TargetInkCanvas(global::Windows.UI.Xaml.Controls.InkToolbar obj, global::Windows.UI.Xaml.Controls.InkCanvas value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = (global::Windows.UI.Xaml.Controls.InkCanvas) global::Windows.UI.Xaml.Markup.XamlBindingHelper.ConvertValue(typeof(global::Windows.UI.Xaml.Controls.InkCanvas), targetNullValue);
                }
                obj.TargetInkCanvas = value;
            }
        };

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        private class CreateFlashCard_obj1_Bindings :
            global::Windows.UI.Xaml.Markup.IComponentConnector,
            ICreateFlashCard_Bindings
        {
            private global::FlashCards.CreateFlashCard dataRoot;
            private bool initialized = false;
            private const int NOT_PHASED = (1 << 31);
            private const int DATA_CHANGED = (1 << 30);

            // Fields for each control that has bindings.
            private global::Windows.UI.Xaml.Controls.InkToolbar obj8;

            public CreateFlashCard_obj1_Bindings()
            {
            }

            // IComponentConnector

            public void Connect(int connectionId, global::System.Object target)
            {
                switch(connectionId)
                {
                    case 8:
                        this.obj8 = (global::Windows.UI.Xaml.Controls.InkToolbar)target;
                        break;
                    default:
                        break;
                }
            }

            // ICreateFlashCard_Bindings

            public void Initialize()
            {
                if (!this.initialized)
                {
                    this.Update();
                }
            }
            
            public void Update()
            {
                this.Update_(this.dataRoot, NOT_PHASED);
                this.initialized = true;
            }

            public void StopTracking()
            {
            }

            public bool SetDataRoot(global::System.Object newDataRoot)
            {
                if (newDataRoot != null)
                {
                    this.dataRoot = (global::FlashCards.CreateFlashCard)newDataRoot;
                    return true;
                }
                return false;
            }

            public void Loading(global::Windows.UI.Xaml.FrameworkElement src, object data)
            {
                this.Initialize();
            }

            // Update methods for each path node used in binding steps.
            private void Update_(global::FlashCards.CreateFlashCard obj, int phase)
            {
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | (1 << 0))) != 0)
                    {
                        this.Update_inkCanvas(obj.inkCanvas, phase);
                    }
                }
            }
            private void Update_inkCanvas(global::Windows.UI.Xaml.Controls.InkCanvas obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    XamlBindingSetters.Set_Windows_UI_Xaml_Controls_InkToolbar_TargetInkCanvas(this.obj8, obj, null);
                }
            }
        }
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                {
                    global::Windows.UI.Xaml.Controls.Page element1 = (global::Windows.UI.Xaml.Controls.Page)(target);
                    #line 6 "..\..\..\CreateFlashCard.xaml"
                    ((global::Windows.UI.Xaml.Controls.Page)element1).SizeChanged += this.OnSizeChange;
                    #line default
                }
                break;
            case 2:
                {
                    this.RootGrid = (global::Windows.UI.Xaml.Controls.Grid)(target);
                }
                break;
            case 3:
                {
                    this.BackButton = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    #line 87 "..\..\..\CreateFlashCard.xaml"
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)this.BackButton).Click += this.GetPreviousCard;
                    #line default
                }
                break;
            case 4:
                {
                    this.ForwardButton = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    #line 88 "..\..\..\CreateFlashCard.xaml"
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)this.ForwardButton).Click += this.GetNextCard;
                    #line default
                }
                break;
            case 5:
                {
                    this.AddButton = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    #line 92 "..\..\..\CreateFlashCard.xaml"
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)this.AddButton).Click += this.AddToDeck;
                    #line default
                }
                break;
            case 6:
                {
                    this.CardNumber = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 7:
                {
                    this.CardTotal = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 8:
                {
                    this.inkToolbar = (global::Windows.UI.Xaml.Controls.InkToolbar)(target);
                }
                break;
            case 9:
                {
                    this.backBorder = (global::Windows.UI.Xaml.Controls.Border)(target);
                }
                break;
            case 10:
                {
                    this.backGrid = (global::Windows.UI.Xaml.Controls.Grid)(target);
                }
                break;
            case 11:
                {
                    this.inkCanvas2 = (global::Windows.UI.Xaml.Controls.InkCanvas)(target);
                }
                break;
            case 12:
                {
                    this.frontBorder = (global::Windows.UI.Xaml.Controls.Border)(target);
                }
                break;
            case 13:
                {
                    this.frontGrid = (global::Windows.UI.Xaml.Controls.Grid)(target);
                }
                break;
            case 14:
                {
                    this.inkCanvas = (global::Windows.UI.Xaml.Controls.InkCanvas)(target);
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            switch(connectionId)
            {
            case 1:
                {
                    global::Windows.UI.Xaml.Controls.Page element1 = (global::Windows.UI.Xaml.Controls.Page)target;
                    CreateFlashCard_obj1_Bindings bindings = new CreateFlashCard_obj1_Bindings();
                    returnValue = bindings;
                    bindings.SetDataRoot(this);
                    this.Bindings = bindings;
                    element1.Loading += bindings.Loading;
                }
                break;
            }
            return returnValue;
        }
    }
}

