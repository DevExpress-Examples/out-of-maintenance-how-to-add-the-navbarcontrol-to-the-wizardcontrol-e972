Imports Microsoft.VisualBasic
Imports DevExpress.XtraWizard
Imports System.Drawing
Imports DevExpress.XtraNavBar
Imports System.Windows.Forms
Imports DevExpress.XtraEditors

Namespace DXSample
	Public Class MyWizard97Model
		Inherits DevExpress.XtraWizard.WizardViewInfo.Wizard97Model
		Public Sub New(ByVal viewInfo As WizardViewInfo)
			MyBase.New(viewInfo)
		End Sub

		Public Sub UpdateNavBarPosition()
			Dim pageBounds As Rectangle = GetExteriorPageBounds((CType(ViewInfo, MyWizardViewInfo)).Owner.SelectedPage)
			CType(ViewInfo, MyWizardViewInfo).NavBarControl.Width = pageBounds.X - 10
			CType(ViewInfo, MyWizardViewInfo).NavBarControl.Dock = DockStyle.Left
		End Sub

		Public Overrides Function GetInteriorPageBounds(ByVal page As BaseWizardPage) As Rectangle
			Return GetExteriorPageBounds(page)
		End Function
		Public Overrides Function GetInteriorHeaderBounds() As Rectangle
			Dim result As Rectangle = GetExteriorTitleBounds()
			result.X -= 10
			result.Width += 10
			Return result
		End Function
		Public Overrides Function GetInteriorHeaderImageBounds() As Rectangle
			Return GetExteriorHeaderImageBounds()
		End Function
	End Class

	Public Class MyWizardViewInfo
		Inherits WizardViewInfo
		Public Sub New(ByVal control As WizardControl)
			MyBase.New(control)
		End Sub

		Friend ReadOnly Property NavBarControl() As PanelControl
			Get
				Return (CType(Owner, MyWizardControl)).navBarPanel
			End Get
		End Property
		Protected Friend Shadows ReadOnly Property Owner() As WizardControl
			Get
				Return MyBase.Owner
			End Get
		End Property

		Public Sub UpdateNavBarBounds()
			CType(Model, MyWizard97Model).UpdateNavBarPosition()
		End Sub

		Protected Overrides Function CreateWizardModelCore(ByVal style As WizardStyle) As WizardModelBase
			Return New MyWizard97Model(Me)
		End Function
	End Class
End Namespace