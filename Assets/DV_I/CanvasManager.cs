using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasManager : MonoBehaviour
{
    [SerializeField] private Simulacro.Player player;
    [SerializeField] private TMP_Text playerLifesTxt;
    [SerializeField] private TMP_Text baseLifesTxt;
    [SerializeField] private TMP_Text timerTxt;
    [SerializeField] private GameObject panel;

    private float timer = 0;

    private void Update()
    {
        timer += Time.deltaTime;
        timerTxt.SetText(timer.ToString());

        playerLifesTxt.SetText(player.Lifes.ToString());

        if(player.Lifes <= 0)
        {
            panel.SetActive(true);
        }
    }
    public void OnButtonClicked()
    {
        SceneManager.LoadScene(0);
    }
}
