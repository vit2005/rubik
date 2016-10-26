using UnityEngine;
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

		public int font_small = 24;
		public int font_big = 28;

		public List<float> gui1;
		public List<float> gui2;
		public List<float> gui3;
		public List<float> gui4;
		public List<float> gui5;
		public List<float> gui6;
		public List<float> gui7;
		public List<float> gui8;

		void Awake()

		{

				center    = Screen.width / (Screen.height / 720.0f) ;
				up        = Screen.height/ (Screen.height / 720.0f) ;

				settings=gameObject.GetComponent<settingsGame>();
				addressRec = "https://mobileapi.rozumgames.com/shop/easyres";

				gui1 = new List<float> (){ 300, 0, 600, 50 };
				gui2 = new List<float> (){ 300, 26, 600, 110 };
				gui3 = new List<float> (){ 300, 110, 600, 50 };
				gui4 = new List<float> (){ 200, 159, 400, 2 };
				gui5 = new List<float> (){ 212, 162, 420, 260 };
				gui6 = new List<float> (){ 300, 415, 600, 50 };
				gui7 = new List<float> (){ 272.5f, 460, 545, 58 };
				gui8 = new List<float> (){ 272.5f, 200, 545, 58 };
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
				style.fontSize         = font_big;
				style.font             = fontMenu [0];

				style.normal.background = null;

				GUI.Label (new Rect(center/2-gui1[0],gui1[1],gui1[2],gui1[3]),settings.languages [22]);

				style.normal.textColor = color;
				style.fontSize = 100;

				GUI.Label (new Rect(center/2-gui2[0],gui2[1],gui2[2],gui2[3]),""+gold);


				style.normal.textColor = Color.white;
				style.fontSize = font_big;
				GUI.Label (new Rect(center/2-gui3[0],gui3[1],gui3[2],gui3[3]),settings.languages [23]);

				style.normal.background = text [12];


				GUI.Label (new Rect (center/2-gui4[0],gui4[1],gui4[2],gui4[3]),"");

				style.normal.background = null;

				style.fontSize = font_small;
				GUI.Label (new Rect (center/2-gui5[0],gui5[1],gui5[2],gui5[3]),settings.languages [50]);

				style.normal.textColor = color;
				style.fontSize         = font_small;

				GUI.Label (new Rect (center/2-gui6[0],gui6[1],gui6[2],gui6[3]),settings.languages [51]+" 10 "+settings.languages [23]);


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
				style2.fontSize = font_big;



				if(GUI.Button(new Rect(center/2-gui7[0],gui7[1],gui7[2],gui7[3]),settings.languages [53]) && acc ==false)
				{
						StartCoroutine(EasyRestartBay());
				}

				style2.fontSize = font_small;
				style2.normal.background = text [13];
				style2.hover.background  = text [13];
				style2.active.background = text [13];

				style2.normal.textColor = color;
				style2.hover .textColor = color;
				style2.active.textColor = color;

				if(GUI.Button(new Rect(center/2-gui8[0],up-gui8[1],gui8[2],gui8[3]),settings.languages [54]) && acc ==false)
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
