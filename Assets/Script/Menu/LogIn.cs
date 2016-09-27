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

	//public   InputField   mainInputField;
	
void Awake()
{

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
			
style3.fontSize = 24;

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
		style.fontSize = 24;
		style.font = fontLog [0];

		if(info == settings.languages [27])
		{
			style.normal.background = texture [8];
			GUI.Label (new Rect (center - 420, 0, 840, 70), info);//Таблица с инфформацией 
		}

		else
		{
			style.normal.background = texture [9];
			GUI.Label (new Rect (center - 420, 0, 840, 70), info);//Таблица с инфформацией 
			style.normal.background = texture [10];
			GUI.Label (new Rect (center+272.5f,158, 69, 58), "");
			GUI.Label (new Rect (center+272.5f,300, 69, 58), ""); 

		}


		

		
		style.fontSize = 36;
		style.font = fontLog [1];
		style.normal.background = null;
		
		GUI.Label (new Rect (center - 420, 89, 840, 45), settings.languages[28]);
		
		style2.normal.background = texture [6];
		style2.hover .background = texture [6];
		style2.active.background = texture [6];
		
		style2.fontSize = 30;
		style2.font = fontLog [1];
		
		style2.alignment        = TextAnchor.MiddleCenter;
		
		
		login= GUI.TextField(new Rect (center-272.5f,158,545,58),login,25);
		
		GUI.Label (new Rect (center - 420, 235, 840, 45), settings.languages[29]);
		
		pass= GUI.PasswordField(new Rect (center-272.5f,300,545,58),pass,"*"[0],25);
		
		style3.normal.background = texture [2];
		style3.hover .background = texture [2];
		style3.active.background = texture [2];
		style3.font = fontLog [0];
		style3.fontSize = 30;
		
		if(GUI.Button(new Rect(center-272.5f,378,545,58),settings.languages[30]))
		{
			EncodePlayer();
			StartCoroutine(Log());
		}
		
		if(GUI.Button(new Rect(center-272.5f,up-156,545,58),settings.languages[31]))
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
			GUI.Label (new Rect (center+272.5f,158, 69, 58), "");
			style.normal.background = texture [9];
		}

		if(info == settings.languages [60])
		{
		style.normal.background = texture [10];
		GUI.Label (new Rect (center+272.5f,300, 69, 58), "");
		GUI.Label (new Rect (center+272.5f,448, 69, 58), ""); 
		style.normal.background = texture [9];
		}

		if(info == settings.languages [59])
		{
			style.normal.background = texture [10];
			GUI.Label (new Rect (center+272.5f,158, 69, 58), "");
			style.normal.background = texture [9];
		}


		style.fontSize = 24;
		style.font = fontLog [0];	
		
		
		GUI.Label (new Rect (center - 420, 0, 840, 70),info);
		
		style.fontSize = 36;
		style.normal.background = null;
		style.font = fontLog [1];	
		
		
		GUI.Label (new Rect (center - 420, 89, 840, 45), settings.languages[28]);
		
		style2.normal.background = texture [6];
		style2.hover .background = texture [6];
		style2.active.background = texture [6];
		
		style2.fontSize = 30;
		style2.font = fontLog [1];
		
		style2.alignment        = TextAnchor.MiddleCenter;
		
		login= GUI.TextField(new Rect (center-272.5f,158,545,58),login,25);
		
		GUI.Label (new Rect (center - 420, 235, 840, 45), settings.languages[29]);
		
		pass  = GUI.PasswordField(new Rect (center-272.5f,300,545,58),pass,"*"[0],25);
		
		GUI.Label (new Rect (center - 420, 379, 840, 45), settings.languages[33]);
		
		pass2 = GUI.PasswordField(new Rect (center-272.5f,448,545,58),pass2,"*"[0],25);
		
		
		style3.normal.background = texture [2];
		style3.hover .background = texture [2];
		style3.active.background = texture [2];
		
		style3.normal.textColor = color;
		style3.hover.textColor  = color;
		style3.active.textColor = color;
		style3.font = fontLog [0];
		style3.fontSize = 30;
		
		if (GUI.Button (new Rect (center - 272.5f, up - 156, 390, 58), settings.languages [34])) 
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
		
		if(GUI.Button(new Rect(center+147.5f,up-156,125,58),settings.languages[35]))
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

