using UnityEngine;
using System.Text;
using System.Collections;

using System.Collections.Generic;
using Assets.Scripts.Common;
using JsonSerialize_DESerialize;
using Assets.Scripts.Generate;


public class LogIn : MonoBehaviour 
{ 

		private  Vector3      i;               // Настройки экрана и позиций 
		private  float        center;
		private  float        up;
		private  string       info;

		public   Texture2D[]  texture;
		public   Font[]       fontLog;         // Шрифт текста


		public   string       addressLogIn;    // Адрес авторизации
		public   string       addressRegistr;  // Адрес регистрации

		public   string       bs64;

		private  bool         regist;          
		private  settingsGame settings;
		private  Color        color;

		public   string       returnBase;
		public   string       sendingBase;
		public   string       json;
		public   string       login;
		public   string       pass;
		public   string       pass2;

		public int font_size_big;
		public int font_size_medium;
		public int font_size_small;

		public List<float> log1;
		public List<float> log2;
		public List<float> log3;
		public List<float> log4;
		public List<float> log5;
		public List<float> log6;
		public List<float> log7;
		public List<float> log8;
		public List<float> log9;
		public List<float> log10;

		public List<float> reg1;
		public List<float> reg2;
		public List<float> reg3;
		public List<float> reg4;
		public List<float> reg5;
		public List<float> reg6;
		public List<float> reg7;
		public List<float> reg8;
		public List<float> reg9;
		public List<float> reg10;
		public List<float> reg11;
		public List<float> reg12;
		public List<float> reg13;

		//public   InputField   mainInputField;

		void Awake()
		{
				addressLogIn = "https://mobileapi.rozumgames.com/auth/login";
				addressRegistr = "https://mobileapi.rozumgames.com/auth/reg";  
				//mainInputField.shouldHideMobileInput = false; 

				if(Application.loadedLevelName == "log_In")
				{
						login = PlayerPrefs.GetString("login");
						pass  = Base64.Decode(PlayerPrefs.GetString("pass"));
						if(login!="" && pass != "")
						{
								Application.LoadLevel("menu");
						}

				}

				settings = gameObject.GetComponent<settingsGame>();
				center   = Screen.width  / (Screen.height / 720.0f)/2;
				up       = Screen.height / (Screen.height / 720.0f);
				i.x      = Screen.height / 720.0f;
				i.y      = Screen.height / 720.0f;
				i.z      = 1;

				color.r  = 68.0f/255.0f;
				color.g  = 66.0f/255.0f;
				color.b  = 63.0f/255.0f;
				color.a  = 1;

				regist   = false;

				float width = 396;
				float left = 198;

				font_size_big = 28;
				font_size_medium = 24;
				font_size_small = 18;

				log1 = new List<float> {left, 0, width, 98};
				log2 = new List<float> {left, 840, width, 70};
				log3 = new List<float> {left, 158, width, 58};
				log4 = new List<float> {left, 300, width, 58};
				log5 = new List<float> {left, 103, width, 45};
				log6 = new List<float> {left, 158, width, 58};
				log7 = new List<float> {left, 235, width, 45};
				log8 = new List<float> {left, 300, width, 58};
				log9 = new List<float> {left, 378, width, 58};
				log10 = new List<float> {left, 193, width, 58};

				reg1 = new List<float> {left, 158, width, 58};
				reg2 = new List<float> {left, 300, width, 58};
				reg3 = new List<float> {left, 448, width, 58};
				reg4 = new List<float> {left, 158, width, 58};
				reg5 = new List<float> {left, 0, width, 98};
				reg6 = new List<float> {left, 103, width, 45};
				reg7 = new List<float> {left, 158, width, 58};
				reg8 = new List<float> {left, 235, width, 45};
				reg9 = new List<float> {left, 300, width, 58};
				reg10 = new List<float> {left, 379, width, 45};
				reg11 = new List<float> {left, 448, width, 58};
				reg12 = new List<float> {left, 193, 283, 58};
				reg13 = new List<float> {94, 193, 96, 58};

		}



		void Start ()
		{
				info     = settings.languages [27];	
		}



