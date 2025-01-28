#include<iostream>
#include<string>

int main() {
	int a = 1;

	printf("%d, %d, %d, %d, %d", a, a, a, a, a);

	return 0;
	std::string filename;
	std::cin >> filename;
	
	std::string command = "nasm -f win64 " + filename + ".asm -o " + filename + "\\" + filename + ".obj && GoLink /console " + filename + "\\" + filename + ".obj kernel32.dll msvcrt.dll && " + filename + "\\" + filename;

	char* com = new char[command.size() + 1];
	for (int i = 0; i < command.size(); ++i)
		com[i] = command[i];
	com[command.size()] = '\t';

	system(com);
	system("pause");
	return 0;
}