#ifndef CANLI_H
#define CANLI_H

#include "stdio.h"
#include "stdlib.h"
#include "time.h"
#include "math.h"
#include "string.h"

struct Canli
{
	int sayi;
	char* adi;
	char* (*gorunum)(struct Canli*);
	void (*clear)(struct Canli*);

};
typedef struct Canli* canli;

canli CanliOlusturma (int sayi,const char* adi);
char* gorunum(const canli);
void clear(const canli);



#endif