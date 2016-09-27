using UnityEngine;
using System.Collections;

[RequireComponent(typeof(settingsGame))]

public class Menu : MonoBehaviour 
{
		public   Texture2D [] text;
		public   Font         menuGameFont;
		private  bool         menu=false;
		private  bool         freePlay=false;
		private  settingsGame settings;
		private  Vector3      i;
		private  float        center;

		public   bool         score=false;
		public   Score        scoreScript;

		void Awake()
		{
				settings =gameObject.GetComponent<settingsGame>();
				center = Screen.width /(Screen.height / 720.0f) / 2;
				i.x    = Screen.height/720.0f;
				i.y    = Screen.height/720.0f;
				i.z    = 1;


				menu=false;
				freePlay=false;

		}

		void Update()
		{
				if (Input.GetKeyDown (KeyCode.Escape))
				{
						menu     =false;
						freePlay =false;
						score    =false;
				}
		}


		void OnGUI () 
		{

				GUI.matrix = Matrix4x4.Scale(i);	



				if (score == false) 
				{
						if (freePlay == false && menu == false) 
						{
								MenuGameOn ();
						}

						if (freePlay == true)
						{
								gameFreeSelest ();			
						}

						if (menu == true) 
						{
								MenuSetings ();			
						}

				} 
				else 
				{
						scoreScript.ScoreGame();
				}


		}



		void MenuGameOn()
		{


				GUIStyle style = GUI.skin.GetStyle ("button");

				Color color;

				color.r = 68.0f/255.0f;
				color.g = 66.0f/255.0f;
				color.b = 63.0f/255.0f;
				color.a = 1;

				style.normal.textColor = color;
				style.hover.textColor = color;
				style.active.textColor = color;

				style.font = menuGameFont;
				style.fontSize = 22;

				if (PlayerPrefs.GetInt ("PlayerLevel") > 0) 
				{
						style.normal.background  = text [1];
						style.hover.background   = text [1];
						style.active.background  = text [1];

						if (GUI.Button (new Rect (center - 339, 20, 226, 226),settings.languages[0]))
						{
								PlayerPrefs.SetString ("compani", "true");
								Application.LoadLevel (PlayerPrefs.GetInt ("PlayerLevel"));				
						}

				}
				else 
				{
						style.normal.background = text [0];
						style.hover.background = text [0];
						style.active.background = text [0];

						GUI.Button (new Rect (center - 339, 20, 226, 226),settings.languages[0]);
				}



				style.normal.background = text [1];
				style.hover.background = text [1];
				style.active.background = text [1];
				style.fontSize = 34;		
				if (GUI.Button (new Rect (center - 113, 20, 226, 226), settings.languages[1])) //
				{
						if(PlayerPrefs.GetString ("training")!="true")
						{
								PlayerPrefs.SetString ("compani", "true");
								PlayerPrefs.SetInt("trainingLevel",1);
								Application.LoadLevel("training");	
						}
						else
						{
								PlayerPrefs.SetString ("compani", "true");	
								Application.LoadLevel (1);	
						}

				}

				if (GUI.Button (new Rect (center - 113, 472, 226, 226),settings.languages[6]))
				{
						Application.Quit ();			
				}
				style.fontSize = 22;

				if (GUI.Button (new Rect (center + 113, 20, 226, 226),settings.languages[67])) 
				{
						freePlay = true;

				}

				if (GUI.Button (new Rect (center - 339, 246, 226, 226),settings.languages[3])) 
				{
						PlayerPrefs.SetInt("trainingLevel",Application.loadedLevel);
						Application.LoadLevel("training");				
				}

				if (GUI.Button (new Rect (center + 113, 246, 226, 226),settings.languages[5])) 
				{
						menu=true;
				}



				if (GUI.Button (new Rect (center + 113, 472, 226, 226),settings.languages[7])) 
				{
						//Application.OpenURL("market://details?id=com.Pingvin.Rubic");
						Application.OpenURL("https://play.google.com/store/apps/details?id=com.Pingvin.Rubic");
				}

				style.normal.background = text [2];
				style.hover.background = text [2];
				style.active.background = text [2];
				style.fontSize = 34;	

				if (GUI.Button (new Rect (center - 113, 246, 226, 226),settings.languages[4])) 
				{
						score=true;			
				}

				style.fontSize = 22;
				style.normal.background = null;
				style.hover.background = null;
				style.active.background = null;

				style.padding.left = 0;
				style.padding.right = 0;
				style.padding.top = 0;
				style.padding.bottom = 0;

				if (GUI.Button (new Rect (center - 339, 472, 113, 113), text [3])) 
				{ // фейсбук
						Application.OpenURL("https://www.facebook.com/rozumgames");
				}
				if (GUI.Button (new Rect (center - 226, 472, 113, 113), text [4])) 
				{ // контакт
						Application.OpenURL("https://vk.com/rozumgames");
				}
				if (GUI.Button (new Rect (center - 339, 585, 113, 113), text [5])) 
				{ // сайт
						Application.OpenURL("https://rozumgames.com/");
				}
				if (GUI.Button (new Rect (center - 226, 585, 113, 113), text [6])) 
				{ // гугл +
						Application.OpenURL("https://plus.google.com/116358092492971276645/about");
				}



		}

