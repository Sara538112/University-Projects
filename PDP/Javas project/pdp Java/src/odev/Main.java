/**
*
* @author Sara Mohamed
* @since 2/04/2023
* <p>
*	GitHubi almak ve datayi indirmek 
* </p>
*/
package odev;

import java.io.BufferedReader;
import java.io.File;
import java.io.IOException;
import java.io.InputStreamReader;
import java.net.HttpURLConnection;
import java.util.ArrayList;
import java.io.FileOutputStream;
import java.io.OutputStream;
import java.net.URL;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

public class Main {
	public static void main(String[] args)
	{
		
		BufferedReader okuyucu = new BufferedReader(new InputStreamReader(System.in));
	    
		try  
		{
			System.out.println("GitHub URL :");
			String githubLink= okuyucu.readLine();  //kullancidan link alma
			
			GitHubInceleme inceleme = new GitHubInceleme(githubLink); // analiz package'daki githubincelemin nesnesine  aktarma
			if (new File("./JavaFiles/").exists()) {
				inceleme.BetirdiktenSonraDelete();
			}
			
			inceleme.download();
			
			ArrayList<String> siniflar =inceleme.GetClassList(); 
			int classIndex = 0;
			var paths=inceleme.PathDondurme();
			for(String Sinif:siniflar)
			{
				String sinifPath = paths.get(classIndex); 
				ClassesOperations sinifOperations=new ClassesOperations(Sinif,sinifPath);
				/**
				* <p>
				*	GitHubtaki Classlar listesi aldiktan sonra tek tek okunmasi icin dongu olsutdum ve path'lari indexle alindi 
				*	ClassesOperationsa paramitre olarak verilmesi. 
				* </p>
				*/
				
				System.out.println("Sinif Adi :"+Sinif + ".java");
				System.out.println("Javadoc Satir Sayisi :" +sinifOperations.JavaDocHesaplama());
				System.out.println("Yorum Satir Sayisi :" +sinifOperations.YorumSHesaplama());
				System.out.println("Kod Satir Sayisi :" +sinifOperations.kodSatir());
				System.out.println("LOC :"+sinifOperations.LOC());
				System.out.println("Fonksiyon Sayisi :"+sinifOperations.fonksiyonSayisi());
				System.out.println("YG :"+sinifOperations.YGHesap()+"    YH :"+sinifOperations.YHesap());				
				System.out.println("Yorum Sapma Yuzdesi :"+"%" +sinifOperations.yorumSapmaHesap());
				System.out.println("--------------------------------------------------");

				classIndex++;

			}
			    

		}
		catch(IOException e)
		{ 
			e.printStackTrace();
		}
		
		
	}



	
}


