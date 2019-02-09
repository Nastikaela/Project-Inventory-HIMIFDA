Imports MySql.Data.MySqlClient
Imports System.Data.SqlClient
Imports System.Data

Public Class tambahuang
    Dim cmd As MySqlCommand
    Dim rd As MySqlDataReader
    Sub clear()
        txtdebit.Text = ""
        txtcredit.Text = ""
        TextBox1.Text = ""

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If txtcredit.Text = "" Or txtdebit.Text = "" Or TextBox1.Text = "" Then
            MsgBox("DATA BELUM LENGKAP")
        Else
            Dim a, b, c, d As Integer
            a = txtcredit.Text
            b = txtdebit.Text
            c = txtsaldo.Text
            d = (c + b) - a
            Dim Sqltambah As String = "INSERT INTO keuangan(tanggal, debit, credit, saldo, keterangan)values (' " & Format(DateTimePicker1.Value, "yyyy-MM-dd") & " ', ' " & txtdebit.Text & " ',' " & txtcredit.Text & " ',' " & d & " ',' " & TextBox1.Text & " ')"
            cmd = New MySqlCommand(Sqltambah, koneksi)
            cmd.ExecuteNonQuery()
            MsgBox("Data Berhasil Disimpan")
            tes2()
            clear()
            Me.Close()
            menus.Show()

        End If
    End Sub

    Sub tes2()
        cmd = New MySqlCommand("select * from keuangan order by No_ID DESC", koneksi)
        rd = cmd.ExecuteReader
        If rd.Read Then
            txtsaldo.Text = rd("saldo")
        Else
            MsgBox("cek")
        End If
    End Sub
    Private Sub Form8_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        tes2()
    End Sub

End Class