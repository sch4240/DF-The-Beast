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
    //public GameObject winScreen;
    //public GameObject deskTexture;
    public GameObject mainMenu;
    public GameObject inventory;
    public GameObject profile;
    public GameObject bestiary;

    //public ElementDictionary elDic;
    //public SpellSOList spellCheckmarks;
    private bool audioOn;
    private GameObject previous;


    // Use this for initialization
    void Start ()
    {
        mainMenu.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        //Disable the FPS to enable the cursor for GUI
        GameObject.Find("FPSController").GetComponent<FirstPersonController>().enabled = false;
        hud.SetActive(false);
        //options.SetActive(false);
        caseFile.SetActive(false);
        //winScreen.SetActive(false);
        audioOn = true;
    }
    //check for keypress "c" to open and close the casefile
    public void Update()
    {
        if (Input.GetKeyDown("c"))
        {
            caseFile.SetActive(!caseFile.active);
            hud.SetActive(!caseFile.active);
            if (caseFile.active)
            {
                GameObject.Find("FPSController").GetComponent<FirstPersonController>().enabled = false;
                Cursor.lockState = CursorLockMode.None;
                //Cursor.lockState = CursorLockMode.Confined;
                Cursor.visible = true;
            }
            else
            {
                GameObject.Find("FPSController").GetComponent<FirstPersonController>().enabled = true;
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
        else
        {
            inventory.SetActive(false);
            profile.SetActive(false);
        }
    }
    //Sets the previous menu visited
    public void SetPrevious(GameObject prev)
    {
        previous = prev;
    }
    public void ToggleInstructions(GameObject instructions)
    {
        if (!instructions.active)
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
        if (!book.active)
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

    #region Main Menu
    public void StartGame()
    {
        //Toggle the HUD
        hud.SetActive(true);
        //options.SetActive(false);
        mainMenu.SetActive(false);
        //Enable the mouse to be locked
        GameObject.Find("FPSController").GetComponent<FirstPersonController>().enabled = true;
        // get reference to music manager and switch music loop

    }

    public void ToggleCredits(GameObject credits)
    {
        if (!credits.active)
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
