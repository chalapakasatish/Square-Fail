using System.Collections.Generic;
using UnityEngine;

public class UIPopupManager : SingletonComponent<UIPopupManager>
{
    #region Inspector Variables

    [SerializeField] private List<Popup> PopupPanels;
    #endregion

    public Stack<string> activePopups = new Stack<string>();
    public static bool isAnimating;

    #region Public Methods
    public void Show(string id)
    {
        GetPopupID(id).GetComponent<Popup>().Show();
        if (id == "PotionPanel" || id == "CoinsPanel" || id == "RewardPanel" || id == "SettingsPanel")
        {
            //AdManager.instance.HideBanner();
        }
    }

    public void Hide(string id)
    {
        GetPopupID(id).GetComponent<Popup>().Hide();
        if (id == "PotionPanel" || id == "CoinsPanel" || id == "RewardPanel" || id == "SettingsPanel")
        {
            if(GameManager.instance.gameState == GameState.FAILED || GameManager.instance.gameState == GameState.PLAYING)
            {
                return;
            }
            //AdManager.instance.ShowBanner();
        }
    }

    public Popup GetPopupID(string id)
    {
        for (int i = 0; i < PopupPanels.Count; ++i)
        {
            if (id == PopupPanels[i].GetComponent<Popup>().id)
            {
                return PopupPanels[i];
            }
        }
        Debug.LogError(" No PopupPanel exists with the id " + id);
        return null;
    }

    #endregion
}


