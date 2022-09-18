namespace RiskCalculatorApp
{
    public class Trade : ITrade
    {
        public Trade(double value, string client, DateTime nextPayDate)
        {
            this._value = value;
            this._clientSector = client;
            this._nextPaymentDate = nextPayDate;
        }
        private double _value;
        public double Value => this._value;

        private string _clientSector;
        public string ClientSector => this._clientSector;

        private DateTime _nextPaymentDate;
        public DateTime NextPaymentDate => this._nextPaymentDate;
        
    }
}
