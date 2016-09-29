﻿using UnityEngine;
using System.Text;
using Assets.Scripts.Common;
using JsonSerialize_DESerialize;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Generate;


[RequireComponent(typeof(settingsGame))]

public class GUIGame : MonoBehaviour 
{

		private  settingsGame settings;         //Кеширование скриптов
		private  GameMenu     gameMenu;
		private  AddGold      goldAdd;
		private  AddMoves     moveAdd;
		private  EasyRestart  EasyRes;
		private  WinDefeat    wd;
		private  ControllerRB game;
		private  LogIn        gameLogIn;

		private  GUIStyle     windowStyle;

		private  Vector3      i;                //кеширование координатов центра,высоты,масштабов
		private  float        center;
		private  float        up;

		public   bool         win;              //победил ли игрок

		public   Texture2D[]  text;             //текстуры и шрифты
		public   Font[]       fontMenu;
		private  Color        color;	
		private  Color        colorGold;

		private  int          move  = 10;
		private  string       moveCode ;
		private  string       moveGame ;
		private  int          gold  = 0;
		private  int          lvl   = 0;

		private  bool         sound;            
		private  int          m;
		private  int          s;


		public   bool         menu;             //проверка на включеные меню
		public   bool         addG;
		public   bool         addM;
		public   bool         EasyRestart;
		public   bool         acc;   
		public   bool         accOF; 
		public   bool         menuExit;
		public   bool         trainingExit;

		private  bool         registr;

		public	 string 	  urlStat;

		void Awake()
		{
				Screen.sleepTimeout = SleepTimeout.NeverSleep;
				lvl         = Application.loadedLevel;
				game        = gameObject.GetComponent<ControllerRB> ();

				moveCode    = Base64.Encode("30");	
				moveGame    = Base64.Encode("0");


				color.r     = 68.0f/255.0f;
				color.g     = 66.0f/255.0f;
				color.b     = 63.0f/255.0f;
				color.a     = 1;


				colorGold.r = 238.0f/255.0f;
				colorGold.g = 246.0f/255.0f;
				colorGold.b = 99.0f/255.0f;
				colorGold.a = 1;



				menu        = false;
				addG        = false;
				addM        = false;
				EasyRestart = false;
				acc         = false;
				accOF       = false;
				registr     = false;


				goldAdd     = gameObject.GetComponent<AddGold>();
				EasyRes     = gameObject.GetComponent<EasyRestart>();
				moveAdd     = gameObject.GetComponent<AddMoves>();
				gameMenu    = gameObject.GetComponent<GameMenu>();
				settings    = gameObject.GetComponent<settingsGame>();
				wd          = gameObject.GetComponent<WinDefeat>();
				gameLogIn   = gameObject.GetComponent<LogIn>();

				center      = Screen.width / (Screen.height / 720.0f) ;
				up          = Screen.height/ (Screen.height / 720.0f) ;
				i.x         = Screen.height/720.0f;
				i.y         = Screen.height/720.0f;
				i.z         = 1;



		}

		public void Start()

		{
				if (PlayerPrefs.GetString ("login") != "" && PlayerPrefs.GetString ("pass") != "") 
				{
						StartCoroutine (GoldInfo ());
				}
		}


		void Update()
		{


				if (Input.GetKeyDown(KeyCode.Escape) || menuExit == true  || trainingExit == true ) 
				{
						menu        = false;
						addG        = false;
						addM        = false;
						EasyRestart = false;
						acc         = false;
						accOF       = false;
						registr     = false;
				}



				if (menu == false && addG == false && addM == false && win == false && EasyRestart == false && move > 0) 
				{
						game.enabled=true;

				}

				if (menu == true || addG == true || addM == true || win == true || EasyRestart == true || move <= 0 ) 
				{

						game.enabled=false;			

				}


				if (win == true ) 
				{
						menu        = false;
						addG        = false;
						addM        = false;
						EasyRestart = false;
				}


				if (menu == true || addG == true || addM == true || win == true || EasyRestart == true || move == 0 || menuExit == true || trainingExit == true)
				{				
						Time.timeScale=0;
				}
				else
				{
						Time.timeScale=1;
				}

				m=(int)(Time.timeSinceLevelLoad/60.0f);
				s=(int)(Time.timeSinceLevelLoad-m*60.0f);

		}

