using System;
using System.Collections.Generic;
using System.Text;

namespace Builder
{
    /// <summary>
    /// 抽象建造者，也可定义为接口
    /// </summary>
    public abstract class Builder
    {
        public abstract void BuildPartCpu();
        public abstract void BuildPartMainBoard();

        //其他组件省略

        //获得组装好的电脑
        public abstract Computer GetComputer();
    }
}
