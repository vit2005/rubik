using UnityEngine;
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

		private  Vector3      j;                //кеширование координатов центра,высоты,масштабов
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

		public int fontsize24 = 20;

		public List<float> gold1 = new List<float> {20,20,140,30};
		public List<float> gold2 = new List<float> {20,50,140,60};
		public List<float> gold3 = new List<float> {20,110,140,40};
		public List<float> moves1 = new List<float> {160,20,140,30};
		public List<float> moves2 = new List<float> {160,50,140,60};
		public List<float> moves3 = new List<float> {160,110,140,40};
		public List<float> time1 = new List<float> {73,20,140,30};
		public List<float> time2 = new List<float> {70,320,140,80};

		public List<float> restart = new List<float> {30,115,170,90};
		public List<float> menu_btn = new List<float> {247,115,170,90};

		public List<float> ico1;
		public List<float> ico2;
		public List<float> ico3;

		public List<float> pa1;
		public List<float> pa2;
		public List<float> pa3;
		public List<float> pa4;
		public List<float> pa5;
		public List<float> pa6;
		public List<float> pa7;
		public List<float> pa8;
		public List<float> pa9;
		public List<float> pa10;
		public List<float> pa11;

		public List<float> paeg1 = new List<float> {186,65,185,74};
		public List<float> paeg2 = new List<float> {3,65,185,74};
		public List<float> paeg3 = new List<float> {215,65,430,165};
		public List<float> paeg4 = new List<float> {201,60,400,150};

		void Awake()
		{
				Screen.sleepTimeout = SleepTimeout.NeverSleep;
				lvl         = Application.loadedLevel;
				game        = gameObject.GetComponent<ControllerRB> ();

				moveCode    = Base64.Encode("30");	
				moveGame    = Base64.Encode("0");

				urlStat = "https://mobileapi.rozumgames.com/statistic/gold";

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
				j.x         = Screen.height/720.0f;
				j.y         = Screen.height/720.0f;
				j.z         = 1;

				gold1 = new List<float> {20,20,140,30};
				gold2 = new List<float> {20,50,140,60};
				gold3 = new List<float> {20,110,140,40};
				moves1 = new List<float> {160,20,140,30};
				moves2 = new List<float> {160,50,140,60};
				moves3 = new List<float> {160,110,140,40};
				time1 = new List<float> {73,20,140,30};
				time2 = new List<float> {70,320,140,80};

				restart = new List<float> {30,115,170,90};
				menu_btn = new List<float> {196,115,170,90};

				ico1 = new List<float> {80,115,90,90};
				ico2 = new List<float> {0,0,100,100};
				ico3 = new List<float> {0,0,100,100};

				pa1 = new List<float> {232,100,465,195};
				pa2 = new List<float> {196,60,395,80};
				pa3 = new List<float> {209,100,418,195};
				pa4 = new List<float> {180,62,120,120};
				pa5 = new List<float> {44,60,460,50};
				pa6 = new List<float> {43,8,160,50};
				pa7 = new List<float> {26,12,155,70};
				pa8 = new List<float> {182,90,185,74};
				pa9 = new List<float> {7,90,178,74};
				pa10 = new List<float> {204,95,408,224};
				pa11 = new List<float> {201,65,400,160};

				paeg1 = new List<float> {186,65,185,74};
				paeg2 = new List<float> {3,65,185,74};
				paeg3 = new List<float> {215,65,430,165};
				paeg4 = new List<float> {201,60,400,150};


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
				GUI.matrix = Matrix4x4.Scale(j);


				GUIStyle style2 = GUI.skin.GetStyle ("button");	
				style2.normal.background = text [1];
				style2.hover.background = text [1];
				style2.active.background = text [1];

				style2.normal.textColor = color;
				style2.hover .textColor = color;
				style2.active.textColor = color;

				style2.font = fontMenu [0];
				style2.fontSize = 20;

				if (menu==false && addG == false && addM == false && win == false && EasyRestart == false && move > 0 ) 
				{
						if (GUI.Button (new Rect (center - menu_btn[0], up - menu_btn[1], menu_btn[2], menu_btn[3]), settings.languages [18])&& acc==false) 
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
						if (menu == false && addG == false && addM == false && win == false && EasyRestart == false && move > 0) {
								CompaniMenu ();
						}
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

						style2.normal.textColor = color;
						style2.hover .textColor = color;
						style2.active.textColor = color;

						style2.font = fontMenu [0];
						style2.fontSize = 18;

						if (GUI.Button (new Rect (center - menu_btn[0], up - menu_btn[1], menu_btn[2], menu_btn[3]), settings.languages [19])&& acc==false) 
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

						if (GUI.Button (new Rect (ico1[0], up - ico1[1], ico1[2], ico1[3]),"")) 
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
						GUI.Window(0,new Rect(ico2[0],ico2[1],center+ico2[2],up+ico2[3]),PersonalArea,"",GUIStyle.none);
				}

				if (menuExit == true  || trainingExit == true ) 
				{
						GUI.Window(0,new Rect(ico3[0],ico3[1],center+ico3[2],up+ico3[3]),PersonalAreaExitGame,"",GUIStyle.none);
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


				GUI.Label (new Rect(gold1[0],gold1[1],gold1[2],gold1[3]),settings.languages[12]); //gold
				GUI.Label (new Rect(center-moves1[0],moves1[1],moves1[2],moves1[3]),settings.languages[13]); //move

				style.normal.textColor = Color.white;
				style.font = fontMenu [0];

				style.fontSize = 40;

				GUI.Label (new Rect(gold2[0],gold2[1],gold2[2],gold2[3]),""+gold); //gold
				GUI.Label (new Rect(center-moves2[0],moves2[1],moves2[2],moves2[3]),""+move); //move

				GUIStyle style2  = GUI.skin.GetStyle ("button");
				style2.normal.background = text [0];
				style2.hover.background  = text [0];
				style2.active.background = text [0];
				style2.normal.textColor = Color.black;
				style2.hover .textColor = Color.black;
				style2.active.textColor = Color.black;

				style2.font = fontMenu [0];
				style2.fontSize = 22;


				if (GUI.Button (new Rect (gold3[0], gold3[1], gold3[2], gold3[3]), settings.languages [14]) && acc==false) //add gold
				{
						if(menu==false && addM == false && addG == false && EasyRestart == false )
						{
								addG = true;
						}

				}

				if (GUI.Button (new Rect (center - moves3[0], moves3[1], moves3[2], moves3[3]), settings.languages [14])&& acc==false) //add move
				{
						if(menu==false && addM == false && addG == false && EasyRestart == false )
						{
								addM = true;
						}
				}

				style.fontSize = fontsize24;		

				//GUI.Label (new Rect(20,up/2-60,140,40),settings.languages[15]); //Level
				GUI.Label (new Rect(center/2-time1[0],time1[1],time1[2],time1[3]),settings.languages[16]); //time

				style.fontSize = 50;
				//GUI.Label (new Rect(20,up/2-40,140,80),""+lvl); //Level
				if (s >= 10) {
						GUI.Label (new Rect (center/2 - time2[0], up / 2 - time2[1], time2[2], time2[3]), "" + m + ":" + s); //time
				} 
				else 
				{
						GUI.Label (new Rect (center/2 - time2[0], up / 2 - time2[1], time2[2], time2[3]), "" + m + ":0" + s); //time
				}

				style2.normal.background = text [1];
				style2.hover.background = text [1];
				style2.active.background = text [1];

				style2.normal.textColor = color;
				style2.hover .textColor = color;
				style2.active.textColor = color;

				style2.font = fontMenu [0];
				style2.fontSize = fontsize24;

				if (menu == false && addM == false && addG == false && EasyRestart == false)
				{
						if (GUI.Button (new Rect (restart[0], up - restart[1], restart[2], restart[3]), settings.languages [17])) 
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
				//GUI.Label(new Rect(center/2-pa1[0],up/2-pa1[1],pa1[2],pa1[3]),"");//Фон

				style.fontStyle = FontStyle.Normal;

				style.normal.textColor = Color.white;
				style.hover .textColor = Color.white;
				style.active.textColor = Color.white;



				if(accOF==false)
				{
						style2.normal.textColor = Color.white;
						style2.hover .textColor = Color.white;
						style2.active.textColor = Color.white;
						style2.fontSize=30;
						style2.active.background  = text [16];
						style2.normal.background  = text [16];
						style2.hover.background = text [16];

						if(GUI.Button(new Rect(center/2-pa2[0],up/2+pa2[1],pa2[2],pa2[3]), settings.languages [63]))//Сменить аккаунт
						{
								accOF=true;			
						}

						style.normal.background = text [15];
						GUI.Label(new Rect(center/2-pa3[0],up/2-pa3[1],pa3[2],pa3[3]),"");//Фон

						style.normal.background = text [17];
						GUI.Label(new Rect(center/2-pa4[0],up/2-pa4[1],pa4[2],pa4[3]),"");
						//GUI.Label(new Rect(0,0,0,0),"");

						style.alignment = TextAnchor.MiddleLeft;
						style.normal.background = null;
						style.font=fontMenu[0];
						style.fontSize=30;


						GUI.Label(new Rect(center/2-pa5[0],up/2-pa5[1],pa5[2],pa5[3]),PlayerPrefs.GetString("login"));

						style.fontSize=fontsize24;

						style.normal.textColor = colorGold;
						style.hover .textColor = colorGold;
						style.active.textColor = colorGold;

						GUI.Label(new Rect(center/2-pa6[0],up/2-pa6[1],pa6[2],pa6[3]),"G: "+gold);
						style2.fontSize=fontsize24;
						style2.normal.textColor = Color.white;
						style2.hover .textColor = Color.white;
						style2.active.textColor = Color.white;

						style2.active.background  = text [18];
						style2.normal.background  = text [18];
						style2.hover.background   = text [18];

						if(GUI.Button(new Rect(center/2+pa7[0],up/2-pa7[1],pa7[2],pa7[3]), settings.languages [62]))//Закрыть
						{
								acc  = false;
						}
				}
				else
				{
						style2.normal.textColor   = Color.white;
						style2.hover .textColor   = Color.white;
						style2.active.textColor   = Color.white;

						style2.active .background  = text [19];
						style2.normal .background  = text [19];
						style2.hover.background    = text [19];

						style2.fontSize=fontsize24;

						if(GUI.Button(new Rect(center/2-pa8[0],up/2+pa8[1],pa8[2],pa8[3]), settings.languages [65]))//Подтверждение
						{
								PlayerPrefs.SetString("login","");
								PlayerPrefs.SetString("pass" ,"");
								Application.LoadLevel("log_In");
						}

						if(GUI.Button(new Rect(center/2+pa9[0],up/2+pa9[1],pa9[2],pa9[3]), settings.languages [66]))//Отмена
						{
								accOF  = false;
						}

						style.normal.background = text [15];
						GUI.Label(new Rect(center/2-pa10[0],up/2-pa10[1],pa10[2],pa10[3]),"");//Фон

						style.alignment = TextAnchor.MiddleCenter;
						style.normal.background = null;
						style.font=fontMenu[0];
						style.fontSize=fontsize24;

						style.normal.textColor = Color.white;
						style.hover .textColor = Color.white;
						style.active.textColor = Color.white;

						GUI.Label(new Rect(center/2-pa11[0],up/2-pa11[1],pa11[2],pa11[3]), settings.languages [64]);//Предупреждение о выходе в регистрацию

				}




		}

		public void PersonalAreaExitGame(int windowID)
		{
				GUI.DrawTexture(new Rect(0,0,center,up),text[3]);

				GUIStyle style  = GUI.skin.GetStyle ("label");
				GUIStyle style2 = GUI.skin.GetStyle ("button");

				style2.normal.textColor   = Color.white;
				style2.hover .textColor   = Color.white;
				style2.active.textColor   = Color.white;

				style2.active .background  = text [19];
				style2.normal .background  = text [19];
				style2.hover.background    = text [19];

				style2.fontSize=fontsize24;

				if(GUI.Button(new Rect(center/2-paeg1[0],up/2+paeg1[1],paeg1[2],paeg1[3]), settings.languages [65]))//Подтверждение
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

				if(GUI.Button(new Rect(center/2+paeg2[0],up/2+paeg2[1],paeg2[2],paeg2[3]), settings.languages [66]))//Отмена
				{
						menuExit      = false;
						trainingExit  = false;
						menu          = true;
				}




				style.fontStyle = FontStyle.Normal;

				style.normal.background = text [15];

				style.normal.textColor = Color.white;
				style.hover .textColor = Color.white;
				style.active.textColor = Color.white;

				GUI.Label(new Rect(center/2-paeg3[0],up/2-paeg3[1],paeg3[2],paeg3[3]),"");//Фон 




				style.alignment = TextAnchor.MiddleCenter;
				style.normal.background = null;
				style.font=fontMenu[0];
				style.fontSize=fontsize24;

				style.normal.textColor = Color.white;
				style.hover .textColor = Color.white;
				style.active.textColor = Color.white;

				GUI.Label(new Rect(center/2-paeg4[0],up/2-paeg4[1],paeg4[2],paeg4[3]), settings.languages [89]);//Предупреждение о выходе в регистрацию


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









