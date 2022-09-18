namespace RiskCalculatorApp
{
    public abstract class CalculatorAbstract 
    {
        private readonly DateTime _dueDate;
        private readonly ITrade _trade;
        public CalculatorAbstract(ITrade trade, DateTime dueDate)
        {
            this._trade = trade;
            this._dueDate = dueDate;    
        }
    
        public abstract RiskCategories CalcularRiscoTrade();
        public abstract bool CheckIfApplied();
    }
}
