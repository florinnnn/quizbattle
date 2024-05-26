using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DraggableTurret : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    static private Button cancelPlacementButton;
    static private int turretPrice = 40;
    static public bool dragging = false;
    static public GameObject[] snappingZones;
    private GameObject draggedTurret;
    private GameObject copyOfTurret;

    // Update is called once per frame
    void Update()
    {
        snappingZones = GameObject.FindGameObjectsWithTag("SnappingZone");
        if (copyOfTurret != null)
        {
            //GameManagerScript.coins -= turretPrice;
            Vector3 mousePosition = Input.mousePosition;
            Ray ray = mainCamera.ScreenPointToRay(mousePosition);
            if (dragging == false)
            {
                Destroy(copyOfTurret);
                cancelPlacementButton.interactable = false;
            }
            else
            {
                if (Physics.Raycast(ray, out RaycastHit hit))
                {
                    GameObject closestSnappingZone = null;
                    float closestDistance = 3.0f;

                    foreach (GameObject snappingZone in snappingZones)
                    {
                        float distance = Vector3.Distance(new Vector3(hit.point.x, hit.point.y - 0.53f, hit.point.z), snappingZone.transform.position);
                        if (distance < closestDistance)
                        {
                            closestSnappingZone = snappingZone;
                        }
                    }
                    if (closestSnappingZone != null)
                    {
                        copyOfTurret.transform.position = new Vector3(closestSnappingZone.transform.position.x, closestSnappingZone.transform.position.y - 0.53f, closestSnappingZone.transform.position.z);
                    }
                    else
                    {
                        copyOfTurret.transform.position = new Vector3(hit.point.x, hit.point.y - 0.53f, hit.point.z);
                    }
                
                    if (Input.GetMouseButtonDown(0))
                    {
                        if (closestSnappingZone != null && turretPrice <= GameManagerScript.coins)
                        {
                            GameManagerScript.coins -= turretPrice;
                            copyOfTurret.tag = "Untagged";
                            copyOfTurret = null;
                            Destroy(closestSnappingZone);
                            cancelPlacementButton.interactable = false;
                            dragging = false;
                        }
                    }
                }
            }
            
        }
    }

    void Start()
    {
        draggedTurret = this.transform.GetChild(0).gameObject;
        cancelPlacementButton = GameObject.Find("CancelPlacement").GetComponent<Button>();
        cancelPlacementButton.interactable = false;
        mainCamera = Camera.main;
    }

    public void ButtonPressed()
    {
        if (!dragging)
        {
            copyOfTurret = Instantiate(draggedTurret, new Vector3(0, 0, 0), new Quaternion());
            copyOfTurret.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
            copyOfTurret.GetComponent<Turret>().enabled = false;
            copyOfTurret.tag = "DraggableTurret";
            cancelPlacementButton.interactable = true;
            dragging = true;
        }
    }
}
