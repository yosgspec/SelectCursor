#カーソル選択モジュール
def SelectCursor(items):
	cursor=0
	#カーソルの移動
	def move(x,max):
		nonlocal cursor
		cursor+=x
		if cursor<0: cursor=0
		if max-1<cursor: cursor=max-1

	#カーソルの表示
	def view():
		nonlocal items,cursor
		select=[False for i in items]
		select[cursor]=True
		s=""
		for i in range(len(items)):
			s+=f"[{items[i]}]" if select[i] else items[i]
		print(f"{s}\r",end="")

	view()
	from msvcrt import getch
	while True:
		ch=ord(getch())
		if ch==0x0d:
			print()
			break

		if ch==0xe0:
			ch=ord(getch())
			if ch==0x4b: move(-1,len(items))	#左
			if ch==0x4d: move(1,len(items))		#右

		view()

	return cursor

if __name__=="__main__":
	items=["壱","弍","参","四","五","六","七","八","九","拾"]
	while True:
		cursor=SelectCursor(items)
		print(f"SelectedItem: {items[cursor]}")
