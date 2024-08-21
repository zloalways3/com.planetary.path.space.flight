    using TMPro;
    using UnityEngine;
    using UnityEngine.SceneManagement;
    using UnityEngine.UI;

    public class PPGameOver : MonoBehaviour
    {
        [SerializeField] private CanvasGroup ppHUD;
        [SerializeField] private CanvasGroup ppWIN;
        [SerializeField] private CanvasGroup ppLOSE;

        [SerializeField] private Button ppRestart;
        [SerializeField] private Button ppNext;
        [SerializeField] private Button[] ppBack;
        
        [SerializeField] private TMP_Text ppScore;
        
        [SerializeField] private AudioSource ppAudioSFXSource;
        [SerializeField] private AudioClip ppWin;
        [SerializeField] private AudioClip ppLose;
        
        private void Awake()
        {
            ppHUD.PPCHANGE(true);
            ppWIN.PPCHANGE(false);
            ppLOSE.PPCHANGE(false);
            
            PPSTATICHELPER.PPisGame = true;
            
            ppRestart.onClick.AddListener(()=> SceneManager.LoadScene(2));
            ppNext.onClick.AddListener(() =>
            {
                var ppLevel = PlayerPrefs.GetInt("PPLEVEL", 1);
                ppLevel++;
                PlayerPrefs.SetInt("PPLEVEL", ppLevel);
                SceneManager.LoadScene(2);
            });
            
            foreach (var ppButton in ppBack)
                ppButton.onClick.AddListener(() => SceneManager.LoadScene(1));
        }

        public void PPSHOWWIN(int ppLvl)
        {
            PPSTATICHELPER.PPisGame = false;
            
            ppAudioSFXSource.PlayOneShot(ppWin);
            
            ppScore.text = $"level {ppLvl}\nComplete";
            ppHUD.PPCHANGE(false);
            ppWIN.PPCHANGE(true);
        }
        
        public void PPSHOWLOSE()
        {
            PPSTATICHELPER.PPisGame = false;
            
            ppAudioSFXSource.PlayOneShot(ppLose);

            ppHUD.PPCHANGE(false);
            ppLOSE.PPCHANGE(true);
        }
    }
