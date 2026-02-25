using System.Collections;
using UnityEngine;

public class ChasingSystem : MonoBehaviour
{
    [SerializeField] private float speed = 2f;

    private GameObject villain;
    private Transform target;

    private IEnumerator HeroWait()
    {
        yield return new WaitForSeconds(1f);

        // 씬에서 빌런 찾기
        villain = GameObject.FindWithTag("Villain");
        if (villain != null)
            target = villain.transform;
    }

    private void Start()
    {
        StartCoroutine(HeroWait());
    }

    private void Update()
    {
        if (target == null) return;

        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        if (Vector3.Distance(transform.position, target.position) < 0.1f)
        {
            Debug.Log("히어로가 빌런을 잡았다!");

            Destroy(villain);
            Destroy(this.gameObject);
        }
    }
}