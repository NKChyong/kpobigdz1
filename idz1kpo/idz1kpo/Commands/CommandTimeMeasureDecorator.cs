using System.Diagnostics;

namespace FinancialAccounting.Commands
{
    public class CommandTimeMeasureDecorator : ICommand
    {
        private readonly ICommand _innerCommand;

        public CommandTimeMeasureDecorator(ICommand innerCommand)
        {
            _innerCommand = innerCommand;
        }

        public string CommandName => _innerCommand.CommandName;

        public void Execute()
        {
            var sw = Stopwatch.StartNew();
            _innerCommand.Execute();
            sw.Stop();
            System.Console.WriteLine("Время: " + sw.ElapsedMilliseconds + " мс");
        }
    }
}