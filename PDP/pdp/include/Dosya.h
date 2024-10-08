#ifndef DOSYA_H
#define DOSYA_H

#include <stdio.h>
#include <stdlib.h>
#include <string.h>

struct Dosya
{
	const char* dosyaAdi;
	int Rows;
	int Cols;
	
	int** (*DosyaOku)(struct Dosya*,const char*);
	int (*getRows)(struct Dosya*);
	int (*getCols)(struct Dosya*);
	void (*clearFile)(struct Dosya*);
};
typedef struct Dosya* dosya;

	dosya dosyaOlusturma(const char* dosyaAdi);
	int** DosyaOku(dosya,const char* dosyaAdi);
	int getRows(dosya);
	int getCols(dosya);
	void clearFile(dosya);

#endif