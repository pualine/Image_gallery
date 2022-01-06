Imports System.IO

Public Class Form1
    Private folderPath As String
    Private pics() As PictureBox

    Private Sub FlowPanel_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles FlowPanel.Paint

    End Sub


    Private Sub OpenFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenFile.Click
        FolderBrowser.SelectedPath = Directory.GetCurrentDirectory
        If FolderBrowser.ShowDialog() = DialogResult.Cancel Then
            Return
        End If
        folderPath = FolderBrowser.SelectedPath()

        Dim fileNames As String() = Directory.GetFiles(folderPath)
        If fileNames.Length = 0 Then
            MessageBox.Show("Unable to fined image files!")
        End If

        Me.Text = folderPath
        ReDim pics(fileNames.Length - 1)

        For i As Integer = 0 To fileNames.Length - 1
            pics(i) = New PictureBox()
            With pics(i)
                .Size = New System.Drawing.Size(300, 200)
                .SizeMode = PictureBoxSizeMode.Zoom
                .Image = New Bitmap(fileNames(i))
                FlowPanel.Controls.Add(pics(i))
            End With
        Next
    End Sub
End Class
