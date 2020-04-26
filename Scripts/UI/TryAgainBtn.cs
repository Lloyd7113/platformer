using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class TryAgainBtn : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnPointerClick(PointerEventData eventData){
        if (eventData.button == PointerEventData.InputButton.Left){
            SceneManager.LoadScene("Level1", LoadSceneMode.Single);
        }
    }
}
