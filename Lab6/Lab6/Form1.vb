Imports System.Data.OleDb

Public Class Form1

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FindAll()
    End Sub

    Private Sub btnPub_Click(sender As Object, e As EventArgs) Handles btnPub.Click
        fromPubName()
    End Sub
    Private Sub btnYear_Click(sender As Object, e As EventArgs) Handles btnYear.Click
        fromYear()
    End Sub
    Private Sub FindAll()
        Dim SQlStatement As String = "SELECT Book.BookName, Book.BookAuthor, Book.BookEditionYear FROM Books;"

        Dim connectionString As String = "Provider = Microsoft.Jet.OLEDB.4.0;" & "Data Source = Lab6.mdb"
        Dim dtProperties As New DataTable()
        Dim dbDataAdapter As OleDbDataAdapter
        dbDataAdapter = New OleDbDataAdapter(SQlStatement, connectionString)
        dbDataAdapter.Fill(dtProperties)
        DataGridView1.DataSource = dtProperties
    End Sub
    Private Sub fromPubName()
        Dim SQlStatement As String = "SELECT Book.BookName, Book.BookAuthor, Book.BookEditionYear
                                      FROM Publisher INNER JOIN Book ON Publisher.PubID = Book.PubID
                                      WHERE (((Publisher.PubName)='" + txtPub.Text + "'));"

        Dim connectionString As String = "Provider = Microsoft.et.OLEDB.4.0;" & "Data Source = Lab6.mdb"
        Dim dtProperties As New DataTable()
        Dim dbDataAdapter As OleDbDataAdapter
        dbDataAdapter = New OleDbDataAdapter(SQlStatement, connectionString)
        dbDataAdapter.Fill(dtProperties)
        DataGridView1.DataSource = dtProperties
    End Sub

    Private Sub fromYear()
        Dim SQlStatement As String = "SELECT Book.BookName, Book.BookAuthor, Book.BookEditionYear, Publisher.PubName
                                      FROM Book INNER JOIN Publisher ON Book.PubID = Publisher.PubID
                                      WHERE (((Book.BookEditionYear)='" + txtYear.Text + "'));"

        Dim connectionString As String = "Provider = Microsoft.et.OLEDB.4.0;" & "Data Source = Lab6.mdb"
        Dim dtProperties As New DataTable()
        Dim dbDataAdapter As OleDbDataAdapter
        dbDataAdapter = New OleDbDataAdapter(SQlStatement, connectionString)
        dbDataAdapter.Fill(dtProperties)
        DataGridView1.DataSource = dtProperties
    End Sub

End Class
