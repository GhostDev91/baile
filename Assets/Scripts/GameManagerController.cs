using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerController : MonoBehaviour
{
    [SerializeField] AnimationClip[] animations;
    [SerializeField] GameObject dancer;
    [SerializeField] Animator anim;
    [SerializeField] GameObject[] characters;
    [SerializeField] GameObject particlesHappy;
    [SerializeField] GameObject particlesSad;
    string animationOfLeadDancer;
    List<string> animationsOfOtherDancers = new List<string>();
    // Start is called before the first frame update
    void Start()
    {
        anim = dancer.GetComponent<Animator>();
        SelectRandomDance();
        InitializeDancers();
        SetearDancers();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    [ContextMenu("change dance")]
    public void SelectRandomDance() {
        string danceToPlay="Base";
        int danceIndex = Random.Range(0, animations.Length);
        danceToPlay = animations[danceIndex].name;
        Debug.Log("lead dancer:"+danceToPlay);
        animationOfLeadDancer = danceToPlay;
        anim.Play(danceToPlay);
    }
    public void InitializeDancers() {
        List<string> modelsNamesTaken = new List<string>();
        for (int i = 0; i < characters.Length; i++) {
            characters[i].GetComponent<Npc>().DisableModel();
        }
        for(int i = 0; i < characters.Length; i++) {
            characters[i].GetComponent<Npc>().SelectModel(modelsNamesTaken);
            modelsNamesTaken.Add(characters[i].GetComponent<Npc>().GetModelActiveName());
        }
    }
    [ContextMenu("setDancers")]
    public void SetearDancers() {
        
        animationsOfOtherDancers = new List<string>();
        for (int i = 0; i < characters.Length; i++) {
            if (i > 0) {

                string animationToCharacter = "";
                int danceIndexForCharacter = Random.Range(0, animations.Length);
                bool findAnimation = FindDanceOnList(animations[danceIndexForCharacter].name);

                while (animations[danceIndexForCharacter].name.Equals(animationOfLeadDancer) || findAnimation) {
                    danceIndexForCharacter = Random.Range(0, animations.Length);
                    findAnimation = FindDanceOnList(animations[danceIndexForCharacter].name);
                }
                animationToCharacter = animations[danceIndexForCharacter].name;
                animationsOfOtherDancers.Add(animationToCharacter);
            } else {
                string animationToCharacter = "";
                int danceIndexForCharacter = Random.Range(0, animations.Length);
                while (animations[danceIndexForCharacter].name.Equals(animationOfLeadDancer)) {
                    danceIndexForCharacter = Random.Range(0, animations.Length);
                }
                animationToCharacter = animations[danceIndexForCharacter].name;
                animationsOfOtherDancers.Add(animationToCharacter);
            }

            
            
        }
        
        int index = Random.Range(0, characters.Length);
        characters[index].GetComponent<Animator>().Play(animationOfLeadDancer);
        animationsOfOtherDancers[index] = animationOfLeadDancer;
        for(int i = 0; i < animationsOfOtherDancers.Count; i++) {
            Debug.Log(animationsOfOtherDancers[i]);
        }
        DanceEverybody();
    }
    [ContextMenu("dance")]
    public void DanceEverybody() {
        for(int i = 0; i < characters.Length; i++) {
            characters[i].GetComponent<Animator>().Play(animationsOfOtherDancers[i]);
        }
    }
    public bool FindDanceOnList(string danceToFind) {
        for(int i = 0; i < animationsOfOtherDancers.Count; i++) {
            if (danceToFind.Equals(animationsOfOtherDancers[i])) {
                return true;
            }
        }
        return false;
    }
    public void CompareDancer(int index) {
        if (animationOfLeadDancer.Equals(animationsOfOtherDancers[index])) {
            Debug.Log("correct");
            SelectRandomDance();
            InitializeDancers();
            SetearDancers();
            GameObject part=Instantiate(particlesHappy,characters[index].transform);
            part.transform.position = characters[index].transform.position;
            part.GetComponent<ParticleSystem>().Play();
        } else {
            Debug.Log("incorrect");
            GameObject part = Instantiate(particlesSad, characters[index].transform);
            part.transform.position = characters[index].transform.position;
            part.GetComponent<ParticleSystem>().Play();
        }
    }
}
