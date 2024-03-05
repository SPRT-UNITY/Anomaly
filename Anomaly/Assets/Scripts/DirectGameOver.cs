using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectGameOver : MonoBehaviour
{
    public void GameOver()
    {
        GameManager.Instance.Die();
    }
}
