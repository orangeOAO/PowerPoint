namespace PowerPoint.Command
{
    public interface Command
    {

        /// execute
        /// </summary>
        void Execute();

        /// unexecute
        /// </summary>
        void Unexecute();
    }
}