using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

namespace TrelloAPI
{
    public class UsageExample : MonoBehaviour
    {
        [Header("Personal Trello Information")]
        public string yourKey = "Your Key";
        public string yourToken = "Your Token";
        public string currentBoard = "Your Trello Board";

        [Space(15)]
        [Tooltip("Places new uploaded cards on top of the list")]
        public bool newCardsOnTop = true;

        [Space(15)]
        [Header("Setup report types to appear in the dropdown here")]
        public List<Dropdown.OptionData> reportType;

        [Space(15)]
        [Header("UI Objects")]
        public GameObject inProgressUI;
        public GameObject successUI;
        public GameObject fillInFormMessageUI;

        //Singleton instance
        public static UsageExample instance;

        // Trello API obj
        private Trello trello;

        void Awake()
        {
            //Check if instance already exists
            if (instance == null)

                //if not, set instance to this
                instance = this;

            //If instance already exists and it's not this:
            else if (instance != this)

                //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of this object
                Destroy(gameObject);

            //Sets this to not be destroyed when reloading scene
            DontDestroyOnLoad(gameObject);
        }

        public IEnumerator Start()
        {
            //Checks if we are already connected
            if (trello != null && trello.IsConnected())
            {
                Debug.Log("Connection with Trello server succesful");
                yield break;
            }

            // Creates our trello Obj with our key and token
            trello = new Trello(yourKey, yourToken);

            // gets the boards of the current user
            yield return trello.PopulateBoardsRoutine();
            trello.SetCurrentBoard(currentBoard);

            // gets the lists on the current board
            yield return trello.PopulateListsRoutine();

            // check if our reportType matches the lists in your trello board
            // otherwise it creates new lists and uploads them
            for (int i = 0; i < reportType.Count; i++)
            {
                if (!trello.IsListCached(reportType[i].text))
                {
                    var optionList = trello.NewList(reportType[i].text);
                    yield return trello.UploadListRoutine(optionList);
                }
            }

            // caches the new lists created (if any)
            yield return trello.PopulateListsRoutine();
        }

        public IEnumerator SendReportRoutine(TrelloCard card)
        {
            // Shows the "in progress" text
            inProgressUI.SetActive(true);

            yield return trello.UploadCardRoutine(card);

            // Wait for one extra second to let the player read that his isssue is being processed
            yield return new WaitForSeconds(1);

            // Since we are done we can deactivate the in progress canvas
            inProgressUI.SetActive(false);

            // Now we show the success text to let the user know the action has been completed
            StartCoroutine(SetActiveForSecondsRoutine(successUI, 2));
        }

        // Sets gameObject active or inactive for timeInSeconds
        public IEnumerator SetActiveForSecondsRoutine(GameObject gameObject, float timeInSeconds, bool setActive = true)
        {
            gameObject.SetActive(setActive);
            yield return new WaitForSeconds(timeInSeconds);
            gameObject.SetActive(!setActive);
        }

        public Coroutine SendReport(string title, string description, string listName)
        {
            // if both the title and description are empty show error message to avoid spam
            if (title == "" && description == "")
            {
                StartCoroutine(SetActiveForSecondsRoutine(fillInFormMessageUI, 2));
                return null;
            }

            TrelloCard card = trello.NewCard(title, description, listName);
            return StartCoroutine(SendReportRoutine(card));
        }
    }
}