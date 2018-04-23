using DevExpress.XtraWizard;
using System.Drawing;
using DevExpress.XtraNavBar;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace DXSample {
    public class MyWizard97Model : DevExpress.XtraWizard.WizardViewInfo.Wizard97Model {
        public MyWizard97Model(WizardViewInfo viewInfo) : base(viewInfo) { }

        public void UpdateNavBarPosition() {
            Rectangle pageBounds = GetExteriorPageBounds(((MyWizardViewInfo)ViewInfo).Owner.SelectedPage);
            ((MyWizardViewInfo)ViewInfo).NavBarControl.Width = pageBounds.X - 10;
            ((MyWizardViewInfo)ViewInfo).NavBarControl.Dock = DockStyle.Left;
        }

        public override Rectangle GetInteriorPageBounds(BaseWizardPage page) { return GetExteriorPageBounds(page); }
        public override Rectangle GetInteriorHeaderBounds() { 
            Rectangle result = GetExteriorTitleBounds();
            result.X -= 10;
            result.Width += 10;
            return result;
        }
        public override Rectangle GetInteriorHeaderImageBounds() { return GetExteriorHeaderImageBounds(); }
    }

    public class MyWizardViewInfo : WizardViewInfo {
        public MyWizardViewInfo(WizardControl control) : base(control) { }

        internal PanelControl NavBarControl { get { return ((MyWizardControl)Owner).navBarPanel; } }
        protected internal new WizardControl Owner { get { return base.Owner; } }

        public void UpdateNavBarBounds() { ((MyWizard97Model)Model).UpdateNavBarPosition(); }

        protected override WizardModelBase CreateWizardModelCore(WizardStyle style) { return new MyWizard97Model(this); }
    }
}