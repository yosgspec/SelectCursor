using System;
using System.Collections.Generic;

//カーソル選択モジュール
static class SelectCursors{
	public static int SelectCursor(List<string> items){
		var cursor=0;
		//カーソルの移動
		Action<int,int> move=(x,max)=>{
			cursor+=x;
			if(cursor<0) cursor=0;
			if(max-1<cursor) cursor=max-1;
		};

		//カーソルの表示
		Action view=()=>{
			var select=new bool[items.Count];
			select[cursor]=true;
			var s="";
			for(int i=0;i<items.Count;i++){
				s+=select[i]? $"[{items[i]}]": items[i];
			}
			Console.Write($"{s}\r");
		};

		view();
		for(;;){
			var ch=Console.ReadKey(true);
			if(ch.Key==ConsoleKey.Enter){
				Console.WriteLine();
				return cursor;
			}
			if(ch.Key==ConsoleKey.LeftArrow) move(-1,items.Count);	//左
			if(ch.Key==ConsoleKey.RightArrow) move(1,items.Count);	//右
			view();
		}
	}
}

class Program{
	static void Main(){
		var items=new List<string>{"壱","弍","参","四","五","六","七","八","九","拾"};
		for(;;){
			var cursor=SelectCursors.SelectCursor(items);
			Console.WriteLine($"SelectedItem: {items[cursor]}");
		}
	}
}
