/**
*
* @author Sara Mohamed
* @since 2/04/2023 - 4/04/2023
* <p>
*	GitHub uzerine incelemek 
* </p>
*/
package odev;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import  java.net.HttpURLConnection;
import java.net.URL;
import java.nio.file.Files;
import java.util.ArrayList;
import java.util.Comparator;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

import org.eclipse.jgit.api.Git;
import org.eclipse.jgit.api.errors.GitAPIException;
import org.eclipse.jgit.api.errors.InvalidRemoteException;
import org.eclipse.jgit.api.errors.TransportException;

import java.io.File;
import java.nio.charset.StandardCharsets;
import java.nio.file.Path;
import java.nio.file.Paths;


public class GitHubInceleme {
	private String link;
	private String path;
	private String className;
	private ArrayList<String> classesName;
	private ArrayList<String> javaFiles;
	private ArrayList<String> classes;
	private ArrayList<String> classesPaths;
	
	public GitHubInceleme(String URL)
	{
		this.link=URL;
		javaFiles = new ArrayList<>();
		classes = new ArrayList<>();
		classesPaths = new ArrayList<>();
	}
	public void download() throws IOException
	{
		/**
		* <p>
		*	GitHubin kod dosyayi indirmek - klonlamak
		*	defualt olarak indirme yeri belirlemesi
		*	GitHub icindeki dosyalari aramak
		* </p>
		*/
		 String defaultDirectory = "./JavaFiles/";
	     Path directoryPath = Paths.get(defaultDirectory); 
		 File localPath = directoryPath.toFile(); 
		
         try {
			Git.cloneRepository()
			    .setURI(link)
			    .setDirectory(localPath)
			    .call();
			//klonlama 
		} catch (Exception e) {
			e.printStackTrace();
		}
        
         searchJavaFiles(directoryPath.toFile()); //2. adima
	}
	public void BetirdiktenSonraDelete()throws IOException
	{
		/**
		* <p>
		*	Proje biitikten sonra indirdigi dosya silmesi icin olusturuldu
		*	Files uzerine gecer ve try catch ile silmesine saglanir 
		* </p>
		*/
		Path defaultPath=Paths.get("./JavaFiles/");
		
	     try {
	            Files.walk(defaultPath)
	                    .sorted(Comparator.reverseOrder())
	                    .map(Path::toFile)
	                    .forEach(File::delete);
	        } catch (IOException e) {
	            e.printStackTrace();
	        }     

	}
	public void searchJavaFiles(File directory)
	{
		/**
		* <p>
		*	Dosyalar liste olarak dizileme 
		*	.java uzantili dosyalar diziye eklenir
		*	ClassesFromFiles e gonderilir
		* </p>
		*/
		File[] files = directory.listFiles(); 
		if (files !=null)
		{
			for(File file:files)
			{
				if(file.getName().endsWith(".java"))
				{	
					if(!file.getName().startsWith("I")) {
						javaFiles.add(file.getAbsolutePath());
						classesFromFiles(file); //3.adim
					}else continue;
				}else
					searchJavaFiles(file);
			}
		}
	}
	

	public void classesFromFiles(File file)
	{
		/**
		* <p>
		*	Sadece classlar almak icin olusturildu
		*	Fileyi karakterleri okumak ve StringBuldier ile ifade tamamlamak(cumle)
		*	ve String ifadeleri birlestirmekle (metin) olusturmak 
		*	metrin uzerine class ifadesine araniyor ve array list icinde depolanir
		* </p>
		*/
		try (BufferedReader reader = Files.newBufferedReader(file.toPath(), StandardCharsets.UTF_8))
		{
		    StringBuilder metin = new StringBuilder();//satir satir okunmasi
		    String line;
		    while ((line = reader.readLine()) != null) 
		    {
		        metin.append(line).append("\n");//metini olusturacak sekilde dizi nesneye atilir
		    }
		    
		    String fileContent = metin.toString();
		    Pattern pattern = Pattern.compile("class\\s+(\\w+)");
		    Matcher matcher = pattern.matcher(fileContent);
		    while (matcher.find()) 
		    {
		        classes.add(matcher.group(1));
		    }
		    this.path=file.toPath().toString();
		    } catch (IOException e) {
		    e.printStackTrace();
		}
	}
	public ArrayList<String> PathDondurme()
	{
		/**
		* <p>
		*	JavaFiles dondurme (uzantilari ile)
		* </p>
		*/
		return this.javaFiles;
	}
	
	public ArrayList<String> GetClassList(){
		/**
		* <p>
		*	Classlar dondurme
		* </p>
		*/
		return classes;
	}

	 
}
