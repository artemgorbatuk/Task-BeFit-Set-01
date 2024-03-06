namespace _01_Async_Consistent_Execution_Tests
{
    /// <summary>
    /// Класс создан для теста, для создания задач чтобы задавать скорость выполнения
    /// </summary>
    public class TaskHandler
    {
        public Task CreateTask(Action action, TimeSpan delay)
        {
            action();

            return Task.Delay(delay);
        }
    }
}