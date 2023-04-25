namespace AstroShift
{
    public interface IModule
    {
        IAutomatonable Automaton { get; set; }
        public bool IsBootedUp { get; }
        void EnableModule();
        void DisableModule();
        void DismantleModule();
        void Perform();
    }
}
