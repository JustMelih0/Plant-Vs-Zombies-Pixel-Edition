
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    [SerializeField]private GameObject cameraObject;
    [SerializeField]private float camSpeed;
    [SerializeField]private Transform startPoint;
    [SerializeField]private GameObject levelLoseScreen;
    [SerializeField]private GameObject GameEndScreen;

    public void ChangeScene(string sceneName)
    {
        AudioManager.Instance.PlaySFX("Click_SFX");
        SceneManager.LoadScene(sceneName);
    }
    private void OnEnable() {
        ZombieBase.zombieWin += DefeatedGame;
        SpawnManager.winGame += WinGame;
    }
    private void OnDisable() {
        ZombieBase.zombieWin -= DefeatedGame;
        SpawnManager.winGame -= WinGame;
    }
    public void ResumeGame()
    {
        AudioManager.Instance.PlaySFX("Click_SFX");
        GameManager.Instance.ChangeState(GameManager.GameState.GameState);
    }
    public void PauseGame()
    {
        AudioManager.Instance.PlaySFX("Click_SFX");
        GameManager.Instance.ChangeState(GameManager.GameState.PauseState);
    }
    public void WinGame()
    {
        AudioManager.Instance.PlaySFX("Level_Completed_SFX");
        GameEndScreen.SetActive(true);
    }
    public void NextLevel()
    {
        int levelIndex  = PlayerPrefs.GetInt("levelIndex");
        PlayerPrefs.SetInt("levelIndex", levelIndex + 1);
        SceneManager.LoadScene("Chapter1Scene");

    }
    public void DefeatedGame()
    {
        AudioManager.Instance.PlaySFX("Defeated_SFX");
        GameManager.Instance.ChangeState(GameManager.GameState.EndState);
        StartCoroutine(MoveTarget());
    }
    IEnumerator MoveTarget()
    {
        Time.timeScale = 0f;
        Vector3 moveTarget = startPoint.position;
        moveTarget.z = -10f;
        moveTarget.y = cameraObject.transform.position.y;
        while (Mathf.Abs(cameraObject.transform.position.x - moveTarget.x) >= 0.1f)
        {
            cameraObject.transform.position = Vector3.MoveTowards(cameraObject.transform.position, moveTarget, camSpeed * Time.unscaledDeltaTime);
            yield return null;
        }

        yield return new WaitForSecondsRealtime(5f);
        levelLoseScreen.SetActive(true);

    }
    
}
