using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiController : MonoBehaviour
{
    SpavnLevel spavnLevel;
    private GameObject Player;
    [SerializeField] Text text_Count;
    private void Start()
    {
        spavnLevel = GetComponent<SpavnLevel>();
    }
    public void ResetLevel()
    {
        Destroy(FindObjectOfType<TriggersPlayer>().gameObject);
        spavnLevel.CreateGameObjectInScene();
        text_Count.text = "";
    }
}
