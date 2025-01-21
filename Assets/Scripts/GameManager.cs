using System.Collections;
using UnityEngine;


// For UI, Ranking, Gameover
public class GameManager : MonoBehaviour
{
    public static GameManager Inst{get;private set;}
    void Awake() => Inst = this;

    [Multiline(10)]
    [SerializeField] string cheatInfo;
    [SerializeField] NotificationPanel notificaionPanel;
    [SerializeField] ResultPanel resultPanel;
    [SerializeField] TitlePanel titlePanel;
    [SerializeField] CameraEffect cameraEffect;
    [SerializeField] GameObject endTurnBtn;
    WaitForSeconds delay2 = new WaitForSeconds(2);

    void Start()
    {
        UISetup();
    }

    void UISetup()
    {
        notificaionPanel.ScaleZero();
        resultPanel.ScaleZero();
        titlePanel.Active(true);
        cameraEffect.SetGrayScale(false);
    }

    // Update is called once per frame
    void Update()
    {
        #if UNITY_EDITOR
        InputCheatKey();
        #endif
    }

    void InputCheatKey()
    {
        if(Input.GetKeyDown(KeyCode.F1))
            TurnManager.OnAddCard?.Invoke(true);

        if(Input.GetKeyDown(KeyCode.F2))
            TurnManager.OnAddCard?.Invoke(false);

        if(Input.GetKeyDown(KeyCode.F3))
            TurnManager.Inst.EndTurn();
        
        if(Input.GetKeyDown(KeyCode.F4))
            CardManager.Inst.TryPutCard(false);

        if(Input.GetKeyDown(KeyCode.F5))
            EntityManager.Inst.DammageBoss(true,19);

        if(Input.GetKeyDown(KeyCode.F6))
            EntityManager.Inst.DammageBoss(false,19);            
    }

    public void StartGame()
    {
        StartCoroutine(TurnManager.Inst.StartGameCo());
    }

    public void Notification(string message)
    {
        notificaionPanel.Show(message);
    }


    public IEnumerator GameOver(bool isMyWin)
    {
        TurnManager.Inst.isLoading = true;
        endTurnBtn.SetActive(false);
        yield return delay2;

        TurnManager.Inst.isLoading=true;
        resultPanel.Show(isMyWin ? "Victory" : "Defeat");
        cameraEffect.SetGrayScale(true);
    }
}
