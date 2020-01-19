using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public static LevelController inst;

    public Player player;

    public EnemyPath path;

    [Header("Waves")]
    [SerializeField] float startGameIn = 20;
    public List<EnemyWave> waves;
    float timer;
    float restartAfter = 5f;

    public float Timer
    {
        get => timer;
        private set
        {
            timer = value;
            timerEvent.Invoke();
        }
    }

    [HideInInspector] public UnityEvent timerEvent;

    void Awake()
    {
        if (!inst)
            inst = this;

        timerEvent = new UnityEvent();

        Timer = startGameIn;
    }

    void Start()
    {
        StartCoroutine(_Timer());
    }

    public void EndGame(bool win)
    {
        if (win)
            GUIController.inst.ShowWinScreen();
        else
            GUIController.inst.ShowLoseScreen();

        StartCoroutine(_Help());

        IEnumerator _Help()
        {
            yield return new WaitForSeconds(restartAfter);
            SceneManager.LoadScene(0);
        }

    }

    IEnumerator _Timer()
    {
        GUIController.inst.ChangeWave(EnemyManager.inst.currentWaveCount, waves.Count);

        while (Timer > 0)
        {
            yield return new WaitForSeconds(1);
            Timer--;

        }

        if (EnemyManager.inst.currentWaveCount >= waves.Count)
        {
            EndGame(true);
            yield break;
        }

        EnemyManager.inst.StartWave();
        Timer = waves[EnemyManager.inst.currentWaveCount - 1].duration;
        StartCoroutine(_Timer());
    }
}
