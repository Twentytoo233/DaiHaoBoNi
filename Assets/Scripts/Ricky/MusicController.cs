using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    private Dictionary<string, string> sceneMusicPaths;

    // Start is called before the first frame update
    void Start()
    {
        // 初始化字典，添加场景和音乐路径的对应关系
        sceneMusicPaths = new Dictionary<string, string>
        {
            {"SceneL0", "Assets/Resources/Musics/Chapter0/BearyUnder_mus_Scene0_before.wav"},
            {"SceneL1", "Assets/Resources/Musics/Chapter0/BearyUnder_mus_Scene2.wav"},
            {"SceneL0_02", "Assets/Resources/Musics/Chapter0/BearyUnder_mus_Scene1.wav"},
            {"DiErGuan", "Assets/Resources/Musics/Chapter0/BearyUnder_mus_Scene3.wav"}
           
        };

        string currentScene = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
        if (sceneMusicPaths.ContainsKey(currentScene))
        {
            MusicMgr.Instance.PlayerBKMusic(sceneMusicPaths[currentScene]);
            MusicMgr.Instance.ChangeBKMusicValue(0.5f);
            MusicMgr.Instance.SetBKMusicLoop(true);
        }
    }

    public void ChangeBKMusicLoop(bool isLoop)
    {
        MusicMgr.Instance.SetBKMusicLoop(isLoop);
    }
}
