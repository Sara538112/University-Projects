#include "Canli.h"
#include <stdlib.h>
#include "Bocek.h"

#define maxSatir 100

bocek bocekOlusturma(int s)
{
	
		bocek this;
		this=(bocek)malloc(sizeof(struct Bocek));
		this->supper= CanliOlusturma(s,"C");
		//this->supper->adi="C";
		this->clear=&clearBocek;

		return this;	
} 
void clearBocek(const bocek this)
{
	if (this == NULL) return; 
	this->supper->clear(this->supper);
	free(this);
}