using UnityEngine;

public class scale : MonoBehaviour
{
    public Vector3 originalscale;
    public Vector3 minscale = new Vector3(0.1f,0.1f,0.1f);
    private Vector3 depthscale;
    public float depth=0;
    public float maxdepth = 100f;
    public int speed = 4;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //depthスライダーで調整
        depthscale = originalscale - (depth / maxdepth)*(originalscale-minscale);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        depthscale = originalscale - (depth / maxdepth) * (originalscale - minscale);
        this.transform.localScale = depthscale;
        depth+=speed;
        if (depth>maxdepth)
        {
            depth = 0;
        }
    }
}
