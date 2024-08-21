using UnityEngine;
using UnityEngine.UI;

public class PPSettings : MonoBehaviour
{
    [SerializeField] private CanvasGroup ppCg;
    [SerializeField] private Button ppOpen;
    [SerializeField] private Button ppClose;

    [SerializeField] private Button ppSound;
    [SerializeField] private Button ppMusic;

    [SerializeField] private Sprite ppOn;
    [SerializeField] private Sprite ppOff;
    
    [SerializeField] private AudioSource ppSoundSource;
    [SerializeField] private AudioSource ppMusicSource;

    [SerializeField] private AudioClip ppClickPew;
    
    private void Start()
    {
        ppCg.PPCHANGE(false);
        Application.targetFrameRate = 120;
        
        ppOpen.onClick.AddListener(() =>
        {
            PPSTATICHELPER.PPisGame = false;
            ppCg.PPCHANGE(true);
        });
        ppClose.onClick.AddListener(() =>
        {
            PPSTATICHELPER.PPisGame = true;
            ppCg.PPCHANGE(false);
        });
        
        ppSound.onClick.AddListener(ppSoundCheck);
        ppMusic.onClick.AddListener(ppMusicCheck);
        
        var ppCur = PlayerPrefs.GetInt("ppSound", 1);
        ppSoundSource.mute = ppCur <= 0;
        ppSound.image.sprite = ppSoundSource.mute ? ppOff : ppOn;
        
        var ppCurMsc = PlayerPrefs.GetInt("ppMusic", 1);
        ppMusicSource.mute = ppCurMsc <= 0;
        ppMusic.image.sprite = ppMusicSource.mute ? ppOff : ppOn;
        
        return;

        void ppSoundCheck()
        {
            var ppCur = PlayerPrefs.GetInt("ppSound", 1);
            ppCur *= -1;
            PlayerPrefs.SetInt("ppSound", ppCur);
            
            ppSoundSource.mute = ppCur <= 0;
            ppSound.image.sprite = ppSoundSource.mute ? ppOff : ppOn;
        }
        
        void ppMusicCheck()
        {
            var ppCur = PlayerPrefs.GetInt("ppMusic", 1);
            ppCur *= -1;
            PlayerPrefs.SetInt("ppMusic", ppCur);
            
            ppMusicSource.mute = ppCur <= 0;
            ppMusic.image.sprite = ppMusicSource.mute ? ppOff : ppOn;
        }
    }

    public void ppClick()
    {
        ppSoundSource.PlayOneShot(ppClickPew);
    }
}