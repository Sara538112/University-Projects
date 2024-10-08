#include "Canli.h"
#include <stdlib.h>
#include "Sinek.h"



sinek sinekOlusturma(int s)
{
	
		sinek this;
		this=(sinek)malloc(sizeof(struct Sinek));
		this->supper= bocekOlusturma(s);
		if (this->supper != NULL) 
		{
            this->supper->supper->adi = "S";
            this->clear =&clearSinek;
        } 
		else 
		{
            free(this); 
            this = NULL;
        }	
		return this;	
} 
void clearSinek(const sinek this)
{
	if(this==NULL) return;
	this->supper->clear(this->supper);
	free(this);
}