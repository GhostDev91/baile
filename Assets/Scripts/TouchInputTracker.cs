using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TouchInputTracker : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject GM_Controller;
    

    public bool singlePlayer=false;
    [SerializeField] TextMeshProUGUI textSign;
    // Update is called once per frame
    void FixedUpdate()
    {
        if(Input.touchCount>0) {


            
            if (Input.touches[0].phase == TouchPhase.Ended) {
                Ray ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit)) {
                    if (hit.collider != null) {
                        if (hit.collider.CompareTag("dancer0")) {
                            GM_Controller.GetComponent<GameManagerController>().CompareDancer(0);
                            
                        }
                        if (hit.collider.CompareTag("dancer1")) {
                            GM_Controller.GetComponent<GameManagerController>().CompareDancer(1);

                        }
                        if (hit.collider.CompareTag("dancer2")) {
                            GM_Controller.GetComponent<GameManagerController>().CompareDancer(2);

                        }
                        if (hit.collider.CompareTag("dancer3")) {
                            GM_Controller.GetComponent<GameManagerController>().CompareDancer(3);

                        }
                    }
                }
            }

        }
        if (Input.GetMouseButtonUp(0)) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit)) {
                if (hit.collider != null) {
                    if (hit.collider.CompareTag("dancer0")) {
                        GM_Controller.GetComponent<GameManagerController>().CompareDancer(0);

                    }
                    if (hit.collider.CompareTag("dancer1")) {
                        GM_Controller.GetComponent<GameManagerController>().CompareDancer(1);

                    }
                    if (hit.collider.CompareTag("dancer2")) {
                        GM_Controller.GetComponent<GameManagerController>().CompareDancer(2);

                    }
                    if (hit.collider.CompareTag("dancer3")) {
                        GM_Controller.GetComponent<GameManagerController>().CompareDancer(3);

                    }
                }
            }
        }

        

    }
    
    
}
