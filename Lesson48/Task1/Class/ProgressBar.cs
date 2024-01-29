namespace Task1.Class
{
    internal class ProgressBar
    {
        private int Progress { get; set; }

        public async Task<ProgressBar> StartProgressBar()
        {
            for (int i = 0; i <= 100; i++)
            {
                Progress = i;
                await Task.Delay(100);
            }
            return new ProgressBar();
        }

        public async Task GetProgressInfo()
        {
            await Task.Delay(300);
            Console.Clear();
            Console.WriteLine(Progress);
        }

        public int GetProgress() => Progress;

        public void SetProgress(int val) => Progress = val;
    }
}
