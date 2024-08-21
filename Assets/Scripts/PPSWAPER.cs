using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class PPSWAPER : MonoBehaviour
{
    private void Awake()
    {
        Invoke(nameof(ppLoadNext), Random.Range(0.2f, 06f));
    }

    private void ppLoadNext() => SceneManager.LoadScene(1);
}