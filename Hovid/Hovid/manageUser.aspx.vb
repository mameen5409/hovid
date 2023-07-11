Public Class manageUser
    Inherits System.Web.UI.Page
    Dim cls As New clsUser
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            getuserlist()
        End If
    End Sub
    Sub getuserlist()
        If cls.getuserlist Then

            GridView1.DataSource = cls.getresultdata
            GridView1.DataBind()

        End If
    End Sub

    Private Sub GridView1_RowCancelingEdit(sender As Object, e As GridViewCancelEditEventArgs) Handles GridView1.RowCancelingEdit
        GridView1.EditIndex = -1
      
    End Sub

    Private Sub GridView1_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GridView1.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Cells(3).Enabled = False
        End If
    End Sub

    
    

    Private Sub GridView1_RowDeleting(sender As Object, e As GridViewDeleteEventArgs) Handles GridView1.RowDeleting


        cls.UserID = e.Keys.Item(0)


        If cls.DeleteUser Then
            lbstatus.ForeColor = Drawing.Color.Blue
            lbstatus.Text = "Update Record Successfully"
        Else
            lbstatus.ForeColor = Drawing.Color.Red
            lbstatus.Text = "Error!" + cls.errglobal
        End If


        getuserlist()
    End Sub

    Private Sub GridView1_RowEditing(sender As Object, e As GridViewEditEventArgs) Handles GridView1.RowEditing
        GridView1.EditIndex = e.NewEditIndex

        getuserlist()
    End Sub

    Private Sub GridView1_RowUpdating(sender As Object, e As GridViewUpdateEventArgs) Handles GridView1.RowUpdating


        cls.UserID = e.Keys.Item(0)
        cls.Username = e.NewValues.Item(0)
        cls.UserNo = e.NewValues.Item(1)

        If cls.Updateuser Then
            lbstatus.ForeColor = Drawing.Color.Blue
            lbstatus.Text = "Update Record Successfully"
        Else
            lbstatus.ForeColor = Drawing.Color.Red
            lbstatus.Text = "Error!" + cls.errglobal
        End If

        GridView1.EditIndex = -1
        getuserlist()
    End Sub

    Private Sub GridView1_Sorting(sender As Object, e As GridViewSortEventArgs) Handles GridView1.Sorting
      
        If cls.getuserlist Then
            cls.getresultdata.DefaultView.Sort = e.SortExpression & " " & chksortingNo(If(ViewState("ordNo"), "ASC"))
            GridView1.DataSource = cls.getresultdata

            GridView1.DataBind()

        End If
    End Sub
    Function chksortingNo(ByRef srt As String) As String
        Dim srtgridNo As String
        Select Case srt

            Case "ASC"
                srtgridNo = "DESC"

            Case "DESC"
                srtgridNo = "ASC"
        End Select
        ViewState("ordNo") = srtgridNo
        Return srtgridNo
    End Function
End Class