Imports Microsoft.VisualBasic
Imports System
Imports System.Windows.Forms
#Region "#usings"
Imports DevExpress.XtraRichEdit.API.Native
#End Region ' #usings

Namespace BulletedListExample
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
			richEditControl1.CreateNewDocument()
			AddBulletedListToDocument()
		End Sub
		#Region "#definelist"
		Private Sub AddBulletedListToDocument()
			Dim doc As Document = richEditControl1.Document
			' Define an abstract numbered list and add it to the document.
			DefineAbstractList(doc)
			' Create a numbering list. It is based on a previously defined abstract list with ID = 0.
			doc.NumberingLists.Add(0)
		End Sub
		Private Sub DefineAbstractList(ByVal doc As Document)
			doc.BeginUpdate()
			'Describe the pattern used for bulleted list.
			'Specify parameters used to represent each list level.

			Dim list As AbstractNumberingList = richEditControl1.Document.AbstractNumberingLists.Add()
			list.NumberingType = NumberingType.Bullet

			Dim level As ListLevel = list.Levels(0)
			level.ParagraphProperties.LeftIndent = 150
			level.CharacterProperties.FontName = "Symbol"
			level.DisplayFormatString = New String(ChrW(&H00B7), 1)


			level = list.Levels(1)
			level.ParagraphProperties.LeftIndent = 300
			level.CharacterProperties.FontName = "Symbol"
			level.DisplayFormatString = New String(ChrW(&H006F), 1)


			level = list.Levels(2)
			level.ParagraphProperties.LeftIndent = 450
			level.CharacterProperties.FontName = "Symbol"
			level.DisplayFormatString = New String(ChrW(&H00B7), 1)

			doc.EndUpdate()
		End Sub
			#End Region ' #definelist

		Private Sub comboBoxEdit1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles comboBoxEdit1.SelectedIndexChanged
'			#Region "#setlistlevel"
			' Create a bulleted list item from the selected paragraph. A list pattern with index 0 is used.
			' The list level is specified by selecting an item in a combo box.
			Dim doc As Document = richEditControl1.Document
			If doc.Selection IsNot Nothing Then
				Dim listLevel As Integer = comboBoxEdit1.SelectedIndex
				doc.BeginUpdate()
				Dim paragraphs As ParagraphCollection = doc.GetParagraphs(doc.Selection)
				For Each pgf As Paragraph In paragraphs
					pgf.ListIndex = 0
					pgf.ListLevel = listLevel
				Next pgf
				doc.EndUpdate()
			End If
'			#End Region ' #setlistlevel
		End Sub

		Private Sub btnSimpleBullet_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSimpleBullet.Click
			Dim doc As Document = richEditControl1.Document
			doc.BeginUpdate()
			Dim numberingList As NumberingList = doc.NumberingLists.Add(0)
			Dim listIndex As Integer = numberingList.Index
			' Append list items
			AppendListParagraph(doc, "Level0 Par0", 0, 0, listIndex)
			AppendListParagraph(doc, "Level0 Par1", 1, 0, listIndex)
			AppendListParagraph(doc, "Level0 Par2", 2, 0, listIndex)
			AppendListParagraph(doc, "Level1 Par3", 3, 1, listIndex)
			AppendListParagraph(doc, "Level1 Par4", 4, 1, listIndex)
			AppendListParagraph(doc, "Level2 Par5", 5, 2, listIndex)
			AppendListParagraph(doc, "Level2 Par6", 6, 2, listIndex)
			AppendListParagraph(doc, "Level0 Par7", 7, 0, listIndex)
			AppendListParagraph(doc, "Level1 Par8", 8, 1, listIndex)
			AppendListParagraph(doc, "Level1 Par9", 9, 1, listIndex)
			AppendListParagraph(doc, "Level0 Par10", 10, 0, listIndex)
			doc.AppendParagraph()
			doc.EndUpdate()
		End Sub

		Private Sub AppendListParagraph(ByVal doc As Document, ByVal text As String, ByVal paragraphIndex As Integer, ByVal numberingLevel As Integer, ByVal numberingIndex As Integer)
			doc.AppendText(text)
			doc.AppendParagraph()
			Dim paragraph As Paragraph = doc.Paragraphs(paragraphIndex)
			paragraph.ListIndex = numberingIndex
			paragraph.ListLevel = numberingLevel
		End Sub

	End Class
End Namespace
