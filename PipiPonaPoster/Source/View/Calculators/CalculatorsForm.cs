using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

using PipiPonaPoster.Source.View.Calculators;

#pragma warning disable IDE1006

namespace PipiPonaPoster.Source.View
{
    public partial class CalculatorsForm : Form
    {
        private record Field(TextBox TextBox, string Id, CalcType CalcType);

        private enum CalcType { PriceDifference, PercentOfNumber, Commission }

        private Process _windowsCalc;

        private readonly List<Field> _priceDifference_Fields;
        private readonly List<Field> _percentOfNumber_Fields;
        private readonly List<Field> _commission_Fields;

        private double _startPrice;
        private double _suggestedPrice;

        private double _percent;
        private double _number;

        private DateTime _selectedDate;
        private double _bankGuarantee;
        private DateTime _termOfPerformance;
        private double _interestRate;

        const int ADD_WEEK = 7;
        const int ADD_MONTH = 31;
        const int DAYS_IN_YEAR = 365;
        const int PERCENTS = 100;

        public CalculatorsForm()
        {
            InitializeComponent();

            _priceDifference_Fields = new List<Field>()
            {
                new(textBoxStartPrice, PriceDifferenceFieldID.StartPrice, CalcType.PriceDifference),
                new(textBoxSuggestedPrice, PriceDifferenceFieldID.SuggestedPrice, CalcType.PriceDifference)
            };

            _percentOfNumber_Fields = new List<Field>()
            {
                new(textBoxPercent, PercentOfNumberFieldID.Percent, CalcType.PercentOfNumber),
                new(textBoxNumber, PercentOfNumberFieldID.Number, CalcType.PercentOfNumber)
            };

            _commission_Fields = new List<Field>()
            {
                new(textBoxSelectedDate, CommissionFieldID.SelectedDate, CalcType.Commission),
                new(textBoxBankGuarantee, CommissionFieldID.BankGuarantee, CalcType.Commission),
                new(textBoxTermOfPerformance, CommissionFieldID.TermOfPerformance, CalcType.Commission),
                new(textBoxInterestRate, CommissionFieldID.InterestRate, CalcType.Commission),
            };

            _windowsCalc = Process.Start("calc.exe");
        }

        #region PriceDifference EventHandlers
        private void textBoxStartPrice_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                HandleInput(new(sender as TextBox, PriceDifferenceFieldID.StartPrice, CalcType.PriceDifference));
        }

