using UnityEngine;
using System.Collections.Generic;
[RequireComponent(typeof(RandomColors))]
[RequireComponent(typeof(MovingСolors))]
[RequireComponent(typeof(GUIGame))]

public class ControllerRB : MonoBehaviour 
{
		public      AudioClip        gameSound         ;
		private     GUIGame          guiG              ;

		public      Texture[]        gameEfect         ; //текстуры верхней полоски с доп ячейкой
		public      int              lenght            ; //длина ряда
		public      int[]            coordinates       ; //координаты нажатой кнопки
		public      Texture[]        colors            ; //массив цветов ячеек или количество цветов используемых для уровня
		public      List<Texture>    texture           ; //массив всех ячеек
		public      Rect             ButtonTap         ; //позиция нажатой кнопки
		public     int              size              ; //количество ячеек
		public     float            sizeButton        ; //размер кнопки
		public     float            RectButton        ; //координаты начала ряда
		public     bool             iController       ; //проверка на нажатие
		public 		float 			verticalOffset = 80;


		private     int[]            e                 ; //проверка всех рядов 
		private     AudioSource      source            ;
		public      int              moreCell          ; //смещение доп ячейки



		public void Awake()
		{
				source = GetComponent<AudioSource>();
				guiG   = GetComponent<GUIGame>();

				if (PlayerPrefs.GetString ("compani") == "true") 
				{
						PlayerPrefs.SetInt ("PlayerLevel", Application.loadedLevel);
						if(PlayerPrefs.GetInt ("ProgressCompani")<Application.loadedLevel)
						{
								PlayerPrefs.SetInt ("ProgressCompani", Application.loadedLevel);
						}
				}

				e=new int[lenght];
				coordinates       = new int[2]                                 ;
				size              = lenght*lenght                              ;	
				sizeButton        = (Screen.width-40)/(lenght+1)              ;
				float l=0.0f;
				l=(float)lenght;
				RectButton        = Screen.width/2 - sizeButton*(l/2)          ;




		}

		void Start()
		{
				gameObject.GetComponent<RandomColors>().RandomColor(lenght,colors);

		}

		void Update()
		{
				moreCell=Mathf.Clamp(moreCell,1,lenght);



				if(Input.touchCount == 0)
				{
						coordinates[0]=-1;
						coordinates[1]=-1;
						iController=true;
				}
				ButtonTap= new Rect(RectButton+(sizeButton*(coordinates[0]-1)),sizeButton*(coordinates[1]),sizeButton,sizeButton);

				if (PlayerPrefs.GetString ("compani") == "true") 
				{
						Wins ();
				}

		}

		public void Wins()
		{
				for(int i=0;i<lenght;i++)
				{
						int j=0;
						while(j<lenght)
						{
								if(texture[1+(i*lenght)].name==texture[1+(i*lenght)+j].name)
								{
										j++;
								}
								else
								{
										j=lenght+1;
								}
						}
						e[i]=j;
				}


				int w=0;
				while(w<lenght)
				{
						if(e[w]==lenght)
						{
								w++;
						}
						else
						{
								w=lenght+1;
						}
				}
				if(w==lenght)
				{
						guiG.win=true;
				}
				else
				{
						guiG.win=false;
				}

		}







		public void OnGUI()
		{

				GUIStyle style = GUI.skin.GetStyle ("button");

				style.normal.background = null;
				style.hover.background = null;
				style.active.background = null;

				style.padding.left = 0;
				style.padding.right = 0;
				style.padding.top = 0;
				style.padding.bottom = 0;



				GUI.depth = 5;
				GUI.DrawTexture(new Rect(RectButton,verticalOffset,sizeButton*lenght,sizeButton),gameEfect[0]);

				for(int g=0;g<lenght;g++)
				{
						if(moreCell != g+1)
						{
								if(GUI.RepeatButton(new Rect(RectButton+(sizeButton*g),verticalOffset,sizeButton,sizeButton),gameEfect[1]))
								{
										if(Time.timeScale > 0)
										{
												if (PlayerPrefs.GetInt ("sound") != 1) 
												{
														source.PlayOneShot(gameSound,1);
												}

												moreCell=g+1;
												coordinates[0]=g+1;
												coordinates[1]=0;
												iController=false;
										}
								}
						}

				}

				if(GUI.RepeatButton(new Rect(RectButton+((moreCell-1)*sizeButton),verticalOffset,sizeButton,sizeButton),texture[0])) //Дополнительная ячейка
				{
						if(iController==true)
						{
								coordinates[0]=moreCell;
								coordinates[1]=0;
								iController=false;
						}
				}



				int s=0;                                                             //переменная линий


				int l=0;                                                            //контроль ячеек в ряду
				for(int i=1;i<texture.Count;i++)                                     //отрисовка цветовых ячеек на екран
				{

						if(l==lenght)                                                        //если количество ячеек равняется заданой длине то переходим к следущему ряду
						{
								s++;                                                                   
								l=0;
						}
						if(GUI.RepeatButton(new Rect(RectButton+(sizeButton*s),verticalOffset+sizeButton*(l+1),sizeButton,sizeButton),texture[i]))
						{
								if(iController==true)
								{
										coordinates[0]=s+1;
										coordinates[1]=l+1;
										iController=false;
								}
						}
						l++;

				}	

		}


}

