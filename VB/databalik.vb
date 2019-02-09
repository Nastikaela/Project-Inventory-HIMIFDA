Imports MySql.Data.MySqlClient
Imports System.Data.SqlClient
Imports System.Data

Public Class databalik
    Dim cmd As MySqlCommand

    Sub opentable()
        koneksi()
        Dim myadapter As New MySqlDataAdapter("select * from pengembalian", koneksi)
        Dim mydata As New DataTable
        myadapter.Fill(mydata)
        DataGridView1.DataSource = mydata
    End Sub

    Sub atur()
        Me.DataGridView1.Columns(0).HeaderText = "KODE BALIK"
        Me.DataGridView1.Columns(1).HeaderText = "NAMA PEMINJAM"
        Me.DataGridView1.Columns(2).HeaderText = "NAMA BARANG"
        Me.DataGridView1.Columns(3).HeaderText = "TANGGAL PINJAM"
        Me.DataGridView1.Columns(4).HeaderText = "TANGGAL PENGEMBALIAN"
        Me.DataGridView1.Columns(5).HeaderText = "DENDA"
        Me.DataGridView1.Columns(6).HeaderText = "JUMLAH BARANG"
        Me.DataGridView1.Columns(5).Width = 100
        Me.DataGridView1.Columns(0).Width = 100
        Me.DataGridView1.Columns(1).Width = 100
        Me.DataGridView1.Columns(2).Width = 100
        Me.DataGridView1.Columns(3).Width = 100
        Me.DataGridView1.Columns(4).Width = 100

    End Sub

    Sub clear()
        TextBox1.Text = ""
    End Sub


    Private Sub Form3_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        opentable()
        koneksi()
        Dim myadapter As New MySqlDataAdapter("select * from pengembalian", koneksi)
        Dim mydata As New DataTable
        atur()
        TextBox1.Visible = False
    End Sub

    Private Sub btnapus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnapus.Click
        koneksi()
        cmd = New MySqlCommand("DELETE FROM pengembalian where kode_balik= '" & TextBox1.Text & "'", koneksi)
        cmd.ExecuteNonQuery()
        clear()
        MsgBox("Yakin ingin hapus data?", MsgBoxStyle.OkOnly, "Pemberitahuan")
        opentable()
    End Sub

    Private Sub DataGridView1_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseClick
        TextBox1.Text = DataGridView1.Rows(e.RowIndex).Cells(0).Value
    End Sub

    Private Sub PictureBox1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
    End Sub
End Class