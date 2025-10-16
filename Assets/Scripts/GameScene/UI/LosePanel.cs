using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LosePanel : BasePanel<LosePanel>
{
    public CustomGUIButton restartButton;
    public CustomGUIButton quitButton;

    // Start is called before the first frame update
    void Start()
    {
        restartButton.clickEvent += () =>
        {
            Time.timeScale = 1;
            SceneManager.LoadScene("GameScene");
        };

        quitButton.clickEvent += () =>
        {
            Time.timeScale = 1;
            SceneManager.LoadScene("BeginScene");
        };

        HideMe();
    }

    
}
