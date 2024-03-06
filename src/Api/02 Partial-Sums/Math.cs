namespace _02_Partial_Sums
{
    public static class Math
    {
        /// <summary>
        /// Пример вычисления частичных сумм для ряда: 1,2,3,4
        /// /n1 частичная сумма будет 1.
        /// 2 частичная сумма будет 1 + 2 = 3.
        /// 3 частичная сумма будет 1 + 2 + 3 = 6.
        /// 4 частичная сумма будет 1 + 2 + 3 + 4 = 10.
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns></returns>
        public static IEnumerable<double> GetRowSums(IEnumerable<double> numbers)
        {
            var total = 0d;
            
            return numbers.Select(number => total += number);
        }
    }
}
