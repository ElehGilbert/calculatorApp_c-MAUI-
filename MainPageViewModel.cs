using System;
using System.Data;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using System.ComponentModel;
using System.Runtime.CompilerServices;


namespace Caleh.ViewModels
{
    public class MainPageViewModel :
        INotifyPropertyChanged
    {
        private string _expressionDisplay;
        private string _resultDisplay;


        //Property to Display the Expression
        public string ExpressionDisplay
        {
            get => _expressionDisplay;
            set
            {
                _expressionDisplay = value;
                OnpropertyChanged();
            }
        }

        //Property to Display Result
        public string ResultDisplay
        {
            get => _resultDisplay;
            set
            {
                _resultDisplay = value;
                OnpropertyChanged();
            }
        }
        //command to handle button clicks
        public ICommand ButtonCommand { get; }

        public MainPageViewModel()
        {

            //Initialize the command with the method to execute
            ButtonCommand = new Command<string>(OnButtonClicked);



        }

    //Method to handle button Clicks
    private void OnButtonClicked(string value)
    {
        //if the value is "AC", clear the displays

        if (value == "AC")
        {
            ExpressionDisplay = string.Empty;
            ResultDisplay = string.Empty;
        }

        //if the value is "=", Calculate the result
        else if (value == "=")
        { try
            {
                // evaluating the expression
                var result = EvaluateExpression(ExpressionDisplay);
                ResultDisplay = result.ToString();

            }
            catch
            {
                ResultDisplay = "Error";
            }
                //if(value == "1")
                //{ ExpressionDisplay = "1"; }

        }

        //Otherwise, append the Value to the expression
        else
        {
            ExpressionDisplay += value;
        }
    }

    //Simple method to evaluate the Expression
    private double EvaluateExpression(string expression)
    {
        //For simplicity, Using DataTable.Compute to evaluate the expression
        var table = new System.Data.DataTable();
        return Convert.ToDouble(table.Compute(expression, string.Empty));

    }

    //Event to notify the UI property changes

    public event PropertyChangedEventHandler PropertyChanged;

    protected void OnpropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
}