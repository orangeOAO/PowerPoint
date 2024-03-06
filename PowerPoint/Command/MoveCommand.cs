using System.Drawing;

namespace PowerPoint.Command
{
    public class MoveCommand : Command
    {
        public MoveCommand(Model model, int index, Size bias)
        {
            _model = model;
            _index = index;
            _bias = bias;
        }

        /// execute
        /// </summary>
        public void Execute()
        {
            _model.MoveShapeByBias(_bias, _index);
        }

        /// Undo
        /// </summary>
        public void Undo()
        {
            _model.MoveShapeByBias(new Size(-1 * _bias.Width, -1 * _bias.Height), _index);
        }

        readonly Model _model;
        readonly int _index;
        private Size _bias;
    }
}