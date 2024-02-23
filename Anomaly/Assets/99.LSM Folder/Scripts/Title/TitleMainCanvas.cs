using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleMainCanvas : MonoBehaviour
{
    [field: Header("Buttons")]
    [SerializeField] private Button GameStartButton;
    [SerializeField] private Button GameOptionButton;
    [SerializeField] private Button GameEndButton;

    private void Awake()
    {
        GameEndButton.onClick.AddListener(() => TitleSceneManager.Instance.EndGame());
    }
}
