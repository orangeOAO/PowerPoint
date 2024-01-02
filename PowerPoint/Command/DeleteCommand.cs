namespace PowerPoint.Command
{
    public class DeleteCommand : Command
    {
        public DeleteCommand(Model model, Shape shape, int index)
        {
            _model = model;
            _shape = shape;
            _index = index;
        }

        /// execute
        /// </summary>
        public void Execute()
        {
            _model.DeleteShapeByUndo(_index);
        }

        /// unexecute
        /// </summary>
        public void Unexecute()
        {
            _model.InsertShape(_shape, _index);
        }

        readonly Model _model;
        readonly Shape _shape;
        readonly int _index;
    }
}