using UnityEngine;

public class LevelPart : MonoBehaviour
{
    TubesMover _mover;

    Transform _transform;
    BoxCollider2D _collider;
    float _width;

    protected void Awake()
    {
        _transform = transform;
        _collider = GetComponent<BoxCollider2D>();
        _width = _collider.bounds.size.x;
        _mover = GetComponent<TubesMover>();
    }
    public virtual void Move(float xPos)
    {
        _transform.position = new Vector2(xPos + _width, transform.position.y);

        if (_mover != null) _mover.CalculateTubesPosition();
    }
    public void Appear()
    {

    }
}
