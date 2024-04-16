using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ButtonScript : MonoBehaviour
{
    [SerializeField] private GameObject gameFinish;
    public TextMeshProUGUI gameScore;
    private int nextSceneIndex;

    private void Awake()
    {
        gameFinish.SetActive(false);

    }
    private void Start()
    {
        nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
    }
    private void Update()
    {
        //if all animals are dropped in right slots then activate the end screen
        if (ItemSlot.animalCount == 0)
        {
            gameFinish.SetActive(true);
            gameScore.text = "Game Finished\nIncorrect Attempts : " + ItemSlot.incorrectAttempt;
        }
    }
    public void replayButton()
    {
        gameFinish.SetActive(false);
        SceneManager.LoadScene("Level1");
    }
    public void exitButton()
    {
        Application.Quit();
    }
    public void nextButton()
    {
        gameFinish.SetActive(false);
        SceneManager.LoadScene(nextSceneIndex);
    }
}
