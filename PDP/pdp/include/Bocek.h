#ifndef BOCEK_H
#define BOCEK_H

#include "stdio.h"
#include "stdlib.h"
#include "string.h"
#include "Canli.h"


struct Bocek
{
	canli supper;	
	void (*clear)(struct Bocek*);

};
typedef struct Bocek* bocek;
bocek bocekOlusturma(int);
void clearBocek( const bocek );
#endif