namespace TheDummyApp.FPractices.BConcurrency
{
    internal class No
    {
        public void HandleRequest()
        {
            Task.Run(() => DoSomeWorkAsync());
        }

        private async Task DoSomeWorkAsync()
        {
            await Task.Delay(5000);
        }

    }
}
