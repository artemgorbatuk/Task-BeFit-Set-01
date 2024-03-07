namespace _04_Sum_Representation_Finder
{
    public static class Math
    {
        public static bool CanSum(int[] numbers, int sum)
        {
            // причина почему закомментировано - нет условия в тестовом задании

            //if (numbers == null || numbers.Length == 0)
            //{
            //    if(sum == 0)
            //        return true;

            //    return false;
            //}

            if (numbers.Contains(sum))
                return true;

            numbers = numbers.Where(p => p <= sum).ToArray();

            if (numbers.Length == 0 || (numbers.Length == 1 && numbers[0] != sum))
                return false;

            foreach (int number in numbers)
            {
                int remainder = sum - number;
                if (CanSum(Array.FindAll(numbers, n => n != number), remainder))
                    return true;
            }

            return false;
        }
    }
}
