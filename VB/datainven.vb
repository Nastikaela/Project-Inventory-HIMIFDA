Imports MySql.Data.MySqlClient
Imports System.Data.SqlClient
Imports System.Data

Public Class datainven
    Dim cmd As MySqlCommand

    Sub opentable()
        'koneksi()
        Dim myadapter As New MySqlDataAdapter("select * from inventaris", koneksi)
        Dim mydata As New DataTable
        myadapter.Fill(mydata)
        DataGridView1.DataSource = mydata
    End Sub

    Sub atur()
        Me.DataGridView1.Columns(0).HeaderText = "NO BARANG"
        Me.DataGridView1.Columns(1).HeaderText = "TANGGAL MASUK"
        Me.DataGridView1.Columns(2).HeaderText = "NAMA BARANG"
        Me.DataGridView1.Columns(3).HeaderText = "JUMLAH BARANG"
        Me.DataGridView1.Columns(4).HeaderText = "KETERSEDIAAN BARANG"
        
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
        atur()
        TextBox1.Visible = False
    End Sub

    Private Sub btnapus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnapus.Click
        koneksi()
        cmd = New MySqlCommand("DELETE FROM inventaris where No_brg= '" & TextBox1.Text & "'", koneksi)
        cmd.ExecuteNonQuery()
        clear()
        MsgBox("Yakin ingin hapus data?", MsgBoxStyle.OkOnly, "Pemberitahuan")
        opentable()
    End Sub

    Private Sub DataGridView1_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseClick
        TextBox1.Text = DataGridView1.Rows(e.RowIndex).Cells(0).Value

    End Sub
   
End Class