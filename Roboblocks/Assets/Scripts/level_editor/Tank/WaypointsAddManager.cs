using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Linq;

public class WaypointsAddManager : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{

    public Color defaultColor;
    public Color clickedColor;
    public Color hoverColor;

    public GameObject Waypoint_prefab;

    public void OnPointerEnter(PointerEventData eventData)
    {
        gameObject.GetComponent<Image>().color = hoverColor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        gameObject.GetComponent<Image>().color = defaultColor;
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        gameObject.GetComponent<Image>().color = clickedColor;

        if (TankWaypoints.waypoints.Count == 0)
        {

        }
        else
        {

        }

        GameObject wayp = Instantiate(Waypoint_prefab, null);
        if (TankWaypoints.waypoints.Count == 0)
        {
            wayp.transform.position = new Vector3(SelectedStatic.selected.transform.position.x + 1.5f, SelectedStatic.selected.transform.position.y, SelectedStatic.selected.transform.position.z);
            Waypoint w = new Waypoint();
            w.posX = wayp.transform.position.x;
            w.posY = wayp.transform.position.y;
            w.posZ = wayp.transform.position.z;

            TankWaypoints.waypoints.Add(w);
            TankWaypoints.LastWaypoint = wayp;
            TankWaypoints.waypointsGameobject.Add(wayp);
        }
        else
        {
            wayp.transform.position = new Vector3(TankWaypoints.waypoints.Last().posX + 1f, TankWaypoints.waypoints.Last().posY, TankWaypoints.waypoints.Last().posZ);
            Waypoint w = new Waypoint();
            w.posX = wayp.transform.position.x;
            w.posY = wayp.transform.position.y;
            w.posZ = wayp.transform.position.z;

            TankWaypoints.waypoints.Add(w);
            TankWaypoints.LastWaypoint = wayp;
            TankWaypoints.waypointsGameobject.Add(wayp);
        }

        gameObject.GetComponent<Image>().color = defaultColor;

    }
}
