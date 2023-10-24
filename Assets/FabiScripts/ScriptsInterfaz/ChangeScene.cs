using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeScene : MonoBehaviour
{
    // Start is called before the first frame update

    public Button button;
    public string SceneName;

    void Awake()
    {
       button=GetComponent<Button>();
        button.onClick.AddListener(CambiarPantalla);
    }
    void CambiarPantalla()
    {
        SceneManager.LoadScene(SceneName);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
