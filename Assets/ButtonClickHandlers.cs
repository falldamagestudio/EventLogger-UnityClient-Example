using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClickHandlers : MonoBehaviour {

    public int Button1ClickCount = 0;
    public int Button2ClickCount = 0;
    public int Button3ClickCount = 0;

    [Serializable]
    public class ButtonEventData
    {
        public string ButtonName;
        public int ButtonClickCount;

        public ButtonEventData(string buttonName, int buttonClickCount)
        {
            ButtonName = buttonName;
            ButtonClickCount = buttonClickCount;
        }
    }

    public void OnButton1Clicked()
    {
        Button1ClickCount++;
        LogSession.Log("Button1Clicked");
    }

    public void OnButton2Clicked()
    {
        Button2ClickCount++;
        ButtonEventData data = new ButtonEventData("Button 2", Button2ClickCount);
        string jsonData = JsonUtility.ToJson(data);
        LogSession.LogJsonData("ButtonClicked", jsonData);
    }

    public void OnButton3Clicked()
    {
        Button3ClickCount++;
        ButtonEventData data = new ButtonEventData("Button 3", Button2ClickCount);
        LogSession.LogSerializableObject("ButtonClicked", data);
    }
}
