﻿using UnityEngine;
using System.Collections;

public class Training : MonoBehaviour {

		public   Texture2D[]  text;
		public   settingsGame settings;
		public   Font         font;


		private  int          sceneTraining;
		private  Vector3      scale;
		private  float        center;
		private  float        up;

		private  Color        color      ;
		private  Color        colorGrey  ;
		private  Color        colorYellow;

		void Awake()
		{
				PlayerPrefs.SetString ("training","true");

				center   = Screen.width  / (Screen.height / 720.0f) / 2;
				up       = Screen.height / (Screen.height / 720.0f);
				scale.x  = Screen.height / 720.0f;
				scale.y  = Screen.height / 720.0f;
				scale.z  = 1;
		}


		void Start () 
		{

				color.r       = 154.0f/255.0f;
				color.g       = 154.0f/255.0f;
				color.b       = 154.0f/255.0f;
				color.a       = 1;

				colorGrey.r   = 68.0f/255.0f;
				colorGrey.g   = 66.0f/255.0f;
				colorGrey.b   = 63.0f/255.0f;
				colorGrey.a   = 1;

				colorYellow.r = 238.0f/255.0f;
				colorYellow.g = 246.0f/255.0f;
				colorYellow.b = 99.0f/255.0f;
				colorYellow.a = 1;

				sceneTraining = 0;
				gameObject.GetComponent<settingsGame> ();
		}


		void OnGUI () 
		{


				GUI.matrix          = Matrix4x4.Scale (scale);

				GUIStyle style      = GUI.skin.GetStyle ("label");
				GUIStyle style2     = GUI.skin.GetStyle ("button");



				style.fontStyle     = FontStyle.Normal;
				style2.fontStyle    = FontStyle.Normal;
				style.alignment     = TextAnchor.MiddleCenter;
				style2.alignment    = TextAnchor.UpperCenter;

				style2.font         = font;
				style2.fontSize     = 36;

				style2.normal.background = text [9];
				style2.hover.background  = text [9];
				style2.active.background = text [9];

				style2.normal.textColor = colorGrey; ;
				style2.hover .textColor = colorGrey;
				style2.active.textColor = colorGrey;

				if (sceneTraining == 0) 
				{
						if (GUI.Button (new Rect (center - 272.5f, up - 78, 545, 58), settings.languages [69])) //начать обучение //"Start learning"
						{
								sceneTraining ++;
						}

				}

				if (sceneTraining == 7) 
				{
						if (GUI.Button (new Rect (center - 272.5f, up - 78, 545, 58), settings.languages [81])) //завершить обучение
						{


								Application.LoadLevel(PlayerPrefs.GetInt("trainingLevel"));
						}

				}



				if (sceneTraining > 0 && sceneTraining < 7)
				{
						if(GUI.Button(new Rect (center-272.5f,up-78,545,58) ,settings.languages[68])) //продолжить обучение
						{
								sceneTraining ++;
						}

				}
				style2.alignment    = TextAnchor.MiddleCenter;
				style2.normal.background = text [8];
				style2.hover.background  = text [8];
				style2.active.background = text [8];
				style2.fontSize     = 24;

				if(GUI.Button(new Rect (center*2-160,up-160,140,140) ,settings.languages[47]))//главное меню
				{
						Application.LoadLevel("menu");	
				}

				if(sceneTraining > 0)
				{
						if(GUI.Button(new Rect (20,up-160,140,140) ,settings.languages[11]))//назад
						{
								sceneTraining--;	
						}
				}


				if(sceneTraining==0)
				{
						Slide1();
				}

				if(sceneTraining==1)
				{
						Slide2();
				}
				if(sceneTraining==2)
				{
						Slide3();
				}

				if(sceneTraining==3)
				{
						Slide4();
				}
				if(sceneTraining==4)
				{
						Slide5();
				}

				if(sceneTraining==5)
				{
						Slide6();
				}
				if(sceneTraining==6)
				{
						Slide7();
				}
				if(sceneTraining==7)
				{
						Slide8();
				}
		}