		public void Move ()
		{

				if (PlayerPrefs.GetString ("compani") == "true") 
				{
						move = System.Convert.ToInt32 (Base64.Decode (moveCode))-20 - 1;
						moveCode = Base64.Encode (System.Convert.ToString (move+20));
						moveGame = Base64.Encode (System.Convert.ToString (System.Convert.ToInt32 (Base64.Decode (moveGame)) + 1));
				}

		}

		public void MoveBay (int moveB)
		{
				move     =  System.Convert.ToInt32(Base64.Decode(moveCode))+moveB; ;
				moveCode =  Base64.Encode(System.Convert.ToString(move));

				StartCoroutine(GoldInfo());
		}





		void OnGUI()
		{
				GUI.matrix = Matrix4x4.Scale(i);


				GUIStyle style2 = GUI.skin.GetStyle ("button");	
				style2.normal.background = text [1];
				style2.hover.background = text [1];
				style2.active.background = text [1];

				style2.normal.textColor = color; 
				style2.hover .textColor = color;
				style2.active.textColor = color;

				style2.font = fontMenu [0];
				style2.fontSize = 24;

				if (menu==false && addG == false && addM == false && win == false && EasyRestart == false && move > 0 ) 
				{
						if (GUI.Button (new Rect (center - 160, up - 160, 140, 140), settings.languages [18])&& acc==false) 
						{

								addM        = false;
								win         = false;
								EasyRestart = false;
								addG        = false;
								menu        = true;

						}

				}

				if (PlayerPrefs.GetString ("login") != "" && PlayerPrefs.GetString ("pass") != "" && registr == true) 
				{
						registr=false;
				}



				if (PlayerPrefs.GetString ("compani") == "true") 
				{
						CompaniMenu ();
						if(menu==true && registr == false)
						{
								gameMenu.MenuOn (text, fontMenu, acc);
						}
				} 
				else 
				{
						if(menu==true && registr == false)
						{
								gameMenu.MenuOnFree (text, fontMenu, acc);
						}
				}

				if (addG == true || addM == true || EasyRestart == true || registr == true  ) 
				{			
						if(PlayerPrefs.GetString("login") == "" ||  PlayerPrefs.GetString("pass")=="")
						{
								GUI.DrawTexture(new Rect(0,0,center,up),text[3]);
								gameLogIn.LogInPlayer();

						}

						else
						{

								if (addG == true) 
								{
										goldAdd.PurchasesRubiks (text, fontMenu, gold, acc);
								}

								if (addM == true) 
								{

										moveAdd.Purchases (text, fontMenu, gold, acc);
								}
								if (EasyRestart == true) 
								{
										EasyRes.EasyRGme (text, fontMenu, gold, acc);
								}
						}
				}

				if (addG == true || addM == true || EasyRestart == true || menu == true) 
				{
						style2.normal.background = text [1];
						style2.hover.background = text [1];
						style2.active.background = text [1];

						style2.normal.textColor = color; 
						style2.hover .textColor = color;
						style2.active.textColor = color;

						style2.font = fontMenu [0];
						style2.fontSize = 18;

						if (GUI.Button (new Rect (center - 160, up - 160, 140, 140), settings.languages [19])&& acc==false) 
						{
								addG        = false;
								addM        = false;
								EasyRestart = false;
								menu        = false;
								registr     = false;
						}

				}



				if (win == true && s > 1 && menu == false && addG == false && addM == false && EasyRestart == false && PlayerPrefs.GetString("compani") == "true" ) 
				{
						int mg = System.Convert.ToInt32(Base64.Decode(moveGame));
						wd.Wictory(mg,m,s);
				}

				if (move == 0 && menu == false && addG == false && addM == false && EasyRestart == false && PlayerPrefs.GetString("compani") == "true" ) 
				{
						wd.Defeat();
				}

				if(menu == true || addM == true || addG == true || EasyRestart == true)
				{

						style2.normal.background = text [14];
						style2.hover.background  = text [14];
						style2.active.background = text [14];

						if (GUI.Button (new Rect (20, up - 160, 140, 140),"")) 
						{
								if(PlayerPrefs.GetString("login")!= "" && PlayerPrefs.GetString("pass")!= "")
								{
										acc = true;
								}
								else
								{
										registr=true;
								}
						}

				}

				if(acc == true  )
				{
						GUI.Window(0,new Rect(0,0,center+100,up+100),PersonalArea,"",windowStyle);
				}

				if (menuExit == true  || trainingExit == true ) 
				{
						GUI.Window(0,new Rect(0,0,center+100,up+100),PersonalAreaExitGame,"",windowStyle);
				}

		}






