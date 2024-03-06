using _01_Async_�onsistent_Execution;

namespace _01_Async_Consistent_Execution_Tests
{
    public class TaskProcessorTests
    {
        [Fact(Timeout = 7_000)]
        public async void TaskProcessorAsyncTest()
        {
            // Arrange
            var taskProcessor = new TaskProcessor();
            var taskHandler = new TaskHandler();
            var expectedOrder = new List<int> { 1, 2, 3 };
            var actualOrder = new List<int>();

            // Act
            // ������� ������ 1 � ��������� � 2 �������
            var task1 = taskHandler.CreateTask(() => actualOrder.Add(1), TimeSpan.FromSeconds(5));

            // ������� ������ 2 � ��������� � 1 �������
            var task2 = taskHandler.CreateTask(() => actualOrder.Add(2), TimeSpan.FromSeconds(2));

            // ������� ������ 3 � ��������� � 0 ������
            var task3 = taskHandler.CreateTask(() => actualOrder.Add(3), TimeSpan.FromSeconds(0));

            _ = taskProcessor.AddTask(task1);
            _ = taskProcessor.AddTask(task2);
            _ = taskProcessor.AddTask(task3);

            await taskProcessor.WaitForCompletion();

            // Assert
            Assert.Equal(expectedOrder, actualOrder);
        }
    }
}