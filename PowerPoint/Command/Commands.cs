namespace PowerPoint.Command
{
    public interface Command
    {

        /// execute
        /// </summary>
        void Execute();

        /// Undo
        /// </summary>
        void Undo();
    }
}