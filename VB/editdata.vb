Imports MySql.Data.MySqlClient
Imports System.Data.SqlClient
Imports System.Data

Public Class editdata
    Dim cmd As MySqlCommand
    Dim rd As MySqlDataReader
    Sub clear()
        TextBox3.Text = ""
        TextBox4.Text = ""

    End Sub

    Sub atur()
        Me.DataGridView1.Columns(0).HeaderText = "NO BARANG"
        Me.DataGridView1.Columns(1).HeaderText = "TANGGAL MASUK"
        Me.DataGridView1.Columns(2).HeaderText = "NAMA BARANG"
        Me.DataGridView1.Columns(3).HeaderText = "JUMLAH BARANG"
        Me.DataGridView1.Columns(4).HeaderText = "KETERSEDIAAN BARANG"


    End Sub
    Sub opentable()
        koneksi()
        Dim myadapter As New MySqlDataAdapter("select * from inventaris", koneksi)
        Dim mydata As New DataTable
        myadapter.Fill(mydata)
        DataGridView1.DataSource = mydata
        atur()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If TextBox3.Text = "" Or TextBox4.Text = "" Then
            MsgBox("DATA BELUM LENGKAP")
        Else
            cmd = New MySqlCommand(" UPDATE inventaris SET tgl_masuk = ' " & Format(DateTimePicker1.Value, "yyyy-MM-dd") & " ', nama_brg = ' " & TextBox3.Text & " ', jmlh_brg = ' " & TextBox4.Text & "' where No_brg ='" & TextBox1.Text & "'", koneksi)
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
        Dim myadapter As New MySqlDataAdapter("select * from inventaris", koneksi)
        Dim mydata As New DataTable

    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        TextBox1.Text = DataGridView1.Rows(e.RowIndex).Cells(0).Value
        TextBox3.Text = DataGridView1.Rows(e.RowIndex).Cells(2).Value
        TextBox4.Text = DataGridView1.Rows(e.RowIndex).Cells(3).Value
    End Sub
End Class