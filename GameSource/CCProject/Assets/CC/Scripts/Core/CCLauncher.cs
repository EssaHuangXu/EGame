using CC.Core;
using UnityEngine;

public class CCLauncher : MonoBehaviour
{
    private void Update()
    {
        CCApplication.Instance.Update(Time.deltaTime);
    }
}
