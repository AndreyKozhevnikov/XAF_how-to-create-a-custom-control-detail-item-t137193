﻿using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Layout;
using DevExpress.ExpressApp.Web;
using DevExpress.Web;
using MySolution.Module.BusinessObjects;
using System;

namespace MySolution.Module.Web.Controllers {
    public class ControlDetailItemControllerWeb : ObjectViewController<DetailView, Contact>
    {
        protected override void OnActivated() {
            base.OnActivated();
            ControlViewItem item = ((DetailView)View).FindItem("MyButton") as ControlViewItem;
            if (item != null) {
                item.ControlCreated += item_ControlCreated;
            }
        }
        private void item_ControlCreated(object sender, EventArgs e) {
            ASPxButton button = ((ControlViewItem)sender).Control as ASPxButton;
            if (button == null) return;
            button.ID = "MyButton";
            button.Text = "Click me!";
            button.Click += ButtonClickHandlingWebController_Click;
        }

        void ButtonClickHandlingWebController_Click(object sender, EventArgs e) {
            WebWindow.CurrentRequestWindow.RegisterClientScript("ShowAlert", @"alert('Action from custom View Item was executed!');");
        }
    }
}