		void OnGUI () 
		{
				GUI.matrix = Matrix4x4.Scale(i);

				if(Application.loadedLevelName == "log_In")
				{
						LogInPlayer();

						GUIStyle style3        = GUI.skin.GetStyle ("button");

						style3.normal.background = texture [1];
						style3.hover .background = texture [1];
						style3.active.background = texture [1];

						style3.normal.textColor = color;
						style3.hover.textColor  = color;
						style3.active.textColor = color;

						style3.fontSize = font_size_small;

						if(GUI.Button(new Rect(center-272.5f,up-78,545,58),settings.languages[32]))
						{	
								PlayerPrefs.SetString("login","");
								PlayerPrefs.SetString("pass","");

								Application.LoadLevel("menu");		
						}
				}

		}


		public void LogInPlayer () 
		{		
				if (regist == false) 
				{
						LogGame();			
				}
				else		
				{
						Registration();			
				}

		}

		void LogGame()
		{

				GUIStyle style         = GUI.skin.GetStyle ("label");
				GUIStyle style2        = GUI.skin.GetStyle ("textfield");
				GUIStyle style3        = GUI.skin.GetStyle ("button");

				style.normal.textColor = Color.white;
				style.alignment        = TextAnchor.MiddleCenter;
				style.fontSize = font_size_small;
				style.font = fontLog [0];

				if(info == settings.languages [27])
				{
						style.normal.background = texture [8];
						GUI.Label (new Rect (center - log1[0], log1[1], log1[2], log1[3]), info);//Таблица с инфформацией 
				}

				else
				{
						style.normal.background = texture [9];
						GUI.Label (new Rect (center - log2[0], log2[1], log2[2], log2[3]), info);//Таблица с инфформацией 
						style.normal.background = texture [10];
						GUI.Label (new Rect (center + log3[0], log3[1], log3[2], log3[3]), "");
						GUI.Label (new Rect (center + log4[0], log4[1], log4[2], log4[3]), ""); 

				}





				style.fontSize = font_size_big;
				style.font = fontLog [1];
				style.normal.background = null;

				GUI.Label (new Rect (center - log5[0], log5[1], log5[2], log5[3]), settings.languages[28]);

				style2.normal.background = texture [6];
				style2.hover .background = texture [6];
				style2.active.background = texture [6];

				style2.fontSize = font_size_medium;
				style2.font = fontLog [1];

				style2.alignment        = TextAnchor.MiddleCenter;


				login= GUI.TextField(new Rect (center - log6[0], log6[1], log6[2], log6[3]),login,25);

				GUI.Label (new Rect (center - log7[0], log7[1], log7[2], log7[3]), settings.languages[29]);

				pass= GUI.PasswordField(new Rect (center - log8[0], log8[1], log8[2], log8[3]),pass,"*"[0],25);

				style3.normal.background = texture [2];
				style3.hover .background = texture [2];
				style3.active.background = texture [2];
				style3.font = fontLog [0];
				style3.fontSize = font_size_medium;

				if(GUI.Button(new Rect(center - log9[0], log9[1], log9[2], log9[3]),settings.languages[30]))
				{
						EncodePlayer();
						StartCoroutine(Log());
				}

				if(GUI.Button(new Rect(center - log10[0], up - log10[1], log10[2], log10[3]),settings.languages[31]))
				{
						info     = settings.languages [27];	
						login ="";
						pass  ="";
						pass2 ="";
						regist=true;		
				}

		}




