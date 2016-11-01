using UnityEngine;
using Assets.Scripts.Common;
using JsonSerialize_DESerialize;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Generate;


public class WinDefeat : MonoBehaviour 
{
		private  Vector3       i;
		private  float         center;
		private  float         up;
		private	 Color         color;
		private  settingsGame  settings;
		private  GUIGame       gameM; 
		private  float         sizeBackground;

		private  bool 	       scoreGet;
		private  string 	   scoreInfo;

		public   Texture2D[]   texture;
		public   Font[]	       fontLog;

		public   string        addressRec;	
		public   string        sendingBase;

		public List<float> victory1;
		public List<float> victory2;
		public List<float> victory3;
		public List<float> victory4;
		public List<float> victory5;
		public List<float> victory6;
		public List<float> victory7;
		public List<float> victory8;
		public List<float> victory9;
		public List<float> victory10;
		public List<float> victory11;
		public List<float> victory12;
		public List<float> victory13;
		public List<float> victory14;

		public List<float> defeat1;
		public List<float> defeat2;
		public List<float> defeat3;
		public List<float> defeat4;
		public List<float> defeat5;
		public List<float> defeat6;
		public List<float> defeat7;


		public int fontsize_small = 22;
		public int fontsize_medium = 26;
		public int fontsize_big = 28;

		void Start () 
		{
				scoreGet = false;
				addressRec = "https://mobileapi.rozumgames.com/stage";
				sizeBackground =Screen.height - ((Screen.height / (Application.loadedLevel + 3)))+60.0f ;		
				center   = Screen.width / (Screen.height / 720.0f)/2;
				up       = Screen.height/ (Screen.height / 720.0f)  ;
				i.x      = Screen.height/720.0f;
				i.y      = Screen.height/720.0f;
				i.z      = 1;

				settings = gameObject.GetComponent<settingsGame>();
				gameM    = gameObject.GetComponent<GUIGame> ();

				victory1 = new List<float> (){ 113, 20, 226, 244 };
				victory2 = new List<float> (){ 260, 254, 520, 50 };
				victory3 = new List<float> (){ 260, 304, 520, 50 };
				victory4 = new List<float> (){ 260, 304, 520, 50 };
				victory5 = new List<float> (){ 200, 485, 400, 60 };
				victory6 = new List<float> (){ 260, 354, 520, 4 };
				victory7 = new List<float> (){ 225, 358, 260, 50 };
				victory8 = new List<float> (){ 42, 358, 260, 50 };
				victory9 = new List<float> (){ 225, 398, 260, 80 };
				victory10 = new List<float> (){ 225, 398, 260, 80 };
				victory11 = new List<float> (){ 42, 398, 260, 80 };
				victory12 = new List<float> (){ 226, 170, 452, 70 };
				victory13 = new List<float> (){ 226, 170, 452, 70 };
				victory14 = new List<float> (){ 226, 90, 452, 70 };

				defeat1 = new List<float> (){ 127, 20, 254, 274 };
				defeat2 = new List<float> (){ 260, 260, 520, 50 };
				defeat3 = new List<float> (){ 200, 312, 400, 120};
				defeat4 = new List<float> (){ 340, 426, 680, 50 };
				defeat5 = new List<float> (){ 300, 236, 600, 60 };
				defeat6 = new List<float> (){ 300, 153, 600, 60 };
				defeat7 = new List<float> (){ 226, 81, 452, 70 };

		}




