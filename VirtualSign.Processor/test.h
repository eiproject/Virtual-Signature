#include <iostream>
using namespace std;

#define EXPORT_API __declspec(dllexport)

extern "C" EXPORT_API string SayHi();
extern "C" EXPORT_API int CallNumber();