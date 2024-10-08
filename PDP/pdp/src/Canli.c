#include "Canli.h"
#include <stdlib.h>



canli CanliOlusturma(int s, const char* ad)
{
	canli this;
	this =(canli)malloc(sizeof(struct Canli));
	
	if(this !=NULL)
	{
		this->sayi=s;
	}
	this->adi=strdup(ad);
	this->gorunum=&gorunum;
	this->clear=&clear;
	return this;
}

char* gorunum(const canli this)
{
	return this->adi;
}

void clear(const canli this)
{
	if (this != NULL)
	{ 
		if(this->adi !=NULL)
		{free(this->adi);}
		free(this); 
		
	}
}
