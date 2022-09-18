namespace RiskCalculatorApp
{
    public class HighRiskTrade : CalculatorAbstract
    {
        private readonly DateTime _dueDate;
        private readonly ITrade _trade;

        public HighRiskTrade(ITrade trade, DateTime dueDate)
            :base(trade,dueDate)
        {
            this._trade = trade;
            this._dueDate = dueDate;
        }

        public override RiskCategories CalcularRiscoTrade()
        {
            if (this.CheckIfApplied())
                return RiskCategories.HIGHRISK;
            return new MediumRiskTrade(this._trade, this._dueDate).CalcularRiscoTrade();
        }

        public override bool CheckIfApplied() 
            => this._trade.Value > 1000000 && this._trade.ClientSector == "Private"; 
    }
}
