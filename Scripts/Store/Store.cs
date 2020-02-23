using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace LukasScripts
{
    /// <summary>
    /// set up the prices for different balls = done
    /// hook it up to ui  = done
    /// save the transaction = done
    /// minus out the difference = done
    /// able to pick any and = done
    ///  instantiate the proper player = done
    /// fix the previous btn so it actually shows selected ball info = done  
    /// play-test = done
    /// </summary>

    public class Store : MonoBehaviour
    {
        #region Values
        #region Buttons
        public Button buy_2_btn;
        public Button buy_3_btn;
        public Button buy_4_btn;
        public Button buy_5_btn;
        public Button nextBtn;
        public Button backBtn;


        public Button choose_1_Btn;
        public Button choose_2_Btn;
        public Button choose_3_Btn;
        public Button choose_4_Btn;
        public Button choose_5_Btn;
        #endregion

        public GameObject shopPanel;

        [SerializeField]
        private float timer = 1f;

        [SerializeField]
        private GameObject[] balls;
        private GameObject _currentBall;

        [SerializeField]
        private GameObject priceParent;

        [SerializeField]
        private Text priceTxt = null;

        public int _ballCounter { get; set;}

        #region Prices
        [System.Serializable]
        public class BallPrices
        {
            public int ball_2_Price = 200;
            public int ball_3_Price = 400;
            public int ball_4_Price = 600;
            public int ball_5_Price = 800;
           
        }

        public BallPrices ballPrices;
        #endregion
        #region Bools
        [HideInInspector]
        public bool hasSelected = false;
        private bool _ball2Bought = false;
        private bool _ball3Bought = false;
        #endregion
        public StoreAnimController animController;

        private PlayerData _playerData;

        private SaveManager saveManager;

        [SerializeField]
        private PlayerReferences references;

        [SerializeField]
        private BallSelector selector;

        [SerializeField]
        private StoreEvents storeEvents;



        #endregion

        private void Awake()
        {
            if (storeEvents == null)
                storeEvents = GetComponentInChildren<StoreEvents>();
        }

        private void Start()
        {
            _playerData = new PlayerData(SaveManager.instance);
            saveManager = SaveManager.instance;

            _currentBall = balls[0];
            _currentBall.SetActive(true);
            choose_1_Btn.gameObject.SetActive(true);
            buy_2_btn.gameObject.SetActive(false);
        }

      
        #region Store Balls

        public void BuyBall_2()
        {
            if (_playerData.cointCount >= ballPrices.ball_2_Price)
            {
               // add text that says you unlocked ball
                int result =  _playerData.cointCount - ballPrices.ball_2_Price;
                references.curCoinCount.value = result;
                references.e_Update_UI.Raise();
                references.boughtBall2 = true;
                // this event will disable buy button 
                storeEvents.RaiseBuyEvent2();
                choose_2_Btn.gameObject.SetActive(true);
                buy_2_btn.gameObject.SetActive(false);

                if (saveManager == null)
                    saveManager = SaveManager.instance;

                saveManager.SaveData();
               
            }
            else if (_playerData.cointCount< ballPrices.ball_2_Price)
            {
               // add text that says not enough coins
                return;
            }
        }




        public void BuyBall_3()
        {
            if (_playerData.cointCount >= ballPrices.ball_3_Price)
            {
            
                int result = _playerData.cointCount - ballPrices.ball_3_Price;
                references.curCoinCount.value = result;
                references.e_Update_UI.Raise();
                references.boughtBall3= true;
                storeEvents.RaiseBuyEvent3();


                if (saveManager == null)
                    saveManager = SaveManager.instance;

                saveManager.SaveData();


            }
            else if (_playerData.cointCount < ballPrices.ball_3_Price)
            {      
                return;
            }
        }

        public void BuyBall_4()
        {
            if (_playerData.cointCount >= ballPrices.ball_4_Price)
            {

                int result = _playerData.cointCount - ballPrices.ball_4_Price;
                references.curCoinCount.value = result;
                references.e_Update_UI.Raise();
                references.boughtBall4 = true;
                storeEvents.RaiseBuyEvent4();

                if (saveManager == null)
                    saveManager = SaveManager.instance;

                saveManager.SaveData();


            }
            else if (_playerData.cointCount < ballPrices.ball_4_Price)
            {
                return;
            }
        }

        public void BuyBall_5()
        {
            if (references.curCoinCount.value >= ballPrices.ball_5_Price)
            {

                int result = _playerData.cointCount - ballPrices.ball_5_Price;
                references.curCoinCount.value = result;
                references.e_Update_UI.Raise();
                references.boughtBall5 = true;
                storeEvents.RaiseBuyEvent5();


                if (saveManager == null)
                    saveManager = SaveManager.instance;

                saveManager.SaveData();


            }
            else if (_playerData.cointCount < ballPrices.ball_5_Price)
            {
                return;
            }
        }
        #endregion

        #region Chosed Ball
        public void ChosedBall()
        {
            hasSelected = true;
            selector.selector = 0;
            animController.CloseStore(timer, shopPanel);     
        }

        public void ChosedBall2()
        {
            hasSelected = true;
            selector.selector = 1;
            animController.CloseStore(timer, shopPanel);     
        }

        public void ChosedBall3()
        {
            hasSelected = true;
            selector.selector = 2;
            animController.CloseStore(timer, shopPanel);       
        }

        public void ChosedBall4()
        {
            hasSelected = true;
            selector.selector = 3;
            animController.CloseStore(timer, shopPanel);
        }

        public void ChosedBall5()
        {
            hasSelected = true;
            selector.selector = 4;
            animController.CloseStore(timer, shopPanel);
        }

        #endregion


        #region Browsing Bouncing Balls

        public void NextBall()
        {
            if (_ballCounter == balls.Length -1)
                  return;

            _ballCounter++;

            if (_ballCounter == 1)
            {
                _currentBall.SetActive(false);
                balls[1].SetActive(true);
                priceTxt.text = ballPrices.ball_2_Price.ToString();

                choose_1_Btn.gameObject.SetActive(false);
                buy_2_btn.gameObject.SetActive(true);

                if (references.boughtBall2 == true)
                {
                    choose_2_Btn.gameObject.SetActive(true);
                    buy_2_btn.gameObject.SetActive(false);

                    priceParent.SetActive(false);
                }
                else
                {
                    priceParent.SetActive(true);

                    choose_2_Btn.gameObject.SetActive(false);
                    buy_2_btn.gameObject.SetActive(true);
                }

            }

            if(_ballCounter == 2)
            {
                balls[1].SetActive(false);
                balls[2].SetActive(true);

                priceTxt.text = ballPrices.ball_3_Price.ToString();

                if(references.boughtBall3 == true)
                {
                    choose_3_Btn.gameObject.SetActive(true);
                    choose_2_Btn.gameObject.SetActive(false);
                    buy_3_btn.gameObject.SetActive(false);

                    priceParent.SetActive(false);
                }
                else
                {
                    #region Previous Btns
                    choose_2_Btn.gameObject.SetActive(false);
                    buy_2_btn.gameObject.SetActive(false);
                    #endregion

                    choose_3_Btn.gameObject.SetActive(false);
                    buy_3_btn.gameObject.SetActive(true);

                    priceParent.SetActive(true);
                }
               
            }
            if(_ballCounter == 3)
            {
                balls[2].SetActive(false);
                balls[3].SetActive(true);

                priceTxt.text = ballPrices.ball_4_Price.ToString();

                if(references.boughtBall4 == true)
                {
                    choose_3_Btn.gameObject.SetActive(false);
                    buy_4_btn.gameObject.SetActive(false);
                    choose_4_Btn.gameObject.SetActive(true);
                    priceParent.SetActive(false);
                }
                else
                {
                    #region Previous Btns
                    choose_3_Btn.gameObject.SetActive(false);
                    buy_3_btn.gameObject.SetActive(false);
                    #endregion

                    if(choose_4_Btn.gameObject.activeInHierarchy)
                        choose_4_Btn.gameObject.SetActive(false);

                    buy_4_btn.gameObject.SetActive(true);

                    priceParent.SetActive(true);
                }
            }
            if(_ballCounter == 4)
            {
                balls[3].SetActive(false);
                balls[4].SetActive(true);

                priceTxt.text = ballPrices.ball_5_Price.ToString();

                if(references.boughtBall5 == true)
                {
                    choose_4_Btn.gameObject.SetActive(false);
                    buy_5_btn.gameObject.SetActive(false);
                    choose_5_Btn.gameObject.SetActive(true);
                    
                    priceParent.SetActive(false);
                }
                else
                {
                    #region Previous Btns
                    choose_4_Btn.gameObject.SetActive(false);
                    buy_4_btn.gameObject.SetActive(false);
                    #endregion

                    if (choose_5_Btn.gameObject.activeInHierarchy)
                        choose_5_Btn.gameObject.SetActive(false);

                    buy_5_btn.gameObject.SetActive(true);

                    priceParent.SetActive(true);

                }
            }
         
        }

        public void previousBall()
        {

            _ballCounter--;

            if (_ballCounter <= 0)
                _ballCounter = 0;

            if (_ballCounter == 0)
            {
                _ballCounter = 0;

                balls[1].SetActive(false);
                _currentBall.SetActive(true);

                choose_1_Btn.gameObject.SetActive(true);
                choose_2_Btn.gameObject.SetActive(false);

                priceParent.SetActive(false);

                if(buy_2_btn.gameObject.activeInHierarchy || buy_3_btn.gameObject.activeInHierarchy)
                {
                    buy_2_btn.gameObject.SetActive(false);
                    buy_3_btn.gameObject.SetActive(false);
                }

            }

            else if(_ballCounter == 1)
            {
                balls[2].SetActive(false);
                balls[1].SetActive(true);


                if (buy_3_btn.gameObject.activeInHierarchy)
                    buy_3_btn.gameObject.SetActive(false);

                if (references.boughtBall2 == true)
                {
                    choose_3_Btn.gameObject.SetActive(false);
                    choose_2_Btn.gameObject.SetActive(true);
                    buy_2_btn.gameObject.SetActive(false);

                    priceParent.SetActive(false);
                }
                else
                {
                    buy_3_btn.gameObject.SetActive(false);
                    choose_2_Btn.gameObject.SetActive(false);
                    buy_2_btn.gameObject.SetActive(true);

                    priceParent.SetActive(true);
                    priceTxt.text = ballPrices.ball_2_Price.ToString();
                }
            } 

            else if (_ballCounter == 2)
            {
                balls[3].SetActive(false);
                balls[2].SetActive(true);

                if (buy_4_btn.gameObject.activeInHierarchy)
                    buy_4_btn.gameObject.SetActive(false);

             

                if (references.boughtBall4 == true)
                {
                    choose_4_Btn.gameObject.SetActive(false);
                    choose_3_Btn.gameObject.SetActive(true);
                    buy_3_btn.gameObject.SetActive(false);

                    priceParent.SetActive(false);
                }
                else
                {
                    buy_3_btn.gameObject.SetActive(true);
                    choose_3_Btn.gameObject.SetActive(false);
                    buy_4_btn.gameObject.SetActive(false);

                    priceParent.SetActive(true);
                    priceTxt.text = ballPrices.ball_3_Price.ToString();
                }
         


            }
            else if(_ballCounter == 3)
            {
                balls[4].SetActive(false);
                balls[3].SetActive(true);

                if (buy_5_btn.gameObject.activeInHierarchy)
                    buy_5_btn.gameObject.SetActive(false);

                if (references.boughtBall3)
                {
                    if(choose_5_Btn.gameObject.activeInHierarchy)
                         choose_5_Btn.gameObject.SetActive(false);

                    buy_4_btn.gameObject.SetActive(false);
                    choose_4_Btn.gameObject.SetActive(true);

                    priceParent.SetActive(false);
                }
                else
                {
                    if (choose_5_Btn.gameObject.activeInHierarchy)
                        choose_5_Btn.gameObject.SetActive(false);

                    choose_4_Btn.gameObject.SetActive(false);
                    buy_4_btn.gameObject.SetActive(true);

                    priceParent.SetActive(true);
                    priceTxt.text = ballPrices.ball_3_Price.ToString();
                }
            }
            
        }

        #endregion

     

    }

}