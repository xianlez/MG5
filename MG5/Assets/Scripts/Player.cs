using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    private Animator _animator;
    private NavMeshAgent _agent;
    private Vector3 _lastKnownLocation;

    private Camera _mainCamera;
    private RaycastHit _raycastHit;
    private bool _raycastSuccessful = false;
    private Ray _mouseRay;

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _mainCamera = Camera.main;
        _animator = GetComponent<Animator>();

        _lastKnownLocation = transform.position;
    }

    private void Update()
    {
        // 
        if (Input.GetMouseButtonDown(0))
        {
            _mouseRay = _mainCamera.ScreenPointToRay(
                Input.mousePosition
            );

            // 
            _raycastSuccessful = Physics.Raycast(
                _mouseRay,
                out _raycastHit,
                Mathf.Infinity,
                LayerMask.GetMask("Ground")
            );

            if (_raycastSuccessful)
            {
                Vector3 mouseHitPosition = _raycastHit.point;

                // 
                _lastKnownLocation = transform.position;

                // 
                _agent.SetDestination(mouseHitPosition);
            }
        }

        // 
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_agent.Warp(_lastKnownLocation))
            {
                // 
                _agent.ResetPath();
            }
        }

        // 
        _animator.SetBool(
            "isMoving",
            _agent.velocity.magnitude > 0.0f
        );
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(_mouseRay);

        Gizmos.color = Color.green;
        Gizmos.DrawSphere(_raycastHit.point, 0.2f);
    }
}