using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinPanel : BasePanel<WinPanel>
{
    public CustomGUIButton backButton;
    public CustomGUIButton restartButton;
    public CustomGUIInput  inputName;

    // Start is called before the first frame update
    void Start()
    {
        backButton.clickEvent += () =>
        {
            Time.timeScale = 1.0f;
            //¼ÇÂ¼³É¼¨
            GameDataMgr.Instance.AddRankInfo(inputName.content.text,
                GamePanel.Instance.nowTime, GamePanel.Instance.score);
            SceneManager.LoadScene("BeginScene");
        };
        restartButton.clickEvent += () =>
        {
            Time.timeScale = 1.0f;
            GameDataMgr.Instance.AddRankInfo(inputName.content.text,
                GamePanel.Instance.nowTime, GamePanel.Instance.score);
            SceneManager.LoadScene("GameScene");
        };

        HideMe();
    }

    
}
