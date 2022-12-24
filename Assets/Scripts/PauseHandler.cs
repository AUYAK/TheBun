using UnityEngine;
using UnityEngine.EventSystems;

public class PauseHandler : MonoBehaviour,IPointerDownHandler
{
    public static bool isPause;
    public GameObject pausePanel;
    public void OnPointerDown(PointerEventData eventData)
    {
        if (this.gameObject.name == "Pause")
        {
            isPause = true;
            Time.timeScale = 0f;
            pausePanel.SetActive(true);
        }
        if (this.gameObject.name == "Resume")
        {
            isPause = false;
            Time.timeScale = 1f;
            pausePanel.SetActive(false);
        }

    }
    
}
