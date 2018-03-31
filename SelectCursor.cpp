#include <iostream>
#include <string>
#include <vector>
#include <conio.h>

//カーソル選択モジュール
int SelectCursor(std::vector<std::string> items){
	auto cursor=0;
	//カーソルの移動
	auto move=[&](int x,int max){
		cursor+=x;
		if(cursor<0) cursor=0;
		if(max-1<cursor) cursor=max-1;
	};

	//カーソルの表示
	auto view=[&](){
		std::vector<bool> select(items.size(),false);
		select[cursor]=true;
		std::string s="";
		for(int i=0;i<items.size();i++){
			s+=select[i]? "["+items[i]+"]": items[i];
		}
		std::cout<<s<<"\r"<<std::flush;
	};

	view();
	for(;;){
		auto ch=getch();
		if(ch==0x0d){
			std::cout<<std::endl;
			break;
		}
		if(ch==0xe0){
			ch=getch();
			if(ch==0x4b) move(-1,items.size());	//左
			if(ch==0x4d) move(1,items.size());	//右
		}
		view();
	}
	return cursor;
}

int main(){
	std::vector<std::string> items{"壱","弍","参","四","五","六","七","八","九","拾"};
	for(;;){
		auto cursor=SelectCursor(items);
		std::cout<<"SelectedItem: "<<items[cursor]<<std::endl;
	}
	return 0;
}