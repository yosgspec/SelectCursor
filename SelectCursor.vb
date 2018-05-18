Option Strict On
Option Infer On
Imports System
Imports System.Collections.Generic

'カーソル選択モジュール
Module SelectCursor
	Function SelectCursor(items As List(Of String)) As Integer
		Dim cursor=0I
		'カーソルの移動
		Dim move As Action(Of Integer,Integer)=Sub(x,max)
			cursor+=x
			if cursor<0 Then cursor=0
			if max-1<cursor Then cursor=max-1
		End Sub

		'カーソルの表示
		Dim view As Action=Sub()
			Dim _select(items.Count-1) As Boolean
			_select(cursor)=True
			Dim s=""
			For i=0I To items.Count-1
				s+=If(_select(i),$"[{items(i)}]",items(i))
			Next
			Console.Write($"{s}{vbCr}")
		End Sub

		view()
		Do
			Dim ch=Console.ReadKey(True)
			If ch.Key=ConsoleKey.Enter Then
				Console.WriteLine()
				Return cursor
			End If
			If ch.Key=ConsoleKey.LeftArrow Then move(-1,items.Count)	'左
			If ch.Key=ConsoleKey.RightArrow Then move(1,items.Count)	'右
			view()
		Loop
	End Function
End Module

Module Program
	Sub Main
		Dim items As New List(Of String) from {"壱","弍","参","四","五","六","七","八","九","拾"}
		Do
			Dim cursor=SelectCursor.SelectCursor(items)
			Console.WriteLine($"SelectedItem: {items(cursor)}")
		Loop
	End Sub
End Module
