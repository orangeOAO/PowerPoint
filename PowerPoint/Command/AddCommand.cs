namespace PowerPoint.Command
{
    public class AddCommand : Command
    {
        public AddCommand(Model model, Shape shape, int index)
        {
            _model = model;
            _shape = shape;
            _index = index;
        }


        /// execute
        /// </summary>
        public void Execute()
        {
            _model.InsertShape(_shape, _index);
        }


        /// unexecute
        /// </summary>
        public void Unexecute()
        {
            _model.DeleteShapeByUndo(_model.GetShapes().Count - 1);
        }

        readonly Model _model;
        readonly Shape _shape;
        readonly int _index;
    }
}