		void Slide1()
		{

				GUIStyle style     = GUI.skin.GetStyle ("label");

				style.normal.background = null;
				style.normal.textColor  = colorYellow; ;

				style.font          = font;
				style.fontSize      = 36;

				GUI.Label(new Rect (center-320,20,640,50) ,settings.languages[70]); //Welcome to our game!

				style.normal.textColor  = Color.white; ;
				GUI.Label(new Rect (center-320,70,640,260),settings.languages[71]); //"In order to\nunderstand the rules\nof the game,\nwe have prepared\nfor You a short training."
				style.normal.background = text [0];
				GUI.Label(new Rect (center-146,330,292,292),"");

		}

		void Slide2()
		{

				GUIStyle style     = GUI.skin.GetStyle ("label");

				style.normal.background = null;
				style.normal.textColor  = colorYellow; ;

				style.font          = font;
				style.fontSize      = 36;

				GUI.Label(new Rect (center-320,20,640,50) ,settings.languages[72]);

				style.normal.textColor  = Color.white; ;
				GUI.Label(new Rect (center-320,70,640,170),settings.languages[73]);
				style.normal.background = text [1];
				GUI.Label(new Rect (center-147,240,294,340),"");


		}

		void Slide3()
		{

				GUIStyle style     = GUI.skin.GetStyle ("label");

				style.normal.background = null;

				style.font          = font;
				style.fontSize      = 36;
				style.normal.textColor  = Color.white; ;

				GUI.Label(new Rect (center-320,20,640,200) ,settings.languages[74]);

				style.normal.background = text [2];
				GUI.Label(new Rect (center-202,220,349,349),"");


		}

		void Slide4()
		{

				GUIStyle style     = GUI.skin.GetStyle ("label");

				style.normal.background = null;
				style.normal.textColor  = Color.white; ;

				style.font          = font;
				style.fontSize      = 36;


				GUI.Label(new Rect (center-320,20,640,200),settings.languages[75]);
				style.normal.background = text [3];
				GUI.Label(new Rect (center-202,220,349,349),"");


		}

		void Slide5()
		{

				GUIStyle style     = GUI.skin.GetStyle ("label");

				style.normal.background = null;
				style.normal.textColor  = Color.white; ;

				style.font          = font;
				style.fontSize      = 36;

				GUI.Label(new Rect (center-320,20,640,200) ,settings.languages[76]);
				style.normal.background = text [4];
				GUI.Label(new Rect (center-202,220,349,349),"");


		}

		void Slide6()
		{

				GUIStyle style     = GUI.skin.GetStyle ("label");

				style.normal.background = null;
				style.normal.textColor  = Color.white; ;

				style.font          = font;
				style.fontSize      = 36;

				GUI.Label(new Rect (center-400,20,800,260) ,settings.languages[77]);

				style.normal.background = text [5];
				GUI.Label(new Rect (center-206,280,412,258),"");


		}
		void Slide7()
		{

				GUIStyle style     = GUI.skin.GetStyle ("label");

				style.normal.background = null;
				style.font          = font;
				style.fontSize      = 36;


				style.normal.textColor  = Color.white; ;
				GUI.Label(new Rect (center-320,20,640,200),settings.languages[78]);
				style.normal.background = text [6];
				GUI.Label(new Rect (center-206,280,412,258),"");


		}

		void Slide8()
		{

				GUIStyle style     = GUI.skin.GetStyle ("label");

				style.normal.background = null;
				style.font          = font;
				style.fontSize      = 36;


				style.normal.textColor  = Color.white; ;
				GUI.Label(new Rect (center-410,20,820,300),settings.languages[79]);
				style.normal.textColor  = colorYellow; ;
				style.fontSize      = 26;
				style.alignment     = TextAnchor.MiddleLeft;
				GUI.Label(new Rect (center-135.5f,up-248,460,180),settings.languages[80]);

				style.normal.background = text [7];
				GUI.Label(new Rect (center-275.5f,up-213,140,120),"");


		}

}
