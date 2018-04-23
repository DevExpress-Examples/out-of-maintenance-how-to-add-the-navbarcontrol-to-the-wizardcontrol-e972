using DevExpress.XtraWizard;
using DevExpress.XtraEditors;
using DevExpress.XtraNavBar;

namespace DXSample {
    public class MyWizardControl :WizardControl {
        internal DevExpress.XtraNavBar.NavBarControl navBarControl1;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroup1;
        internal PanelControl navBarPanel;

        public MyWizardControl() : base() {
            InitializeComponent();            
        }

        private DisabledItemsVisibility disabledItemsVisibility = DisabledItemsVisibility.Disabled;
        public DisabledItemsVisibility DisabledItemsVisibility {
            get { return disabledItemsVisibility; }
            set { 
                disabledItemsVisibility = value;
                foreach (NavBarItemLink link in navBarGroup1.ItemLinks) {
                    link.Item.Enabled = true;
                    link.Visible = true;
                }
                UpdateLinksStatus();
            }
        }

        private void InitializeComponent() {
            this.navBarControl1 = new DevExpress.XtraNavBar.NavBarControl();
            this.navBarGroup1 = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarPanel = new PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // navBarControl1
            // 
            this.navBarControl1.ContentButtonHint = null;
            this.navBarControl1.Name = "navBarControl1";
            this.navBarControl1.OptionsNavPane.ExpandedWidth = 140;
            this.navBarControl1.Text = "navBarControl1";
            this.navBarControl1.Groups.Add(navBarGroup1);
            this.navBarControl1.AllowSelectedLink = true;
            this.navBarControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            ((MyWizardViewInfo)ViewInfo).UpdateNavBarBounds();
            navBarPanel.Controls.Add(navBarControl1);
            // 
            // navBarGroup1
            // 
            this.navBarGroup1.Caption = "Steps";
            this.navBarGroup1.Expanded = true;
            this.navBarGroup1.Name = "navBarGroup1";
            this.Controls.Add(navBarPanel);
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        private void UpdateLinks() {
            foreach (NavBarItem item in navBarControl1.Items)
                item.LinkClicked -= new NavBarLinkEventHandler(Item_LinkClicked);
            navBarGroup1.ItemLinks.Clear();
            navBarControl1.Items.Clear();
            foreach (BaseWizardPage page in Pages) {
                navBarGroup1.AddItem();
                navBarGroup1.ItemLinks[navBarGroup1.ItemLinks.Count - 1].Item.Caption = page.Text;
                navBarGroup1.ItemLinks[navBarGroup1.ItemLinks.Count - 1].Item.LinkClicked += new NavBarLinkEventHandler(Item_LinkClicked);
            }
            UpdateLinksStatus();
        }

        void Item_LinkClicked(object sender, NavBarLinkEventArgs e) {
            SelectedPageIndex = navBarGroup1.ItemLinks.IndexOf(e.Link);
        }

        private void UpdateLinksStatus() {
            if (SelectedPageIndex < 0 || SelectedPageIndex >= navBarGroup1.ItemLinks.Count) return;
            navBarControl1.SelectedLink = navBarGroup1.ItemLinks[SelectedPageIndex];
            for (int i = 0; i < navBarGroup1.ItemLinks.Count; i++)
                if (i <= SelectedPageIndex) {
                    navBarGroup1.ItemLinks[i].Item.Enabled = true;
                    navBarGroup1.ItemLinks[i].Visible = true;
                } else if (DisabledItemsVisibility == DisabledItemsVisibility.Disabled) navBarGroup1.ItemLinks[i].Item.Enabled = false;
                else navBarGroup1.ItemLinks[i].Visible = false;
        }

        protected override WizardViewInfo CreateViewInfo() { return new MyWizardViewInfo(this); }

        protected override void OnPageAdded(BaseWizardPage page) {
            base.OnPageAdded(page);
            UpdateLinks(); 
        }
        protected override void OnPageRemoved(BaseWizardPage page) {
            base.OnPageRemoved(page);
            UpdateLinks();
        }

        protected override void SetSelectedPageCore(BaseWizardPage prevPage, BaseWizardPage value, Direction direction) {
            base.SetSelectedPageCore(prevPage, value, direction);
            UpdateLinksStatus();
        }
    }

    public enum DisabledItemsVisibility {
        Disabled,
        Hidden
    }
}