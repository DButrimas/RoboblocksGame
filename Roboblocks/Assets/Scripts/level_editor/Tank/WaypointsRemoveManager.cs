using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Linq;

public class WaypointsRemoveManager : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{

    public Color defaultColor;
    public Color clickedColor;
    public Color hoverColor;


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
            Destroy(TankWaypoints.LastWaypoint.gameObject);
            TankWaypoints.waypoints.Remove(TankWaypoints.waypoints.Last());
            TankWaypoints.waypointsGameobject.Remove(TankWaypoints.LastWaypoint);
            TankWaypoints.LastWaypoint = TankWaypoints.waypointsGameobject.Last();

        }

        gameObject.GetComponent<Image>().color = defaultColor;

    }
}