		public void CompaniMenu()
		{

				GUIStyle style  = GUI.skin.GetStyle ("label");

				style.normal.background  = null;
				style.hover.background   = null;
				style.active.background  = null;	

				style.normal.textColor   = Color.gray;

				style.alignment = TextAnchor.MiddleCenter;
				style.fontSize = 26;
				style.font = fontMenu [2];


				GUI.Label (new Rect(20,20,140,30),settings.languages[12]);
				GUI.Label (new Rect(center-160,20,140,30),settings.languages[13]);

				style.normal.textColor = Color.white;
				style.font = fontMenu [0];

				style.fontSize = 40;

				GUI.Label (new Rect(20,60,140,44),""+gold);
				GUI.Label (new Rect(center-160,60,140,44),""+move);

				GUIStyle style2  = GUI.skin.GetStyle ("button");
				style2.normal.background = text [0];
				style2.hover.background  = text [0];
				style2.active.background = text [0];

				style2.normal.textColor = Color.black; ;
				style2.hover .textColor = Color.black;
				style2.active.textColor = Color.black;

				style2.font = fontMenu [0];
				style2.fontSize = 22;


				if (GUI.Button (new Rect (20, 120, 140, 60), settings.languages [14]) && acc==false) 
				{
						if(menu==false && addM == false && addG == false && EasyRestart == false )
						{
								addG = true;
						}

				}

				if (GUI.Button (new Rect (center - 160, 120, 140, 60), settings.languages [14])&& acc==false)
				{
						if(menu==false && addM == false && addG == false && EasyRestart == false )
						{
								addM = true;
						}
				}

				style.fontSize = 24;		

				GUI.Label (new Rect(20,up/2-60,140,40),settings.languages[15]);
				GUI.Label (new Rect(center-160,up/2-60,140,40),settings.languages[16]);

				style.fontSize = 50;
				GUI.Label (new Rect(20,up/2-40,140,80),""+lvl);
				if (s >= 10) {
						GUI.Label (new Rect (center - 160, up / 2 - 40, 140, 80), "" + m + ":" + s);
				} 
				else 
				{
						GUI.Label (new Rect (center - 160, up / 2 - 40, 140, 80), "" + m + ":0" + s);
				}

				style2.normal.background = text [1];
				style2.hover.background = text [1];
				style2.active.background = text [1];

				style2.normal.textColor = color; ;
				style2.hover .textColor = color;
				style2.active.textColor = color;

				style2.font = fontMenu [0];
				style2.fontSize = 24;

				if (menu == false && addM == false && addG == false && EasyRestart == false)
				{
						if (GUI.Button (new Rect (20, up - 160, 140, 140), settings.languages [17])) 
						{
								EasyRestart = true;
						}

				}

		}



		public void PersonalArea(int windowID)

		{

				GUI.DrawTexture(new Rect(0,0,center,up),text[3]);

				GUIStyle style  = GUI.skin.GetStyle ("label");
				GUIStyle style2 = GUI.skin.GetStyle ("button");

				style.normal.background = text [15];
				GUI.Label(new Rect(center/2-341,up/2-98,682,196),"");//Фон

				style.fontStyle = FontStyle.Normal;

				style.normal.textColor = Color.white; ;
				style.hover .textColor = Color.white; ;
				style.active.textColor = Color.white; ;



				if(accOF==false)
				{
						style2.normal.textColor = Color.white; ;
						style2.hover .textColor = Color.white; ;
						style2.active.textColor = Color.white; ;
						style2.fontSize=30;
						style2.active.background  = text [16];
						style2.normal.background  = text [16];
						style2.hover.background = text [16];

						if(GUI.Button(new Rect(center/2-312,up/2+65,624,74), settings.languages [63]))//Сменить аккаунт
						{
								accOF=true;			
						}

						style.normal.background = text [15];
						GUI.Label(new Rect(center/2-341,up/2-98,682,196),"");//Фон

						style.normal.background = text [17];
						GUI.Label(new Rect(center/2-301,up/2-58,120,120),"");

						style.alignment = TextAnchor.MiddleLeft;
						style.normal.background = null;
						style.font=fontMenu[0];
						style.fontSize=30;


						GUI.Label(new Rect(center/2-141,up/2-58,460,50),PlayerPrefs.GetString("login"));

						style.fontSize=24;

						style.normal.textColor = colorGold; ;
						style.hover .textColor = colorGold; ;
						style.active.textColor = colorGold; ;

						GUI.Label(new Rect(center/2-141,up/2-8,160,50),"G: "+gold);
						style2.fontSize=24;
						style2.normal.textColor = Color.white; ;
						style2.hover .textColor = Color.white; ;
						style2.active.textColor = Color.white; ;

						style2.active.background  = text [18];
						style2.normal.background  = text [18];
						style2.hover.background   = text [18];

						if(GUI.Button(new Rect(center/2+75,up/2-12,226,70), settings.languages [62]))//Закрыть
						{
								acc  = false;
						}
				}
				else
				{
						style2.normal.textColor   = Color.white; ;
						style2.hover .textColor   = Color.white; ;
						style2.active.textColor   = Color.white; ;

						style2.active .background  = text [19];
						style2.normal .background  = text [19];
						style2.hover.background    = text [19];

						style2.fontSize=24;

						if(GUI.Button(new Rect(center/2-290,up/2+63,288,74), settings.languages [65]))//Подтверждение
						{
								PlayerPrefs.SetString("login","");
								PlayerPrefs.SetString("pass" ,"");
								Application.LoadLevel("log_In");
						}

						if(GUI.Button(new Rect(center/2+2,up/2+63,288,74), settings.languages [66]))//Отмена
						{
								accOF  = false;
						}

						style.normal.background = text [15];
						GUI.Label(new Rect(center/2-341,up/2-98,682,196),"");//Фон

						style.alignment = TextAnchor.MiddleCenter;
						style.normal.background = null;
						style.font=fontMenu[0];
						style.fontSize=24;

						style.normal.textColor = Color.white; ;
						style.hover .textColor = Color.white; ;
						style.active.textColor = Color.white; ;

						GUI.Label(new Rect(center/2-301,up/2-98,602,196), settings.languages [64]);//Предупреждение о выходе в регистрацию

				}




		}

