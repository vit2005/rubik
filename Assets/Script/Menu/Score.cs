using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Common;
using JsonSerialize_DESerialize;
using Assets.Scripts.Generate;


public class Score : MonoBehaviour 
{
		public   string[] scoreGame;
		public   Texture2D []  text       ;
		public   Font []       fontScore  ;
		public   List<string>  Name       ;
		public   settingsGame  settings   ;
		public   Menu          menuScript ; 	
		public   int            level      ;

		public   string        returnBase;
		public   string        addressRec;	
		public   string        sendingBase;


		public  List<string>   namePl;
		public  List<string>   move;
		public  List<string>   time;
		public  List<string>   player;


		public   string[]      score      ;
		private  Vector3       scale      ;
		private  float         center     ;
		private  float         up         ;

		private  Color         color      ;
		private  Color         colorGrey  ;
		private  Color         colorYellow;

		public List<float> level_btns;

		public List<float> number_txt;
		public List<float> name_txt;
		public List<float> moves_txt;
		public List<float> time_txt;

		public List<float> number_val;
		public List<float> name_val;
		public List<float> moves_val;
		public List<float> time_val;

		public List<float> line1;
		public List<float> line2;
		public List<float> line3;

		void Awake () 

		{
				settings = gameObject.GetComponent<settingsGame>();
				StartCoroutine(RecordsSetBase());

				if(player.Count == 0)
				{
						player.Add(" ");
						player.Add(" ");
						player.Add(" ");
						player.Add(" ");
				}


				center   = Screen.width /(Screen.height / 720.0f) / 2;
				up       = Screen.height / (Screen.height / 720.0f);
				scale.x  = Screen.height/720.0f;
				scale.y  = Screen.height/720.0f;
				scale.z  = 1;

				level_btns = new List<float>(){190, 100, 30, 80, 30};
				number_txt = new List<float>(){170, 50, 60, 70};
				name_txt = new List<float>(){-10, 50, 410, 70};
				moves_txt = new List<float>(){-183, 50, 150, 70};
				time_txt = new List<float>(){-112, 50, 150, 70};

				number_val = new List<float>(){-11, 90, 50, 410, 70};
				name_val = new List<float>(){200, 90, 50, 80, 70};
				moves_val = new List<float>(){-185, 90, 50, 150, 70};
				time_val = new List<float>(){-110, 90, 50, 150, 70};

				line1 = new List<float>(){143, 100, 2, 450};
				line2 = new List<float>(){-73, 100, 2, 450};
				line3 = new List<float>(){0, 100, 2, 450};

		}


		void Start()
		{
				Name.Add("3x3");
				Name.Add("4x4");
				Name.Add("5x5");
				Name.Add("6x6");



				colorGrey.r   = 68.0f/255.0f;
				colorGrey.g   = 66.0f/255.0f;
				colorGrey.b   = 63.0f/255.0f;
				colorGrey.a   = 1;


				color.r       = 154.0f/255.0f;
				color.g       = 154.0f/255.0f;
				color.b       = 154.0f/255.0f;
				color.a       = 1;



				colorYellow.r = 255.0f/255.0f;
				colorYellow.g = 189.0f/255.0f;
				colorYellow.b = 75.0f/255.0f;
				colorYellow.a = 1;


		}


		public 	void ScoreGame ()

