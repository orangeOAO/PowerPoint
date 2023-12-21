namespace PowerPoint.Command
{
    public class DrawingCommand : Command
    {
        public DrawingCommand(Model model, Shape shape, int index)
        {
            _model = model;
            _shape = shape;
            _index = index;
        }


        /// execute
        /// </summary>
        public void Execute()
        {
            _model.InsertShapeByShape(_shape, _index);
        }


        /// unexecute
        /// </summary>
        public void Unexecute()
        {
            _model.DeleteShape(_model.GetShapes().Count - 1);
        }

        readonly Model _model;
        readonly Shape _shape;
        readonly int _index;
    }
}