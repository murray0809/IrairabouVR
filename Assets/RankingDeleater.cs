using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OVR;

public class RankingDeleater : MonoBehaviour
{
    [SerializeField] float clearLimit = 5f;
    float counter = 0;
    // Update is called once per frame
    void Update()
    {
        if (OVRInput.Get(OVRInput.RawButton.X) || Input.GetKey(KeyCode.A))
        {
            if (counter <= clearLimit)
            {
                counter += Time.deltaTime;
            }
            else
            {
                UserDatas.Instans.ClearAllData();
                FindObjectOfType<RankingView>().GetComponent<RankingView>().ClearPanel();
                counter = 0;
            }
        }
    }
}
