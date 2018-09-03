namespace 策略模式
{
    /// <summary>
    /// 收费策略类
    /// </summary>
    public interface IChargeStrategy
    {
        double Calculate(double meony);
    }
}
