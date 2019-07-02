// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Office.Interop.Outlook;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace WinformsControlsTest
{
    public partial class ComboBoxes : Form
    {
        public ComboBoxes()
        {
            InitializeComponent();
        }

        protected override void OnShown(EventArgs e)
        {
            var accounts = new List<Account>();
            var accountNames = new List<string>();
            Outlook.Application outlook = new Outlook.Application();
            foreach (Account account in outlook.Session.Accounts)
            {
                accounts.Add(account);
                accountNames.Add(account.DisplayName);
            }

            comboBox1.DataSource = accountNames;

            comboBox2.DataSource = accounts;
            comboBox2.DisplayMember = "DisplayName";

            base.OnShown(e);
        }
    }
}
