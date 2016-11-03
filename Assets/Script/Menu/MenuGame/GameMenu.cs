using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class GameMenu : MonoBehaviour {

		private  settingsGame settings;

		private  Color        color;
		private  float        center;
		private  float        up;

		public float size;
		public float size2;
		public float leftOffset;
		public float leftOffset2;
		public float leftOffset3;
		public float topOffset;
		public float topOffset2;
		public float topOffset3;
		public float topOffset4;
		public float topOffset5;
		public float topOffset6;

		void Awake()
		{
				color.r = 68.0f/255.0f;
				color.g = 66.0f/255.0f;
				color.b = 63.0f/255.0f;
				color.a = 1;

				center   = Screen.width / (Screen.height / 720.0f) ;
				up       = Screen.height/ (Screen.height / 720.0f) ;

				settings=gameObject.GetComponent<settingsGame>();


				size = 188;
				size2 = 91;
				leftOffset = 185;
				leftOffset2 = 92;
				leftOffset3 = 0;
				topOffset = 22;
				topOffset2 = 212;
				topOffset3 = 404;
				topOffset4 = 498;
				topOffset5 = 226;
				topOffset6 = 30;
		}


		public void MenuOn(Texture2D[] text,Font[] fontMenu, bool acc)
		{
				GUI.DrawTexture(new Rect(0,0,center,up),text[3]);

				GUIStyle style = GUI.skin.GetStyle ("button");

				style.normal.textColor = color;
				style.hover.textColor  = color;
				style.active.textColor = color;

				style.normal.background = text [2];
				style.hover.background = text [2];
				style.active.background = text [2];
				style.font = fontMenu[0];
				style.fontSize = 24;





				if (GUI.Button (new Rect (center / 2 - leftOffset, up/2-topOffset5, size, size), settings.languages[1]) && acc ==false) 
				{
						if (GUIGame.banner!=null)
								GUIGame.banner.Hide();
						Debug.Log ("Hide");
						Application.LoadLevel(1);	
				}	


				if (GUI.Button (new Rect (center / 2 - leftOffset3, up/2-topOffset5, size, size), settings.languages[3]) && acc ==false) 
				{
						gameObject.GetComponent<GUIGame>().trainingExit=true;				

				}

				if (PlayerPrefs.GetInt ("sound") == 1) {

						if (GUI.Button (new Rect (center/ 2 - leftOffset, up/2 - topOffset6, size, size), settings.languages[8] + "\n" + settings.languages[9]) && acc ==false) 
						{
								PlayerPrefs.SetInt ("sound", 0);
						}

				}
				else 
				{
						if (GUI.Button (new Rect (center / 2 - leftOffset, up/2 - topOffset6, size, size), settings.languages[8] + "\n" + settings.languages[10]) && acc ==false) 
						{
								PlayerPrefs.SetInt ("sound", 1);
						}

				}


				if (GUI.Button (new Rect (center / 2 - leftOffset3, up/2 - topOffset6, size, size), settings.languages[21]) && acc ==false) 
				{
						gameObject.GetComponent<GUIGame>().menuExit=true;	
				}

		}


		public void MenuOnFree(Texture2D[] text,Font[] fontMenu, bool acc)

		{
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



				if (GUI.Button (new Rect (center / 2 - leftOffset, topOffset, size, size),settings.languages[11]) && acc ==false) 
				{
						gameObject.GetComponent<GUIGame>().menu=false;				
				}

				if (GUI.Button (new Rect (center / 2 - leftOffset3, topOffset, size, size), settings.languages[3]) && acc ==false) 
				{
						PlayerPrefs.SetInt("trainingLevel",Application.loadedLevel);
						if (GUIGame.banner!=null)
								GUIGame.banner.Hide();
						Debug.Log ("Hide");
						Application.LoadLevel("training");	
				}	

				if (PlayerPrefs.GetInt ("sound") == 1) 
				{

						if (GUI.Button (new Rect (center / 2 - leftOffset, topOffset2, size, size), settings.languages[8] + "\n" + settings.languages[9]) && acc ==false) 
						{
								PlayerPrefs.SetInt ("sound", 0);
						}

				} 
				else 
				{
						if (GUI.Button (new Rect (center / 2 - leftOffset, topOffset2, size, size), settings.languages[8] + "\n" + settings.languages[10]) && acc ==false) 
						{
								PlayerPrefs.SetInt ("sound", 1);
						}
				}



				if (GUI.Button (new Rect (center / 2 , topOffset2, size, size), settings.languages[21]) && acc ==false) 
				{
						if (GUIGame.banner!=null)
								GUIGame.banner.Hide();
						Debug.Log ("Hide");
						Application.LoadLevel("menu");	
				}

				if (GUI.Button (new Rect (center / 2 , topOffset3, size, size),settings.languages[7] ) && acc ==false) 
				{
						Application.OpenURL("market://details?id=com.Pingvin.Rubic");

				}


				style.normal.background = null;
				style.hover.background = null;
				style.active.background = null;

				style.padding.left = 0;
				style.padding.right = 0;
				style.padding.top = 0;
				style.padding.bottom = 0;


				if (GUI.Button (new Rect (center / 2 - leftOffset, topOffset3, size2, size2), text [5]) && acc ==false) 
				{ // фейсбук
						Application.OpenURL("https://facebook.com/pinguinmobile");
				}
				if (GUI.Button (new Rect (center / 2 - leftOffset2, topOffset3, size2, size2), text [6]) && acc ==false) 
				{ // контакт
						Application.OpenURL("https://vk.com/pinguinmobile");
				}
				if (GUI.Button (new Rect (center / 2 - leftOffset, topOffset4, size2, size2), text [8]) && acc ==false) 
				{ // ?
						Application.OpenURL("http://pinguin-studio.com.ua/");
				}
				if (GUI.Button (new Rect (center / 2 - leftOffset2, topOffset4, size2, size2), text [7]) && acc ==false) 
				{ // гугл +
						Application.OpenURL("https://plus.google.com/116358092492971276645/about");
				}

		}

}
