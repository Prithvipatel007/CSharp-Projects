using System.Collections;
using UnityEngine;

public class FlameAnimations : MonoBehaviour
{
    private const float waitTime = 0.99f;

    [SerializeField]
    public int LightMode;

    [SerializeField]
    public GameObject FlameLight;

    // Update is called once per frame
    void Update()
    {
        if (LightMode == 0)
        {
            StartCoroutine(AnimateLight());
        }
    }

    private IEnumerator AnimateLight()
    {
        LightMode = UnityEngine.Random.Range(1, 4);

        if (LightMode == 1)
        {
            FlameLight.GetComponent<Animation>().Play("TorchAnim1");
        }

        if (LightMode == 2)
        {
            FlameLight.GetComponent<Animation>().Play("TorchAnim2");
        }

        if (LightMode == 3)
        {
            FlameLight.GetComponent<Animation>().Play("TorchAnim3");
        }

        yield return new WaitForSeconds(waitTime);
        LightMode = 0;
    }
}

