using UnityEngine;

public class DeathTimer : MonoBehaviour
{
    public float Duration = 5;
    public float counter = 0;

    // Update is called once per frame
    void Update()
    {
        counter += Time.deltaTime;
        if (counter > Duration)
        {
            Destroy(gameObject);
        }
    }
}
