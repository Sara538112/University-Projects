#include "Canli.h"
#include "Bitki.h"
#include "Bocek.h"
#include "Sinek.h"
#include "Pire.h"
#include "Habitat.h"

#include <stdlib.h>
#include <stdbool.h>
#include "math.h"

#include "habitat.h"

habitat habitatOlusturma(int** array, int str, int stn)
{
	habitat this;
	this=(habitat)malloc(sizeof(struct Habitat));
	this->sayilar=array;
	this->kazanan=NULL;
	this->satirSayisi = str;
	this->sutunSayisi = stn;

	this->gameSpace=&gameSpace;
	this->eatIt=&eatIt;
	this->smallerThan=&smallerThan;
	this->ifEqual=&ifEqual;
	this->clearHabitat = &clearHabitat;

	this->canliArray = gameSpace(this);
	return this;
};

canli** gameSpace(habitat this) {
	int** sayilar = this->sayilar;
	int Rows = this->satirSayisi;
	int Cols = this->sutunSayisi;
    canli** yeniArray = (canli**)malloc(Rows * sizeof(canli*));

    for (int i = 0; i < Rows; i++) {
        yeniArray[i] = (canli*)malloc(Cols * sizeof(canli));

        for (int j = 0; j < Cols; j++) {
            if (i >= 0 && i < Rows && j >= 0 && j < Cols) {
                int sayi = sayilar[i][j];


                canli c = NULL;

                if (sayi >= 1 && sayi <= 9) {
                    bitki b = bitkiOlusturma(sayi);
                    yeniArray[i][j] = b->supper;
                } else if (sayi >= 10 && sayi <= 20) {
                    bocek c = bocekOlusturma(sayi);
                    yeniArray[i][j] = c->supper;
                } else if (sayi >= 21 && sayi <= 50) {
                    sinek s = sinekOlusturma(sayi);
                    yeniArray[i][j] = s->supper->supper;
                } else if (sayi >= 51 && sayi <= 99) {
                    pire p = pireOlusturma(sayi);
                    yeniArray[i][j] = p->supper->supper;
                } else {
                    // Handle unexpected cases or errors
                    printf("Invalid sayi value at (%d, %d)\n", i, j);
                }

            } else {
                printf("Out-of-bounds access at (%d, %d)\n", i, j);
            }
        }
    }
    return yeniArray; 
}

void yazdir(habitat this)
{
	canli** array = this->canliArray;
	int Rows = this->satirSayisi;
	int Cols = this->sutunSayisi;

	char* oldu="X";
	for(int i=0 ; i<Rows ; i++)
	{
		for(int j=0; j<Cols; j++)
		{
			if (array[i][j] != NULL)
			{
				char* cikti = gorunum(array[i][j]);
				printf("%s\t",cikti);
			}
			else 
			{
				printf("%s\t",oldu);
			}
		}
		printf("\n");
	}
}

boolean smallerThan(canli c1, canli c2)
{
	if ( c1 == NULL || c2 == NULL){
		printf("Hello smaller Than one of us is NULL!\n");
	}
	char* ad1 = (c1)->gorunum(c1);
	char* ad2 = (c2)->gorunum(c2);
	if ((strcmp(ad1,"B")==0  && (strcmp(ad2,"P")==0)) ||
        ((strcmp(ad1,"C")==0 && strcmp(ad2,"B")==0)) ||
        ((strcmp(ad1,"S")==0 && strcmp(ad2,"P")==0)) ||
        ((strcmp(ad1,"B")==0 && strcmp(ad2,"S")==0)) ||
        ((strcmp(ad1,"S")==0 && strcmp(ad2,"C")==0)) ||
        ((strcmp(ad1,"C")==0 && strcmp(ad2,"P")==0))) 
    {
        return true;
    }
   else if((strcmp(ad1, "P") == 0 && strcmp(ad2, "B") == 0) ||
		   (strcmp(ad1, "B") == 0 && strcmp(ad2, "C") == 0) ||
		   (strcmp(ad1, "P") == 0 && strcmp(ad2, "S") == 0) ||
		   (strcmp(ad1, "S") == 0 && strcmp(ad2, "B") == 0) ||
		   (strcmp(ad1, "C") == 0 && strcmp(ad2, "S") == 0) ||
		   (strcmp(ad1, "P") == 0 && strcmp(ad2, "C") == 0))
    {
        return false;
    }
	else
	{
		return ifEqual(c1,c2);
	}
};

