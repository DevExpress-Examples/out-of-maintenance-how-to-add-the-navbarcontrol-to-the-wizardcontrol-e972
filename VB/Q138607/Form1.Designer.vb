Imports Microsoft.VisualBasic
Imports System
Namespace Q138607
	Partial Public Class Form1
		''' <summary>
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

		''' <summary>
		''' Clean up any resources being used.
		''' </summary>
		''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing AndAlso (components IsNot Nothing) Then
				components.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Windows Form Designer generated code"

		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.myWizardControl1 = New DXSample.MyWizardControl()
			Me.welcomeWizardPage1 = New DevExpress.XtraWizard.WelcomeWizardPage()
			Me.completionWizardPage1 = New DevExpress.XtraWizard.CompletionWizardPage()
			Me.wizardPage3 = New DevExpress.XtraWizard.WizardPage()
			CType(Me.myWizardControl1, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.myWizardControl1.SuspendLayout()
			Me.SuspendLayout()
			' 
			' myWizardControl1
			' 
			Me.myWizardControl1.CancelButtonCausesValidation = False
			Me.myWizardControl1.Controls.Add(Me.welcomeWizardPage1)
			Me.myWizardControl1.Controls.Add(Me.completionWizardPage1)
			Me.myWizardControl1.Controls.Add(Me.wizardPage3)
			Me.myWizardControl1.DisabledItemsVisibility = DXSample.DisabledItemsVisibility.Disabled
			Me.myWizardControl1.HelpButtonCausesValidation = False
			Me.myWizardControl1.Name = "myWizardControl1"
			Me.myWizardControl1.Pages.AddRange(New DevExpress.XtraWizard.BaseWizardPage() { Me.welcomeWizardPage1, Me.wizardPage3, Me.completionWizardPage1})
			Me.myWizardControl1.PreviousButtonCausesValidation = False
			' 
			' welcomeWizardPage1
			' 
			Me.welcomeWizardPage1.Name = "welcomeWizardPage1"
			Me.welcomeWizardPage1.Size = New System.Drawing.Size(588, 288)
			' 
			' completionWizardPage1
			' 
			Me.completionWizardPage1.Name = "completionWizardPage1"
			Me.completionWizardPage1.Size = New System.Drawing.Size(588, 288)
			' 
			' wizardPage3
			' 
			Me.wizardPage3.Name = "wizardPage3"
			Me.wizardPage3.Size = New System.Drawing.Size(588, 288)
			' 
			' Form1
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(805, 421)
			Me.Controls.Add(Me.myWizardControl1)
			Me.Name = "Form1"
			Me.Text = "Form1"
			CType(Me.myWizardControl1, System.ComponentModel.ISupportInitialize).EndInit()
			Me.myWizardControl1.ResumeLayout(False)
			Me.ResumeLayout(False)

		End Sub

		#End Region

		Private myWizardControl1 As DXSample.MyWizardControl
		Private welcomeWizardPage1 As DevExpress.XtraWizard.WelcomeWizardPage
		Private completionWizardPage1 As DevExpress.XtraWizard.CompletionWizardPage
		Private wizardPage3 As DevExpress.XtraWizard.WizardPage

	End Class
End Namespace

