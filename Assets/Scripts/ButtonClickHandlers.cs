using System;
using UnityEngine;

public class ButtonClickHandlers : MonoBehaviour {

    public int Button1ClickCount = 0;
    public int Button2ClickCount = 0;
    public int Button3ClickCount = 0;

    [Serializable]
    public class ButtonClicked : EventLogger.LogEvent
    {
        public string ButtonName;
        public int ButtonClickCount;

        public ButtonClicked(string buttonName, int buttonClickCount)
        {
            ButtonName = buttonName;
            ButtonClickCount = buttonClickCount;
        }
    }

    public void OnButton1Clicked()
    {
        Button1ClickCount++;
        
        // Log event by name, without data
        LogSession.Log("Button1Clicked");
    }

    public void OnButton2Clicked()
    {
        Button2ClickCount++;

        // Log event by name, with JSON data
        ButtonClicked data = new ButtonClicked("Button 2", Button2ClickCount);
        string jsonData = JsonUtility.ToJson(data);
        LogSession.Log("ButtonClicked", jsonData);
    }

    public void OnButton3Clicked()
    {
        Button3ClickCount++;

        // Log event by type; name will be derived from class name, and object contents will be serialized into JSON data
        ButtonClicked data = new ButtonClicked("Button 3", Button2ClickCount);
        LogSession.Log(data);
    }
}
