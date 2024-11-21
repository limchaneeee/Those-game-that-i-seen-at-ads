using UnityEngine;

public class MovingMap : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private GameObject map2;
    private Vector3 initPosOffset = new Vector3(0, 0, 150f);

    private void Start()
    {
        map2 = Instantiate(this.gameObject);
        map2.transform.position = this.transform.position + initPosOffset;
        Destroy(map2.GetComponent<MovingMap>());
    }

    private void FixedUpdate()
    {
        transform.position += Vector3.back * moveSpeed * Time.deltaTime;
        map2.transform.position += Vector3.back * moveSpeed * Time.deltaTime;

        RePosition();
    }

    private void RePosition()
    {
        if (transform.position.z <= -160f)
        {
            transform.position += new Vector3(0, 0, 300f);
        }

        if (map2.transform.position.z <= -160f)
        {
            map2.transform.position += new Vector3(0, 0, 300f);
        }
    }

}