		public void Wictory (int move ,int m,int s, bool fake = false) 
		{



				GUI.matrix = Matrix4x4.Scale(i);

				if (scoreGet == false && !fake)
				{
						StartCoroutine(RecordGet(move, m , s));
						scoreGet=true;
				}

				if(!fake)
					GUI.DrawTexture(new Rect(0,0,center*2,up),texture[4]);

				color.r = 68.0f/255.0f;
				color.g = 66.0f/255.0f;
				color.b = 63.0f/255.0f;
				color.a = 1;

				GUIStyle style         = GUI.skin.GetStyle ("label");

				GUIStyle style2        = GUI.skin.GetStyle ("button");

				if(Application.loadedLevelName!="6x6")
				{
						style.normal.background = texture[0];
				}
				else
				{
						style.normal.background = texture[9];
				}

				style.hover .background = null;
				style.active.background = null;

				style.normal.textColor = Color.white ;
				style.hover.textColor  = Color.white;
				style.active.textColor = Color.white;

				style.font = fontLog [0];
				style.fontSize = fontsize_big;

				GUI.Label(new Rect (center-victory1[0],victory1[1],victory1[2],victory1[3]),"");

				style.normal.background = null;

				GUI.Label(new Rect (center-victory2[0],victory2[1],victory2[2],victory2[3]),settings.languages[36]);

				style.fontSize = fontsize_medium;

				if(Application.loadedLevelName != "6x6")
				{
						GUI.Label(new Rect (center-victory3[0],victory3[1],victory3[2],victory3[3]),settings.languages[37]+ "  " + Application.loadedLevelName);
				}
				else
				{
						GUI.Label(new Rect (center-victory4[0],victory4[1],victory4[2],victory4[3]),settings.languages[85]);
				}

				style.fontSize = fontsize_small;

				style.normal.textColor = Color.gray;
				GUI.Label(new Rect (center-victory5[0],victory5[1],victory5[2],victory5[3]),scoreInfo);
				style.normal.textColor = Color.white;


				style.normal.background = texture[2];

				GUI.Label(new Rect (center-victory6[0],victory6[1],victory6[2],victory6[3]),"");

				style.normal.background = null;

				GUI.Label(new Rect (center-victory7[0],victory7[1],victory7[2],victory7[3]),settings.languages[38]);
				GUI.Label(new Rect (center-victory8[0],victory8[1],victory8[2],victory8[3]),settings.languages[39]);

				style.fontSize = 60;

				if (s >= 10) 
				{
						GUI.Label(new Rect (center-victory9[0],victory9[1],victory9[2],victory9[3]),m+":" +s);
				} 
				else 
				{
						GUI.Label(new Rect (center-victory10[0],victory10[1],victory10[2],victory10[3]),m+":0" +s);
				}


				GUI.Label(new Rect (center-victory11[0],victory11[1],victory11[2],victory11[3]),""+move);

				style2.normal.background = texture[5];
				style2.hover .background = texture[5];
				style2.active.background = texture[5];

				style2.normal.textColor = Color.white ;
				style2.hover.textColor  = Color.white;
				style2.active.textColor = Color.white;

				style2.font = fontLog [0];
				style2.fontSize = fontsize_medium;

				if(Application.loadedLevelName!="6x6")
				{	
						if(GUI.Button(new Rect(center-victory12[0],up-victory12[1],victory12[2],victory12[3]),settings.languages[40]))
						{
								SaveGame();
								StartCoroutine(RecordGet(move, m , s));
						}
				}
				else
				{
						if(GUI.Button(new Rect(center-victory13[0],up-victory13[1],victory13[2],victory13[3]),settings.languages[87]))
						{
								SaveGame();
								StartCoroutine(RecordGet(move, m , s));
						}
				}


				style2.normal.background = texture[6];
				style2.hover .background = texture[6];
				style2.active.background = texture[6];

				style2.normal.textColor = color ;
				style2.hover.textColor  = color;
				style2.active.textColor = color;

				if(GUI.Button(new Rect(center-victory14[0],up-victory14[1],victory14[2],victory14[3]),settings.languages[41]))
				{
						Application.LoadLevel(Application.loadedLevel);	
				}

				style2.normal.background = texture[8];
				style2.hover .background = texture[8];
				style2.active.background = texture[8];

				style2.fontSize = 24;		
//				if(GUI.Button(new Rect(center*2-160,up-160,140,140),settings.languages[47]))
//				{
//						Application.LoadLevel("menu");	
//				}

		}




