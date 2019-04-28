using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using DG.Tweening;

public class UIManager : MonoBehaviour {

    [Header("Start Menu")]
    public Transform startMenu;
    public RectTransform title;
    public RectTransform buttonPlay;
    public RectTransform buttonSelect;
    public RectTransform buttonMenu;
    public RectTransform buttonSetting;
    [Space(10)]

    [Header("Setting")]
    public RectTransform settingMenu;
    [Space(10)]

    [Header("Tutorial")]
    public Transform tutorialMenu;
    public Text content;
    public Image describe;
    public Sprite[] allDescribes;
    private int orderTutorial;
    private string[] contents = { "PRESS K TO JUMP", "HOLD K TO FLY UP\nRELEASE K TO FLY DOWN","TAP WHILE TOUCHING A RING TO PERFORM A RING JUMP" };
    [Space(10)]

    [Header("Pause Menu")]
    public Transform pauseMenu;
    public GameObject textPause;
    public GameObject textComplete;
    public GameObject buttonContinue;
    public GameObject buttonPlayAgain;
    [Space(10)]

    [Header("Sub Menu")]
    public RectTransform subMenu;
    [Space(10)]

    [Header("World Menu")]
    public Transform worldMenu;
    // Use this for initialization
    void Start () {
        if(startMenu != null)
        ShowStartMenu();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    #region Start Menu
    public void ShowStartMenu()
    {
        startMenu.gameObject.SetActive(true);
        ShowStartMenuElements();
        HideSubMenu();
        HideSetting();
        HideWorldMenu();
    }
    void HideStartMenu()
    {
        HideStartMenuElements();
        startMenu.gameObject.SetActive(false);
    }
    void ShowStartMenuElements()
    {
        title.DOAnchorPosY(230, 0.25f);
        buttonSelect.DOAnchorPosX(-290, 0.25f);
        buttonMenu.DOAnchorPosX(290, 0.25f);
        buttonSetting.DOAnchorPosY(-270, 0.25f);
    }
    void HideStartMenuElements()
    {
        title.DOAnchorPosY(450, 0.25f);
        buttonSelect.DOAnchorPosX(-750, 0.25f);
        buttonMenu.DOAnchorPosX(750, 0.25f);
        buttonSetting.DOAnchorPosY(-450, 0.25f);
    }
    #endregion

    #region Setting
    public void ShowSetting()
    {
        settingMenu.DOAnchorPosY(0, 0.3f);
    }

    void HideSetting()
    {
        settingMenu.DOAnchorPosY(700, 0.3f);
    }
    #endregion

    #region Tutorial
    public void ShowTutorial() {
        orderTutorial = 0;
        content.text = contents[orderTutorial];
        describe.sprite = allDescribes[orderTutorial];
        tutorialMenu.gameObject.SetActive(true);
        tutorialMenu.DOScale(new Vector3(1, 1, 1), 0.3f);
    }
    public void HideTutorial()
    {
        tutorialMenu.DOScale(Vector3.zero, 0.15f);
        tutorialMenu.gameObject.SetActive(false);
    }

    public void NextContent()
    {
        orderTutorial++;
        if (orderTutorial > 2)
        {
            HideTutorial();
        }
        else
        {
            content.text = contents[orderTutorial];
            describe.sprite = allDescribes[orderTutorial];
        }
    }
    #endregion

    #region Pause Menu
    public void ShowPauseMenu(bool isComplete)
    {
        pauseMenu.gameObject.SetActive(true);
        if (!isComplete)
        {
            textPause.SetActive(true);
            textComplete.SetActive(false);
            buttonContinue.SetActive(true);
            buttonPlayAgain.SetActive(false);
        }
        else
        {
            textPause.SetActive(false);
            textComplete.SetActive(true);
            buttonContinue.SetActive(false);
            buttonPlayAgain.SetActive(true);
        }
    }

    public void HidePauseMenu()
    {
        pauseMenu.gameObject.SetActive(false);
    }
    #endregion

    #region SubMenu
    public void ShowSubMenu()
    {
        subMenu.DOAnchorPosX(0, 0.3f);
        HideStartMenu();
    }
    void HideSubMenu()
    {
        subMenu.DOAnchorPosX(1350, 0.3f);
    }
    #endregion
    #region World Menu
    public void ShowWorldMenu()
    {
        worldMenu.gameObject.SetActive(true);
        worldMenu.DOScale(new Vector3(1, 1, 1), 0.25f);
    }
    void HideWorldMenu()
    {
        worldMenu.DOScale(Vector3.zero, 0.25f);
        worldMenu.gameObject.SetActive(false);
    }
    #endregion
}
