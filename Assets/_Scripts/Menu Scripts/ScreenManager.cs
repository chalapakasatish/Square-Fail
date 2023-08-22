using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace SimpleSolitaire.Controller
{
    public class ScreenManager : SingletonComponent<ScreenManager>
    {

        #region Inspector Variables
        [SerializeField] private List<Screen> uiScreens;
        [Space]
        public static bool isClicked;
        #endregion

        #region Member Variables
        // The screen that is currently being shown
        public Screen currentUIScreen;
        public bool isAnimating;


        public const string MenuScreen = "MenuScreen";
        public const string Gamescreen = "GameScreen";
        public const string ContinueScreen = "ContinueScreen";
        public const string SelectMode = "SelectMode";
        public const string LevelsScreen = "LevelsScreen";
        public const string LevelCompletedArcade = "LevelCompletedArcade";
        public const string LevelCompletedClassic = "LevelCompletedClassic";
        #endregion

        #region Unity Methods

        private IEnumerator Start()
        {

            // Initialize and hide all the screens
            for (int i = 0; i < uiScreens.Count; i++)
            {
                uiScreens[i].Initialize();
                uiScreens[i].gameObject.SetActive(true);

                HideUIScreen(uiScreens[i], null);

            }

            // Show the main screen when the app starts up
            yield return new WaitForSeconds(0.1f);
            ShowMainScreen();
        }

        public void ShowMainScreen()
        {

            //if (PlayerPrefs.GetInt(GlobalPlayerPrefsManager.I_FirstInstall_WC, 0) == 0) // show gamescrren
            //{
            //	PlayerPrefs.SetInt(GlobalPlayerPrefsManager.I_FirstInstall_WC, 1);
            //	PlayerPrefs.Save();
            //}

            //else
            //{
            //    ScreenManager.Instance.Show(MenuScreen);
            //}
            ScreenManager.Instance.Show(MenuScreen);
        }

        private void Update()
        {
            //back button functionality
            if (Input.GetKeyUp(KeyCode.Escape) && isAnimating == false && isClicked == false)
            {
                isClicked = true;

                if (UIPopupManager.Instance.activePopups.Count <= 0)
                {
                    switch (currentUIScreen.id)
                    {
                        case MenuScreen:
                            UIPopupManager.Instance.Show("QuitPanel");
                            break;
                        case Gamescreen:
                            UIPopupManager.Instance.Show("PausePanel");
                            Time.timeScale = 0;
                            break;

                        default:
                            break;
                    }
                }
                else if (UIPopupManager.Instance.activePopups.Count > 0)
                {
                    //GlobalSoundManager.instance.Play(AudioClipid.Button_open);
                    string activePopup = UIPopupManager.Instance.activePopups.Peek();

                    Debug.Log(activePopup);

                    Popup activePopupRequest = UIPopupManager.Instance.GetPopupID(activePopup);

                    if (activePopupRequest.IsPopupReqInput == true/* || FortuneWheelManager.instance.isSpinning == true || DailyRewardsManager.instance.dailyrewardcomplete == true*/)
                    {
                        Debug.Log(activePopup);
                        // return;
                    }
                    else
                    {
                        UIPopupManager.Instance.Hide(activePopup);
                    }
                    //if (activePopup == "DailyRewards")
                    //{
                    //    if (DailyRewardsManager.dailyrewardcomplete)
                    //    {
                    //        DailyRewardsManager.instance.OnClaimClicked();
                    //        // UIPopupManager.Instance.Hide("DailyRewards");
                    //    }
                    //}
                    //else if (activePopup == "SpinWheel")
                    //{
                    //    if (DailyRewardsManager.dailyrewardcomplete)
                    //    {
                    //        DailyRewardsManager.instance.OnClaimClicked();
                    //        // UIPopupManager.Instance.Hide("DailyRewards");
                    //    }
                    //}

                    //new line
                    //Time.timeScale = 1;
                }

                StartCoroutine(WaitforClick());
            }
        }
        #endregion

        #region Public Methods

        public void Show(string id, System.Action onTweenFinished = null)
        {

            if (isAnimating)
            {
                return;
            }

            isAnimating = true;
            Screen uiScreen = GetScreenInfo(id);

            if (uiScreen != null)
            {

                //switch (currentUIScreen.id)
                //{
                //    case "GameScreen":
                //        AdManager.instance.HideBanner();
                //        break;
                //    case "FailedScreen":
                //        AdManager.instance.ShowBanner();
                //        break;
                //    case "MenuScreen":
                //        AdManager.instance.ShowBanner();
                //        break;
                //}

                ShowUIScreen(uiScreen, onTweenFinished);


            }


        }


        #endregion

        #region Private Methods

        private void ShowUIScreen(Screen uiScreen, System.Action onTweenFinished)
        {

            if (uiScreen == null)
            {
                return;
            }
            uiScreen.OnShowing();
            currentUIScreen = uiScreen;
            uiScreen.gameObject.SetActive(true);
            

            isAnimating = false;
            if (onTweenFinished != null)
            {
                onTweenFinished();
            }
        }

        public void Hide(string id, System.Action onTweenFinished = null)
        {
            Screen uiScreen = GetScreenInfo(id);
            if (uiScreen != null)
            {
                HideUIScreen(uiScreen, onTweenFinished);
            }
        }

        private void HideUIScreen(Screen uiScreen, System.Action onTweenFinished)
        {
            if (uiScreen == null)
            {
                return;
            }
            uiScreen.gameObject.SetActive(false);

        }


        private Screen GetScreenInfo(string id)
        {
            for (int i = 0; i < uiScreens.Count; i++)
            {
                if (id == uiScreens[i].id)
                {
                    return uiScreens[i];
                }
            }

            Debug.LogError("[UIScreenController] No UIScreen exists with the id " + id);

            return null;
        }

        private IEnumerator WaitforClick()
        {
            yield return new WaitForSeconds(1f);
            isClicked = false;
        }

        #endregion


    }
}
