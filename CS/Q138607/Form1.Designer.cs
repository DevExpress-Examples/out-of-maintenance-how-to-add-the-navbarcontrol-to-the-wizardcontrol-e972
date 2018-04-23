namespace Q138607 {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.myWizardControl1 = new DXSample.MyWizardControl();
            this.welcomeWizardPage1 = new DevExpress.XtraWizard.WelcomeWizardPage();
            this.completionWizardPage1 = new DevExpress.XtraWizard.CompletionWizardPage();
            this.wizardPage3 = new DevExpress.XtraWizard.WizardPage();
            ((System.ComponentModel.ISupportInitialize)(this.myWizardControl1)).BeginInit();
            this.myWizardControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // myWizardControl1
            // 
            this.myWizardControl1.CancelButtonCausesValidation = false;
            this.myWizardControl1.Controls.Add(this.welcomeWizardPage1);
            this.myWizardControl1.Controls.Add(this.completionWizardPage1);
            this.myWizardControl1.Controls.Add(this.wizardPage3);
            this.myWizardControl1.DisabledItemsVisibility = DXSample.DisabledItemsVisibility.Disabled;
            this.myWizardControl1.HelpButtonCausesValidation = false;
            this.myWizardControl1.Name = "myWizardControl1";
            this.myWizardControl1.Pages.AddRange(new DevExpress.XtraWizard.BaseWizardPage[] {
            this.welcomeWizardPage1,
            this.wizardPage3,
            this.completionWizardPage1});
            this.myWizardControl1.PreviousButtonCausesValidation = false;
            // 
            // welcomeWizardPage1
            // 
            this.welcomeWizardPage1.Name = "welcomeWizardPage1";
            this.welcomeWizardPage1.Size = new System.Drawing.Size(588, 288);
            // 
            // completionWizardPage1
            // 
            this.completionWizardPage1.Name = "completionWizardPage1";
            this.completionWizardPage1.Size = new System.Drawing.Size(588, 288);
            // 
            // wizardPage3
            // 
            this.wizardPage3.Name = "wizardPage3";
            this.wizardPage3.Size = new System.Drawing.Size(588, 288);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(805, 421);
            this.Controls.Add(this.myWizardControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.myWizardControl1)).EndInit();
            this.myWizardControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DXSample.MyWizardControl myWizardControl1;
        private DevExpress.XtraWizard.WelcomeWizardPage welcomeWizardPage1;
        private DevExpress.XtraWizard.CompletionWizardPage completionWizardPage1;
        private DevExpress.XtraWizard.WizardPage wizardPage3;

    }
}