boolean ifEqual(canli c1,canli c2)
{
	//printf("It's Draw !\n");
	
	if ( c1 == NULL || c2 == NULL){
		printf("Hello equal one of us is NULL!\n");
	}
	int sayi1=(c1)->sayi;
	int sayi2=(c2)->sayi;
	//printf("Simdiki Sayi = %d, Sonraki Sayi = %d\n",sayi1,sayi2);
	if(sayi1>sayi2)
	{
		return true;
	}else if (sayi1 < sayi2)
	{
		return false;
	}
	else{
		return false;
	}
};

void eatIt(habitat this) {
	
	int Rows = this->satirSayisi;
	int Cols = this->sutunSayisi;
	canli simdeki = this->canliArray[0][0];
    canli sonraki = NULL;
	
	int simdikiIndexi = 0;
	int simdikiIndexj = 0;
	int sonrakiIndexi = 0; 
	int sonrakiIndexj = 0;
	int toplamCanli = Rows*Cols;

	while(sonrakiIndexj < toplamCanli){
		system("CLS");
		sonrakiIndexj++;
		if((sonrakiIndexj ) % Cols == 0){
			sonrakiIndexi++;
		}

		if(sonrakiIndexi == Rows)
			break;

		sonraki = this->canliArray[sonrakiIndexi][(sonrakiIndexj) % Cols];
		//printf("sonrakiIndex = (%d,%d,%d)\n",sonrakiIndexi,sonrakiIndexj,sonrakiIndexj%Cols);
		//printf("Simdiki(%s) VS Soraki(%s)\n",simdeki->gorunum(simdeki),sonraki->gorunum(sonraki));
		boolean sonuc = smallerThan(simdeki, sonraki);
		if (sonuc == true)
		{ 
			//printf("Simdiki Is Stronger\n");
			canli smallest = sonraki;
			(smallest)->clear(smallest);
			
			this->canliArray[sonrakiIndexi][sonrakiIndexj % Cols] = NULL;
			yazdir(this);
			continue;
			
		}
		else if (sonuc == false)
		{ 
			//printf("Sonraki Is Stronger\n");
					
			canli smallest = simdeki;
			(smallest)->clear(smallest);
			this->canliArray[simdikiIndexi][simdikiIndexj % Cols] = NULL; 
			
			simdikiIndexi = sonrakiIndexi;
			simdikiIndexj = sonrakiIndexj % Cols;
			yazdir(this);
			simdeki = sonraki;
			continue;
		}
	} 
	printf("Kazanan : %s(%d,%d)\n",simdeki->gorunum(simdeki),simdikiIndexi,simdikiIndexj);

	simdeki->clear(simdeki);
	this->canliArray[simdikiIndexi][simdikiIndexj % Cols] = NULL; 

}

void clearHabitat(const habitat this){
	if(this != NULL)
	{
		int Rows = this->satirSayisi;
		int Cols = this->sutunSayisi;
		canli** array = this->canliArray;
		int** sayilar = this->sayilar;
		for(int i=0 ; i<Rows ; i++)
		{
			for(int j=0; j<Cols; j++)
			{
				if (array[i][j] != NULL)
				{
					array[i][j]->clear(array[i][j]);
				}
			}
			free(array[i]);
			free(sayilar[i]);
		}
		free(array);
		free(sayilar);
	}
}