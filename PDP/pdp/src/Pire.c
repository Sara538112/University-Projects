#include "Canli.h"
#include "Pire.h"
#include "Bocek.h"

#include <stdlib.h>



pire pireOlusturma(int s)
{
	
		pire this;
		this=(pire)malloc(sizeof(struct Pire));
		this->supper= bocekOlusturma(s);
		
		if (this->supper != NULL) 
		{
            this->supper->supper->adi = "P";
            this->clear =&clearPire;
        }
		else 
		{
            free(this); 
            this = NULL;
        }	
		return this;
} 
void clearPire(const pire this)
{
	if(this==NULL) return;
	this->supper->clear(this->supper);
	free(this);
}