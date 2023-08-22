using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using SimpleSolitaire.Controller;


public class Popup : MonoBehaviour
{
    public static Popup instance;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    #region Inspector Variables

    public string id;
    public bool IsPopupReqInput = false;
    #endregion

    #region Member Variables

    private bool isShowing;

    #endregion

    #region Public Methods

    public virtual void Show()
    {

        if (isShowing)
        {
            return;
        }
        isShowing = true;
        gameObject.SetActive(true);
        UIPopupManager.Instance.activePopups.Push(id);

    }

    public virtual void Hide()
    {
        if (!isShowing)
        {
            return;
        }

        isShowing = false;
        gameObject.SetActive(false);
        UIPopupManager.Instance.activePopups.Pop();
    }
    #endregion


    
}