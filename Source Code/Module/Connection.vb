Imports MySql.Data.MySqlClient
Imports System.Security.Cryptography
Imports System.Runtime.InteropServices, System.IO, DShowNET, DShowNET.Device, System.Drawing, System.Drawing.Imaging, System.Collections, System.ComponentModel, System.Diagnostics
Imports System.Data, DirectShowLib
Imports System.Data.OleDb

Module Connection
    Public OfflineMode As Boolean
    Public dst As New DataSet 'miniature of your table - cache table to client

    Public local_conn As New OleDb.OleDbConnection
    Public local_msda As OleDb.OleDbDataAdapter
    Public local_com As New OleDbCommand
    Public local_rst As OleDbDataReader

    Public conn As New MySqlConnection 'for MySQLDatabase Connection
    Public msda As MySqlDataAdapter 'is use to update the dataset and datasource
    Public com As New MySqlCommand
    Public rst As MySqlDataReader
    Public globallogin As Boolean

    Public sqlserver As String
    Public sqlPort As String
    Public sqluser As String
    Public sqlpass As String
    Public sqldatabase As String
    Public globaluserid As String
    Public globalUsername As String
    Public globalFullname As String
    Public globalofficeid As String

    Public file_conn As String = Application.StartupPath.ToString & "\CoffeecupAttendance.conn"
    Public connclient As New MySqlConnection 'for MySQLDatabase Connection
    Public msdaclient As MySqlDataAdapter 'is use to update the dataset and datasource
    Public dstclient As New DataSet 'miniature of your table - cache table to client
    Public comclient As New MySqlCommand
    Public rstclient As MySqlDataReader

    Public clientserver As String
    Public clientport As String
    Public clientuser As String
    Public clientpass As String
    Public clientdatabase As String

    Public firstActive As Boolean
    Public capFilter As DShowNET.IBaseFilter
    Public graphBuilder As DShowNET.IGraphBuilder
    Public capGraph As DShowNET.ICaptureGraphBuilder2
    Public sampGrabber As DShowNET.ISampleGrabber
    Public mediaCtrl As DShowNET.IMediaControl
    Public mediaEvt As DShowNET.IMediaEventEx
    Public videoWin As DShowNET.IVideoWindow
    Public baseGrabFlt As DShowNET.IBaseFilter
    Public videoInfoHeader As DShowNET.VideoInfoHeader
    Public captured As Boolean = True
    Public bufferedSize As Integer
    Public savedArray As Byte()
    Public capDevices As ArrayList
    Public Const WM_GRAPHNOTIFY As Integer = &H8001
    Public Const WS_CHILD As Integer = &H40000000
    Public Const WS_CLIPCHILDREN As Integer = &H2000000
    Public Const WS_CLIPSIBLINGS As Integer = &H4000000
    Public Delegate Sub CaptureDone()
    Public rotCookie As Integer = 0
    Public mediaControl As DirectShowLib.IMediaControl = Nothing
    Public theDevice As DirectShowLib.IBaseFilter = Nothing
    Public ActiveCamera As Boolean
    Public m_rot As DsROTEntry = Nothing

    Public imgBytes As Byte() = Nothing
    Public stream As MemoryStream = Nothing
    Public img As Image = Nothing
    Public sqlcmd As New MySqlCommand
    Public sql As String
    Public arrImage() As Byte = Nothing

    Public Function OpenMysqlConnection() As Boolean
        Dim strSetup As String = ""
        Dim sr As StreamReader = File.OpenText(file_conn)
        Dim br As String = sr.ReadLine() : sr.Close()
        strSetup = DecryptTripleDES(br) : Dim cnt As Integer = 0
        For Each word In strSetup.Split(New Char() {","c})
            If cnt = 1 Then
                sqlserver = word
            ElseIf cnt = 2 Then
                sqlPort = word
            ElseIf cnt = 3 Then
                sqluser = word
            ElseIf cnt = 4 Then
                sqlpass = word
            ElseIf cnt = 5 Then
                sqldatabase = word
            End If
            cnt = cnt + 1
        Next
        Try
           
            conn.Close()
            conn = New MySql.Data.MySqlClient.MySqlConnection
            conn.ConnectionString = "server=" & sqlserver & "; Port=" & sqlPort & "; user id=" & sqluser & "; password=" & sqlpass & "; database=" & sqldatabase & "; Connection Timeout=6000000 ; Allow Zero Datetime=True"
            conn.Open()
            com.Connection = conn
            com.CommandTimeout = 6000000
        Catch errMYSQL As MySqlException
            OpenMysqlConnection = False
            Return False
        End Try
        Return True
    End Function
     

    'Public Function OpenLocalConnection() As Boolean
    '    Try
    '        local_conn.Close()
    '        local_conn = New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath.ToString & "\db.accdb;Jet OLEDB:Database Password=12sysadmin34;")
    '        local_conn.Open()
    '        local_com.Connection = local_conn
    '        local_com.CommandTimeout = 6000000
    '    Catch errMYSQL As MySqlException
    '        Return False
    '    End Try
    '    Return True
    'End Function

    Public Function OpenClientServer() As Boolean
        Try
            connclient = New MySql.Data.MySqlClient.MySqlConnection
            connclient.ConnectionString = "server=" & clientserver & "; Port=" & clientport & "; user id=" & clientuser & "; password=" & clientpass & "; database=" & clientdatabase & ""
            connclient.Open()
            comclient.Connection = connclient
            comclient.CommandTimeout = 0
            OpenClientServer = True

        Catch errMYSQL As MySqlException
            MessageBox.Show("Message:" & errMYSQL.Message & vbCrLf, _
                             "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            OpenClientServer = False
            Return False
        Catch errMS As Exception
            MessageBox.Show("Message:" & errMS.Message & vbCrLf, _
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            OpenClientServer = False
            Return False
        End Try
    End Function
    Public Function countqry(ByVal tbl As String, ByVal cond As String)
        Dim cnt As Integer = 0
        Try
            com.CommandText = "select count(*) as cnt from " & tbl & " where " & cond
            rst = com.ExecuteReader
            While rst.Read
                cnt = Val(rst("cnt").ToString)
            End While
            rst.Close()
        Catch errMYSQL As MySqlException
            MessageBox.Show("Message:" & errMYSQL.Message & vbCrLf, _
                             "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Catch errMS As Exception
            MessageBox.Show("Message:" & errMS.Message & vbCrLf, _
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False

        End Try
        Return cnt
    End Function

    Public Function countqrylocal(ByVal tbl As String, ByVal cond As String)
        Dim cnt As Integer = 0
        Try
            local_com.CommandText = "select * from " & tbl & " where " & cond
            local_rst = local_com.ExecuteReader
            If local_rst.HasRows = True Then
                cnt = 1
            End If
            'While local_rst.Read
            '    cnt = Val(local_rst("cnt").ToString)
            'End While
            local_rst.Close()
        Catch errMYSQL As OleDbException
            MessageBox.Show("Message:" & errMYSQL.Message & vbCrLf, _
                             "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Catch errMS As Exception
            MessageBox.Show("Message:" & errMS.Message & vbCrLf, _
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
        Return cnt
    End Function

    Public Function LoadToGridComboBox(ByVal query As String, ByVal fields As String, ByVal cb As Windows.Forms.DataGridViewComboBoxColumn)
        cb.Items.Clear()
        com.CommandText = query : rst = com.ExecuteReader
        While rst.Read
            If rst(fields).ToString <> "" Then
                cb.Items.Add(rst(fields).ToString)
            End If
        End While
        rst.Close()
        Return 0
    End Function
    Public Function LoadToPainComboBox(ByVal query As String, ByVal fields As String, ByVal cb As Windows.Forms.ComboBox)
        cb.Items.Clear()
        com.CommandText = query : rst = com.ExecuteReader
        While rst.Read
            If rst(fields).ToString <> "" Then
                cb.Items.Add(rst(fields).ToString)
            End If
        End While
        rst.Close()
        Return 0
    End Function
    Public Function LoadToComboBox(ByVal query As String, ByVal fields As String, ByVal id As String, ByVal cb As Windows.Forms.ComboBox)
        cb.Items.Clear()
        com.CommandText = query : rst = com.ExecuteReader
        While rst.Read
            If rst(fields).ToString <> "" Then
                cb.Items.Add(New ComboBoxItem(rst(fields).ToString, rst(id.ToString)))
            End If
        End While
        rst.Close()
        Return 0
    End Function

    Public Class ComboBoxItem
        Private displayValue As String
        Private m_hiddenValue As String

        Public Sub New(ByVal d As String, ByVal h As String)
            displayValue = d
            m_hiddenValue = h
        End Sub

        Public ReadOnly Property HiddenValue() As String
            Get
                Return m_hiddenValue
            End Get
        End Property

        Public Overrides Function ToString() As String
            Return displayValue
        End Function
    End Class

    Const sKey As String = "kira"

    Public Function EncryptTripleDES(ByVal sIn As String) As String
        Dim DES As New TripleDESCryptoServiceProvider()
        Dim hashMD5 As New MD5CryptoServiceProvider()

        ' Compute the MD5 hash.
        DES.Key = hashMD5.ComputeHash(System.Text.ASCIIEncoding.ASCII.GetBytes(sKey))
        ' Set the cipher mode.
        DES.Mode = CipherMode.ECB
        ' Create the encryptor.
        Dim DESEncrypt As ICryptoTransform = DES.CreateEncryptor()
        ' Get a byte array of the string.
        Dim Buffer As Byte() = System.Text.ASCIIEncoding.ASCII.GetBytes(sIn)
        ' Transform and return the string.
        Return Convert.ToBase64String(DESEncrypt.TransformFinalBlock(Buffer, 0, Buffer.Length))
    End Function

    Public Function DecryptTripleDES(ByVal sOut As String) As String
        Dim DES As New TripleDESCryptoServiceProvider()
        Dim hashMD5 As New MD5CryptoServiceProvider()

        ' Compute the MD5 hash.
        DES.Key = hashMD5.ComputeHash(System.Text.ASCIIEncoding.ASCII.GetBytes(sKey))
        ' Set the cipher mode.
        DES.Mode = CipherMode.ECB
        ' Create the decryptor.
        Dim DESDecrypt As ICryptoTransform = DES.CreateDecryptor()
        Dim Buffer As Byte() = Convert.FromBase64String(sOut)
        ' Transform and return the string.
        Return System.Text.ASCIIEncoding.ASCII.GetString(DESDecrypt.TransformFinalBlock(Buffer, 0, Buffer.Length))
    End Function
    Public Function rchar(ByVal str As String)
        str = str.Replace("'", "''")
        str = str.Replace("\", "\\")
        Return str
    End Function
    Public Function CLearDateString(ByVal str As String)
        str = str.Replace(":", "")
        str = str.Replace("/", "")
        str = str.Replace("AM", "")
        str = str.Replace("PM", "")
        str = str.Replace(" ", "")
        Return str
    End Function
    Public Function qrysingledata(ByVal field As String, ByVal fqry As String, ByVal tblandqry As String)
        Dim def As String = ""
        com.CommandText = "select " & fqry & " from " & tblandqry : rst = com.ExecuteReader
        While rst.Read
            def = rst(field).ToString
        End While
        rst.Close()
        Return def
    End Function
    Public Function qrysingledatalocal(ByVal field As String, ByVal fqry As String, ByVal tblandqry As String)
        Dim def As String = ""
        local_com.CommandText = "select [" & fqry & "] from " & tblandqry : local_rst = local_com.ExecuteReader
        While local_rst.Read
            def = local_rst(field).ToString
        End While
        local_rst.Close()
        Return def
    End Function

    Public Function ConvertServerTime(ByVal d As Date)
        Return d.ToString("HH:mm:ss")
    End Function

    Public Function CC(ByVal m As String)
        Return Val(m.Replace(",", ""))
    End Function
    Public Function ConvertDate(ByVal d As Date)
        Return d.ToString("yyyy-MM-dd")
    End Function
    Public Function GetServerDate() As String
        GetServerDate = ""
        com.CommandText = "select date_format(current_timestamp, '%W %M %d, %Y')  as dt"
        rst = com.ExecuteReader
        While rst.Read
            GetServerDate = rst("dt").ToString
        End While
        rst.Close()
        Return GetServerDate
    End Function
    Public Function getGlobalTrnid(ByVal init As String, ByVal endid As String)
        Dim strs As Date
        Dim finalstr As String = ""

        com.CommandText = "select current_timestamp as trnid"
        rst = com.ExecuteReader
        While rst.Read
            strs = rst("trnid").ToString
            finalstr = strs.ToString("yyyyMMddhhmmss")
        End While
        rst.Close()
        finalstr = init & "-" & finalstr & "-" & endid
        Return finalstr
    End Function


    Public Function GridCurrencyColumn(ByVal grdView As DataGridView, ByVal column As Array) As DataGridView
        For Each valueArr As String In column
            For i = 0 To grdView.ColumnCount - 1
                If valueArr = grdView.Columns(i).Name Then
                    ' grdView.Columns(i).ValueType = System.Type.GetType("System.Decimal")
                    grdView.Columns(i).ValueType = GetType(Decimal)
                    grdView.Columns(i).DefaultCellStyle.Format = "n2"
                    grdView.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    grdView.Columns(i).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight

                End If
            Next
        Next
        Return grdView
    End Function
    Public Function GridColumnAlignment(ByVal grdView As DataGridView, ByVal column As Array, ByVal alignment As DataGridViewContentAlignment) As DataGridView
        '   Dim array() As String = {a}
        For Each valueArr As String In column
            For i = 0 To grdView.ColumnCount - 1
                If valueArr = grdView.Columns(i).Name Then
                    grdView.Columns(i).DefaultCellStyle.Alignment = alignment
                    grdView.Columns(i).HeaderCell.Style.Alignment = alignment
                End If
            Next
        Next
        Return grdView
    End Function
    Public Function getproid()
        Dim strng As Integer = 0 : Dim newprocode As String = ""
        If CInt(countrecord("tblglobalproductssequence")) = 0 Then
            If CInt(countrecord("tblglobalproducts")) = 0 Then
                strng = 1000001
            Else
                com.CommandText = "select  right(productid,7) as 'proid' from tblglobalproducts order by right(productid,7) desc limit 1" : rst = com.ExecuteReader()
                While rst.Read
                    strng = Val(rst("proid").ToString) + 1
                End While
                rst.Close()
            End If
        Else
            com.CommandText = "select productid from tblglobalproductssequence" : rst = com.ExecuteReader()
            While rst.Read
                strng = Val(rst("productid").ToString) + 1
            End While
            rst.Close()
        End If
        com.CommandText = "delete from tblglobalproductssequence" : com.ExecuteNonQuery()
        com.CommandText = "insert into tblglobalproductssequence set productid='" & strng & "'" : com.ExecuteNonQuery()
        newprocode = "I" & strng.ToString
        Return newprocode
    End Function
    Public Function countrecord(ByVal tbl As String)
        Dim cnt As Integer = 0
        com.CommandText = "select count(*) as cnt from " & tbl & " "
        rst = com.ExecuteReader
        While rst.Read
            cnt = rst("cnt")
        End While
        rst.Close()
        Return cnt
    End Function
    Public Function getStockhouseid()
        Dim strng = ""

        If CInt(countrecord("tblstockhouse")) = 0 Then
            strng = "H100001"
        Else
            com.CommandText = "select stockhouseid from tblstockhouse order by right(stockhouseid,6) desc limit 1" : rst = com.ExecuteReader()
            Dim removechar As Char() = "H".ToCharArray()
            Dim sb As New System.Text.StringBuilder
            While rst.Read
                Dim str As String = rst("stockhouseid").ToString
                For Each ch As Char In str
                    If Array.IndexOf(removechar, ch) = -1 Then
                        sb.Append(ch)
                    End If
                Next
            End While
            rst.Close()
            strng = "H" & Val(sb.ToString) + 1
        End If
        Return strng.ToString
    End Function

    Public Function ResizedImage(ByVal img As Image) As Image
        ResizedImage = Nothing
        If img Is Nothing Then Exit Function
        Dim Original As New Bitmap(img)
        img = Original

        Dim m As Int32 = 200
        Dim n As Int32 = m * Original.Height / Original.Width

        Dim Thumb As New Bitmap(m, n, Original.PixelFormat)
        Thumb.SetResolution(Original.HorizontalResolution, Original.VerticalResolution)

        Dim g As Graphics = Graphics.FromImage(Thumb)
        g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High

        g.DrawImage(Original, New Rectangle(0, 0, m, n))
        ResizedImage = Thumb
        Return ResizedImage
    End Function

    Public Function UpdateImage(ByVal qry As String, ByVal fld As String, ByVal tbl As String, ByVal Ximg As Image, ByVal myform As Form)
        Try
            Dim arrImage As Byte()
            If Not Ximg Is Nothing Then
                Ximg = ResizedImage(Ximg)
                Dim mstream As New System.IO.MemoryStream()
                Ximg.Save(mstream, System.Drawing.Imaging.ImageFormat.Png)
                arrImage = mstream.GetBuffer()
                mstream.Close()
            End If

            With com
                .CommandText = "Update " & tbl & " set " & fld & " = @file where " & qry
                .Connection = conn
                .Parameters.AddWithValue("@file", arrImage)
                .ExecuteNonQuery()
            End With
            com.Parameters.Clear()

        Catch errMYSQL As MySqlException
            MessageBox.Show("Form:" & myform.Name & vbCrLf _
                             & "Module:" & "form_load" & vbCrLf _
                             & "Message:" & errMYSQL.Message & vbCrLf _
                             & "Details:" & errMYSQL.StackTrace, _
                             "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch errMS As Exception
            MessageBox.Show("Form:" & myform.Name & vbCrLf _
                             & "Module:" & "form_load" & vbCrLf _
                             & "Message:" & errMS.Message & vbCrLf _
                             & "Details:" & errMS.StackTrace, _
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return 0
    End Function
    Public Function UpdateImagelocal(ByVal qry As String, ByVal fld As String, ByVal tbl As String, ByVal filename As String, ByVal Ximg As Image, ByVal myform As Form)
        Try
            If Not Ximg Is Nothing Then
                Ximg = ResizedImage(Ximg)
                Ximg.Save(Application.StartupPath.ToString & "\Image\" & filename & ".jpg")
                local_com.CommandText = "update " & tbl & " set " & fld & "='" & filename & "' where " & qry : local_com.ExecuteNonQuery()
            End If

        Catch errMS As Exception
            MessageBox.Show("Form:" & myform.Name & vbCrLf _
                             & "Module:" & "form_load" & vbCrLf _
                             & "Message:" & errMS.Message & vbCrLf _
                             & "Details:" & errMS.StackTrace, _
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return 0
    End Function

    Public Function LoadToComboBoxQuery(ByVal fld As String, ByVal fquery As String, ByVal tblandQuery As String, ByVal combo As ComboBox)
        Try
            combo.Items.Clear()
            com.CommandText = "Select " & fquery & " from " & tblandQuery
            rst = com.ExecuteReader
            combo.BeginUpdate()
            Try
                While rst.Read
                    combo.Items.Add(rst(fld))
                End While
                rst.Close()
            Finally
                combo.EndUpdate()
            End Try
        Catch errMYSQL As MySqlException
            MessageBox.Show("Message:" & errMYSQL.Message & vbCrLf _
                             & "Details:" & errMYSQL.StackTrace, _
                             "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch errMS As Exception
            MessageBox.Show("Message:" & errMS.Message & vbCrLf _
                             & "Details:" & errMS.StackTrace, _
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return combo
    End Function
    Public Function SaveDefaultComboItem(ByVal combo As System.Windows.Forms.ComboBox, ByVal textvalue As String, ByVal codevalue As String, ByVal form As System.Windows.Forms.Form)
        If Not IO.Directory.Exists(Application.StartupPath & "\Config\") Then
            IO.Directory.CreateDirectory(Application.StartupPath & "\Config\")
        End If
        If System.IO.File.Exists(Application.StartupPath & "\Config\" & EncryptFileName("default_" & form.Name & "_" & combo.Name)) = True Then
            System.IO.File.Delete(Application.StartupPath & "\Config\" & EncryptFileName("default_" & form.Name & "_" & combo.Name))
        End If
        Dim detailsFile = New StreamWriter(Application.StartupPath & "\Config\" & EncryptFileName("default_" & form.Name & "_" & combo.Name), True)
        detailsFile.WriteLine(EncryptTripleDES(textvalue & "," & codevalue))
        detailsFile.Close()
    End Function
    Public Function EncryptFileName(ByVal sIn As String) As String
        Dim DES As New TripleDESCryptoServiceProvider()
        Dim hashMD5 As New MD5CryptoServiceProvider()

        ' Compute the MD5 hash.
        DES.Key = hashMD5.ComputeHash(System.Text.ASCIIEncoding.ASCII.GetBytes(sKey))
        ' Set the cipher mode.
        DES.Mode = CipherMode.ECB
        ' Create the encryptor.
        Dim DESEncrypt As ICryptoTransform = DES.CreateEncryptor()
        ' Get a byte array of the string.
        Dim Buffer As Byte() = System.Text.ASCIIEncoding.ASCII.GetBytes(sIn)
        ' Transform and return the string.
        Return RemoveSpecialCharacter(Convert.ToBase64String(DESEncrypt.TransformFinalBlock(Buffer, 0, Buffer.Length)))
    End Function
    Public Function RemoveSpecialCharacter(ByVal str As String)
        Dim removechar As Char() = "!@#$%^&*()_+-={}|[]\:;'<>?/".ToCharArray()
        Dim sb As New System.Text.StringBuilder
        For Each ch As Char In str
            If Array.IndexOf(removechar, ch) = -1 Then
                sb.Append(ch)
            End If
        Next
        Return sb.ToString
    End Function
    Public Function defaultCombobox(ByVal combo As System.Windows.Forms.ComboBox, ByVal form As System.Windows.Forms.Form, ByVal showcode As Boolean)
        Dim DefaultglItemLocation As String = "" : Dim defaultCode As String = "" : Dim defaultItem As String = "" : Dim Result As String = ""
        If System.IO.File.Exists(Application.StartupPath & "\Config\" & EncryptFileName("default_" & form.Name & "_" & combo.Name)) = True Then
            DefaultglItemLocation = Application.StartupPath & "\Config\" & EncryptFileName("default_" & form.Name & "_" & combo.Name)
            Dim sr As StreamReader = File.OpenText(DefaultglItemLocation)
            Try
                Dim str As String = sr.ReadLine() : Dim cnt As Integer = 0
                For Each strresult In DecryptTripleDES(str).Split(New Char() {","c})
                    If cnt = 0 Then
                        defaultItem = strresult
                    ElseIf cnt = 1 Then
                        defaultCode = strresult
                    End If
                    cnt = cnt + 1
                Next
                sr.Close()
                sr.Dispose()
            Catch errMS As Exception
                sr.Close()
            End Try
            If showcode = True Then
                Result = defaultCode
            Else
                Result = defaultItem
            End If
            Return Result
        End If
    End Function

End Module