		public void Defeat () 
		{
				GUI.matrix = Matrix4x4.Scale(i);	
				GUI.DrawTexture(new Rect(center-(sizeBackground/2),0,sizeBackground,up),texture[3]);
				GUI.DrawTexture(new Rect(0,0,center*2,up),texture[4]);

				color.r = 68.0f/255.0f;
				color.g = 66.0f/255.0f;
				color.b = 63.0f/255.0f;
				color.a = 1;

				GUIStyle style         = GUI.skin.GetStyle ("label");

				GUIStyle style2        = GUI.skin.GetStyle ("button");

				style.normal.background = texture[1];
				style.hover .background = null;
				style.active.background = null;

				style.normal.textColor = Color.white ;
				style.hover.textColor  = Color.white;
				style.active.textColor = Color.white;

				style.font = fontLog [0];
				style.fontSize = fontsize_big;



				GUI.Label(new Rect (center-defeat1[0],defeat1[1],defeat1[2],defeat1[3]),"");

				style.normal.background = null;

				GUI.Label(new Rect (center-defeat2[0],defeat2[1],defeat2[2],defeat2[3]),settings.languages[42]);

				style.fontSize = fontsize_medium;

				GUI.Label(new Rect (center-defeat3[0],defeat3[1],defeat3[2],defeat3[3]),settings.languages[43]);

				GUI.Label(new Rect (center-defeat4[0],defeat4[1],defeat4[2],defeat4[3]),settings.languages[44]);




				style2.normal.background = texture[7];
				style2.hover .background = texture[7];
				style2.active.background = texture[7];

				style2.normal.textColor = color ;
				style2.hover.textColor  = color;
				style2.active.textColor = color;


				style2.font = fontLog [0];
				style2.fontSize = fontsize_medium;

				if(GUI.Button(new Rect(center-defeat5[0],up-defeat5[1],defeat5[2],defeat5[3]),settings.languages[45]))
				{
						gameObject.GetComponent<GUIGame>().addM=true;			
				}


				if(GUI.Button(new Rect(center-defeat6[0],up-defeat6[1],defeat6[2],defeat6[3]),settings.languages[46]))
				{
						gameObject.GetComponent<GUIGame>().EasyRestart=true;			
				}

				style2.normal.background = texture[6];
				style2.hover .background = texture[6];
				style2.active.background = texture[6];

				if(GUI.Button(new Rect(center-defeat7[0],up-defeat7[1],defeat7[2],defeat7[3]),settings.languages[41]))
				{
						Application.LoadLevel(Application.loadedLevel);	
				}

				style2.normal.background = texture[8];
				style2.hover .background = texture[8];
				style2.active.background = texture[8];

				style2.fontSize = 24;		
//				if(GUI.Button(new Rect(center*2-160,up-160,140,140),settings.languages[47]))
//				{
//						Application.LoadLevel("menu");	
//				}


		}
		private void SaveGame()
		{

				if(Application.loadedLevelName!="6x6")
				{	
						Application.LoadLevel(Application.loadedLevel+1);
				}
				else
				{

						//GoogleAnalyticsV4.instance.LogEvent("LevelChange","Victory",Application.loadedLevelName,1);

						PlayerPrefs.SetInt ("PlayerLevel", Application.loadedLevel);
						Application.LoadLevel("3x3");
				}
		}


		IEnumerator RecordGet(int move,int m ,int s)
		{
				if (PlayerPrefs.GetString ("login") != "") 
				{
						Dictionary<string, string> gameData = new Dictionary<string, string> ();
						gameData.Add ("code", "6Av4TpIt");
						gameData.Add ("login", PlayerPrefs.GetString ("login"));
						gameData.Add ("lvl", System.Convert.ToString (Application.loadedLevel));
						gameData.Add ("move", System.Convert.ToString (move));
						gameData.Add ("time", System.Convert.ToString ((m * 60) + s));

						string json = JsonSerialize_DESerialize.Json.SerializeStringIndDictionary (gameData);
						sendingBase = Base64.Encode (json);
						sendingBase = GenerateKey.CreatingTrash (sendingBase);


						WWWForm form = new WWWForm ();
						form.AddField ("str", sendingBase);
						WWW dowload = new WWW (addressRec, form);
						yield return dowload;
						if (dowload.text == "true/ОК" || dowload.text == "true/запись обновилась") 
						{
								scoreInfo = "";
						} 
						else 
						{
								scoreInfo = settings.languages [86];
						}
				} 
				else 
				{
						scoreInfo = settings.languages [84];
				}

		}




}
