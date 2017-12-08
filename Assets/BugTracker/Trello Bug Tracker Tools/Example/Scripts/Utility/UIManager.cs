using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TrelloAPI;

public class UIManager : MonoBehaviour
{
    [Header("UI objects")]
    public InputField inputTitle;
    public InputField inputDescription;
    public Dropdown reportOptionsDropDown;

    void Start()
    {
        if (UsageExample.instance != null)
            reportOptionsDropDown.AddOptions(UsageExample.instance.reportType);
    }

    public void ReportIssue()
    {
        if (UsageExample.instance != null)
        {
            UsageExample.instance.SendReport(inputTitle.text, inputDescription.text, reportOptionsDropDown.captionText.text);
            
            // After reporting We clear the input fields so they are ready to be used again
            inputTitle.text = "";
            inputDescription.text = "";
        }
    }
}