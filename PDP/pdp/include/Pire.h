#ifndef PIRE_H
#define PIRE_H

#include "stdio.h"
#include "stdlib.h"
#include "string.h"
#include "Canli.h"
#include "Bocek.h"

struct Pire
{
	bocek supper;
	void (*clear)(struct Pire*);
	
};
typedef struct Pire* pire;
pire pireOlusturma(int);
void clearPire(const pire);
#endif