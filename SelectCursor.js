//カーソル選択モジュール
require("readline").emitKeypressEvents(process.stdin);
process.stdin.setRawMode(true);
const SelectCursor=items=>{
	var cursor=0;
	//カーソルの移動
	function move(x,max){
		cursor+=x;
		if(cursor<0) cursor=0;
		if(max-1<cursor) cursor=max-1;
	}

	//カーソルの表示
	function view(){
		const select=Array(items.length).fill(false);
		select[cursor]=true;
		var s="";
		for(var i in select){
			s+=select[i]? `[${items[i]}]`: `${items[i]}`;
		}
		process.stdout.write(`${s}\r`);
	}

	return new Promise(resolve=>{
		view();
		process.stdin.on("keypress",function self(k,ch){
			if(ch.name=="return"){
				console.log();
				process.stdin.removeListener("keypress",self);
				return resolve(cursor);
			}
			if(ch.name=="left") move(-1,items.length);	//左
			if(ch.name=="right") move(1,items.length);	//右
			view();
		});
	});
};

(async function(){
	const items=["壱","弍","参","四","五","六","七","八","九","拾"];
	for(;;){
		var cursor=await SelectCursor(items);
		console.log(`SelectedItem: ${items[cursor]}`);
	}
})();
