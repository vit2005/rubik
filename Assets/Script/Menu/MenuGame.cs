﻿using UnityEngine;
using System.Collections;

[RequireComponent(typeof(settingsGame))]

public class MenuGame : MonoBehaviour {

		private  settingsGame settings;
		private  Vector3      i;
		private  float        center;
		private  float        up;

		public   Texture2D[]  text;
		public   Font[]       fontMenu;

		private  int          muve =20;
		private  int          gold =0;
		private  int          lvl  =0;

		private  bool         sound;
		private  float        gameRange;
		private  int          m;
		private  int          s;

		private  bool         menu;


		void Awake()
		{
				lvl=Application.loadedLevel;
				settings =gameObject.GetComponent<settingsGame>();
				center   = Screen.width / (Screen.height / 720.0f) ;
				up       = Screen.height/ (Screen.height / 720.0f) ;
				i.x      = Screen.height/720.0f;
				i.y      = Screen.height/720.0f;
				i.z      = 1;

		}

		public void MenuFon(float m)
		{
				gameRange=m;
		}

		void Update()
		{

				m=(int)(Time.timeSinceLevelLoad/60.0f);
				s=(int)(Time.timeSinceLevelLoad-m*60.0f);

		}

		public void Muve ()
		{
				muve--;
		}



		void OnGUI()
		{
				GUI.matrix = Matrix4x4.Scale(i);	


				if (PlayerPrefs.GetString ("compani") == "true") {
						CompaniMenu ();
				} 
				else 
				{
						FreeMenu();
				}

		}


		void FreeMenu()
		{

				GUIStyle style2 = GUI.skin.GetStyle ("button");

				style2.normal.background = text [1];
				style2.hover.background = text [1];
				style2.active.background = text [1];

				style2.normal.textColor = Color.grey;		
				style2.hover .textColor = Color.grey;
				style2.active.textColor = Color.grey;
				style2.font = fontMenu [0];
				style2.fontSize = 24;




				if(GUI.Button (new Rect(center-160,up-160,140,140),settings.languages[18]))
				{
						if (menu == true )
						{
								menu = false;
						}
						else
						{
								menu = true;
						}
				}


				if (menu == true )
				{				
						Time.timeScale=0;
						MenuOnFree();
				}
				else
				{
						Time.timeScale=1;
				}

		}



		void CompaniMenu()
		{
				GUIStyle style = GUI.skin.GetStyle ("label");
				style.normal.textColor = Color.grey;

				style.fontStyle = FontStyle.Bold;
				style.alignment = TextAnchor.MiddleCenter;
				style.fontSize = 24;

				style.font = fontMenu [2];

				GUI.Label (new Rect (20, 20, 140, 30), settings.languages [12]);
				GUI.Label (new Rect (center - 160, 20, 140, 30), settings.languages [13]);

				style.normal.textColor = Color.white;
				style.font = fontMenu [0];

				GUI.Label (new Rect (20, 60, 140, 30), "" + gold);
				GUI.Label (new Rect (center - 160, 60, 140, 30), "" + muve);


				GUIStyle style2 = GUI.skin.GetStyle ("button");
				style2.normal.background = text [0];
				style2.hover.background = text [0];
				style2.active.background = text [0];
		
				style2.normal.textColor = Color.black;
				style2.hover.textColor = Color.black;
				style2.active.textColor = Color.black;

				style2.font = fontMenu [0];
				style2.fontSize = 22;

				GUI.Button (new Rect(20,110,140,60),settings.languages[14]);
				GUI.Button (new Rect(center-160,110,140,60),settings.languages[14]);



				GUI.Label (new Rect(20,up/2-60,140,40),settings.languages[15]);
				GUI.Label (new Rect(center-160,up/2-60,140,40),settings.languages[16]);


				style.fontSize = 50;
				GUI.Label (new Rect(20,up/2-40,140,80),""+lvl);
				GUI.Label (new Rect(center-160,up/2-40,140,80),""+m+":"+s);



				style2.normal.background = text [1];
				style2.hover.background = text [1];
				style2.active.background = text [1];

				style2.normal.textColor = Color.gray;
				style2.hover .textColor = Color.gray;
				style2.active.textColor = Color.gray;
				style2.font = fontMenu [0];
				style2.fontSize = 24;

				if(GUI.Button (new Rect(20,up-160,140,140),settings.languages[17]))
				{
						Application.LoadLevel(Application.loadedLevel);
						PlayerPrefs.SetInt("lightRestart",1);

				}
				if(GUI.Button (new Rect(center-160,up-160,140,140),settings.languages[18]))
				{
						if (menu == true )
						{
								menu = false;
						}
						else
						{
								menu = true;
						}
				}


				if (menu == true )
				{				
						Time.timeScale=0;
						MenuOn();
				}
				else
				{
						Time.timeScale=1;
				}

		}


