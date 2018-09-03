namespace 策略模式
{
    /// <summary>
    /// 正常收费
    /// </summary>
    public class Normal : IChargeStrategy
    {
        public double Calculate(double meony)
        {
            return meony;
        }
    }
}
