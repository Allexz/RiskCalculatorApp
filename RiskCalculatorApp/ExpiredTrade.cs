namespace RiskCalculatorApp
{
    public class ExpiredTrade : CalculatorAbstract
    {
        private readonly DateTime _dueDate;
        private readonly ITrade _trade;
        public ExpiredTrade(ITrade trade, DateTime dueDate)
            : base(trade, dueDate)
        {
            this._trade = trade;
            this._dueDate = dueDate;    
        }

        public override RiskCategories CalcularRiscoTrade()
        {
            if (this.CheckIfApplied())
                return RiskCategories.EXPIRED;

            return new HighRiskTrade(this._trade, this._dueDate).CalcularRiscoTrade();
        }

        public override bool CheckIfApplied()
            => this._dueDate.Subtract(this._trade.NextPaymentDate).TotalDays > 30;
            
    }
}
