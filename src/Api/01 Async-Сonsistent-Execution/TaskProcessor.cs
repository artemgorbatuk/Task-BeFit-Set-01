namespace _01_Async_Сonsistent_Execution
{
    public class TaskProcessor
    {
        private Queue<Task> tasks = new();

        public async Task AddTask(Task task)
        {
            tasks.Enqueue(task);

            if (tasks.Count == 1)
                await ProcessTasks();
        }

        private async Task ProcessTasks()
        {
            while (tasks.Count > 0)
            {
                await Task.Run(tasks.Peek);
                _ = tasks.Dequeue();
            }
        }

        public async Task WaitForCompletion()
        {
            await Task.WhenAll(tasks);
        }
    }
}