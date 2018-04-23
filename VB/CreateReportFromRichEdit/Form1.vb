Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Imports System.IO
Imports DevExpress.XtraRichEdit
Imports DevExpress.XtraReports.UI
Imports DevExpress.XtraRichEdit.API.Native

Namespace CreateReportFromRichEdit
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub simpleButton1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles simpleButton1.Click
			OpenDocumentAndShowReport()
		End Sub

		Private Sub OpenDocumentAndShowReport()
			Dim openFileDialog1 As New OpenFileDialog()

			openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*"
			openFileDialog1.FilterIndex = 2
			openFileDialog1.RestoreDirectory = True

			If openFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
				Try
					If openFileDialog1.OpenFile() IsNot Nothing Then
						Using reds As New RichEditDocumentServer()
							reds.LoadDocument(openFileDialog1.FileName)

							Using report As New XtraReport1()
								report.RichText.Rtf = reds.RtfText
								report.ShowPreviewDialog()
							End Using
						End Using
					End If
				Catch ex As Exception
					MessageBox.Show("Error: Could not read file from disk. Original error: " & ex.Message)
				End Try
			End If

		End Sub
	End Class
End Namespace
