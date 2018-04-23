Imports Microsoft.VisualBasic
Imports System
Imports DevExpress.XtraWizard
Imports DevExpress.XtraEditors
Imports DevExpress.XtraNavBar

Namespace DXSample
	Public Class MyWizardControl
		Inherits WizardControl
		Friend navBarControl1 As DevExpress.XtraNavBar.NavBarControl
		Private navBarGroup1 As DevExpress.XtraNavBar.NavBarGroup
		Friend navBarPanel As PanelControl

		Public Sub New()
			MyBase.New()
			InitializeComponent()
		End Sub

		Private disabledItemsVisibility_Renamed As DisabledItemsVisibility = DisabledItemsVisibility.Disabled
		Public Property DisabledItemsVisibility() As DisabledItemsVisibility
			Get
				Return disabledItemsVisibility_Renamed
			End Get
			Set(ByVal value As DisabledItemsVisibility)
				disabledItemsVisibility_Renamed = value
				For Each link As NavBarItemLink In navBarGroup1.ItemLinks
					link.Item.Enabled = True
					link.Visible = True
				Next link
				UpdateLinksStatus()
			End Set
		End Property

		Private Sub InitializeComponent()
			Me.navBarControl1 = New DevExpress.XtraNavBar.NavBarControl()
			Me.navBarGroup1 = New DevExpress.XtraNavBar.NavBarGroup()
			Me.navBarPanel = New PanelControl()
			CType(Me.navBarControl1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' navBarControl1
			' 
			Me.navBarControl1.ContentButtonHint = Nothing
			Me.navBarControl1.Name = "navBarControl1"
			Me.navBarControl1.OptionsNavPane.ExpandedWidth = 140
			Me.navBarControl1.Text = "navBarControl1"
			Me.navBarControl1.Groups.Add(navBarGroup1)
			Me.navBarControl1.AllowSelectedLink = True
			Me.navBarControl1.Dock = System.Windows.Forms.DockStyle.Fill
			CType(ViewInfo, MyWizardViewInfo).UpdateNavBarBounds()
			navBarPanel.Controls.Add(navBarControl1)
			' 
			' navBarGroup1
			' 
			Me.navBarGroup1.Caption = "Steps"
			Me.navBarGroup1.Expanded = True
			Me.navBarGroup1.Name = "navBarGroup1"
			Me.Controls.Add(navBarPanel)
			CType(Me.navBarControl1, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub

		Private Sub UpdateLinks()
			For Each item As NavBarItem In navBarControl1.Items
				RemoveHandler item.LinkClicked, AddressOf Item_LinkClicked
			Next item
			navBarGroup1.ItemLinks.Clear()
			navBarControl1.Items.Clear()
			For Each page As BaseWizardPage In Pages
				navBarGroup1.AddItem()
				navBarGroup1.ItemLinks(navBarGroup1.ItemLinks.Count - 1).Item.Caption = page.Text
				AddHandler navBarGroup1.ItemLinks(navBarGroup1.ItemLinks.Count - 1).Item.LinkClicked, AddressOf Item_LinkClicked
			Next page
			UpdateLinksStatus()
		End Sub

		Private Sub Item_LinkClicked(ByVal sender As Object, ByVal e As NavBarLinkEventArgs)
			SelectedPageIndex = navBarGroup1.ItemLinks.IndexOf(e.Link)
		End Sub

		Private Sub UpdateLinksStatus()
			If SelectedPageIndex < 0 OrElse SelectedPageIndex >= navBarGroup1.ItemLinks.Count Then
				Return
			End If
			navBarControl1.SelectedLink = navBarGroup1.ItemLinks(SelectedPageIndex)
			For i As Integer = 0 To navBarGroup1.ItemLinks.Count - 1
				If i <= SelectedPageIndex Then
					navBarGroup1.ItemLinks(i).Item.Enabled = True
					navBarGroup1.ItemLinks(i).Visible = True
				ElseIf DisabledItemsVisibility = DisabledItemsVisibility.Disabled Then
					navBarGroup1.ItemLinks(i).Item.Enabled = False
				Else
					navBarGroup1.ItemLinks(i).Visible = False
				End If
			Next i
		End Sub

		Protected Overrides Function CreateViewInfo() As WizardViewInfo
			Return New MyWizardViewInfo(Me)
		End Function

		Protected Overrides Sub OnPageAdded(ByVal page As BaseWizardPage)
			MyBase.OnPageAdded(page)
			UpdateLinks()
		End Sub
		Protected Overrides Sub OnPageRemoved(ByVal page As BaseWizardPage)
			MyBase.OnPageRemoved(page)
			UpdateLinks()
		End Sub

		Protected Overrides Sub SetSelectedPageCore(ByVal prevPage As BaseWizardPage, ByVal value As BaseWizardPage, ByVal direction As Direction)
			MyBase.SetSelectedPageCore(prevPage, value, direction)
			UpdateLinksStatus()
		End Sub
	End Class

	Public Enum DisabledItemsVisibility
		Disabled
		Hidden
	End Enum
End Namespace