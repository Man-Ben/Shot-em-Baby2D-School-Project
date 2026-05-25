/*
Ez a script a hátteret kezeli, folyamatosan mozgatja lefele.
Amikor eléri a limitet akkor visszahelyezi a legelső panelt a legfalső panel elé.
*/


using System.Collections.Generic;
using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    [SerializeField] float backGroundSpeed = 10;
    [SerializeField] List<Transform> backgroundpanels;

    float width;

    Transform firstPanel;
    Transform lastPanel;

    Vector2 limit = new Vector2(-1.4f, -40);

    void Awake()
    {
        width = backgroundpanels[0].GetComponent<SpriteRenderer>().bounds.size.y;
    }

    void Update()
    {
        if(UIManager.Instance.gameState == UIManager.GameState.Neutral)
            Moving();
    }

    void Moving()
    {
        firstPanel = backgroundpanels[0];
        lastPanel = backgroundpanels[backgroundpanels.Count - 1];

        transform.Translate(Vector2.down * backGroundSpeed * Time.deltaTime);

        if(firstPanel.transform.position.y < limit.y)
        {
            ResetPosition();
        }
    }

    void ResetPosition()
    {
        firstPanel.position = new Vector2(0, lastPanel.position.y + width);

        backgroundpanels.RemoveAt(0);
        backgroundpanels.Add(firstPanel);
    }
}