		void Registration()
		{

				GUIStyle style   = GUI.skin.GetStyle ("label");
				GUIStyle style2  = GUI.skin.GetStyle ("textfield");
				GUIStyle style3  = GUI.skin.GetStyle ("button");

				style.normal.textColor = Color.white;
				style.alignment        = TextAnchor.MiddleCenter;



				if(info == settings.languages [27])
				{
						style.normal.background = texture [8];
				}

				if(info == settings.languages [61])
				{
						style.normal.background = texture [10];
						//GUI.Label (new Rect (center+272.5f,158, 69, 58), "");
						GUI.Label (new Rect (center + reg1[0], reg1[1], reg1[2], reg1[3]), "");
						style.normal.background = texture [9];
				}

				if(info == settings.languages [60])
				{
						style.normal.background = texture [10];
						GUI.Label (new Rect (center + reg2[0], reg2[1], reg2[2], reg2[3]), "");
						GUI.Label (new Rect (center + reg3[0], reg3[1], reg3[2], reg3[3]), ""); 
						style.normal.background = texture [9];
				}

				if(info == settings.languages [59])
				{
						style.normal.background = texture [10];
						GUI.Label (new Rect (center + reg4[0], reg4[1], reg4[2], reg4[3]), "");
						style.normal.background = texture [9];
				}


				style.fontSize = font_size_small;
				style.font = fontLog [0];	


				GUI.Label (new Rect (center - reg5[0], reg5[1], reg5[2], reg5[3]),info);

				style.fontSize = font_size_big;
				style.normal.background = null;
				style.font = fontLog [1];	


				GUI.Label (new Rect (center - reg6[0], reg6[1], reg6[2], reg6[3]), settings.languages[28]);

				style2.normal.background = texture [6];
				style2.hover .background = texture [6];
				style2.active.background = texture [6];

				style2.fontSize = font_size_medium;
				style2.font = fontLog [1];

				style2.alignment        = TextAnchor.MiddleCenter;

				login= GUI.TextField(new Rect (center - reg7[0], reg7[1], reg7[2], reg7[3]),login,25);

				GUI.Label (new Rect (center - reg8[0], reg8[1], reg8[2], reg8[3]), settings.languages[29]);

				pass  = GUI.PasswordField(new Rect (center - reg9[0], reg9[1], reg9[2], reg9[3]),pass,"*"[0],25);

				GUI.Label (new Rect (center - reg10[0], reg10[1], reg10[2], reg10[3]), settings.languages[33]);

				pass2 = GUI.PasswordField(new Rect (center - reg11[0], reg11[1], reg11[2], reg11[3]),pass2,"*"[0],25);


				style3.normal.background = texture [2];
				style3.hover .background = texture [2];
				style3.active.background = texture [2];

				style3.normal.textColor = color;
				style3.hover.textColor  = color;
				style3.active.textColor = color;
				style3.font = fontLog [0];
				style3.fontSize = font_size_medium;

				if (GUI.Button (new Rect (center - reg12[0], up - reg12[1], reg12[2], reg12[3]), settings.languages [34])) 
				{



						if(login=="" || login==" ")
						{
								info  = settings.languages [61];
						}
						else
						{
								if(pass==pass2 && pass!="")
								{
										EncodePlayer();
										StartCoroutine(Regist());	
								}
								else
								{
										info  = settings.languages [60];
								}

						}

				}

				if(GUI.Button(new Rect(center + reg13[0], up - reg13[1], reg13[2], reg13[3]),settings.languages[35]))
				{
						info  = settings.languages [27];	
						login ="";
						pass  ="";
						pass2 ="";

						regist=false;
				}
		}

		void EncodePlayer()
		{
				Dictionary<string, string> gameData = new Dictionary<string, string>();
				gameData.Add("code" ,"6Av4TpIt");
				gameData.Add("login",login);
				gameData.Add("pass" ,Base64.Encode(pass));

				json = JsonSerialize_DESerialize.Json.SerializeStringIndDictionary (gameData);
				sendingBase = Base64.Encode (json);
				sendingBase = GenerateKey.CreatingTrash (sendingBase);
		}





		IEnumerator Log()
		{
				WWWForm form = new WWWForm() ;
				form.AddField("str",sendingBase);
				WWW dowload = new WWW (addressLogIn,form);
				yield return dowload;
				returnBase=dowload.text;

				if (returnBase == "connected") 
				{
						PlayerPrefs.SetString ("login",login);
						PlayerPrefs.SetString("pass"  ,Base64.Encode(pass));

						if(Application.loadedLevelName == "log_In")
						{
								Application.LoadLevel("menu");
						}
						else
						{
								gameObject.GetComponent<GUIGame>().Start();
						}
				} 
				if(returnBase == "not connected")
				{
						info  = settings.languages [58];
				}

				if(returnBase !="connected" && returnBase != "not connected")
				{
						info  = settings.languages [88];
				}

		}

		IEnumerator Regist()
		{
				WWWForm form = new WWWForm() ;
				form.AddField("str",sendingBase);
				WWW dowload = new WWW (addressRegistr,form);
				yield return dowload;
				returnBase=dowload.text;

				if(returnBase=="connected")
				{
						PlayerPrefs.SetString("login",login);
						PlayerPrefs.SetString("pass" ,Base64.Encode(pass));

						if(Application.loadedLevelName == "log_In")
						{
								Application.LoadLevel("menu");
						}
						else
						{
								gameObject.GetComponent<GUIGame>().Start();
						}

				}
				if(returnBase=="not connected")
				{
						info  = settings.languages [59];
				}
				if(returnBase !="connected" && returnBase != "not connected")
				{
						info  = settings.languages [88];
				}


		}



}

