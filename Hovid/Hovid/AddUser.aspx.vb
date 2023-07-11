Public Class AddUser
    Inherits System.Web.UI.Page
    Dim cls As New clsUser
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnCreate_Click(sender As Object, e As EventArgs) Handles btnCreate.Click
        cls.Username = txUsername.Text
        cls.UserNo = txUserNo.Text

        If cls.adduser Then
            lbstatus.Text = "Add User Successfully"
            lbstatus.ForeColor = Drawing.Color.Blue
            txUsername.Text = ""
            txUserNo.Text = ""
        Else
            lbstatus.Text = "Error!. " + cls.errglobal
            lbstatus.ForeColor = Drawing.Color.Red
        End If
    End Sub
End Class