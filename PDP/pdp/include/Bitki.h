#ifndef BITKI_H
#define BITKI_H

#include "stdio.h"
#include "stdlib.h"
#include "string.h"
#include "Canli.h"

struct Bitki
{
	canli supper;	
	void (*clear)(struct Bitki*);

};
typedef struct Bitki* bitki;

bitki bitkiOlusturma(int sayi);
void clearBitki(const bitki);

#endif