using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Animator animator;

    public enum MainMenuPage
    {
        TitleMenu,
        SettingsMenu,
        NewGameMenu,
        LoadGameMenu,
        ContinueGameMenu,
        MainMenuFadeOut,
    }

    private void Start()
    {
        // Initialize the menu to the TitleMenu page
        SetMainMenuPage(MainMenuPage.TitleMenu);
    }

    public void SetMainMenuPage(MainMenuPage page)
    {
        animator.SetBool("IsTitleMenu", page == MainMenuPage.TitleMenu);
        animator.SetBool("IsSettingsMenu", page == MainMenuPage.SettingsMenu);
        animator.SetBool("IsNewGameMenu", page == MainMenuPage.NewGameMenu);
        animator.SetBool("IsLoadGameMenu", page == MainMenuPage.LoadGameMenu);
        animator.SetBool("IsContinueGameMenu", page == MainMenuPage.ContinueGameMenu);
        animator.SetBool("IsMainMenuFadingOut", page == MainMenuPage.MainMenuFadeOut);
    }

    // Overloaded function to set the menu page using an integer
    public void SetMainMenuPage(int pageIndex)
    {
        if (pageIndex >= 0 && pageIndex < (int)MainMenuPage.MainMenuFadeOut)
        {
            SetMainMenuPage((MainMenuPage)pageIndex);
        }
        else
        {
            Debug.LogError("Invalid MainMenuPage index: " + pageIndex);
        }
    }
}
