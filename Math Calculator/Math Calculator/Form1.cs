using System;
using System.Globalization;
using System.Windows.Forms;

namespace Math_Calculator
{
    public partial class Form1 : Form
    {
        // Variable to store the result of the last operation
        double resultValue = 0;

        // Variable to store the operation currently being performed
        string operationPerformed = string.Empty;

        // Flag to check if an operation button was clicked
        bool isOperationPerformed = false;

        // NumberFormatInfo to handle decimal point and other formatting
        NumberFormatInfo numberFormatInfo;

        public Form1()
        {
            InitializeComponent();
            numberFormatInfo = new CultureInfo("en-US", false).NumberFormat;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            // Variable to store the second number for the operation
            double secondValue;

            // Validate and parse the text in the textbox as a number
            if (!double.TryParse(textBox_Results.Text, NumberStyles.Any, numberFormatInfo, out secondValue))
            {
                // Show an error message if the input is not a valid number
                MessageBox.Show("Invalid input. Please enter a valid number.");
                return;
            }

            // Perform the calculation based on the selected operation
            switch (operationPerformed)
            {
                case "+":
                    // Add the two numbers and display the result
                    textBox_Results.Text = (resultValue + secondValue).ToString(numberFormatInfo);
                    break;

                case "-":
                    // Subtract the two numbers and display the result
                    textBox_Results.Text = (resultValue - secondValue).ToString(numberFormatInfo);
                    break;

                case "*":
                    // Multiply the two numbers and display the result
                    textBox_Results.Text = (resultValue * secondValue).ToString(numberFormatInfo);
                    break;

                case "/":
                    // Check for division by zero
                    if (secondValue == 0)
                    {
                        // Show an error message if division by zero is attempted
                        MessageBox.Show("Division by zero is not allowed");
                        textBox_Results.Text = "0";
                    }
                    else
                    {
                        // Divide the two numbers and display the result
                        textBox_Results.Text = (resultValue / secondValue).ToString(numberFormatInfo);
                    }
                    break;

                default:
                    // Handle any unexpected cases
                    break;
            }

            // Update resultValue with the new result
            resultValue = double.Parse(textBox_Results.Text, numberFormatInfo);

            // Clear the operation display and set the flag to true
            labelCurrentOperation.Text = string.Empty;
            isOperationPerformed = true;
        }

        private void button_Click(object sender, EventArgs e)
        {
            // If the textbox is "0" or an operation was performed, clear it
            if (textBox_Results.Text == "0" || isOperationPerformed)
                textBox_Results.Clear();

            // Reset the flag to false, allowing input to be entered
            isOperationPerformed = false;

            // Get the button that was clicked
            Button button = (Button)sender;

            // Handle the dot button separately to ensure only one dot is present
            if (button.Text == ".")
            {
                // Only add the dot if it is not already in the textbox
                if (!textBox_Results.Text.Contains("."))
                    textBox_Results.Text += button.Text;
            }
            else
            {
                // Append the clicked button's text to the textbox
                textBox_Results.Text += button.Text;
            }
        }

        private void operator_click(object sender, EventArgs e)
        {
            // Get the button that was clicked
            Button button = (Button)sender;

            // Validate the current text in the textbox and parse it as a number
            if (!double.TryParse(textBox_Results.Text, NumberStyles.Any, numberFormatInfo, out resultValue))
            {
                // Show an error message if the input is not a valid number
                MessageBox.Show("Invalid input. Please enter a valid number.");
                return;
            }

            // Store the operation performed (e.g., +, -, *, /)
            operationPerformed = button.Text;

            // Display the operation to the user
            labelCurrentOperation.Text = resultValue + " " + operationPerformed;

            // Set the flag to true to indicate that an operation was performed
            isOperationPerformed = true;
        }

        private void btnClear_Entry_Click(object sender, EventArgs e)
        {
            textBox_Results.Text = "0";
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            textBox_Results.Text = "0";
            resultValue = 0;
        }
    }
}

