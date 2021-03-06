﻿using UnityEngine;
using System.Collections;

public class RateThisGame : MonoBehaviour {

	public   Texture2D[]  text;
	public   Font[]       fontMenu;

	private  settingsGame settings;  

	private  Vector3      i;                //кеширование координатов центра,высоты,масштабов
	private  float        center;
	private  float        up;


	private  Color        color;	
	private  Color        colorGold;

	private  GUIStyle     windowStyle;

	void Start () 
	{
		settings    =gameObject.GetComponent<settingsGame>();

		center   = Screen.width / (Screen.height / 720.0f) ;
		up       = Screen.height/ (Screen.height / 720.0f) ;
		i.x      = Screen.height/720.0f;
		i.y      = Screen.height/720.0f;
		i.z      = 1;

	}

	void OnGUI()

	{
	if(PlayerPrefs.GetString("RateThisGame")!="true")
		{
	GUI.matrix = Matrix4x4.Scale(i);
						GUI.Window(0,new Rect(0,0,center+100,up+100),PersonalArea,"",GUIStyle.none);
		}
	}


	public void PersonalArea(int windowID)
		
	{
		
		GUI.DrawTexture(new Rect(0,0,center,up),text[2]);
		
		GUIStyle style  = GUI.skin.GetStyle ("label");
		GUIStyle style2 = GUI.skin.GetStyle ("button");
		
		style.fontStyle = FontStyle.Normal;
		
		style.normal.background = text [0];
		
		style.normal.textColor = Color.white;
		style.hover .textColor = Color.white;
		style.active.textColor = Color.white;
		
		GUI.Label(new Rect(center/2-341,up/2-98,682,196),"");//Фон 
		

			
			
			
        style.alignment = TextAnchor.MiddleCenter;
	    style.normal.background = null;
		style.font=fontMenu[0];
		style.fontSize=24;
			
		style.normal.textColor = Color.white;
		style.hover .textColor = Color.white;
		style.active.textColor = Color.white;
			
		GUI.Label(new Rect(center/2-301,up/2-98,602,196), settings.languages [7]);//Предупреждение о выходе в регистрацию
			
			
			
		style2.normal.textColor   = Color.white;
		style2.hover .textColor   = Color.white;
		style2.active.textColor   = Color.white;
			
		style2.active .background  = text [1];
		style2.normal .background  = text [1];
		style2.hover.background    = text [1];
			
		style2.fontSize=24;

		if(GUI.Button(new Rect(center/2-290,up/2+63,288,74), settings.languages [82]))//Подтверждение
		{
			Application.OpenURL("market://details?id=com.Pingvin.Rubic");
			PlayerPrefs.SetString("RateThisGame","true");
		}
			
		if(GUI.Button(new Rect(center/2+2,up/2+63,288,74), settings.languages [83]))//Отмена
		{
			PlayerPrefs.SetString("RateThisGame","true");	
		}	
}


}
