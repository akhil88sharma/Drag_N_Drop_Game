using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class DragNDrop : MonoBehaviour
{
    [SerializeField] private InputAction mouseClick;
    [SerializeField] private float mouseDragSpeed = 0.1f;
    [SerializeField] GameObject buttonPanel;

    private Camera mainCamera;
    private Vector3 velocity = Vector3.zero;
    [HideInInspector] public string str;


    private void Awake()
    {
        mainCamera = Camera.main;
    }
    private void OnEnable()
    {
        mouseClick.Enable();
        mouseClick.performed += MousePressed;
    }
    private void OnDisable()
    {
        mouseClick.performed -= MousePressed;
        mouseClick.Disable();
    }
    private void MousePressed(InputAction.CallbackContext context)
    {
        Ray ray = mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue());
        RaycastHit hit;
        if(Physics.Raycast(ray, out  hit))
        {
            if(hit.collider != null && (hit.collider.gameObject.CompareTag("CFA") || hit.collider.gameObject.CompareTag("CFB")))
            {
                StartCoroutine(DragUpdate(hit.collider.gameObject));
            }
        }
    }
    private IEnumerator DragUpdate(GameObject clickedObj)
    {
        float initialDist = Vector3.Distance(clickedObj.transform.position, mainCamera.transform.position);
        while(mouseClick.ReadValue<float>() != 0)
        {
            Ray ray = mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue());
            clickedObj.transform.position = Vector3.SmoothDamp(clickedObj.transform.position, ray.GetPoint(initialDist), ref velocity, mouseDragSpeed);
            yield return null;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        buttonPanel.SetActive(true);
        str = other.gameObject.tag;
        Debug.Log(str);
    }
}
