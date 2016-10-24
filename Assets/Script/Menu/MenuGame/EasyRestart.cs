﻿using UnityEngine;
using Assets.Scripts.Common;
using JsonSerialize_DESerialize;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Generate;



public class EasyRestart : MonoBehaviour {

public   string       addressRec;	
public   string       sendingBase;
public 	 string[]     returnBase;

private  settingsGame settings;

private  float        center;
private  float        up;
private  int          moveBay;
	
	
	
void Awake()
		
{
		
center    = Screen.width / (Screen.height / 720.0f) ;
up        = Screen.height/ (Screen.height / 720.0f) ;
		
settings=gameObject.GetComponent<settingsGame>();

}	
	
	
	
	
public	void EasyRGme (Texture2D[] text,Font[] fontMenu, int gold, bool acc) 
{
Color color;

color.r = 238.0f/255.0f;
color.g = 246.0f/255.0f;
color.b = 99.0f/255.0f;
color.a = 1;

GUI.DrawTexture(new Rect(0,0,center,up),text[3]);


GUIStyle style  = GUI.skin.GetStyle ("label");


style.normal.textColor = Color.white;
style.alignment        = TextAnchor.MiddleCenter;
style.fontSize         = 36;
style.font             = fontMenu [0];

style.normal.background = null;

GUI.Label (new Rect(center/2-300,20,600,50),settings.languages [22]);

style.normal.textColor = color;
style.fontSize = 100;
		
GUI.Label (new Rect(center/2-300,70,600,110),""+gold);


style.normal.textColor = Color.white;
style.fontSize = 36;
GUI.Label (new Rect(center/2-300,180,600,50),settings.languages [23]);
		
style.normal.background = text [12];


GUI.Label (new Rect (center/2-200,242,400,2),"");

style.normal.background = null;

style.fontSize = 30;
GUI.Label (new Rect (center/2-310,244,620,260),settings.languages [50]);

style.normal.textColor = color;
style.fontSize         = 30;

GUI.Label (new Rect (center/2-300,504,600,50),settings.languages [51]+" 10 "+settings.languages [23]);

		
GUIStyle style2 = GUI.skin.GetStyle ("button");
		
color.r = 68.0f/255.0f;
color.g = 66.0f/255.0f;
color.b = 63.0f/255.0f;
color.a = 1;

if (gold >= 10) 
{
style2.normal.background = text [10];
style2.hover.background  = text [10];
style2.active.background = text [10];

						style2.normal.textColor = color;
style2.hover .textColor = color;
style2.active.textColor = color;
}
else 
{
style2.normal.background = null;
style2.hover.background  = null;
style2.active.background = null;
			
						style2.normal.textColor = Color.gray;
						style2.hover.textColor = Color.gray;
						style2.active.textColor = Color.gray;
}

style2.font = fontMenu [0];
style2.fontSize = 36;



if(GUI.Button(new Rect(center/2-272.5f,564,545,58),settings.languages [53]) && acc ==false)
{
StartCoroutine(EasyRestartBay());
}

style2.fontSize = 30;
style2.normal.background = text [13];
style2.hover.background  = text [13];
style2.active.background = text [13];

				style2.normal.textColor = color;
style2.hover .textColor = color;
style2.active.textColor = color;

if(GUI.Button(new Rect(center/2-272.5f,up-78,545,58),settings.languages [54]) && acc ==false)
{
gameObject.GetComponent<GUIGame>().addG=true;
gameObject.GetComponent<GUIGame>().EasyRestart=false;
}

}

	
IEnumerator EasyRestartBay()
{

Dictionary<string, string> gameData = new Dictionary<string, string>();
gameData.Add("code" ,"6Av4TpIt");
gameData.Add("login", PlayerPrefs.GetString ("login"));
gameData.Add("pass" , PlayerPrefs.GetString ("pass"));
gameData.Add("operation","EasyRestart");
		
string json = JsonSerialize_DESerialize.Json.SerializeStringIndDictionary (gameData);
sendingBase = Base64.Encode (json);
sendingBase = GenerateKey.CreatingTrash (sendingBase);
		
		
WWWForm form = new WWWForm() ;
form.AddField("easyres",sendingBase);
WWW dowload = new WWW (addressRec,form);
yield return dowload;

returnBase=Base64.Decode(dowload.text).Split(new char[] {'|'});


if(returnBase[0] =="connected" && returnBase[1] =="EasyRestart")

Application.LoadLevel(Application.loadedLevel);
PlayerPrefs.SetInt("lightRestart",1);

}


}
