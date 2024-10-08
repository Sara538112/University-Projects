#ifndef HABITAT_H
#define HABITAT_H

#include "Canli.h"
#include "Bitki.h"
#include "Bocek.h"
#include "Sinek.h"
#include "Pire.h"
#include "Habitat.h"
#include "stdlib.h"
#include "stdio.h"
#include "math.h"

typedef enum 
{
	false=0,true=1
}boolean;

struct Habitat
{
	int**sayilar;
	int satirSayisi;
	int sutunSayisi;
	canli **canliArray;
	canli kazanan;
	canli** (*gameSpace)(struct Habitat*);
	void (*eatIt)(struct Habitat*);
	boolean (*smallerThan)(canli , canli);
	boolean (*ifEqual)(canli , canli);
	void (*yazdir)(struct Habitat*);
	void (*clearHabitat)(struct Habitat*);
	
};
typedef struct Habitat* habitat;

habitat habitatOlusturma(int** array,int str,int stn);
canli** gameSpace(habitat);
void eatIt(habitat);
boolean smallerThan(canli c0,canli c1);
boolean ifEqual(canli c0,canli c1);
void yazdir(habitat);
void clearHabitat(const habitat);

#endif