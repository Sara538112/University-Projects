#include "Canli.h"
#include "Bitki.h"
#include <stdlib.h>
#define maxSatir 100
#define MAX_SAYI_SAYISI 100


bitki bitkiOlusturma(int s)
{
	
		bitki this;
		this=(bitki)malloc(sizeof(struct Bitki));
		this->supper= CanliOlusturma(s,"B"); //  
			if (this->supper != NULL) {
            this->supper->adi = strdup("B");
        }		
		this->clear=&clearBitki;

		return this;	
} 
void clearBitki(const bitki this)
{
	if (this == NULL) return; 
	this->supper->clear(this->supper);
	free(this);
	
}