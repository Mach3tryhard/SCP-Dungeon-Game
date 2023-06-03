using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTemplates : MonoBehaviour
{
    public GameObject[] simple;
    public GameObject[][] complicated;

    public bool DONE=false;

    public GameObject[] bottomRooms;
    public GameObject[] topRooms;
    public GameObject[] rightRooms;
    public GameObject[] leftRooms;

    public GameObject closedRoom;

    void Start() {
        complicated = new GameObject[81][];
        int[] done = new int[81];
        for (int i = 0; i < 81; i++) {
            int size = 1;
            for (int d = 1; d < 81; d *= 3) {
                if ((i / d) % 3 == 0)
                    size *= 2;
            }
            complicated[i] = new GameObject[size];
            done[i] = 0;
        }
        for (int i = 0; i < 16; i++) {
            int idx = 0;
            for (int p3 = 1, p2 = 1; p3 < 81; p3 *= 3, p2 *= 2)
                idx += p3 * (1 + (i / p2) % 2);
            int[] opts = new int[16];
            int size = 1;
            opts[0] = idx;
            for (int j = 1; j < 81; j *= 3) {
                for (int k = 0; k < size; k++)
                    opts[k + size] = opts[k] - ((opts[k] / j) % 3) * j;
                size *= 2;
            }
            //Debug.Log($"[{string.Join(", ", opts)}]");
            for (int j = 0; j < 16; j++) {
                complicated[opts[j]][done[opts[j]]] = simple[i];
                done[opts[j]]++;
            }
            //Debug.Log($"[{string.Join<GameObject>(", ", complicated[18])}]");
        }
        DONE=true;
    }
}
