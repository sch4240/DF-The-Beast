using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;
///<summary> Handles all the toggling of menus </summary>
public class UIMngr : MonoBehaviour
{

    #region Singleton Instance Checks
    //Ensure there is only one instance of the UI manager
    private static UIMngr instance = null;
    public static UIMngr Instance
    {
        get
        {
            //Find the UI manager if it exists
            if(instance == null)
            {
                instance = FindObjectOfType<UIMngr>();
            }
            //Create a new one if it doesn't
            if(instance == null)
            {
                GameObject obj = new GameObject("UIMngr");
                instance = obj.AddComponent<UIMngr>();
            }

            return instance;
        }
    }

    //Ensure the instance is removed when the game is closed
    void OnApplicationQuit()
    {
        instance = null;
    }
    #endregion

    public GameObject hud;
    //public GameObject options;
    //public GameObject overlay;   
    public GameObject caseFile;
    public GameObject winScreen;
    public GameObject decisionScreen;
    public GameObject leavePanel;
    //public GameObject deskTexture;
    public GameObject mainMenu;
    public GameObject inventory;
    public GameObject profile;
    public GameObject bestiary;
    public GameObject decisionChoice;
    public GameObject decisionInventory;
    public GameObject decisionBestiary;
    public GameObject itemDescriptionScreen;
    public GameObject buttons;
    [Header("CrossHair")]
    public GameObject crossHair;
    public Dictionary<int, string> beastDictionary;
    public bool[] beasts;
    public int pickedBeast;
    //public ElementDictionary elDic;
    //public SpellSOList spellCheckmarks;
    private bool audioOn;
    private GameObject previous;
    public GameObject monster;
    private GameObject fpsController;

    // on boarding instructions
    bool caseFileInstruct;
    public GameObject caseFileText;

    // Use this for initialization
    void Start ()
    {
        mainMenu.SetActive(true);
        crossHair.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        //Disable the FPS to enable the cursor for GUI
        GameObject.FindWithTag("FPSController").GetComponent<FirstPersonController>().enabled = false;
        hud.SetActive(false);
        //options.SetActive(false);
        caseFile.SetActive(false);
        winScreen.SetActive(false);
        decisionScreen.SetActive(false);
        itemDescriptionScreen.SetActive(false);
        audioOn = true;
        beasts = new bool[7];
        setDictionary();

        caseFileInstruct = true;
    }
    //check for keypress "c" to open and close the casefile
    public void Update()
    {
        if (Input.GetKeyDown("c"))
        {
            // disable text on first time pressing 'C'
            if (caseFileInstruct)
            {
                caseFileText.GetComponent<Text>().enabled = false;
                caseFileInstruct = false;
            }

            caseFile.SetActive(!caseFile.activeSelf);
            hud.SetActive(!caseFile.activeSelf);
            crossHair.SetActive(!crossHair.activeSelf);
            if (caseFile.activeSelf)
            {
                GameObject.FindWithTag("FPSController").GetComponent<FirstPersonController>().enabled = false;
                Cursor.lockState = CursorLockMode.None;
                //Cursor.lockState = CursorLockMode.Confined;
                Cursor.visible = true;
            }
            else
            {
                GameObject.FindWithTag("FPSController").GetComponent<FirstPersonController>().enabled = true;
            }

        }
    }
    //go between profile, inventory and bestiary
    public void ToggleFile(GameObject file)
    {
        file.SetActive(true);
        if (file.name == "ProfilePanel")
        {
            inventory.SetActive(false);
            bestiary.SetActive(false);
        }
        else if(file.name == "InventoryPanel")
        {
            profile.SetActive(false);
            bestiary.SetActive(false);
        }
        else if(file.name == "BestiaryPanel")
        {
            inventory.SetActive(false);
            profile.SetActive(false);
        }
        else if (file.name == "DecisionChoice")
        {
            decisionInventory.SetActive(false);
            decisionBestiary.SetActive(false);
        }
        else if (file.name == "DecisionInventory")
        {
            decisionChoice.SetActive(false);
            decisionBestiary.SetActive(false);
        }
        else if (file.name == "DecisionBestiary")
        {
            decisionInventory.SetActive(false);
            decisionChoice.SetActive(false);
        }
    }
    public void OpenItemDescription(InventorySlot item)
    {
        if(item.IsEmpty())
            return;

        ItemBase newItem = item.GetItem;
        itemDescriptionScreen.SetActive(true);
        itemDescriptionScreen.GetComponent<ItemPanelScript>().ChangePanelContent(newItem.icon,newItem.name,newItem.description);
       // Debug.Log("LOLLL"+item.GetItem.name);
    }

    public void CloseItemDescription()
    {
        itemDescriptionScreen.SetActive(false);
    }

    //Sets the previous menu visited
    public void SetPrevious(GameObject prev)
    {
        previous = prev;
    }
    public void ToggleInstructions(GameObject instructions)
    {
        if (!instructions.activeSelf)
        {
            instructions.SetActive(true);

            if (previous != null)
                previous.SetActive(false);
        }
        else
        {
            instructions.SetActive(false);
            if (previous != null)
                previous.SetActive(true);
        }
    }

