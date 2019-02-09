Imports MySql.Data.MySqlClient
Imports System.Data.SqlClient
Imports System.Data

Public Class form2
    Dim cmd As MySqlCommand
    Dim rd As MySqlDataReader
    Sub clear()
        TextBox3.Text = ""
        TextBox4.Text = ""

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If TextBox3.Text = "" Or TextBox4.Text = "" Then
            MsgBox("DATA BELUM LENGKAP")
        Else
            Dim d As String
            d = "TERSEDIA"
            Dim Sqltambah As String = "INSERT INTO inventaris(tgl_masuk, nama_brg, jmlh_brg,Tersedia)values (' " & Format(DateTimePicker1.Value, "yyyy-MM-dd") & " ', ' " & TextBox3.Text & " ',' " & TextBox4.Text & " ', ' " & d & " ')"
            cmd = New MySqlCommand(Sqltambah, koneksi)
            cmd.ExecuteNonQuery()
            MsgBox("Data Berhasil Disimpan")
            clear()
            Me.Close()
        End If
    End Sub

    
    Private Sub form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class