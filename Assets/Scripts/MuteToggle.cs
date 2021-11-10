using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Toggle))]
public class MuteToggle : MonoBehaviour
{
    [SerializeField]
    private RectTransform uiHandelRectTransform;

    Image backgroundImage , handelImage;

    Color BackgoundDefaultColor, handelDefaultColor;
    
    public Color backgroundActivateColor;
    public Color handelActivateColor;
   

    private Toggle myToggle;
    private Vector2 handelPosition;
    

    
    // Start is called before the first frame update
    void Start()
    {       
        myToggle = GetComponent<Toggle>();
        handelPosition = uiHandelRectTransform.anchoredPosition;

        backgroundImage = uiHandelRectTransform.parent.GetComponent<Image>();
        handelImage = uiHandelRectTransform.GetComponent<Image>();

        BackgoundDefaultColor = backgroundImage.color;
        handelDefaultColor = handelImage.color;

        myToggle.onValueChanged.AddListener(OnSwitch);

        if (myToggle.isOn)
        {
            OnSwitch(true);
        }

        //this is for audio on-off
        if (AudioListener.volume == 0)
        {
            myToggle.isOn = false;
        }
    }


    public void ToggleAudioOnValueChanged(bool audioIn)
    {
        if (audioIn)
        {
            AudioListener.volume = 1;
        }
        else
        {
          AudioListener.volume = 0;
        }
    }

   //this is for toggle animation
    void OnSwitch(bool on)
    {
        if (on)
        {
            uiHandelRectTransform.anchoredPosition = handelPosition * -1;
            backgroundImage.color = backgroundActivateColor;  //Activating backgroud color
            handelImage.color = handelActivateColor;          //Activating handel color
        }
        else
        {
            uiHandelRectTransform.anchoredPosition = handelPosition;
            backgroundImage.color = BackgoundDefaultColor; //De-Activating backgroud color
            handelImage.color = handelDefaultColor;         //De-Activating handel color
        }        

    }
    
}