		public void PersonalAreaExitGame(int windowID)

		{
				GUI.DrawTexture(new Rect(0,0,center,up),text[3]);

				GUIStyle style  = GUI.skin.GetStyle ("label");
				GUIStyle style2 = GUI.skin.GetStyle ("button");

				style2.normal.textColor   = Color.white; ;
				style2.hover .textColor   = Color.white; ;
				style2.active.textColor   = Color.white; ;

				style2.active .background  = text [19];
				style2.normal .background  = text [19];
				style2.hover.background    = text [19];

				style2.fontSize=24;

				if(GUI.Button(new Rect(center/2-290,up/2+63,288,74), settings.languages [65]))//Подтверждение
				{
						if(menuExit==true)
						{
								Application.LoadLevel("menu");
						}
						else
						{
								PlayerPrefs.SetInt("trainingLevel",Application.loadedLevel);
								Application.LoadLevel("training");
						}
				}

				if(GUI.Button(new Rect(center/2+2,up/2+63,288,74), settings.languages [66]))//Отмена
				{
						menuExit      = false;
						trainingExit  = false;
						menu          = true;
				}




				style.fontStyle = FontStyle.Normal;

				style.normal.background = text [15];

				style.normal.textColor = Color.white; ;
				style.hover .textColor = Color.white; ;
				style.active.textColor = Color.white; ;

				GUI.Label(new Rect(center/2-341,up/2-98,682,196),"");//Фон 




				style.alignment = TextAnchor.MiddleCenter;
				style.normal.background = null;
				style.font=fontMenu[0];
				style.fontSize=24;

				style.normal.textColor = Color.white; ;
				style.hover .textColor = Color.white; ;
				style.active.textColor = Color.white; ;

				GUI.Label(new Rect(center/2-301,up/2-98,602,196), settings.languages [89]);//Предупреждение о выходе в регистрацию











		}



		public IEnumerator GoldInfo()
		{
				Dictionary<string, string> gameData = new Dictionary<string, string>();
				gameData.Add("code" ,"6Av4TpIt");
				gameData.Add("login",PlayerPrefs.GetString("login"));

				string json        = JsonSerialize_DESerialize.Json.SerializeStringIndDictionary (gameData);
				string sendingBase = Base64.Encode (json);
				sendingBase = GenerateKey.CreatingTrash (sendingBase);

				WWWForm form = new WWWForm() ;
				form.AddField("gold",sendingBase);
				WWW dowload = new WWW (urlStat,form);
				yield return dowload;
				string[] returnBase = Base64.Decode(dowload.text).Split(new char[] {'|'});


				if(returnBase[0]=="connected")
				{
						gold=System.Convert.ToInt32(returnBase[1]);
				}
				else
				{
						gold=0;
				}



		}


}









