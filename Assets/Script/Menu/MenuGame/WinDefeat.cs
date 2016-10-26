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
		}




		public void Wictory (int move ,int m,int s) 
		{



				GUI.matrix = Matrix4x4.Scale(i);

				if (scoreGet == false)
				{
						StartCoroutine(RecordGet(move, m , s));
						scoreGet=true;
				}

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
				style.fontSize = 36;

				GUI.Label(new Rect (center-113,20,226,244),"");

				style.normal.background = null;

				GUI.Label(new Rect (center-260,254,520,50),settings.languages[36]);

				style.fontSize = 30;

				if(Application.loadedLevelName != "6x6")
				{
						GUI.Label(new Rect (center-260,304,520,50),settings.languages[37]+ "  " + Application.loadedLevelName);
				}
				else
				{
						GUI.Label(new Rect (center-260,304,520,50),settings.languages[85]);
				}

				style.fontSize = 22;

				style.normal.textColor = Color.gray;
				GUI.Label(new Rect (center-350,485,700,50),scoreInfo);
				style.normal.textColor = Color.white;


				style.normal.background = texture[2];

				GUI.Label(new Rect (center-260,354,520,4),"");

				style.normal.background = null;

				GUI.Label(new Rect (center-260,358,260,50),settings.languages[38]);
				GUI.Label(new Rect (center    ,358,260,50),settings.languages[39]);

				style.fontSize = 60;

				if (s >= 10) 
				{
						GUI.Label(new Rect (center-260,398,260,80),m+":" +s);
				} 
				else 
				{
						GUI.Label(new Rect (center-260,398,260,80),m+":0" +s);
				}


				GUI.Label(new Rect (center    ,398,260,80),""+move);

				style2.normal.background = texture[5];
				style2.hover .background = texture[5];
				style2.active.background = texture[5];

				style2.normal.textColor = Color.white ;
				style2.hover.textColor  = Color.white;
				style2.active.textColor = Color.white;

				style2.font = fontLog [0];
				style2.fontSize = 30;

				if(Application.loadedLevelName!="6x6")
				{	
						if(GUI.Button(new Rect(center-226,up-170,452,70),settings.languages[40]))
						{
								SaveGame();
								StartCoroutine(RecordGet(move, m , s));
						}
				}
				else
				{
						if(GUI.Button(new Rect(center-226,up-170,452,70),settings.languages[87]))
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

				if(GUI.Button(new Rect(center-226,up-90,452,70),settings.languages[41]))
				{
						Application.LoadLevel(Application.loadedLevel);	
				}

				style2.normal.background = texture[8];
				style2.hover .background = texture[8];
				style2.active.background = texture[8];

				style2.fontSize = 24;		
				if(GUI.Button(new Rect(center*2-160,up-160,140,140),settings.languages[47]))
				{
						Application.LoadLevel("menu");	
				}

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
				style.fontSize = 36;



				GUI.Label(new Rect (center-127,20,254,274),"");

				style.normal.background = null;

				GUI.Label(new Rect (center-260,294,520,50),settings.languages[42]);

				style.fontSize = 30;

				GUI.Label(new Rect (center-340,344,680,50),settings.languages[43]);

				GUI.Label(new Rect (center-340,398,680,50),settings.languages[44]);




				style2.normal.background = texture[7];
				style2.hover .background = texture[7];
				style2.active.background = texture[7];

				style2.normal.textColor = color ;
				style2.hover.textColor  = color;
				style2.active.textColor = color;


				style2.font = fontLog [0];
				style2.fontSize = 30;

				if(GUI.Button(new Rect(center-300,up-250,600,60),settings.languages[45]))
				{
						gameObject.GetComponent<GUIGame>().addM=true;			
				}


				if(GUI.Button(new Rect(center-300,up-170,600,60),settings.languages[46]))
				{
						gameObject.GetComponent<GUIGame>().EasyRestart=true;			
				}

				style2.normal.background = texture[6];
				style2.hover .background = texture[6];
				style2.active.background = texture[6];

				if(GUI.Button(new Rect(center-226,up-90,452,70),settings.languages[41]))
				{
						Application.LoadLevel(Application.loadedLevel);	
				}

				style2.normal.background = texture[8];
				style2.hover .background = texture[8];
				style2.active.background = texture[8];

				style2.fontSize = 24;		
				if(GUI.Button(new Rect(center*2-160,up-160,140,140),settings.languages[47]))
				{
						Application.LoadLevel("menu");	
				}


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
