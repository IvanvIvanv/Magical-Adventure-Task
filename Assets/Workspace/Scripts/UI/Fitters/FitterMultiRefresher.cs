using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FitterMultiRefresher : MonoBehaviour
{
    public List<LayoutRebuilder> FitterRefreshers;

    public void RefreshAll()
    {
        FitterRefreshers.ForEach(refresher => refresher.Rebuild());
    }
}
