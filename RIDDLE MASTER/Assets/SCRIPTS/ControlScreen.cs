using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class ControlScreen : MonoBehaviour
{
    public Toggle toggle;
    public TMP_Dropdown dropdownList;
    Resolution[] resolutionAvaliable;

    void Start()
    {
        if (Screen.fullScreen)
        {
            toggle.isOn = true;
        }
        else
        {
            toggle.isOn = false;
        }
        controlResolution();
    }

    public void fullScreenActive(bool toggleIsOn)
    {
        Screen.fullScreen = toggleIsOn;
    }

    public void controlResolution()
    {
        resolutionAvaliable = Screen.resolutions;
        dropdownList.ClearOptions();
        List<string> options = new List<string>();
        int resolutionActual = 0;

        for (int i = 0; i < resolutionAvaliable.Length; i++)
        {
            string option = resolutionAvaliable[i].width + " x " + resolutionAvaliable[i].height+" "+resolutionAvaliable[i].refreshRate+" Hz";
            options.Add(option);

            if(Screen.fullScreen && resolutionAvaliable[i].width == Screen.currentResolution.width && resolutionAvaliable[i].height == Screen.currentResolution.height){
               resolutionActual=i;     
            }
        }

        dropdownList.AddOptions(options);
        dropdownList.value= resolutionActual;
        dropdownList.RefreshShownValue();

        dropdownList.value= PlayerPrefs.GetInt("numberResolution",0);
    }

    public void changeResolution(int indexdOptionDropDown){
        PlayerPrefs.SetInt("numberResolution",dropdownList.value);
        Resolution resolution= resolutionAvaliable[indexdOptionDropDown];
        Screen.SetResolution(resolution.width,resolution.height,Screen.fullScreen);
    }
}
