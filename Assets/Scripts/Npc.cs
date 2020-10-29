using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Npc : MonoBehaviour
{
    [SerializeField] GameObject[] models;
    List<string> modelsNames = new List<string>();
    GameObject modelActive;
    private void Awake() {
        for(int i = 0; i < models.Length; i++) {
            modelsNames.Add(models[i].name);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SelectModel(List<string> listOfModelsAlreadyTaken) {
        int index = Random.Range(0, models.Length);
        bool findeModelActive = FindModelOnList(modelsNames[index], listOfModelsAlreadyTaken);
        while (findeModelActive) {
            index = Random.Range(0, models.Length);
            findeModelActive = FindModelOnList(modelsNames[index], listOfModelsAlreadyTaken);
        }
        models[index].SetActive(true);
        modelActive = models[index];
    }
    public string GetModelActiveName() {
        return modelActive.name;
    }
    public void DisableModel() {
        if (modelActive != null) {
            modelActive.SetActive(false);
        }
        
    }
    public bool FindModelOnList(string modelToFind,List<string> list) {
        for (int i = 0; i < list.Count; i++) {
            if (modelToFind.Equals(list[i])) {
                return true;
            }
        }
        return false;
    }
}
