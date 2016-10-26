using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using OnePF;

using Assets.Scripts.Common;
using JsonSerialize_DESerialize;
using Assets.Scripts.Generate;


public class AddGold : MonoBehaviour 
{	
		private  const string SKU_100 = "gold100";
		private  const string SKU_200 = "gold200";
		private  const string SKU_400 = "gold400";

		private  string       sendingBase;
		private  settingsGame settings;	
		private  float        center;
		private  float        up; 

		public  int           goldPrise;
		public   const string googleKey ="MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAkjqxWnup5GstNVUPZVS1nFAjrjhicB2mLF1mf6KG71qCi1KPdtJbBmMZep1jHcV3tju24LUKGGMmLq2+xF5+qpMUW78dolYj/tuSigy6khzcJ8c5Cum25syrzARgXkplvDmuWP9/BHN1QT87UxQrcX0iFHaTVBjk3oDRTx9YvmdMAkzXNUfIA+nV96eF6Xd9uc3VqWN/zv4zxKWmHVXfM2vjeQaeflgQ2XcZ8Q2kt8yL5icHf52MEQ9RnhPp3IM3H9cUcQjheDEBLskR6vpfFIXYE8nKtAFwtJ1WhxYIMVJv0INB+ex2tzoAUrFuYqTCjzhiu5l/PhY87c0wX+dRaQIDAQAB";

		public float topOffset;

		public int fontsize_small = 28;

		private void Awake()
		{
				goldPrise  = 1;
				center     = Screen.width / (Screen.height / 720.0f) ;
				up         = Screen.height/ (Screen.height / 720.0f) ;

				settings=gameObject.GetComponent<settingsGame>();

				// Subscribe to all billing events
				OpenIABEventManager.billingSupportedEvent += OnBillingSupported;
				OpenIABEventManager.billingNotSupportedEvent += OnBillingNotSupported;
				OpenIABEventManager.purchaseSucceededEvent += OnPurchaseSucceded;
				OpenIABEventManager.purchaseFailedEvent += OnPurchaseFailed;
				OpenIABEventManager.consumePurchaseSucceededEvent += OnConsumePurchaseSucceeded;
				OpenIABEventManager.consumePurchaseFailedEvent += OnConsumePurchaseFailed;
				OpenIABEventManager.transactionRestoredEvent += OnTransactionRestored;
				OpenIABEventManager.restoreSucceededEvent += OnRestoreSucceeded;
				OpenIABEventManager.restoreFailedEvent += OnRestoreFailed;

				topOffset = 200;
		}	

		private void OnDestroy()
		{
				// Unsubscribe to avoid nasty leaks
				OpenIABEventManager.billingSupportedEvent -= OnBillingSupported;
				OpenIABEventManager.billingNotSupportedEvent -= OnBillingNotSupported;
				OpenIABEventManager.purchaseSucceededEvent -= OnPurchaseSucceded;
				OpenIABEventManager.purchaseFailedEvent -= OnPurchaseFailed;
				OpenIABEventManager.consumePurchaseSucceededEvent -= OnConsumePurchaseSucceeded;
				OpenIABEventManager.consumePurchaseFailedEvent -= OnConsumePurchaseFailed;
				OpenIABEventManager.transactionRestoredEvent -= OnTransactionRestored;
				OpenIABEventManager.restoreSucceededEvent -= OnRestoreSucceeded;
				OpenIABEventManager.restoreFailedEvent -= OnRestoreFailed;
		}



		private void Start()
		{
				OpenIAB.mapSku(SKU_100, OpenIAB_Android.STORE_GOOGLE, "gold100");
				OpenIAB.mapSku(SKU_200, OpenIAB_Android.STORE_GOOGLE, "gold200");
				OpenIAB.mapSku(SKU_400, OpenIAB_Android.STORE_GOOGLE, "gold400");

				var options = new OnePF.Options();	
				options.storeKeys.Add(OpenIAB_Android.STORE_GOOGLE,googleKey);
				options.verifyMode = OptionsVerifyMode.VERIFY_ONLY_KNOWN;
				OpenIAB.init(options);
		}


		private void OnBillingSupported()
		{
				OpenIAB.queryInventory(new string[] { SKU_100, SKU_200, SKU_400 }); //если возможны покупки запрашиваем наши
		}



		private void OnBillingNotSupported(string error)
		{

		}


		private void OnQueryInventoryFailed(string error)
		{

		}




