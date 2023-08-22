using DG.Tweening;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class Screen : MonoBehaviour
{
    public static float width;
    public static float height;
    #region Inspector Variables

    public string id;

    #endregion

    #region Properties

    public RectTransform RectT => gameObject.GetComponent<RectTransform>();

    #endregion

    #region Public Methods

    public virtual void Initialize()
    {

    }
    public virtual void OnShowing()
    {
        //if (id == "GameScreen")
        //    //AdManager.instance.HideBanner();

        //if (id == "MenuScreen")
        //    //AdManager.instance.ShowBanner();


        //StartCoroutine(AnimateMenu());
    }


    #endregion

    #region Private Methods
    private IEnumerator AnimateMenu()
    {
        yield return new WaitForEndOfFrame();
        DOTweenAnimation[] listTween = transform.GetComponentsInChildren<DOTweenAnimation>();
        for (int i = 0; i < listTween.Length; i++)
        {
            //if (listTween[i].autoPlay)
            {
                listTween[i].tween.Restart();
            }
        }

    }

    #endregion
}