		{



				GUI.matrix          = Matrix4x4.Scale (scale);

				GUIStyle style      = GUI.skin.GetStyle ("button");
				GUIStyle style2     = GUI.skin.GetStyle ("label");


				style.fontStyle     = FontStyle.Normal;
				style2.fontStyle    = FontStyle.Normal;
				style.alignment     = TextAnchor.MiddleCenter;
				style.font          = fontScore [0];
				style.fontSize      = 30;



				for (int e=0; e<4; e++) //Выводим кнопки выбора уровня
				{
						if (e == level)           //Если выбран этот  уровень  
						{
								style.normal.textColor = Color.white;
								style.hover.textColor  = Color.white;
								style.active.textColor = Color.white;

								style.normal.background = text [0];
								style.hover.background  = text [0];
								style.active.background = text [0];
						} 
						else                       //Если другой
						{
								style.normal.textColor  = colorGrey;
								style.hover.textColor   = colorGrey;
								style.active.textColor  = colorGrey;

								style.normal.background = text [1];
								style.hover.background  = text [1];
								style.active.background = text [1];
						}
						if (GUI.Button (new Rect (center - level_btns[0]+(level_btns[1] * e), level_btns[2], level_btns[3], level_btns[4]), Name [e])) //Выводим кнопку выбора одного из уровней
						{
								level = e;//Меняем на выбранный уровень

								StartCoroutine(RecordsSetBase());//отправляем запрос на получение рекордов
						}
				}


				style.normal.background = text [4];
				style.hover.background  = text [4];
				style.active.background = text [4];

				style.normal.textColor = colorGrey;
				style.hover.textColor  = colorGrey;
				style.active.textColor = colorGrey;
				style.fontSize = 24;

				if (GUI.Button (new Rect (center * 2 - 196, up - 115, 170, 90), settings.languages [21])) //Кнопка выхода из рекордов
				{
						menuScript.score = false;
				}


				style2.normal.background = null;
				style2.normal.textColor = color;
				style2.fontSize = 18;
				style2.font=fontScore[1];

				style2.alignment   = TextAnchor.MiddleLeft;
				GUI.Label(new Rect(center-number_txt[0], number_txt[1], number_txt[2],number_txt[3]),"№");// Позиция игрока
				GUI.Label(new Rect(center-name_txt[0],name_txt[1],name_txt[2],name_txt[3]),settings.languages [55]);//Имя 

				style2.alignment   = TextAnchor.MiddleCenter;
				GUI.Label(new Rect(center+moves_txt[0] ,moves_txt[1],moves_txt[2],moves_txt[3]),settings.languages [13]);//Ходы
				GUI.Label(new Rect(center+time_txt[0],time_txt[1],time_txt[2],time_txt[3]),settings.languages [16]);//Время


				style2.fontSize = 18;
				style2.font=fontScore[0];

				if(score.Length >= 4)//Проверка получили ли данные с базы 
				{
						for (int i = 0; i < namePl.Count && i < 10;i++) 
						{
								if(namePl[i] == PlayerPrefs.GetString ("login"))//Проверка мой ли рекорд выводится 
								{
										style2.normal.textColor = colorYellow;
								}
								else
								{
										style2.normal.textColor = Color.white;
								}


								style2.alignment   = TextAnchor.MiddleLeft;


								GUI.Label(new Rect(center-number_val[0], number_val[1]+(number_val[2]*i), number_val[3], number_val[4]),namePl[i]);//Имя 

								style2.alignment   = TextAnchor.MiddleCenter;
								GUI.Label(new Rect(center-name_val[0], name_val[1]+(name_val[2]*i), name_val[3], name_val[4]),(i+1)+"");// Позиция игрока
								GUI.Label(new Rect(center+moves_val[0], moves_val[1]+(moves_val[2]*i),moves_val[3], moves_val[4]),move[i]);//Ходы	
								GUI.Label(new Rect(center+time_val[0], time_val[1]+(time_val[2]*i),time_val[3], time_val[4]),time[i]);//Время
						}


						style2.normal.background = text[3];
						style2.normal.textColor = colorYellow;
						style2.alignment   = TextAnchor.MiddleLeft;

						//GUI.Label(new Rect(center-445,up-(70),750,50),"");

						style2.normal.background = null;


//						if(player.Count==4)
//						{
//								GUI.Label(new Rect(center-number_val[0],up-(number_val[1]),number_val[2],number_val[3]),player[1]);//Имя 	
//								style2.alignment = TextAnchor.MiddleCenter;
//								GUI.Label(new Rect(center-name_val[0],up-(name_val[1]),name_val[2], name_val[3]),player[0]);// Позиция игрока
//								GUI.Label(new Rect(center+name_val[0] ,up-(name_val[1]),name_val[2],name_val[3]),player[2]);//Ходы	
//								GUI.Label(new Rect(center+name_val[0],up-(name_val[1]),name_val[2],name_val[3]),player[3]);//Время
//						}

				}

				style2.normal.background = text[2];		
				GUI.Label(new Rect(center-line1[0], line1[1], line1[2], line1[3]), ""); //Разделительные полосы
				GUI.Label(new Rect(center+line2[0], line2[1], line2[2], line2[3]), "");
				GUI.Label(new Rect(center+line3[0], line3[1], line3[2], line3[3]), "");
				style2.normal.background = null;
		}



		IEnumerator RecordsSetBase()
		{
				namePl.Clear();//Чистим массивы с информацией рекордов
				move.Clear();
				time.Clear();


				Dictionary<string, string> gameData = new Dictionary<string, string>();
				gameData.Add("code","6Av4TpIt");
				gameData.Add("login",PlayerPrefs.GetString ("login"));
				gameData.Add("lvl",System.Convert.ToString(level+1));


				string json = JsonSerialize_DESerialize.Json.SerializeStringIndDictionary (gameData);
				sendingBase = Base64.Encode (json);
				sendingBase = GenerateKey.CreatingTrash (sendingBase);

				WWWForm form = new WWWForm() ;
				form.AddField("str",sendingBase);
				WWW dowload = new WWW (addressRec,form);
				yield return dowload;
				returnBase=dowload.text;

				scoreGame   = returnBase.Split(new char[] {'*'});
				score       = scoreGame[0].Split(new char[] {'|'});
				string[] scorePlayer = scoreGame[1].Split(new char[] {'|'});

				if(scorePlayer.Length == 4)
				{
						int e = 0;
						for (int iR = 0; iR  < score.Length/3;iR++) 
						{
								namePl.Add(score[e]);//Имя 
								e++;				
								move.Add(score[e]);//Ходы
								e++;

								int timerM =(int)(System.Convert.ToInt32(score[e])/60);
								int timerS =System.Convert.ToInt32(score[e])-(timerM*60);

								if(timerS >= 10)
								{
										time.Add(System.Convert.ToString(timerM)+":"+System.Convert.ToString(timerS));//Время
								}
								else
								{
										time.Add(System.Convert.ToString(timerM)+":0"+System.Convert.ToString(timerS));//Время
								}
								e++;
						}
						if(PlayerPrefs.GetString("login")!="")

						{
								player[0]=scorePlayer[0];
								player[1]=scorePlayer[1];
								player[2]=scorePlayer[2];

								if(scorePlayer[3]!="-")
								{
										int timerMP =(int)(System.Convert.ToInt32(scorePlayer[3])/60);
										int timerSP =System.Convert.ToInt32(scorePlayer[3])-(timerMP*60);

										if(timerSP >= 10)
												player[3]=System.Convert.ToString(timerMP)+":"+System.Convert.ToString(timerSP);
										else
										{
												player[3]=System.Convert.ToString(timerMP)+":0"+System.Convert.ToString(timerSP);
										}
								}
								else
								{
										player[3]=scorePlayer[3];
								}
						}



				}



		}



}
