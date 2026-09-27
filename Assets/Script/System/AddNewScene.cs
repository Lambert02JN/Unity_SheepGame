using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AddNewScene : MonoBehaviour
{
    [SerializeField]private List<string> sceneList;
    // Start is called before the first frame update
    void Start()
    {
        foreach(string scene in sceneList){
            SceneManager.LoadScene(scene,LoadSceneMode.Additive);
        }
    }

}
