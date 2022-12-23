using UnityEngine;
using UnityEngine.UI;

public class Cooldown : MonoBehaviour
{
    public GameObject[] page;
    public Image rebirth;
    public float cooldown;
    public Text yourscore;
    bool isCooldown;
    private ScoreCounter sc;

    private void Start() {
        isCooldown = true;
        sc = FindObjectOfType<ScoreCounter>();
        yourscore.text = sc.scoreText.text;
    }
    private void Update() {
        if (isCooldown)
        {
            rebirth.fillAmount -= 1/(cooldown - 0.5f) * Time.deltaTime;
            if(rebirth.fillAmount <= 0 )
            {
                rebirth.fillAmount = 1;
                isCooldown = false;
            }
        }
        if(!isCooldown)
        {
            page[0].SetActive(false);
            page[1].SetActive(true);
        }
    }


}
