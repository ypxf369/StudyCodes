namespace 策略模式
{
    /// <summary>
    /// 打折
    /// </summary>
    public class Discount : IChargeStrategy
    {
        private double _rebate;

        public Discount(double rebate)
        {
            _rebate = rebate;
        }
        public double Calculate(double meony)
        {
            return meony * _rebate;
        }
    }
}
