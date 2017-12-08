using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeScreenShot : MonoBehaviour {

    public string defaultPathName = "screenshot";
    public GameObject ss_feedback;
    string currentName = "";
    string previousName = "";

    void Start() {
        currentName = defaultPathName;
    }

    public void takeSS() {
        if(currentName.Equals(previousName)) {
            currentName += "1";
            Application.CaptureScreenshot(currentName + ".png");
        } else {
            Application.CaptureScreenshot(currentName + ".png");
        }
        StartCoroutine(feedbackText());
        previousName = currentName;
    }

    IEnumerator feedbackText() {
        ss_feedback.SetActive(true);
        yield return new WaitForSeconds(3.5f);
        ss_feedback.SetActive(false);
    }
}
