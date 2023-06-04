using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class VibratorBT : MonoBehaviour
{
    [SerializeField] Image vibraOn;
    [SerializeField] Image vibraOff , vibraOff_Line;
    public bool vibra = false;


    void Start()
    {
       
        if (!PlayerPrefs.HasKey("vibra"))
        {
            PlayerPrefs.SetInt("vibra", 0);
            Load();
        }
        else
        {
            Load();
        }
        UpdateButtonIcon();
    }
    public void OnButtonPress()
    {
        if (vibra == false)
        {
            vibra = true;
     
        }
        else
        {
            vibra = false;
     
        }
        Save();
        UpdateButtonIcon();
    }


    private void Load()
    {
        vibra = PlayerPrefs.GetInt("vibra") == 1;
    }
    private void Save()
    {
        PlayerPrefs.SetInt("vibra", vibra ? 1 : 0);
    }

    private void UpdateButtonIcon()
    {
        if (vibra == false)
        {
            vibraOn.enabled = false;
            vibraOff.enabled = true;
            vibraOff_Line.enabled = true;
        }
        else
        {
            vibraOn.enabled = true;
            vibraOff.enabled = false;
            vibraOff_Line.enabled= false;
        }

    }

}
