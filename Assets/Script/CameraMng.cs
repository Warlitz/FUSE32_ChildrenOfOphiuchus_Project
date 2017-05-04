using UnityEngine;
using System.Collections;

public class CameraMng : MonoBehaviour {

    [SerializeField]
    private float MaxY;
    [SerializeField]
    private float MinY;
    [SerializeField]
    private float MaxX;
    [SerializeField]
    private float MinX;

    private GameObject player;

    private Vector3 vec;

	void Start ()
    {
        player = GameObject.Find("Player");
        vec = this.transform.position - player.transform.position;
	}

    void Update()
    {
        Vector3 pos = player.transform.position + vec;

        if (pos.x <= MinX)
            pos.x = MinX;
        else if (pos.x >= MaxX)
            pos.x = MaxX;

        if (pos.y <= MinY)
            pos.y = MinY;
        else if (pos.y >= MaxY)
            pos.y = MaxY;

        this.transform.position = pos;
    }
}
