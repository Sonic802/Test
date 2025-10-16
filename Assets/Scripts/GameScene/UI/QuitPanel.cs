using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitPanel : BasePanel<QuitPanel>
{
    public CustomGUIButton quitButton;
    public CustomGUIButton cancelButton;

    // Start is called before the first frame update
    void Start()
    {
        quitButton.clickEvent += () =>
        {
            HideMe();
            SceneManager.LoadScene("BeginScene");
        };

        cancelButton.clickEvent += () =>
        {
            HideMe();
            Time.timeScale = 1.0f;
        };

        HideMe();
    }

   
}
