using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject shopMenu;
    
    public void GoToMenu()
    {
        print("Go to menu");
        shopMenu.SetActive(false);
        pauseMenu.SetActive(true);    
    }
}
