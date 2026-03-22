using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using VogusovaCalculator.Logic;
using VogusovaCalculator.UI.Commands;

namespace VogusovaCalculator.UI.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly CalculatorEngine _engine;
        private string _input;
        private double _currentValue;
        private Operation _currentOperation;
        private bool _isNewInput;

        public MainViewModel()
        {
            _engine = new CalculatorEngine();
            _input = "0";
            _currentValue = 0;
            _currentOperation = Operation.None;
            _isNewInput = true;
            History = new ObservableCollection<string>();

            DigitCommand = new RelayCommand(Digit);
            OperationCommand = new RelayCommand(SetOperation);  
            EqualsCommand = new RelayCommand(o => Calculate()); 
            ClearCommand = new RelayCommand(o => Clear());
        }

        public string Input
        {
            get => _input;
            set
            {
                _input = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<string> History { get; }

        public RelayCommand DigitCommand { get; }
        public RelayCommand OperationCommand { get; }
        public RelayCommand EqualsCommand { get; }
        public RelayCommand ClearCommand { get; }

        private void Digit(object param)
        {
            string digit = param.ToString();
            if (_isNewInput)
            {
                Input = digit;
                _isNewInput = false;
            }
            else if (Input.Length < 15)
            {
                Input += digit;
            }
        }

        
        private void SetOperation(object param)
        {
            if (double.TryParse(Input, out double value))
            {
                _currentValue = value;

                
                string operationName = param.ToString();
                switch (operationName)
                {
                    case "Add":
                        _currentOperation = Operation.Add;
                        break;
                    case "Subtract":
                        _currentOperation = Operation.Subtract;
                        break;
                    case "Multiply":
                        _currentOperation = Operation.Multiply;
                        break;
                    case "Divide":
                        _currentOperation = Operation.Divide;
                        break;
                    case "Power":
                        _currentOperation = Operation.Power;
                        break;
                    default:
                        _currentOperation = Operation.None;
                        break;
                }

                _isNewInput = true;
            }
        }

        
        private void Calculate()
        {
            if (!double.TryParse(Input, out double secondValue) || _currentOperation == Operation.None)
            {
                return;
            }

            try
            {
                double result = _engine.Calculate(_currentValue, secondValue, _currentOperation);
                string expression = $"{_currentValue} {GetOperationSymbol(_currentOperation)} {secondValue} = {result}";
                History.Insert(0, expression);
                Input = result.ToString();
                _currentValue = result;
                _currentOperation = Operation.None;
                _isNewInput = true;
            }
            catch (DivideByZeroException ex)
            {
                Input = "Ошибка";
                History.Insert(0, $"Ошибка: {ex.Message}");
                _isNewInput = true;
            }
            catch (Exception ex)
            {
                Input = "Ошибка";
                History.Insert(0, $"Ошибка: {ex.Message}");
                _isNewInput = true;
            }
        }

        private void Clear()
        {
            Input = "0";
            _currentValue = 0;
            _currentOperation = Operation.None;
            _isNewInput = true;
        }

        private string GetOperationSymbol(Operation op)
        {
            switch (op)
            {
                case Operation.Add:
                    return "+";
                case Operation.Subtract:
                    return "-";
                case Operation.Multiply:
                    return "×";
                case Operation.Divide:
                    return "÷";
                case Operation.Power:
                    return "^";
                default:
                    return "?";
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}