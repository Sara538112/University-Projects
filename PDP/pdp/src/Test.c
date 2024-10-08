#include <stdio.h>
#include <stdlib.h>
#include <string.h>

#include "Dosya.h"
#include "Canli.h"
#include "Bitki.h"
#include "habitat.h"

int main()
{
	
	
	
	const char*dosyaAdi="Veri.txt";
	dosya d=dosyaOlusturma(dosyaAdi);
	if (d == NULL) {
        fprintf(stderr, "Dosya oluşturma başarısız.\n");
        return 1;
    }

	int**array=d->DosyaOku(d,dosyaAdi);
	
	if (array == NULL) {
        fprintf(stderr, "Dosya okuma başarısız.\n");
        d->clearFile(d);
		free(d);
        return 1;
    }
	
	int str=getRows(d);
	int stn=getCols(d);
	
	habitat hb=habitatOlusturma(array, str, stn);
	hb->eatIt(hb);
	hb->clearHabitat(hb);
	free(hb);
	d->clearFile(d);
	free(d);
	return 0;
	
	return 0;
}