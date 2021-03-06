﻿using System.Collections;
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
    public GameObject decisionButtons;

    [Header("Lockbox Panel")]
    public int[] comboNums;
    public GameObject lockPanel;

    public GameObject firstNum;
    public GameObject secondNum;
    public GameObject thirdNum;
    public GameObject fourthNum;
    public bool unlockedBox;
    public GameObject incorrect;
    public GameObject correct;
    public GameObject incorrectTexture;
    public GameObject correctTexture;
    public GameObject blackTexture;
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

    private Inventory inventoryInstance;


    private bool instructOn;
    private bool creditsOn;

    // on boarding instructions
    bool caseFileInstruct;
    public GameObject caseFileText;

    // bool to start countdown timer for when the player gets the right combo for the lockbox

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
        unlockedBox = false;
        beasts = new bool[7];
        setDictionary();
        //HR: modify for inventory
        decisionButtons.SetActive(false);
        caseFileInstruct = true;
        inventoryInstance = Inventory.instance;

        //set size of combo array
    }
    //check for keypress "c" to open and close the casefile
    public void Update()
    {
        if (Input.GetKeyDown("c") && mainMenu.activeSelf == false 
            && instructOn == false && creditsOn == false)
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
            decisionScreen.SetActive(true);
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
            decisionScreen.SetActive(true);
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
            instructOn = true;

            if (previous != null)
                previous.SetActive(false);
        }
        else
        {
            instructions.SetActive(false);
            instructOn = false;
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

    //this method enables the inventory panel in the decision panel
    public void ToggleinventoryDecision(GameObject inventoryDecision)
    {
        caseFile.SetActive(true);
        buttons.SetActive(false);
        inventoryDecision.SetActive(true);
        decisionChoice.SetActive(false);
        profile.SetActive(false);
        bestiary.SetActive(false);
        //disable the panel above the inventory
        decisionBestiary.SetActive(false);
        decisionScreen.SetActive(false);
        decisionButtons.SetActive(true);
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
            creditsOn = true;
            mainMenu.SetActive(false);
        }
        else
        {
            credits.SetActive(false);
            creditsOn = false;
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
            decisionButtons.SetActive(true);
            //hud.SetActive(false);
        }
        else
        {
            crossHair.SetActive(true);
            GameObject.FindWithTag("FPSController").GetComponent<RaycastController>().pressF.enabled = true;
            GameObject.FindWithTag("FPSController").GetComponent<FirstPersonController>().enabled = true;
        }
    }
    //If the user clicks on the door to leave, pull up the leaving panel
    public void ToggleLeaving()
    {
        leavePanel.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        crossHair.SetActive(false);
        GameObject.FindWithTag("FPSController").GetComponent<RaycastController>().pressF.enabled = false;
        GameObject.FindWithTag("FPSController").GetComponent<FirstPersonController>().enabled = false;
    }

    //if the user clicks on the locked box, pull up the locked panel
    public void LockedPanel()
    {
        lockPanel.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        crossHair.SetActive(false);
        GameObject.FindWithTag("FPSController").GetComponent<RaycastController>().pressF.enabled = false;
        GameObject.FindWithTag("FPSController").GetComponent<FirstPersonController>().enabled = false;
    }

    //Displays all the correct evidence at the end of the game
    public void DisplayCorrectEvidence(Text textArea)
    {
        textArea.text = "Evidence leading to the Phobophage:\n";
        List<ItemBase> items = inventoryInstance.items;
        Dictionary<string, string> reference = inventoryInstance.correctClueReference;
        for (int i = 0; i < items.Count; i++)
        {
            string name = items[i].name.ToLower();
            if (reference.ContainsKey(name))
            {
                textArea.text += items[i].name + " - " + reference[name] + "\n";
            }
        }
    }

    //Displays all the misleading evidence at the end of the game
    public void DisplayFalseEvidence(Text textArea)
    {
        textArea.text = "Misleading evidence found:\n";
        List<ItemBase> items = inventoryInstance.items;
        Dictionary<string, string> reference = inventoryInstance.misleadClueReference;

        for (int i = 0; i < items.Count; i++)
        {
            string name = items[i].name.ToLower();
            if (reference.ContainsKey(name))
            {
                textArea.text += items[i].name + " - " + reference[name] + "\n";
            }
        }
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
        decisionButtons.SetActive(false);
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

    #region LockBox Panel
    //lock num increases
    public void IncreaseNum(GameObject text)
    {
        int lockText = int.Parse(text.GetComponent<Text>().text);

        if (lockText >= 0 && lockText != 9)
        {
            lockText++;
        }
        else
        {
            lockText = 0;
        }

        text.GetComponent<Text>().text = lockText.ToString();
    }
    //lock num decreases
    public void DecreaseNum(GameObject text)
    {
        int lockText = int.Parse(text.GetComponent<Text>().text);

        if (lockText <= 9 && lockText != 0)
        {
            lockText--;
        }
        else
        {
            lockText = 9;
        }

        text.GetComponent<Text>().text = lockText.ToString();
    }
    //checks if the numbers are correct to unlock the lock box
    public void checkLock()
    {
        int firstNumCheck = int.Parse(firstNum.GetComponent<Text>().text);
        int secondNumCheck = int.Parse(secondNum.GetComponent<Text>().text);
        int thirdNumCheck = int.Parse(thirdNum.GetComponent<Text>().text);
        int fourthNumCheck = int.Parse(fourthNum.GetComponent<Text>().text);
        //bool is changed when correct and modify texture
        if(firstNumCheck == comboNums[0] && secondNumCheck == comboNums[1] && thirdNumCheck == comboNums[2] && fourthNumCheck == comboNums[3])
        {
            incorrect.GetComponent<RawImage>().texture = blackTexture.GetComponent<RawImage>().texture;
            unlockedBox = true;
            correct.GetComponent<RawImage>().texture = correctTexture.GetComponent<RawImage>().texture;
        }
        else
        {
            incorrect.GetComponent<RawImage>().texture = incorrectTexture.GetComponent<RawImage>().texture;
        }
    }
    public void turnOffIncorrectCircle()
    {
        incorrect.GetComponent<RawImage>().texture = blackTexture.GetComponent<RawImage>().texture;

    }
    public void ToggleLockedBoxOff(GameObject lockedBox)
    {
        lockedBox.SetActive(false);
        crossHair.SetActive(true);
        GameObject.FindWithTag("FPSController").GetComponent<RaycastController>().pressF.enabled = true;
        GameObject.FindWithTag("FPSController").GetComponent<FirstPersonController>().enabled = true;
    }
    public void ToggleLockBoxOn()
    {
        lockPanel.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        crossHair.SetActive(false);
        GameObject.FindWithTag("FPSController").GetComponent<RaycastController>().pressF.enabled = false;
        GameObject.FindWithTag("FPSController").GetComponent<FirstPersonController>().enabled = false;
    }
    // will wait a few seconds before getting rid of the combonation panel
    // t = time in 
    #endregion

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
