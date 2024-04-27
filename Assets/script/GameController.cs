using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public class GameController : MonoBehaviour
{

    public Player player;


    public InputField textEntryField;

    public Text HistoryText;

    public Text currentText;

    public Action[] actions;

    [TextArea]
    public string introText;
    
   




    // Start is called before the first frame update
    void Start()
    {
        HistoryText.text = introText;
        DisplayLocation();
        textEntryField.ActivateInputField();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisplayLocation(bool additive = false)
    {
        string describtion = player.currentLocation.describtion + "\n";
        describtion += player.currentLocation.GetConnectionText();
        describtion += player.currentLocation.GetItemsText();
        if (additive)
            currentText.text = currentText.text + "\n" + describtion;
        else
            currentText.text = describtion;
    }


    public void textEntered()
    {
        LogCurrentText();
        ProcessInput(textEntryField.text);
        textEntryField.text = "";
        textEntryField.ActivateInputField();


    }

    private void LogCurrentText()
    {
        HistoryText.text += "\n\n";
        HistoryText.text += currentText.text;

        HistoryText.text += "\n\n";
        HistoryText.text += "<color=#aaccaaff>" + textEntryField.text+"</color>";
    }

    private void ProcessInput(string input)
    {
        input = input.ToLower();

        char[] delimeter = { ' ' };
        string[] separatedWords = input.Split(delimeter);

        foreach (Action action in actions)
        {

            if (action.keyword.ToLower() == separatedWords[0])
            {
                if (separatedWords.Length > 1)
                {
                    action.RespondToInput(this, separatedWords[1]);
                }

                else
                {
                    action.RespondToInput(this, "");
                }
                return;
            }
        }

        currentText.text = "Nothing happens! (having trouble? type Help)";
    }


   

    
}
