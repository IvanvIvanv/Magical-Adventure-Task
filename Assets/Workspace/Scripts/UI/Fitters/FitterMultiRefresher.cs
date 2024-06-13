using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FitterMultiRefresher : MonoBehaviour
{
    public List<FitterRefresher> FitterRefreshers;

    public void RefreshAll()
    {
        FitterRefreshers.ForEach(refresher => refresher.Refresh());
    }
}
