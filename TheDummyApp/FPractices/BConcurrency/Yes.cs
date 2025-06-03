namespace TheDummyApp.FPractices.BConcurrency
{
    internal class Yes
    {
        public async Task HandleRequestAsync(CancellationToken ct)
        {
            await DoSomeWorkAsync(ct);
        }

        private async Task DoSomeWorkAsync(CancellationToken ct)
        {
            await Task.Delay(5000, ct);
        }
    }
}
