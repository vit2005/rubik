using UnityEngine;
using Assets.Scripts.Common;
using JsonSerialize_DESerialize;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Generate;

public class AddMoves : MonoBehaviour 
{
		public   string       addressRec;	
		public   string       sendingBase;
		public 	 string[]     returnBase;
		private  settingsGame settings;	
		private  float        center;
		private  float        up;
		private  int          moveBay;

		public int fontsize_small = 28;

		public List<float> gui1;
		public List<float> gui2;
		public List<float> gui3;
		public List<float> gui4;
		public List<float> gui5;
		public List<float> gui6;
		public List<float> gui7;
		public List<float> gui8;
		public List<float> gui9;
		public List<float> gui10;
		public List<float> gui11;



		void Awake()
		{

				center    = Screen.width / (Screen.height / 720.0f) ;
				up        = Screen.height/ (Screen.height / 720.0f) ;

				settings  = gameObject.GetComponent<settingsGame>();

				addressRec = "https://mobileapi.rozumgames.com/shop/buy";

				gui1 = new List<float> (){ 300, 11, 600, 50};
				gui2 = new List<float> (){ 300, 46, 600, 110};
				gui3 = new List<float> (){ 300, 142, 600, 50};
				gui4 = new List<float> (){ 200, 198, 400, 2};
				gui5 = new List<float> (){ 300, 198, 600, 64};
				gui6 = new List<float> (){ 60, 262, 120, 120};
				gui7 = new List<float> (){ 300, 382, 600, 50};
				gui8 = new List<float> (){ 272.5f, 460, 545, 58};
				gui9 = new List<float> (){ 272.5f, 197, 545, 58};
				gui10 = new List<float> (){ 145, 358, 60, 60};
				gui11 = new List<float> (){ 85, 358, 60, 60};
		}	




		public	void Purchases (Texture2D[] text,Font[] fontMenu, int gold, bool acc) 
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
				style.fontSize         = fontsize_small;
				style.font             = fontMenu [0];

				style.normal.background = null;

				GUI.Label (new Rect(center/2-gui1[0],gui1[1],gui1[2],gui1[3]),settings.languages [22]);

				style.normal.textColor = color;
				style.fontSize = 100;

				GUI.Label (new Rect(center/2-gui2[0],gui2[1],gui2[2],gui2[3]),""+gold);


				style.normal.textColor = Color.white;
				style.fontSize = fontsize_small;
				GUI.Label (new Rect(center/2-gui3[0],gui3[1],gui3[2],gui3[3]),settings.languages [23]);

				style.normal.background = text [12];


				GUI.Label (new Rect (center/2-gui4[0],gui4[1],gui4[2],gui4[3]),"");

				style.normal.background = null;









				GUI.Label (new Rect(center/2-gui5[0],gui5[1],gui5[2],gui5[3]),settings.languages [14]+":");

				style.normal.background = text [9];
				style.hover .background = text [9];
				style.active.background = text [9];

				color.r = 68.0f/255.0f;
				color.g = 66.0f/255.0f;
				color.b = 63.0f/255.0f;
				color.a = 1;			

				style.normal.textColor = Color.gray;
				style.hover .textColor = Color.gray;
				style.active.textColor = Color.gray;

				style.fontSize = 48;

				GUI.Label (new Rect(center/2-gui6[0],gui6[1],gui6[2],gui6[3]),""+ moveBay);


				style.normal.textColor = Color.white;
				style.hover .textColor = Color.white;
				style.active.textColor = Color.white;

				style.normal.background = null;
				style.hover .background = null;
				style.active.background = null;

				style.fontSize = fontsize_small;

				GUI.Label (new Rect(center/2-gui7[0],gui7[1],gui7[2],gui7[3]),settings.languages [48]+" "+moveBay+" "+settings.languages[23]);






				GUIStyle style2= GUI.skin.GetStyle ("button");	






				style2.font = fontMenu [0];
				style2.fontSize = fontsize_small;

				if (moveBay != 0) 
				{
						style2.normal.background = text [10];
						style2.hover.background = text [10];
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

				if(GUI.Button(new Rect(center/2-gui8[0],gui8[1],gui8[2],gui8[3]),settings.languages [52]) && acc ==false)
				{
						if(moveBay!=0)
						{
								StartCoroutine(MoveBay());
						}
				}


				style2.fontSize = 30;
				style2.normal.background = text [13];
				style2.hover.background  = text [13];
				style2.active.background = text [13];

				style.normal.textColor = color;
				style2.hover .textColor = color;
				style2.active.textColor = color;

				if(GUI.Button(new Rect(center/2-gui9[0],up-gui9[1],gui9[2],gui9[3]),settings.languages [54]) && acc ==false)
				{
						gameObject.GetComponent<GUIGame>().addG=true;
						gameObject.GetComponent<GUIGame>().addM=false;			
				}

				style2.normal.background = text [10];
				style2.hover.background  = text [10];
				style2.active.background = text [10];
				style2.fontSize = 48;


				if (moveBay > 1) 
				{
						if (GUI.Button (new Rect (center / 2 - gui10[0], gui10[1], gui10[2], gui10[3]), "-") && acc ==false) 
						{
								moveBay --;			
						}
				}

				if (moveBay < gold) 
				{
						if (GUI.Button (new Rect (center / 2 + gui11[0], gui11[1], gui11[2], gui11[3]), "+") && acc ==false) 
						{
								moveBay ++;			
						}
				}

		}



		IEnumerator MoveBay()
		{

				Dictionary<string, string> gameData = new Dictionary<string, string>();
				gameData.Add("code","6Av4TpIt");
				gameData.Add("login", PlayerPrefs.GetString ("login"));
				gameData.Add("pass", PlayerPrefs.GetString ("pass"));
				gameData.Add("operation","move");
				gameData.Add("quantity",System.Convert.ToString(moveBay));

				string json = JsonSerialize_DESerialize.Json.SerializeStringIndDictionary (gameData);
				sendingBase = Base64.Encode (json);
				sendingBase = GenerateKey.CreatingTrash (sendingBase);


				WWWForm form = new WWWForm() ;
				form.AddField("buy",sendingBase);
				WWW dowload = new WWW (addressRec,form);
				yield return dowload;

				returnBase = Base64.Decode(dowload.text).Split(new char[] {'|'});

				if(returnBase[0]=="connected")
				{
						gameObject.GetComponent<GUIGame>().MoveBay(System.Convert.ToInt32(returnBase[1]));
						gameObject.GetComponent<GUIGame>().addM=false;
				}

		}




}
