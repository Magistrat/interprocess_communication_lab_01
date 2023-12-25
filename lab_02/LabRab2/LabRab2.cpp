#include <iostream>

char string[] = "Hello World!";

int main() {
    char* ptr = string;
    std::cout << ptr;
    std::cout << (int)ptr;
    char A = getchar();
    std::cout << ptr;
    char B = getchar();
    return 0;
}