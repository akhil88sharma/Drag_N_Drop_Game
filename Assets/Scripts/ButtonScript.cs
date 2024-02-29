using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    [SerializeField] private GameObject gameFinish;

    private void Awake()
    {
        gameFinish.SetActive(false);

    }
    private void Update()
    {
        //if all animals are dropped in right slots then activate the end screen
        if (ItemSlot.animalCount == 0)
        {
            gameFinish.SetActive(true);
        }
    }
    public void replayButton()
    {
        gameFinish.SetActive(false);
        SceneManager.LoadScene("SampleScene");
    }
    public void exitButton()
    {
        Application.Quit();
    }
}
