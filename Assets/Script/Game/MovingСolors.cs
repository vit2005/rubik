using UnityEngine;
using System.Collections.Generic;

public class MovingСolors : MonoBehaviour {
		public       AudioClip        gameSound         ;
		public       List<Texture>    colorsSelected    ;
		private      ControllerRB     parentControl     ;
		private      Vector2          mausPos           ;
		private      int              lenght            ;
		public       int[]            cD                ;   
		private      Texture          temporary         ;
		public       int[]            line              ;
		public       List<Texture>    vert              ;
		public	     int              m                 ;

		private      AudioSource      source            ;

		private      string           saveGame          ;

		void Awake () 
		{
				source = GetComponent<AudioSource>();

				parentControl =gameObject.GetComponent<ControllerRB>();
				lenght        =parentControl.lenght;
		}


		void Update () 
		{
				mausPos.x=Input.mousePosition.x;
				mausPos.y=Screen.height-Input.mousePosition.y;	

				cD=parentControl.coordinates;
				if (Time.timeScale != 0)
				{
						RotateGorizont ();

						if (cD [0] != 0 && cD [0] != lenght + 1) {
								RotateVert ();
						}
				}
		}





		void RotateGorizont()
		{




				//Перемещение влево
				Rect leftRect = parentControl.ButtonTap;
				leftRect.x   -= parentControl.ButtonTap.width;
				//Debug.Log (string.Format("leftRect:[{0},{1}] mouse:[{2},{3}]",leftRect.x, leftRect.y, mausPos.x, mausPos.y));
				if(leftRect.Contains(mausPos))
				{

						if (PlayerPrefs.GetInt ("sound") != 1) 
						{
								source.PlayOneShot(gameSound,1);
						}


						if(cD[1] != 0)
						{


								for(int i=0;i<lenght;i++)
								{
										int ind=i*lenght+cD[1];
										colorsSelected[i]=parentControl.texture[ind];
								}
								temporary=colorsSelected[0];
								colorsSelected.RemoveAt(0);
								colorsSelected.Add(temporary);		

								for(int e=0;e<lenght;e++)
								{
										int ind=e*lenght+cD[1];
										parentControl.texture[ind]=colorsSelected[e];
								}
								parentControl.coordinates[0]--;
						}
						else
						{
								parentControl.moreCell--;
								parentControl.coordinates[0]=Mathf.Clamp(parentControl.moreCell,1,lenght);
						}
				}
				//Вправо

				Rect RightRect = parentControl.ButtonTap;
				RightRect.x   += parentControl.ButtonTap.width;


				if(RightRect.Contains(mausPos))
				{
						if (PlayerPrefs.GetInt ("sound") != 1) 
						{
								source.PlayOneShot(gameSound,1);
						}

						if(cD[1] != 0)
						{
								for(int g=0;g<lenght;g++)
								{
										int ind=g*lenght+cD[1];
										colorsSelected[g]=parentControl.texture[ind];
								}
								temporary=colorsSelected[colorsSelected.Count-1];
								colorsSelected.Insert(0,temporary);
								colorsSelected.RemoveAt(colorsSelected.Count-1);


								for(int j=0;j<lenght;j++)
								{
										int ind=j*lenght+cD[1];
										parentControl.texture[ind]=colorsSelected[j];
								}
								parentControl.coordinates[0]++;
						}
						else
						{
								parentControl.moreCell++;
								parentControl.coordinates[0]=parentControl.moreCell;
						}

				}
		}

		void RotateVert()
		{
				line=new int[3];
				line[0]=(cD[0]-1)*lenght+cD[1];//выбраное
				line[1]=(cD[0]-1)*lenght+1;//начало
				line[2]=(cD[0]-1)*lenght+lenght;//конец

				vert=new List<Texture>();

				if(parentControl.coordinates[0]==parentControl.moreCell)
				{
						vert.Add(parentControl.texture[0]);

						for(int v=line[1];v <= line[2];v++)
						{
								vert.Add(parentControl.texture[v]);
						}
				}
				else
				{
						for(int g=line[1];g <= line[2];g++)
						{
								if (parentControl.texture.Count < g)
									vert.Add(parentControl.texture[g]);
						}
				}


				if(vert.Count==lenght)
				{
						m=cD[1]-1;
				}
				else
				{
						m=cD[1];
				}

				// Вверх

				Rect UpRect  = parentControl.ButtonTap;
				UpRect.y    -= parentControl.ButtonTap.height;


				if(UpRect.Contains(mausPos))
				{
						if (vert.Count > 0) {
								for (int i = m; i >= 0; i--) {
										if (vert [i].name == "kubik_top") {
												if (PlayerPrefs.GetInt ("sound") != 1) {
														source.PlayOneShot (gameSound, 1);
												}

												vert.RemoveAt (i);
												vert.Insert (m, parentControl.colors [0]);
												parentControl.coordinates [1]--;
										}
								}
						}

				}
				// Вниз

				Rect DownRect = parentControl.ButtonTap;
				DownRect.y   += parentControl.ButtonTap.height;

				if(DownRect.Contains(mausPos))
				{

						if (vert.Count > 0) {
								for (int e = m; e < vert.Count; e++) {
										if (vert [e].name == "kubik_top") {
												if (PlayerPrefs.GetInt ("sound") != 1) {
														source.PlayOneShot (gameSound, 1);
												}

												vert.Insert (m, parentControl.colors [0]);
												vert.RemoveAt (e + 1);
												if (parentControl.coordinates [1] == 0) {
														gameObject.GetComponent<GUIGame> ().Move ();
												}
												parentControl.coordinates [1]++;	

										}
								}
						}
				}

				if(vert.Count==lenght)
				{
						for(int r=0;r<vert.Count;r++)
						{
								parentControl.texture[line[1]+r]=vert[r];
						}
				}
				else
				{
						if (vert.Count > 0)
							parentControl.texture[0]=vert[0];
						for(int r2=1;r2<vert.Count;r2++)
						{
								parentControl.texture[line[1]+(r2-1)]=vert[r2];
						}
				}



		}

		void SaveGamePlayer()
		{
				saveGame = Application.loadedLevelName;
				for (int load = 0; load < parentControl.texture.Count; load ++) 
				{
				}
				PlayerPrefs.SetString ("saveGameLoad",saveGame);
		}


}
