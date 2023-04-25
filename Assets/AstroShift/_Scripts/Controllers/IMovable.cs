namespace AstroShift
{
    public interface IMovable
    {
        void Move(float horizontal, float vertical);
        void Rotate(float horizontal);
        void Boost(float amount);
    }
}