/**
*
* @author Sara Mohamed
* @since 4/04/2023 - 5/04/2023
* <p>
*	Classlar uzerine incelemek 
* </p>
*/
package odev;

import java.io.BufferedReader;
import java.io.IOException;

public class ClassesOperations {

	 private String classess;
	 private String path;
	 private GitHubInceleme Names;
	 private String className;
	 private int JavaDocSatirSayisi;
	 private int yorumSatirSayisi;
	 private int kodSatirSayisi;
	 private int kodToplamSatirSayisi;
	 private int kodToplamFonksiyonSayisi;
	 private double YG;
	 private double YH;
	 private double yorumSapma;
	 
	 public ClassesOperations( String fileclasses ,String path)
	 {
		 this.classess=fileclasses;
		 this.path = path;
		 this.JavaDocSatirSayisi=0;
		 this.yorumSatirSayisi=0;
		 this.kodSatirSayisi=0;
		 this.kodToplamSatirSayisi=0;
		 this.kodToplamFonksiyonSayisi=0;
		 this.YG=0;
		 this.YH=0;
		 this.yorumSapma=0;
	 }
	 
	
	 //////////////////// 
	 //JavaDoc hesaplama
	 public int JavaDocHesaplama()
	 {
		 /**
		* <p>
		*	(/**) ile baslayan satirlarla donguye girer ve diger elemana kadar JavDoc i artitir
		*</p>
		*/
		 boolean JavaDocKontrol=false; //javaDoc kontroluu
		 
		 
			 String line;
			 try (BufferedReader reader = new BufferedReader(new FileReader(path)))
		     {
		    	 while((line=reader.readLine()) !=null) 
		    	 {
		    			    if(line.trim().matches(".*\\/\\*\\*.*")) // /** 
		    			    {
			    			    JavaDocKontrol = true;
			    			    while(! line.trim().matches("^.*\\*/.*")) 
			    			    {
		    			    		line=reader.readLine(); 
				    			    JavaDocSatirSayisi++;			    			    		
			    			    }
			    			    JavaDocSatirSayisi--;
		    			    }
		    			    else   JavaDocKontrol = false;

		    	 }
		     }catch(IOException e)
		     {
		    	 e.printStackTrace();
		     }
		 
		 return this.JavaDocSatirSayisi;
	 }
	

///////////////////////
//yorum satir sayisi
	 public int YorumSHesaplama()
	 {
		 boolean yorumKontrolu=false; //javaDoc kontroluu
		
		   /**
			* <p>
			*	// ile baslayan ve /* - */ 
		  /**
		    * aralarainda olan satirlar sayisina artirir
			*</p>	
			*/
			 String line;
		     try (BufferedReader reader = new BufferedReader(new FileReader(path))) //dosyayi okan 
		     {
		    	 while((line=reader.readLine()) !=null) 
		    	 {
		    		 if(line.trim().matches(".*//.*")) // // ile basliyorsa yorum oldugu gosterir
		    		 {
		    			 yorumKontrolu=true; 
		    			 yorumSatirSayisi++;
		    		 }
		    		 else if(line.trim().matches(".*\\/\\*")) 
		    		 {
		    			 while(! line.trim().matches("^.*\\*/.*")) 
		    			 {
	    			    	line=reader.readLine(); 
		    				 yorumKontrolu=true; 
			    			 yorumSatirSayisi++; 
		    			 }
		    			 yorumSatirSayisi--; 
		    		 }else 	 yorumKontrolu=false; 


		    	 }
		     }catch(IOException e)
		     {
		    	 e.printStackTrace();
		     }
		    	
		 return this.yorumSatirSayisi;
	 }
	 
///////////////////////////
//kodun satir sayisi
	 public int kodSatir() // 
	 {
		 boolean KodKontrolu=false; 
		 /**
			* <p>
			*	sadeece kod icerigi satirlar okur
			*	/** ve // ve bos satir ve * ile basliyorsa girmiyor
			*</p>
			*/
		
			 String line;
		     try (BufferedReader reader = new BufferedReader(new FileReader(path))) //dosyayi okan 
		     {
		    	 while((line=reader.readLine()) !=null) 
		    	 {
		    		if(!line.trim().matches("^\\s*\\/\\*\\*.*")&&!line.trim().matches(".*\\*.*")&& !line.trim().matches("^\\s*//.*") && !line.trim().matches("^\\s*$"))
		    		{
		    			KodKontrolu=true;
		    			kodSatirSayisi++;
		    		}else KodKontrolu =false;
		    		 
		    	 }
		     }catch(IOException e)
		     {
		    	 e.printStackTrace();
		     }
		   
		 return this.kodSatirSayisi;
	 }
	
///////////////////////////////////
//line of code
	 public int LOC() 
	 {
		 /**
			* <p>
			*	Tum satirlari okur
			*</p>
			*/
			 String line;
		     try (BufferedReader reader = new BufferedReader(new FileReader(path))) 
		     {
		    	 while((line=reader.readLine()) !=null) 
		    	 {
		    		 kodToplamSatirSayisi++;
		    	 }
		     }catch(IOException e)
		     {
		    	 e.printStackTrace();
		     }
		
		 return this.kodToplamSatirSayisi;
	 }
	
/////////////////////////////////////////////
//Fonksiyon sayisi
	 public int fonksiyonSayisi()
	 {	
		 /**
			* <p>
			*	fonksiyonlar, public , private ve protected ile baslar ve fonksiyon belirtmesi icin () gerektigi icin artirir 
			*</p>
		*/
		 boolean fonksiyonKontrolu=false;
		
			 String line;
		     try (BufferedReader reader = new BufferedReader(new FileReader(path))) //dosyayi okan 
		     {
		    	 while((line=reader.readLine()) !=null) 
		    	 {
		    		
		    		 if(line.matches("^\\s*(public|private|protected)\\s+.*"))
		    		{
		    			 if(line.matches(".*\\(.*"))
		    			 {
		    				 fonksiyonKontrolu=true;
				    		 kodToplamFonksiyonSayisi++;
		    			 }else fonksiyonKontrolu=false;
		    		}else fonksiyonKontrolu=false;
		    
		    	 }
		     }catch(IOException e)
		     {
		    	 e.printStackTrace();
		     }
		   
		 return this.kodToplamFonksiyonSayisi;
	 }
	
/////////////////////////////////////////
	 public double YGHesap()
	 { 
		  this.YG=((this.JavaDocSatirSayisi+this.yorumSatirSayisi)*0.8)/this.kodToplamFonksiyonSayisi;
		 return this.YG; 
	 }
	 public double YHesap()
	 {
		  this.YH=(this.kodSatirSayisi/this.kodToplamFonksiyonSayisi)*0.3;
		 return this.YH;
	 }
	
	 public double yorumSapmaHesap()
	 {
		  this.yorumSapma=((100*YG)/YH)-100;
		 return this.yorumSapma;

	 }
}