        private void textBoxSuggestedPrice_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                HandleInput(new(sender as TextBox, PriceDifferenceFieldID.SuggestedPrice, CalcType.PriceDifference));
        }

        private void buttonRunCalculationPriceDifference_Click(object sender, EventArgs e)
        {
            RunCalculation(CalcType.PriceDifference);
        }
        #endregion

        #region PercentOfNumber EventHandlers
        private void textBoxPercent_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                HandleInput(new(sender as TextBox, PercentOfNumberFieldID.Percent, CalcType.PercentOfNumber));
        }

        private void textBoxNumber_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                HandleInput(new(sender as TextBox, PercentOfNumberFieldID.Number, CalcType.PercentOfNumber));
        }

        private void buttonRunCalculationPercentOfNumber_Click(object sender, EventArgs e)
        {
            RunCalculation(CalcType.PercentOfNumber);
        }
        #endregion

        #region Commission EventHandlers
        private void textBoxSelectedDate_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                HandleInput(new(sender as TextBox, CommissionFieldID.SelectedDate, CalcType.Commission));
        }

        private void textBoxBankGuarantee_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                HandleInput(new(sender as TextBox, CommissionFieldID.BankGuarantee, CalcType.Commission));
        }

        private void textBoxTermOfPerformance_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                HandleInput(new(sender as TextBox, CommissionFieldID.TermOfPerformance, CalcType.Commission));
        }

        private void textBoxInterestRate_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                HandleInput(new(sender as TextBox, CommissionFieldID.InterestRate, CalcType.Commission));
        }

        private void buttonRunCalculationCommission_Click(object sender, EventArgs e)
        {
            RunCalculation(CalcType.Commission);
        }
        #endregion

        private void RunCalculation(CalcType calcType)
        {
            List<Field> fields = calcType switch
            {
                CalcType.PriceDifference => _priceDifference_Fields,
                CalcType.PercentOfNumber => _percentOfNumber_Fields,
                CalcType.Commission => _commission_Fields,
                _ => throw new InvalidOperationException()
            };

            if (ValidateAllFields(out List<Field> invalidFields, calcType))
            {
                CancelTextBoxesErrorHighlighting(fields);
                CalculateAndDisplayResult(calcType);
            }
            else
            {
                const string messageText = "Проверьте выделенные жёлтым поля на корректность введённых данных и их наличие";

                CancelTextBoxesErrorHighlighting(fields);
                HighlightInvalidFields(invalidFields);
                MessageBox.Show(messageText, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HandleInput(Field field)
        {
            if (!ValidateSenderInput(field.Id))
            {
                string message = field.Id;
                field.TextBox.BackColor = Color.White;
                MessageBox.Show($"Некорректный ввод в поле \'{message}\'!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            List<Field> fields = field.CalcType switch
            {
                CalcType.PriceDifference => _priceDifference_Fields,
                CalcType.PercentOfNumber => _percentOfNumber_Fields,
                CalcType.Commission => _commission_Fields,
                _ => throw new InvalidOperationException()
            };

            for (int i = 0; i <= fields.Count; i++)
            {
                if (i == fields.Count)
                {
                    CancelTextBoxesErrorHighlighting(fields);
                    CalculateAndDisplayResult(field.CalcType);
                    return;
                }

                if (!ValidateSenderInput(fields[i].Id))
                {
                    fields[i].TextBox.Focus();
                    return;
                }
            }
        }

        private void HighlightInvalidFields(List<Field> invalidFields) => Invoke(new Action(() =>
        {
            foreach (var field in invalidFields)
                field.TextBox.BackColor = Color.LightGoldenrodYellow;
        }));

        private static void CancelTextBoxesErrorHighlighting(List<Field> fields)
        {
            foreach (Field f in fields)
                if (f.TextBox.BackColor == Color.LightGoldenrodYellow)
                    f.TextBox.BackColor = Color.White;
        }

        private bool ValidateSenderInput(string id) => id switch
        {
            PriceDifferenceFieldID.StartPrice => ValidateStartPrice(),
            PriceDifferenceFieldID.SuggestedPrice => ValidateSuggestedPrice(),

            PercentOfNumberFieldID.Percent => ValidatePercent(),
            PercentOfNumberFieldID.Number => ValidateNumber(),

            CommissionFieldID.SelectedDate => ValidateSelectedDate(),
            CommissionFieldID.BankGuarantee => ValidateBankGuarantee(),
            CommissionFieldID.TermOfPerformance => ValidateTermOfPerformance(),
            CommissionFieldID.InterestRate => ValidateInterestRate(),

            _ => throw new InvalidOperationException(),
        };

        private bool ValidateAllFields(out List<Field> invalidFields, CalcType calcType)
        {
            Func<(bool res, List<Field> fields)> func = calcType switch
            {
                CalcType.PriceDifference => OnPriceDifference,
                CalcType.PercentOfNumber => OnPercentOfNumber,
                CalcType.Commission => OnCommission,
                _ => throw new InvalidOperationException()
            };

            var (res, fields) = func.Invoke();
            bool allFieldsValid = res;
            invalidFields = fields;

            return allFieldsValid;

            (bool res, List<Field> fields) OnPriceDifference()
            {
                List<Field> invalidFields = new();

                invalidFields.Add(ValidateStartPrice() ? null
                    : _priceDifference_Fields.First(f => f.TextBox.Equals(textBoxStartPrice)));
                invalidFields.Add(ValidateSuggestedPrice() ? null
                    : _priceDifference_Fields.First(f => f.TextBox.Equals(textBoxSuggestedPrice)));

                invalidFields.RemoveAll(f => f == null);

                return (invalidFields.Count == 0, invalidFields);
            }

            (bool res, List<Field> fields) OnPercentOfNumber()
            {
                List<Field> invalidFields = new();

                invalidFields.Add(ValidatePercent() ? null
                    : _percentOfNumber_Fields.First(f => f.TextBox.Equals(textBoxPercent)));
                invalidFields.Add(ValidateNumber() ? null
                    : _percentOfNumber_Fields.First(f => f.TextBox.Equals(textBoxNumber)));

                invalidFields.RemoveAll(f => f == null);

                return (invalidFields.Count == 0, invalidFields);
            }

            (bool res, List<Field> fields) OnCommission()
            {
                List<Field> invalidFields = new();

                invalidFields.Add(ValidateSelectedDate() ? null 
                    : _commission_Fields.First(f => f.TextBox.Equals(textBoxSelectedDate)));
                invalidFields.Add(ValidateBankGuarantee() ? null 
                    : _commission_Fields.First(f => f.TextBox.Equals(textBoxBankGuarantee)));
                invalidFields.Add(ValidateTermOfPerformance() ? null 
                    : _commission_Fields.First(f => f.TextBox.Equals(textBoxTermOfPerformance)));
                invalidFields.Add(ValidateInterestRate() ? null 
                    : _commission_Fields.First(f => f.TextBox.Equals(textBoxInterestRate)));

                invalidFields.RemoveAll(f => f == null);

                return (invalidFields.Count == 0, invalidFields);
            }
        }

        private bool ValidateStartPrice()
        {
            string tb = textBoxStartPrice.Text.Replace('.', ',')
                                              .Replace("руб", "")
                                              .Replace("руб.", "");
            return double.TryParse(string.Join(string.Empty, tb.Split(' ', '\'', '`', '\n', '\r')), out _startPrice);
        }

        private bool ValidateSuggestedPrice()
        {
            string tb = textBoxSuggestedPrice.Text.Replace('.', ',')
                                                  .Replace("руб", "")
                                                  .Replace("руб.", "");
            return double.TryParse(string.Join(string.Empty, tb.Split(' ', '\'', '`', '\n', '\r')), out _suggestedPrice);
        }

        private bool ValidatePercent()
        {
            string tb = textBoxPercent.Text.Replace('.', ',');
            return double.TryParse(string.Join(string.Empty, tb.Split(' ', '\'', '`', '\n', '\r', '%')), out _percent);
        }

        private bool ValidateNumber()
        {
            string tb = textBoxNumber.Text.Replace('.', ',');
            return double.TryParse(string.Join(string.Empty, tb.Split(' ', '\'', '`', '\n', '\r')), out _number);
        }

        private bool ValidateSelectedDate()
        {
            return DateTime.TryParse(string.Join(string.Empty, textBoxSelectedDate.Text.Split(' ', '\'', '`', '\n', '\r')), out _selectedDate);
        }

        private bool ValidateBankGuarantee()
        {
            string tb = textBoxBankGuarantee.Text.Replace('.', ',')
                                                 .Replace("руб", "")
                                                 .Replace("руб.", "");
            return double.TryParse(string.Join(string.Empty, tb.Split(' ', '\'', '`', '\n', '\r')), out _bankGuarantee);
        }

        private bool ValidateTermOfPerformance()
        {
            return DateTime.TryParse(string.Join(string.Empty, textBoxTermOfPerformance.Text.Split(' ', '\'', '`', '\n', '\r')), out _termOfPerformance);
        }

        private bool ValidateInterestRate()
        {
            string tb = textBoxInterestRate.Text.Replace('.', ',');
            return double.TryParse(string.Join(string.Empty, tb.Split(' ', '\'', '`', '\n', '\r', '%')), out _interestRate);
        }

        private void CalculateAndDisplayResult(CalcType calcType)
        {
            Action act = calcType switch
            {
                CalcType.PriceDifference => OnPriceDifference,
                CalcType.PercentOfNumber => OnPercentOfNumber,
                CalcType.Commission => OnCommission,
                _ => throw new InvalidOperationException()
            };

            act.Invoke();

            void OnPriceDifference()
            {
                double priceDifference = 100 * (1 - _suggestedPrice / _startPrice);
                textBoxResultPriceDifference.Text = $"{priceDifference:.##}%";
            }

            void OnPercentOfNumber()
            {
                double percentOfNumber = _number * (_percent / 100);
                textBoxResultPercentOfNumber.Text = $"{percentOfNumber:.##}";
            }

            void OnCommission()
            {
                int totalDays = (int)(_termOfPerformance.AddDays(ADD_MONTH) - _selectedDate.AddDays(ADD_WEEK)).TotalDays;
                decimal commission = (decimal)(_interestRate / PERCENTS / DAYS_IN_YEAR * totalDays * _bankGuarantee);
                textBoxResultCommission.Text = $"{string.Format("{0:N}", commission)} руб.";
            }
        }

        private void CalculatorsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _windowsCalc.Kill();
        }
    }
}
