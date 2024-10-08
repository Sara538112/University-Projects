#ifndef SINEK_H
#define SINEK_H

#include "stdio.h"
#include "stdlib.h"
#include "string.h"
#include "Canli.h"
#include "Bocek.h"


struct Sinek
{
	bocek supper;
	void (*clear)(struct Sinek*);

};
typedef struct Sinek* sinek;
sinek sinekOlusturma(int);
void clearSinek( const sinek );
#endif