Module Main
    Sub Main()
        Dim logName As String = "System"
        Dim machineName As String = "."

        Dim LogonTimeList As New List(Of EventLogEntry)
        Dim PowerOnTimeList As New List(Of EventLogEntry)

        If EventLog.Exists(logName, machineName) Then
            Dim log As New EventLog(logName, machineName)
            For Each entry As EventLogEntry In log.Entries
                If entry.InstanceId = 7001 Then
                    logonTimeList.Add(entry)
                ElseIf entry.InstanceId = 18 Then
                    PowerOnTimeList.Add(entry)
                End If
            Next
            log.Close()
        End If

        If LogonTimeList.Count < 2 Or PowerOnTimeList.Count < 2 Then Return

        Dim LogonTIme As DateTime = LogonTimeList(LogonTimeList.Count - 2).TimeGenerated.ToString
        Dim PowerOnTIme As DateTime = PowerOnTimeList(PowerOnTimeList.Count - 2).TimeGenerated.ToString

        MessageBox.Show("システム起動時間" & vbTab & PowerOnTIme.ToString & vbCrLf & "ログオン時間" & vbTab & LogonTIme.ToString, "前回のWindowsログオン情報", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
    End Sub
End Module
