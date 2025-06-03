using TheDummyApp.Models;

namespace TheDummyApp.FPractices.BConcurrency.Extra
{
    internal class SemaphoreExampleSlim
    {
        private async Task ProcessUserAsync(User user, CancellationToken ct)
        {
            ct.ThrowIfCancellationRequested();
            await Task.Delay(TimeSpan.FromMilliseconds(new Random().Next(500, 2000)), ct);
        }

        public async Task ProcessAllAsync(List<User> users, CancellationToken ct)
        {

            using var semaphore = new SemaphoreSlim(5); 

            var tasks = users.Select(async user =>
            {
                await semaphore.WaitAsync(ct);
                try
                {
                    await ProcessUserAsync(user, ct);
                }
                finally
                {
                    semaphore.Release();
                }
            });

            await Task.WhenAll(tasks);
        }


    }
}
