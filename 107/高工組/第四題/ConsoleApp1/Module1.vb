Module Module1

    Sub Main()
        Console.WriteLine("記憶體管理程式-最適配置法(Best Fit)")
        Console.Write("請輸入記憶體區塊數(<6)：")
        Dim n As Integer = 0
        n = Val(Console.ReadLine())
        Dim N_Size(n) As Integer
        Console.Write("請輸入程式數(<6)：")
        Dim Process As Integer = 0
        Process = Val(Console.ReadLine())
        Dim P(Process) As Integer
        Console.WriteLine("請輸入各區塊大小(<10)---")
        For i = 1 To n
            Console.Write("區塊" & i & "：")
            N_Size(i) = Val(Console.ReadLine())
        Next
        Console.WriteLine("請輸入個程序所需的大小(<10)---")
        For i = 1 To Process
            Console.Write("程序" & i & "：")
            P(i) = Val(Console.ReadLine())
        Next
        Console.WriteLine()
        '配置空間
        Console.WriteLine("程序編號" & vbTab & "所需大小" & vbTab & "區塊編號" & vbTab & "區塊大小" & vbTab & "剩餘空間")
        Dim N_T(n) As Integer
        Dim P_T(Process) As Integer
        For I = 1 To Process
            '找最大空間 分配給最大程序
            Dim Max_n, Max_P As Integer
            Max_n = 0 : Max_P = 0
            For J = 1 To n
                If N_Size(Max_n) < N_Size(J) And N_T(J) = 0 Then
                    Max_n = J
                End If
            Next
            For J = 1 To Process
                If P(Max_P) < P(J) And P_T(J) = 0 Then
                    Max_P = J
                End If
            Next
            '如果程序所需空間小於等於配置到的空間則成功分配
            If P(Max_P) <= N_Size(Max_n) Then
                N_T(Max_n) = Max_P
                P_T(Max_P) = Max_n
            Else
                '分配失敗
                P_T(Max_P) = -1
            End If
        Next
        '輸出配置結果
        For I = 1 To Process
            If P_T(I) = -1 Then
                Console.Write(I & vbTab & vbTab & P(I) & vbTab & vbTab & "未分配記憶體區塊")
            Else
                Console.Write(I & vbTab & vbTab & P(I) & vbTab & vbTab & P_T(I) & vbTab & vbTab & N_Size(P_T(I)) & vbTab & vbTab & N_Size(P_T(I)) - P(I))
            End If
            Console.WriteLine()
        Next
        '配置前

        '從配置1開始畫
        For i = 1 To 6
            If i = 3 Then
                Console.Write("配置程序前")
            Else
                Console.Write("          ")
            End If
            '上下
            If i = 1 Or i = 5 Then
                For j = 1 To n
                    For k = 0 To N_Size(j)
                        Console.Write("█")
                    Next
                Next
                Console.Write("█")
            ElseIf i <> 1 And i <> 5 And i <> 6 Then
                '中間
                For j = 1 To n
                    For k = 0 To N_Size(j)
                        If k = 0 Then
                            Console.Write("█")
                        Else
                            Console.Write("  ")
                        End If
                    Next
                Next
                Console.Write("█")
            Else
                '標刻度
                For j = 1 To n
                    For k = 0 To N_Size(j)
                        If k = 0 Then
                            Console.Write("  ")
                        Else
                            Console.Write(k & "-")
                        End If
                    Next
                Next
            End If
            Console.WriteLine()
        Next

        '配置後
        '從配置1開始畫
        For i = 1 To 5
            If i = 3 Then
                Console.Write("程序配置後")
            Else
                Console.Write("          ")
            End If
            '上下
            If i = 1 Or i = 5 Then
                For j = 1 To n
                    For k = 0 To N_Size(j)
                        Console.Write("█")
                    Next
                Next
                Console.Write("█")
            ElseIf i = 3 Then
                '配置
                For j = 1 To n
                    '沒被配置到的空間不要執行
                    If N_T(j) <> 0 Then
                        For k = 0 To N_Size(j)
                            If k = 0 Then
                                Console.Write("█")
                            ElseIf k = 1 Then
                                Console.Write("P" & N_T(j))
                            Else
                                If P(N_T(j)) >= k Then
                                    Console.Write("==")
                                Else
                                    Console.Write("  ")
                                End If
                            End If
                        Next
                    Else
                        '中間空白
                        For K = 0 To N_Size(j)
                            If K = 0 Then
                                Console.Write("█")
                            Else
                                Console.Write("  ")
                            End If
                        Next
                    End If
                Next
                Console.Write("█")
            Else
                '中間空白
                For j = 1 To n
                    For k = 0 To N_Size(j)
                        If k = 0 Then
                            Console.Write("█")
                        Else
                            Console.Write("  ")
                        End If
                    Next
                Next
                Console.Write("█")
            End If
            Console.WriteLine()
        Next
        Console.ReadKey()
        Call Main()
    End Sub
End Module