		void MenuOnFree()
		{
				GUI.DrawTexture(new Rect(center/2-(gameRange/2),0,gameRange,up),text[4]);
				GUI.DrawTexture(new Rect(0,0,center,up),text[3]);


				GUIStyle style = GUI.skin.GetStyle ("button");

				style.normal.textColor = Color.black;
				style.hover.textColor = Color.black;
				style.active.textColor = Color.black;

				style.normal.background = text [2];
				style.hover.background = text [2];
				style.active.background = text [2];
				style.font = fontMenu[0];
				style.fontSize = 24;



				if (GUI.Button (new Rect (center / 2 - 226, 20, 226, 226),settings.languages[19])) 
				{
						menu=false;				
				}

				if (GUI.Button (new Rect (center / 2 , 20, 226, 226), settings.languages[3])) 
				{

				}	

				if (PlayerPrefs.GetInt ("sound") == 1) {

						if (GUI.Button (new Rect (center / 2 - 226, 246, 226, 226), settings.languages[8] + "\n" + settings.languages[9])) {
								PlayerPrefs.SetInt ("sound", 0);
						}

				} 
				else 
				{
						if (GUI.Button (new Rect (center / 2 - 226, 246, 226, 226), settings.languages[8] + "\n" + settings.languages[10])) {
								PlayerPrefs.SetInt ("sound", 1);
						}
				}



				if (GUI.Button (new Rect (center / 2 , 246, 226, 226), settings.languages[21])) 
				{
						Application.LoadLevel("menu");	

				}

				if (GUI.Button (new Rect (center / 2 , 472, 226, 226),settings.languages[7] )) 
				{

				}


				style.normal.background = null;
				style.hover.background = null;
				style.active.background = null;

				style.padding.left = 0;
				style.padding.right = 0;
				style.padding.top = 0;
				style.padding.bottom = 0;

				if (GUI.Button (new Rect (center / 2 - 226, 472, 113, 113), text [5])) 
				{ // фейсбук

				}
				if (GUI.Button (new Rect (center / 2 - 113, 472, 113, 113), text [6])) 
				{ // контакт

				}
				if (GUI.Button (new Rect (center / 2 - 226, 585, 113, 113), text [8])) 
				{ // ?

				}
				if (GUI.Button (new Rect (center / 2 - 113, 585, 113, 113), text [7])) 
				{ // гугл +

				}






		}







		void MenuOn()
		{
				GUI.DrawTexture(new Rect(center/2-(gameRange/2),0,gameRange,up),text[4]);
				GUI.DrawTexture(new Rect(0,0,center,up),text[3]);


				GUIStyle style = GUI.skin.GetStyle ("button");

				style.normal.textColor = Color.black;
				style.hover.textColor = Color.black;
				style.active.textColor = Color.black;

				style.normal.background = text [2];
				style.hover.background = text [2];
				style.active.background = text [2];
				style.font = fontMenu[0];
				style.fontSize = 24;



				if (GUI.Button (new Rect (center / 2 - 226, 20, 226, 226), settings.languages[19])) 
				{
						menu=false;				
				}

				if (GUI.Button (new Rect (center / 2 , 20, 226, 226), settings.languages[1])) 
				{
						Application.LoadLevel(1);	
				}	



				if (GUI.Button (new Rect (center / 2 - 226, 246, 226, 226), settings.languages[20])) 
				{

				}

				if (GUI.Button (new Rect (center / 2 , 246, 226, 226), settings.languages[3])) 
				{


				}

				if (PlayerPrefs.GetInt ("sound") == 1) {

						if (GUI.Button (new Rect (center/ 2 - 226, 472, 226, 226), settings.languages[8] + "\n" + settings.languages[9])) 
						{
								PlayerPrefs.SetInt ("sound", 0);
						}

				}
				else 
				{
						if (GUI.Button (new Rect (center / 2 - 226, 472, 226, 226), settings.languages[8] + "\n" + settings.languages[10])) {
								PlayerPrefs.SetInt ("sound", 1);
						}

				}


				if (GUI.Button (new Rect (center / 2 , 472, 226, 226), settings.languages[21])) 
				{
						Application.LoadLevel("menu");	
				}



		}


}
