using UnityEngine;
using System.Collections.Generic;

public class RandomColors : MonoBehaviour {
ControllerRB i;
private     int[]            e                 ; //проверка всех рядов 


void Awake()
{
i=gameObject.GetComponent<ControllerRB>();

}

public void RandomColor(int l,Texture[] c)                          //длина ряда,массив текстур                      
{
		i.texture[0]= c[0]                                          ;

		if(PlayerPrefs.GetInt("lightRestart")!=1)
		{


		int    r    = 1                                             ;//проверка заняты ли все ячейки
		int    rInt = 0                                             ;//сколько ячеек занял цвет
		int    aCl  = 1                                             ;//цвет из массива
		
		
		while(r<i.texture.Count)
		{
			
		int al = Random.Range(1,i.texture.Count) ;                   //случаййный выбор ячейки
		if(!i.texture[al])                                            //проверка ячейки на пустая или нет
		    {
		i.texture[al] = c[aCl] ;                                      //если ячейка пустая то помещаем в нее цвет
				r++;                                                  //уменьшаем количество не занятых ячеек 
				rInt++;                             
			}
		if(rInt==l)                                                   //если длина ряда равна кличеству занятых ячеек
			{
				rInt=0;
				aCl++ ;
			}
         }
		
		 }


		else
		{
			int rL   =1;                                 //начало и подсчет ячеек
			int restColors= l*Application.loadedLevel+1; //ячейки которые заменяем рестартом
			int rC   =1;                                 //цвета которые берем
			int rCon =0;                                 //счетчик смены цветов

			while(rL<restColors)
			{
				i.texture[rL]=c[rC];
				rL   ++;
				rCon ++; 

				if(rCon==l)                                                   //если длина ряда равна кличеству занятых ячеек
				{
					rCon = 0; 
					rC++    ;
				}
			}

		
			int    r2    = rL ;                                         ;//проверка заняты ли все ячейки
			int    rInt2 = 0                                              ;//сколько ячеек занял цвет
			int    aCl2  = rC                                           ;//цвет из массива


			while(r2<i.texture.Count)
			{

				int al2 = Random.Range(1,i.texture.Count) ;                   //случаййный выбор ячейки
				if(!i.texture[al2])                                            //проверка ячейки на пустая или нет
				{
					i.texture[al2] = c[aCl2] ;                                      //если ячейка пустая то помещаем в нее цвет
					r2++;                                                  //уменьшаем количество не занятых ячеек 
					rInt2++;                             
				}
				if(rInt2==l)                                                   //если длина ряда равна кличеству занятых ячеек
				{
					rInt2=0;
					aCl2++ ;
				}
			}

			i.Wins();

			if(gameObject.GetComponent<GUIGame>().win!=true)
			{
			PlayerPrefs.SetInt("lightRestart",0);
			}
			else
			{
			Application.LoadLevel(Application.loadedLevel);
			}
		}

}
}



