Imports MySql.Data.MySqlClient
Imports System.Data.SqlClient
Imports System.Data

Public Class edituang
    Dim cmd As MySqlCommand
    Dim rd As MySqlDataReader
    Sub clear()
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox1.Text = ""
        TextBox2.Text = ""

    End Sub

    Sub atur()
        Me.DataGridView1.Columns(0).HeaderText = "NO ID"
        Me.DataGridView1.Columns(1).HeaderText = "TANGGAL "
        Me.DataGridView1.Columns(2).HeaderText = "DEBIT"
        Me.DataGridView1.Columns(3).HeaderText = "CREDIT"
        Me.DataGridView1.Columns(4).HeaderText = "SALDO"
        Me.DataGridView1.Columns(5).HeaderText = "KETERANGAN"
        Me.DataGridView1.Columns(0).Width = 100
        Me.DataGridView1.Columns(1).Width = 100
        Me.DataGridView1.Columns(2).Width = 100
        Me.DataGridView1.Columns(3).Width = 100
        Me.DataGridView1.Columns(4).Width = 100
        Me.DataGridView1.Columns(5).Width = 100
    End Sub
    Sub opentable()
        koneksi()
        Dim myadapter As New MySqlDataAdapter("select * from keuangan", koneksi)
        Dim mydata As New DataTable
        myadapter.Fill(mydata)
        DataGridView1.DataSource = mydata
        atur()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim saldo As String
        saldo = Val(TextBox2.Text) - Val(TextBox4.Text) + Val(TextBox3.Text)
        If TextBox3.Text = "" Or TextBox4.Text = "" Or TextBox5.Text = "" Or TextBox2.Text = "" Then
            MsgBox("DATA BELUM LENGKAP")
        Else
            cmd = New MySqlCommand(" UPDATE keuangan SET tanggal = '" & Format(DateTimePicker1.Value, "yyyy-MM-dd") & "', debit = '" & TextBox3.Text & "', credit = '" & TextBox4.Text & "', saldo ='" & saldo & "', keterangan = '" & TextBox5.Text & "' where No_ID = '" & TextBox1.Text & "' ", koneksi)
            cmd.ExecuteNonQuery()
            MsgBox("Data Berhasil Disimpan")
            clear()
            Me.Close()
        End If
    End Sub
    Private Sub Form4_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        opentable()
        atur()
        koneksi()
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        TextBox2.Text = DataGridView1.Rows(e.RowIndex).Cells(4).Value
        TextBox5.Text = DataGridView1.Rows(e.RowIndex).Cells(5).Value
        TextBox3.Text = DataGridView1.Rows(e.RowIndex).Cells(2).Value
        TextBox4.Text = DataGridView1.Rows(e.RowIndex).Cells(3).Value
        TextBox1.Text = DataGridView1.Rows(e.RowIndex).Cells(0).Value
        DateTimePicker1.Value = DataGridView1.Rows(e.RowIndex).Cells(1).Value
    End Sub

    Private Sub TextBox3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox3.TextChanged
        TextBox6.Text = Val(TextBox2.Text) + Val(TextBox3.Text) - Val(TextBox4.Text)
    End Sub
End Class