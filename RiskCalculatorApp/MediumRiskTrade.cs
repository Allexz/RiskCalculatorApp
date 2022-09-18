namespace RiskCalculatorApp
{
    public class MediumRiskTrade : CalculatorAbstract
    {
        private readonly DateTime _dueDate;
        private readonly ITrade _trade;
        public MediumRiskTrade(ITrade trade, DateTime dueDate)
            :base(trade,dueDate)
        {
            this._trade = trade;
            this._dueDate = dueDate;
        }
        public override RiskCategories CalcularRiscoTrade()
        {
            if (this.CheckIfApplied())
                return RiskCategories.MEDIUMRISK;

            throw new ArgumentException("Trade não categorizado");
        }

        public override bool CheckIfApplied()
            => this._trade.Value > 1000000 && this._trade.ClientSector == "Public";
    }
}
