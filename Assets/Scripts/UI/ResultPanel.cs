using UnityEngine;
using TMPro;
using DG.Tweening;
using UnityEngine.SceneManagement;
using UnityEditor.VersionControl;

public class ResultPanel : MonoBehaviour
{
   [SerializeField] TMP_Text resultTMP;
   

   public void Show(string mesage)
   {
        resultTMP.text = mesage;
        transform.DOScale(Vector3.one, 0.5f).SetEase(Ease.InOutQuad);
   }

   public void Restart()
   {
    SceneManager.LoadScene(0);
   }

   void Start() => ScaleZero();

   [ContextMenu("ScaleOne")]
   void ScaleOne() => transform.localScale = Vector3.one;

   [ContextMenu("ScaleZero")]
   public void ScaleZero() => transform.localScale = Vector3.zero;
}