    public void TogglecaseFile(GameObject book)
    {
        if (!book.activeSelf)
        {
            book.SetActive(true);
            hud.SetActive(false);
        }
        else
        {
            book.SetActive(false);
            hud.SetActive(true);
        }
    }

    //this method enables the case panel,
    public void ToggleinventoryDecision(GameObject inventoryDecision)
    {
        caseFile.SetActive(true);
        buttons.SetActive(false);
        inventoryDecision.SetActive(true);
        decisionChoice.SetActive(false);
        profile.SetActive(false);
        decisionBestiary.SetActive(false);
    }
    #region Main Menu
    public void StartGame()
    {
        //Toggle the HUD
        hud.SetActive(true);
        //options.SetActive(false);
        mainMenu.SetActive(false);
        // enable the crosshair
        crossHair.SetActive(true);
        //Enable the mouse to be locked
        GameObject.FindWithTag("FPSController").GetComponent<FirstPersonController>().enabled = true;
        // get reference to music manager and switch music loop

    }

    public void ToggleCredits(GameObject credits)
    {
        if (!credits.activeSelf)
        {
            credits.SetActive(true);
            mainMenu.SetActive(false);
        }
        else
        {
            credits.SetActive(false);
            mainMenu.SetActive(true);
        }
    }
    #endregion
    //Based if the user clicks the yes or no button to leave
    //if yes, enable decisionPanel
    public void LeaveDecision(string decision)
    {
        leavePanel.SetActive(false);
        //when the door is interactive remove this line of code
        GameObject.FindWithTag("FPSController").GetComponent<FirstPersonController>().enabled = false;
        if (decision == "Yes")
        {
            decisionScreen.SetActive(true);
            hud.SetActive(false);
        }
        else
        {
            GameObject.FindWithTag("FPSController").GetComponent<FirstPersonController>().enabled = true;
        }
    }
    //If the user clicks on the door to leave, pull up the leaving panel
    public void ToggleLeaving()
    {
        leavePanel.SetActive(true);
        GameObject.FindWithTag("FPSController").GetComponent<FirstPersonController>().enabled = false;
    }
    //which beast did the user pick? Modify the bool array based on button press
    public void setBeast(int num)
    {
        //set the rest to be false
        for (int i = 0; i < 7; i++)
        {
            beasts[i] = false;
        }
        beasts[num] = true;
    }
    //makes the player have to pick a monster before the win panel
    public void enableConfirm()
    {
        GameObject.Find("ConfirmationButton").GetComponent<Button>().interactable = true;
    }
    //based on the beasts bool array if true, return the string of the monster
    public string getBeast()
    {
        for (int j = 0; j < 7; j++)
        {
            if (beasts[j] == true)
            {
                pickedBeast = j;
                return beastDictionary[j];

            }
        }
        return null;
    }
    //set up a dictionary of all the possible beasts, to get the image for win panel
    public void setDictionary()
    {
        beastDictionary = new Dictionary<int, string>();
        beastDictionary.Add(0, "whiteVampireColor");
        beastDictionary.Add(1, "redVampireColor");
        beastDictionary.Add(2, "fetchColor");
        beastDictionary.Add(3, "grendelkinColor");
        beastDictionary.Add(4, "rawheadColor");
        beastDictionary.Add(5, "skinwalkerColor");
        beastDictionary.Add(6, "oldOneColor");
    }
    //once the player makes the final decision turn on the win panel
    public void toggleDecisionPanel()
    {
        changeImage();
        decisionScreen.SetActive(false);
        winScreen.SetActive(true);
    }
    //modify the texture to the chosen monster's image
    public void changeImage()
    {
        string name = getBeast();
        if (name != null)
        {
            Texture changedTexture = (Texture)Resources.Load(name, typeof(Texture));
            if (changedTexture != null)
            {
                monster.GetComponent<RawImage>().texture = changedTexture;
            }

        }

    }
    //when the player hits the 'X' button on a journal
    public void toggleJournal(GameObject journalEntry)
    {
        journalEntry.SetActive(false);
    }
    #region Options Menu
    //Toggles the options menu
    public void ToggleOptions()
    {
        //if (hud.active)
        //{
        //    hud.SetActive(false);
        //    options.SetActive(true);
        //    overlay.SetActive(true);
        //}
        //else
        //{
        //    hud.SetActive(true);
        //    options.SetActive(false);
        //    overlay.SetActive(false);
        //}
    }

    public void ToggleWinScreen()
    {
        //if(hud.activeSelf)
        //{
        //    hud.SetActive(false);
        //    deskTexture.SetActive(false);
        //    winScreen.SetActive(true);
        //}
    }

    public void ClearBoard()
    {
        GameObject[] allObjects = GameObject.FindGameObjectsWithTag("DraggableElement");
        for(int i=0;i<allObjects.Length;i++)
        {
            Destroy(allObjects[i]);
        }
    }

    
    #endregion

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