		public	void PurchasesRubiks (Texture2D[] text,Font[] fontMenu, int gold, bool acc) 
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

				GUI.Label (new Rect(center/2-300,20,600,50),settings.languages [22]);

				style.normal.textColor = color;
				style.fontSize = 100;

				GUI.Label (new Rect(center/2-300,70,600,110),""+gold);


				style.normal.textColor = Color.white;
				style.fontSize = fontsize_small;
				GUI.Label (new Rect(center/2-300,180,600,50),settings.languages [23]);

				style.normal.background = text [12];


				GUI.Label (new Rect (center/2-200,242,400,2),"");

				style.normal.background = null;

				GUI.Label (new Rect(center/2-300,244,600,64),settings.languages [24]);

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

				GUI.Label (new Rect(center/2-60,328,120,120),""+ goldPrise*100);


				style.normal.textColor = Color.white;
				style.hover .textColor = Color.white;
				style.active.textColor = Color.white;

				style.normal.background = null;
				style.hover .background = null;
				style.active.background = null;

				style.fontSize = fontsize_small;

				//GUI.Label (new Rect(center/2-300,468,600,50),settings.languages [25]+goldPrise+" $");

				GUIStyle style2          = GUI.skin.GetStyle ("button");	

				style2.normal.textColor = color;
				style2.hover .textColor = color;
				style2.active.textColor = color;

				style2.font = fontMenu [0];


				style2.fontSize = 30;
				style2.normal.background = text [10];
				style2.hover.background  = text [10];
				style2.active.background = text [10];

				if(GUI.Button(new Rect(center/2-272.5f,up-topOffset,545,58),settings.languages [26]) && acc ==false)
				{
						Bay(goldPrise);
				}


				style2.fontSize = 48;


				if (goldPrise > 1) 
				{
						if (GUI.Button (new Rect (center / 2 - 145, 358, 60, 60), "-") && acc ==false) 
						{
								goldPrise /=2;			
						}
				}

				if (goldPrise < 3) 
				{
						if (GUI.Button (new Rect (center / 2 + 85, 358, 60, 60), "+") && acc ==false) 
						{
								goldPrise *=2;			
						}
				}

		}

		public void Bay(int bayNumbe)
		{
				if(bayNumbe==1)
				{
						OpenIAB.purchaseProduct(SKU_100);
				}
				if(bayNumbe==2)
				{
						OpenIAB.purchaseProduct(SKU_200);
				}
				if(bayNumbe==4)
				{
						OpenIAB.purchaseProduct(SKU_400);
				}
		}


		private void OnPurchaseSucceded(Purchase purchase)
		{
				if (purchase.Sku == SKU_100)
				{
						OpenIAB.consumeProduct(purchase);
				}
				if (purchase.Sku == SKU_200)
				{
						OpenIAB.consumeProduct(purchase);
				}
				if (purchase.Sku == SKU_400)
				{
						OpenIAB.consumeProduct(purchase);
				}
		}


		private void OnPurchaseFailed(int errorCode, string error)
		{

		}

		private void OnConsumePurchaseSucceeded(Purchase purchase)
		{
				StartCoroutine(GoldsBay(goldPrise*100));
		}

		private void OnConsumePurchaseFailed(string error)
		{

		}

		private void OnTransactionRestored(string sku)
		{

		}

		private void OnRestoreSucceeded()
		{

		}

		private void OnRestoreFailed(string error)
		{

		}





		private IEnumerator GoldsBay(int gold)
		{

				Dictionary<string, string> gameData = new Dictionary<string, string>();
				gameData.Add("code","6Av4TpIt");
				gameData.Add("login", PlayerPrefs.GetString ("login"));
				gameData.Add("operation","Gold");
				gameData.Add("quantity",System.Convert.ToString(gold));

				string jsonBayGold = JsonSerialize_DESerialize.Json.SerializeStringIndDictionary (gameData);
				sendingBase = Base64.Encode (jsonBayGold);
				sendingBase = GenerateKey.CreatingTrash (sendingBase);


				WWWForm formGold = new WWWForm() ;
				formGold.AddField("buygold",sendingBase);
				WWW dowloadGold = new WWW ("http://games.pinguin-studio.com.ua/shop.php",formGold);
				yield return dowloadGold;
				if(dowloadGold.text=="connected")
				{
						gameObject.GetComponent<GUIGame>().Start();
				}

		}




}
