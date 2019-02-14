namespace PowerPointAddIn1
{
    partial class Ribbon1 : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public Ribbon1()
            : base(Globals.Factory.GetRibbonFactory())
        {
            InitializeComponent();
        }

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Ribbon1));
            this.tab1 = this.Factory.CreateRibbonTab();
            this.group4 = this.Factory.CreateRibbonGroup();
            this.toggleButton1 = this.Factory.CreateRibbonToggleButton();
            this.group3 = this.Factory.CreateRibbonGroup();
            this.toggleButton4 = this.Factory.CreateRibbonToggleButton();
            this.group5 = this.Factory.CreateRibbonGroup();
            this.editBox2 = this.Factory.CreateRibbonEditBox();
            this.editBox3 = this.Factory.CreateRibbonEditBox();
            this.editBox1 = this.Factory.CreateRibbonEditBox();
            this.editBox4 = this.Factory.CreateRibbonEditBox();
            this.editBox5 = this.Factory.CreateRibbonEditBox();
            this.group1 = this.Factory.CreateRibbonGroup();
            this.toggleButton2 = this.Factory.CreateRibbonToggleButton();
            this.group2 = this.Factory.CreateRibbonGroup();
            this.toggleButton3 = this.Factory.CreateRibbonToggleButton();
            this.group6 = this.Factory.CreateRibbonGroup();
            this.toggleButton5 = this.Factory.CreateRibbonToggleButton();
            this.tab1.SuspendLayout();
            this.group4.SuspendLayout();
            this.group3.SuspendLayout();
            this.group5.SuspendLayout();
            this.group1.SuspendLayout();
            this.group2.SuspendLayout();
            this.group6.SuspendLayout();
            this.SuspendLayout();
            // 
            // tab1
            // 
            this.tab1.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.tab1.Groups.Add(this.group4);
            this.tab1.Groups.Add(this.group3);
            this.tab1.Groups.Add(this.group5);
            this.tab1.Groups.Add(this.group1);
            this.tab1.Groups.Add(this.group2);
            this.tab1.Groups.Add(this.group6);
            this.tab1.Label = "SR+";
            this.tab1.Name = "tab1";
            // 
            // group4
            // 
            this.group4.Items.Add(this.toggleButton1);
            this.group4.Label = "Power";
            this.group4.Name = "group4";
            // 
            // toggleButton1
            // 
            this.toggleButton1.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.toggleButton1.Image = ((System.Drawing.Image)(resources.GetObject("toggleButton1.Image")));
            this.toggleButton1.Label = "OFF";
            this.toggleButton1.Name = "toggleButton1";
            this.toggleButton1.ShowImage = true;
            this.toggleButton1.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.toggleButton1_Click);
            // 
            // group3
            // 
            this.group3.Items.Add(this.toggleButton4);
            this.group3.Label = "Language";
            this.group3.Name = "group3";
            // 
            // toggleButton4
            // 
            this.toggleButton4.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.toggleButton4.Label = "עברית";
            this.toggleButton4.Name = "toggleButton4";
            this.toggleButton4.ShowImage = true;
            this.toggleButton4.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.toggleButton4_Click);
            // 
            // group5
            // 
            this.group5.Items.Add(this.editBox2);
            this.group5.Items.Add(this.editBox3);
            this.group5.Items.Add(this.editBox1);
            this.group5.Items.Add(this.editBox4);
            this.group5.Items.Add(this.editBox5);
            this.group5.Label = "Info";
            this.group5.Name = "group5";
            // 
            // editBox2
            // 
            this.editBox2.Label = "";
            this.editBox2.Name = "editBox2";
            this.editBox2.SizeString = "ZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZ";
            this.editBox2.Text = "פקולטה";
            // 
            // editBox3
            // 
            this.editBox3.Label = "";
            this.editBox3.Name = "editBox3";
            this.editBox3.SizeString = "ZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZ";
            this.editBox3.Text = "מחלקה";
            this.editBox3.TextChanged += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.editBox3_TextChanged);
            // 
            // editBox1
            // 
            this.editBox1.Label = "";
            this.editBox1.Name = "editBox1";
            this.editBox1.SizeString = "ZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZ";
            this.editBox1.Text = "שם הקורס";
            this.editBox1.TextChanged += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.editBox1_TextChanged_1);
            // 
            // editBox4
            // 
            this.editBox4.Label = "";
            this.editBox4.Name = "editBox4";
            this.editBox4.SizeString = "ZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZ";
            this.editBox4.Text = "שנה";
            // 
            // editBox5
            // 
            this.editBox5.Label = "";
            this.editBox5.Name = "editBox5";
            this.editBox5.SizeString = "ZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZ";
            this.editBox5.Text = "סמסטר";
            // 
            // group1
            // 
            this.group1.Items.Add(this.toggleButton2);
            this.group1.Label = "group1";
            this.group1.Name = "group1";
            // 
            // toggleButton2
            // 
            this.toggleButton2.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.toggleButton2.Image = ((System.Drawing.Image)(resources.GetObject("toggleButton2.Image")));
            this.toggleButton2.Label = "toggleButton1";
            this.toggleButton2.Name = "toggleButton2";
            this.toggleButton2.ShowImage = true;
            this.toggleButton2.Visible = false;
            // 
            // group2
            // 
            this.group2.Items.Add(this.toggleButton3);
            this.group2.Label = "group2";
            this.group2.Name = "group2";
            // 
            // toggleButton3
            // 
            this.toggleButton3.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.toggleButton3.Image = ((System.Drawing.Image)(resources.GetObject("toggleButton3.Image")));
            this.toggleButton3.Label = "toggleButton1";
            this.toggleButton3.Name = "toggleButton3";
            this.toggleButton3.ShowImage = true;
            this.toggleButton3.Visible = false;
            // 
            // group6
            // 
            this.group6.Items.Add(this.toggleButton5);
            this.group6.Label = "Save";
            this.group6.Name = "group6";
            // 
            // toggleButton5
            // 
            this.toggleButton5.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.toggleButton5.Image = ((System.Drawing.Image)(resources.GetObject("toggleButton5.Image")));
            this.toggleButton5.Label = "Upload";
            this.toggleButton5.Name = "toggleButton5";
            this.toggleButton5.ShowImage = true;
            this.toggleButton5.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.toggleButton5_Click);
            // 
            // Ribbon1
            // 
            this.Name = "Ribbon1";
            this.RibbonType = "Microsoft.PowerPoint.Presentation";
            this.Tabs.Add(this.tab1);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.Ribbon1_Load);
            this.tab1.ResumeLayout(false);
            this.tab1.PerformLayout();
            this.group4.ResumeLayout(false);
            this.group4.PerformLayout();
            this.group3.ResumeLayout(false);
            this.group3.PerformLayout();
            this.group5.ResumeLayout(false);
            this.group5.PerformLayout();
            this.group1.ResumeLayout(false);
            this.group1.PerformLayout();
            this.group2.ResumeLayout(false);
            this.group2.PerformLayout();
            this.group6.ResumeLayout(false);
            this.group6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab tab1;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group4;
        internal Microsoft.Office.Tools.Ribbon.RibbonToggleButton toggleButton1;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group1;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group2;
        internal Microsoft.Office.Tools.Ribbon.RibbonToggleButton toggleButton2;
        internal Microsoft.Office.Tools.Ribbon.RibbonToggleButton toggleButton3;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group3;
        internal Microsoft.Office.Tools.Ribbon.RibbonToggleButton toggleButton4;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group5;
        internal Microsoft.Office.Tools.Ribbon.RibbonEditBox editBox2;
        internal Microsoft.Office.Tools.Ribbon.RibbonEditBox editBox3;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group6;
        internal Microsoft.Office.Tools.Ribbon.RibbonToggleButton toggleButton5;
        internal Microsoft.Office.Tools.Ribbon.RibbonEditBox editBox1;
        internal Microsoft.Office.Tools.Ribbon.RibbonEditBox editBox4;
        internal Microsoft.Office.Tools.Ribbon.RibbonEditBox editBox5;
    }

    partial class ThisRibbonCollection
    {
        internal Ribbon1 Ribbon1
        {
            get { return this.GetRibbon<Ribbon1>(); }
        }
    }
}
