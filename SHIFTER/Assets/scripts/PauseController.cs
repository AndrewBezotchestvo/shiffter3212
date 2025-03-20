using UnityEngine;

public class PauseController : MonoBehaviour
{
    [SerializeField] private GameObject _pausePanel;

    private bool _paused;
    void Start()
    {
        _paused = true;
        _pausePanel.SetActive(true);
        Time.timeScale = 0f;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            ChangePauseState();
        }
    }

    public void ChangePauseState()
    {
        _paused = !_paused;

        if (_paused)
        {
            _pausePanel.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            _pausePanel.SetActive(false);
            Time.timeScale = 1f;
        }
    }
}