		void gameFreeSelest()
		{

				GUIStyle style = GUI.skin.GetStyle ("button");

				style.normal.textColor = Color.black;
				style.hover.textColor = Color.black;
				style.active.textColor = Color.black;

				style.normal.background = text [1];
				style.hover.background = text [1];
				style.active.background = text [1];


				style.font = menuGameFont;
				style.fontSize = 22;



				if (GUI.Button (new Rect (center - 339, 20, 226, 226), settings.languages[2])) 
				{
						PlayerPrefs.SetString ("compani", "false");
						Application.LoadLevel(1);				
				}

				if(PlayerPrefs.GetInt ("ProgressCompani")>=0)
				{
						style.normal.background = text [1];
						style.hover.background = text [1];
						style.active.background = text [1];

						if (GUI.Button (new Rect (center - 113, 20, 226, 226), "3 X 3")) 
						{
								PlayerPrefs.SetString ("compani", "true");
								Application.LoadLevel(1);	
						}

				}
				else
				{
						style.normal.background = text [0];
						style.hover.background = text [0];
						style.active.background = text [0];
						GUI.Button (new Rect (center - 113, 20, 226, 226), "3 X 3");
				}



				if(PlayerPrefs.GetInt ("ProgressCompani")>=2)
				{
						style.normal.background = text [1];
						style.hover.background = text [1];
						style.active.background = text [1];
						if (GUI.Button (new Rect (center + 113, 20, 226, 226), "4 X 4")) 
						{
								PlayerPrefs.SetString ("compani", "true");
								Application.LoadLevel(2);	
						}

				}
				else
				{
						style.normal.background = text [0];
						style.hover.background = text [0];
						style.active.background = text [0];

						GUI.Button (new Rect (center + 113, 20, 226, 226), "4 X 4");

				}



				if(PlayerPrefs.GetInt ("ProgressCompani")>=3)
				{
						style.normal.background = text [1];
						style.hover.background = text [1];
						style.active.background = text [1];

						if (GUI.Button (new Rect (center - 339, 246, 226, 226), "5 X 5")) 
						{
								PlayerPrefs.SetString ("compani", "true");
								Application.LoadLevel(3);	
						}

				}
				else
				{
						style.normal.background = text [0];
						style.hover.background = text [0];
						style.active.background = text [0];
						GUI.Button (new Rect (center - 339, 246, 226, 226), "5 X 5");

				}



				if(PlayerPrefs.GetInt ("ProgressCompani")>=4)
				{
						style.normal.background = text [1];
						style.hover.background = text [1];
						style.active.background = text [1];

						if (GUI.Button (new Rect (center - 113, 246, 226, 226), "6 X 6")) 
						{
								PlayerPrefs.SetString ("compani", "true");
								Application.LoadLevel(4);	
						}

				}
				else
				{
						style.normal.background = text [0];
						style.hover.background = text [0];
						style.active.background = text [0];

						GUI.Button (new Rect (center - 113, 246, 226, 226), "6 X 6");
				}


				style.normal.background = text [1];
				style.hover.background = text [1];
				style.active.background = text [1];

				if (GUI.Button (new Rect (center + 113, 246, 226, 226),settings.languages[11])) 
				{
						freePlay = false;	
				}

				style.normal.background = text [0];
				style.hover.background = text [0];
				style.active.background = text [0];



				if (GUI.Button (new Rect (center - 113, 472, 226, 226), "")) 
				{

				}
				if (GUI.Button (new Rect (center - 339, 472, 226, 226), "")) 
				{

				}

				if (GUI.Button (new Rect (center + 113, 472, 226, 226), "")) 
				{

				}

		}




		void MenuSetings()
		{		
				GUIStyle style = GUI.skin.GetStyle ("button");

				style.normal.textColor = Color.black;
				style.hover.textColor = Color.black;
				style.active.textColor = Color.black;

				style.normal.background = text [1];
				style.hover.background = text [1];
				style.active.background = text [1];


				style.font = menuGameFont;
				style.fontSize = 22;

				if (GUI.Button (new Rect (center - 339, 20, 226, 226), "Русский")) 
				{

						PlayerPrefs.SetString ("languages", "Russian");	
						settings.languagesGame ();
				}

				if (GUI.Button (new Rect (center - 113, 20, 226, 226), "English")) 
				{

						PlayerPrefs.SetString ("languages", "English");
						settings.languagesGame ();

				}	

				if (GUI.Button (new Rect (center + 113, 20, 226, 226), "Українська")) 
				{
						PlayerPrefs.SetString ("languages", "Ukrainian");
						settings.languagesGame ();
				}				

				if (PlayerPrefs.GetInt ("sound") == 1) 
				{

						if (GUI.Button (new Rect (center - 339, 246, 226, 226),settings.languages[8]+"\n"+settings.languages[9])) 
						{
								PlayerPrefs.SetInt("sound",0);
						}

				} 
				else 
				{
						if (GUI.Button (new Rect (center - 339, 246, 226, 226),settings.languages[8]+"\n"+settings.languages[10])) 
						{
								PlayerPrefs.SetInt("sound",1);
						}

				}

				if (GUI.Button (new Rect (center - 113, 246, 226, 226),settings.languages[57])) 
				{
						PlayerPrefs.SetString("login","");
						PlayerPrefs.SetString("pass" ,"");
						Application.LoadLevel("log_In");

				}

				if(GUI.Button (new Rect (center + 113, 246, 226, 226),settings.languages[11]))
				{
						menu=false;
				}


				style.normal.background = text [0];
				style.hover.background = text [0];
				style.active.background = text [0];

				if (GUI.Button (new Rect (center - 113, 472, 226, 226), "")) 
				{

				}
				if (GUI.Button (new Rect (center - 339, 472, 226, 226), "")) 
				{

				}

				if (GUI.Button (new Rect (center + 113, 472, 226, 226), "")) 
				{

				}
		}


}


