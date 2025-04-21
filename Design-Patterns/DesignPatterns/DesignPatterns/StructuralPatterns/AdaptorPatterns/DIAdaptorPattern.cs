using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.StructuralPatterns.AdaptorPatterns
{
    public interface ICommand
    {
        void Execute();
    }

    public class SaveCommand : ICommand
    {
        public void Execute()
        {
            Console.WriteLine("Saving a file");
        }
    }

    public class OpenCommand : ICommand
    {
        public void Execute()
        {
            Console.WriteLine("Opening a file");
        }
    }

    public class Button
    {
        private ICommand _Command;
        private string _Name;

        public Button(ICommand command, string name)
        {
            _Command = command ?? throw new ArgumentNullException(nameof(command));
            _Name = name ?? throw new ArgumentNullException(nameof(name));
        }

        public void Click()
        {
            _Command.Execute();
        }

        public void PrintMe()
        {
            Console.WriteLine($"I am a button called by {_Name}");
        }
    }

    public class Editor
    {
        private IEnumerable<Button> _Buttons;

        public IEnumerable<Button> Buttons { get => _Buttons; }

        public Editor(IEnumerable<Button> buttons)
        {
            _Buttons = buttons ?? throw new ArgumentNullException(nameof(buttons));
        }

        public void ClickAll()
        {
            foreach (var button in _Buttons)
            {
                button.Click();
            }
        }

    }


}
