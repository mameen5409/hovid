Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration

Public Class clsUser
    Dim connstring As String = ConfigurationManager.ConnectionStrings("HovidConnectionString").ConnectionString
    Dim conn As New SqlConnection(connstring)


    Public errglobal As String
    Dim comm As SqlCommand
    Dim dr As SqlDataReader
    Dim sql As String
    Dim ds As DataSet
    Dim dsref As DataSet
    Dim da As SqlDataAdapter

    Public Username As String
    Public UserNo As Integer
    Public UserID As Integer

    Public getresultdata As DataTable

    Function getuserlist() As Boolean
        If getresult("select * from tbuser ") Then
            Return True
        Else
            Return False

        End If
    End Function

    Function adduser() As Boolean
        Try

            comm = New SqlCommand("sp_UserAdd", conn)
            comm.CommandType = CommandType.StoredProcedure
            comm.Parameters.AddWithValue("@Username", Username)
            comm.Parameters.AddWithValue("@UserNo", UserNo)
            comm.Parameters.AddWithValue("@CreateDate", Format(Now, "MM/dd/yyyy hh:mm:ss tt"))

            If conn.State = ConnectionState.Closed Then conn.Open()
            comm.ExecuteNonQuery()


            Return True

        Catch ex As Exception
            errglobal = ex.Message
            Return False
        End Try
    End Function
   
    Function Updateuser() As Boolean
        Try

            comm = New SqlCommand("sp_UserUpdate", conn)
            comm.CommandType = CommandType.StoredProcedure
            comm.Parameters.AddWithValue("@Userid", UserID)
            comm.Parameters.AddWithValue("@Username", Username)
            comm.Parameters.AddWithValue("@UserNo", UserNo)
            comm.Parameters.AddWithValue("@CreateDate", Format(Now, "MM/dd/yyyy hh:mm:ss tt"))

            If conn.State = ConnectionState.Closed Then conn.Open()
            comm.ExecuteNonQuery()


            Return True

        Catch ex As Exception
            errglobal = ex.Message
            Return False
        End Try

    End Function
    Function DeleteUser() As Boolean
        Try

            comm = New SqlCommand("sp_UserDelete", conn)
            comm.CommandType = CommandType.StoredProcedure
            comm.Parameters.AddWithValue("@Userid", UserID)
           

            If conn.State = ConnectionState.Closed Then conn.Open()
            comm.ExecuteNonQuery()


            Return True

        Catch ex As Exception
            errglobal = ex.Message
            Return False
        End Try

    End Function

    Function getresult(ByVal sql As String) As Boolean
        Try

            Dim comm = New SqlCommand(sql, conn)

            If conn.State = ConnectionState.Closed Then conn.Open()

            Dim ds = New DataSet
            Dim da = New SqlDataAdapter
            da.SelectCommand = comm
            da.Fill(ds, "getresult")

            getresultdata = ds.Tables(0)
            ds.Dispose()
            comm.Dispose()

            da.Dispose()
            Return True

        Catch ex As Exception
            errglobal = ex.Message
            Return False
        Finally
            If conn.State = ConnectionState.Open Then conn.Close()
        End Try


    End Function
End Class



