#include <iostream>
#include <string>
#include <vector>
#include <conio.h>

//�J�[�\���I�����W���[��
int SelectCursor(std::vector<std::string> items){
	auto cursor=0;
	//�J�[�\���̈ړ�
	auto move=[&](int x,int max){
		cursor+=x;
		if(cursor<0) cursor=0;
		if(max-1<cursor) cursor=max-1;
	};

	//�J�[�\���̕\��
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
			if(ch==0x4b) move(-1,items.size());	//��
			if(ch==0x4d) move(1,items.size());	//�E
		}
		view();
	}
	return cursor;
}

int main(){
	std::vector<std::string> items{"��","��","�Q","�l","��","�Z","��","��","��","�E"};
	for(;;){
		auto cursor=SelectCursor(items);
		std::cout<<"SelectedItem: "<<items[cursor]<<std::endl;
	}
	return 0;
}