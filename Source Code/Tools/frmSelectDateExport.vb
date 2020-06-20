Imports MySql.Data.MySqlClient ' this is to import MySQL.NET
Imports System
Imports System.IO

Public Class frmSelectDateExport
    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, ByVal keyData As Keys) As Boolean
        If keyData = (Keys.Escape) Then
            Me.Close()
        End If
        Return ProcessCmdKey
    End Function

    Private Sub frmSelectDateExport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtDateFrom.Value = CDate(Now.AddDays(-1))
    End Sub

    Private Sub cmdset_Click(sender As Object, e As EventArgs) Handles cmdset.Click
        Dim officelist As String = "" : Dim details As String = ""
        com.CommandText = "select distinct tblpayrollattendancelog.officeid from tblpayrollattendancelog inner join tblemployees on tblpayrollattendancelog.employeeid = tblemployees.employeeid where logindate between '" & ConvertDate(txtDateFrom.Value) & "' and '" & ConvertDate(txtDateTo.Value) & "'" : rst = com.ExecuteReader()
        While rst.Read
            officelist += rst("officeid").ToString & ","
        End While
        rst.Close()

        If officelist.Length > 0 Then
            officelist = officelist.Remove(officelist.Length - 1, 1)
            For Each word In officelist.Split(New Char() {","c})
                msda = Nothing : dst = New DataSet
                msda = New MySqlDataAdapter("select * from tblpayrollattendancelog inner join tblemployees on tblpayrollattendancelog.employeeid = tblemployees.employeeid where tblpayrollattendancelog.officeid='" & word & "' and logindate between '" & ConvertDate(txtDateFrom.Value) & "' and '" & ConvertDate(txtDateTo.Value) & "' group by tblemployees.employeeid order by fullname asc", conn)
                msda.Fill(dst, 0)
                For cnt = 0 To dst.Tables(0).Rows.Count - 1
                    With (dst.Tables(0))
                        details += .Rows(cnt)("fullname").ToString() & Environment.NewLine
                        details += "----------------------------------------------------------------------------------------------------------------------------------------------" & Environment.NewLine
                        details += "Date" & vbTab & vbTab & "AM IN" & vbTab & vbTab & "AM OUT" & vbTab & vbTab & "PM IN" & vbTab & vbTab & "PM OUT" & vbTab & vbTab & "OVERTIME IN" & vbTab & vbTab & "OVERTIME OUT" & Environment.NewLine
                        com.CommandText = "select tblpayrollattendancelog.employeeid, date_format(logindate,'%Y-%m-%d') as 'logdate', (select fullname from tblemployees where employeeid =tblpayrollattendancelog.employeeid) as 'Employee Name', " _
                                               + " date_format(1st_timein,'%r') as 'Morning IN', date_format(1st_timeout,'%r') as 'Morning Out', " _
                                               + " date_format(2nd_timein,'%r') as 'Afternoon IN', date_format(2nd_timeout,'%r') as 'Afternoon Out', " _
                                               + " date_format(3rd_timein,'%r') as 'Overtime IN', date_format(3rd_timeout,'%r') as 'Overtime OUT' " _
                                               + " from tblpayrollattendancelog inner join tblemployees on tblpayrollattendancelog.employeeid = tblemployees.employeeid where tblpayrollattendancelog.officeid='" & word & "' and tblpayrollattendancelog.employeeid='" & .Rows(cnt)("employeeid").ToString() & "' and logindate between '" & ConvertDate(txtDateFrom.Value) & "' and '" & ConvertDate(txtDateTo.Value) & "' order by logindate asc" : rst = com.ExecuteReader()
                        While rst.Read
                            details += rst("logdate").ToString & vbTab & rst("Morning IN").ToString & vbTab & rst("Morning Out").ToString & vbTab & rst("Afternoon IN").ToString & vbTab & rst("Afternoon Out").ToString & vbTab & rst("Overtime IN").ToString & vbTab & rst("Overtime Out").ToString & Environment.NewLine
                        End While
                        rst.Close()
                        details += Environment.NewLine & Environment.NewLine
                    End With
                Next
            Next
        End If

        If System.IO.File.Exists(Application.StartupPath & "\updateinfo.txt") = True Then
            System.IO.File.Delete(Application.StartupPath & "\updateinfo.txt")
        End If

        Dim detailsFile As StreamWriter = Nothing
        detailsFile = New StreamWriter(Application.StartupPath.ToString & "\updateinfo.txt", True)
        detailsFile.WriteLine("Coffeecup Client Update Logs" & Environment.NewLine & Environment.NewLine & details & "Winter S. Bugahod" & Environment.NewLine & "IT-Devt. Katipunan Bank")
        detailsFile.Close()

        Process.Start(Application.StartupPath & "\updateinfo.txt")
    End Sub
End Class