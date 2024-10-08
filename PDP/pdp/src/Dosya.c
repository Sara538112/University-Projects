#include "Dosya.h"
#define maxSatir 100
#define maxSutun 100


dosya dosyaOlusturma(const char* ds)
{
	dosya this;
	this=(dosya)malloc(sizeof(struct Dosya));
	if (this == NULL) {
        fprintf(stderr, "Bellek tahsisi basarisiz.\n");
        return NULL;
    }

	this->dosyaAdi=ds;
	this->Rows=0;
	this->Cols=0 ;
	this->DosyaOku=&DosyaOku;
	this->getRows=&getRows;
	this->getCols=&getCols;
	this->clearFile = &clearFile;
	
	return this;
};
int** DosyaOku(dosya this,const char* dosyaAdi)
{
	FILE*file = fopen(dosyaAdi,"r");//dosya acilimi
	if (file == NULL) {
        fprintf(stderr, "Dosya acilamadi: %s\n", dosyaAdi);
        return NULL;
    }
	
	int capacity=100;
	int satirSayisi=0;
	int sutunSayisi=0;
	
	int**sayilarDizisi=(int**)malloc(sizeof(int*) * capacity);
	if (sayilarDizisi == NULL) {
        fclose(file);
        return NULL;  
    }
	
	
	char satir[1024];
	int str=0;
	while(fgets(satir,sizeof(satir),file) !=NULL)
	{
		int stn=0;
		char* parcalnma=strtok(satir," ");
		
		sayilarDizisi[str]=(int*)malloc(sizeof(int)*capacity);
		//1.dimantion
		if(sayilarDizisi[str] ==NULL)
		{
			fclose(file);
			for (int i = 0; i < str; i++) {
                free(sayilarDizisi[i]);
            }
            free(sayilarDizisi);
            return NULL;
		}
		while(parcalnma !=NULL)
		{
			sscanf(parcalnma,"%d",&sayilarDizisi[str][stn]);
			stn++;
			parcalnma=strtok(NULL," ");
		}
		
		if(stn > sutunSayisi)
		{
			sutunSayisi=stn;
		}
		str++;
		
		
		if(str >= capacity)
		{
			capacity *=2;
			int** yeniDizi=(int**)realloc(sayilarDizisi,sizeof(int*)*capacity);
			if (yeniDizi == NULL) {
                fclose(file);

                for (int i = 0; i < str; i++) 
				{
                    free(sayilarDizisi[i]);
                }
                free(sayilarDizisi);
                return NULL;
            }
			sayilarDizisi=yeniDizi;
		}
		
	}
		
		satirSayisi=str;
		
		this->Rows = satirSayisi;
		this->Cols = sutunSayisi;


		fclose(file);
		return sayilarDizisi;
}
int getRows(dosya this)
{
	return this->Rows;
};
int getCols(dosya this)
{
	return this->Cols;
};
void clearFile(dosya this)
{
	if (this != NULL)
        free(this);
}
