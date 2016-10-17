using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class GameMenu : MonoBehaviour {

		private  settingsGame settings;

		private  Color        color;
		private  float        center;
		private  float        up;

		public float size = 226;
		public float size2 = 113;
		public float leftOffset = 226;
		public float leftOffset2 = 113;
		public float topOffset = 20;
		public float topOffset2 = 246;
		public float topOffset3 = 472;
		public float topOffset4 = 585;

		void Awake()
		{
				color.r = 68.0f/255.0f;
				color.g = 66.0f/255.0f;
				color.b = 63.0f/255.0f;
				color.a = 1;

				center   = Screen.width / (Screen.height / 720.0f) ;
				up       = Screen.height/ (Screen.height / 720.0f) ;

				settings=gameObject.GetComponent<settingsGame>();

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





				if (GUI.Button (new Rect (center / 2 - leftOffset,up/2-226, size, size), settings.languages[1]) && acc ==false) 
				{
						Application.LoadLevel(1);	
				}	


				if (GUI.Button (new Rect (center / 2 ,up/2-226, size, size), settings.languages[3]) && acc ==false) 
				{
						gameObject.GetComponent<GUIGame>().trainingExit=true;				

				}

				if (PlayerPrefs.GetInt ("sound") == 1) {

						if (GUI.Button (new Rect (center/ 2 - leftOffset, up/2, size, size), settings.languages[8] + "\n" + settings.languages[9]) && acc ==false) 
						{
								PlayerPrefs.SetInt ("sound", 0);
						}

				}
				else 
				{
						if (GUI.Button (new Rect (center / 2 - leftOffset,up/2, size, size), settings.languages[8] + "\n" + settings.languages[10]) && acc ==false) 
						{
								PlayerPrefs.SetInt ("sound", 1);
						}

				}


				if (GUI.Button (new Rect (center / 2 ,up/2, size, size), settings.languages[21]) && acc ==false) 
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



				if (GUI.Button (new Rect (center / 2 - leftOffset, topOffset, size, size),settings.languages[19]) && acc ==false) 
				{
						gameObject.GetComponent<GUIGame>().menu=false;				
				}

				if (GUI.Button (new Rect (center / 2 , topOffset, size, size), settings.languages[3]) && acc ==false) 
				{
						PlayerPrefs.SetInt("trainingLevel",Application.loadedLevel);
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
				if (GUI.Button (new Rect (center / 2 - leftOffset, 585, size2, size2), text [8]) && acc ==false) 
				{ // ?
						Application.OpenURL("http://pinguin-studio.com.ua/");
				}
				if (GUI.Button (new Rect (center / 2 - leftOffset2, 585, size2, size2), text [7]) && acc ==false) 
				{ // гугл +
						Application.OpenURL("https://plus.google.com/116358092492971276645/about");
				}

		}

}
